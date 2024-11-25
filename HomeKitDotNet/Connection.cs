// HomeKitDotNet Copyright (C) 2024 
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Affero General Public License for more details.
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using HomeKitDotNet.TLV;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace HomeKitDotNet
{
    public class Connection : IDisposable
    {
        TcpClient client;
        EncryptedStreamWriter? writer;
        EncryptedStreamReader? reader;
        string? host;
        SemaphoreSlim semaphore = new SemaphoreSlim(1);
        Channel<HttpResponseMessage> responses = Channel.CreateUnbounded<HttpResponseMessage>();
        public event EventHandler<HttpResponseMessage>? EventReceived;
        CancellationTokenSource token = new CancellationTokenSource();

        public Connection()
        {
            client = new TcpClient();
            client.ReceiveTimeout = 30000;
            client.SendTimeout = 10000;
        }

        public async Task ConnectAsync(IPEndPoint ep, CancellationToken cancellationToken = default)
        {
            host = $"Host: {ep.Address}:{ep.Port}\r\n";
            await client.ConnectAsync(ep.Address, ep.Port, cancellationToken);
            writer = new EncryptedStreamWriter(client.GetStream());
            reader = new EncryptedStreamReader(client.GetStream());
            await Task.Factory.StartNew(ReceiveLoop, token.Token);
        }

        public void Dispose()
        {
            token.Cancel();
            token.Dispose();
            client.Dispose();
        }

        public async Task EnableEncryption(byte[] writeKey, byte[] readKey)
        {
            AssertConnected();
            token.Cancel();
            token.Dispose();

            writer.EnableEncryption(new ChaCha20Poly1305(writeKey));
            reader.EnableDecryption(new ChaCha20Poly1305(readKey));

            token = new CancellationTokenSource();
            await Task.Factory.StartNew(ReceiveLoop, token.Token);
        }

        public async Task<HttpResponseMessage> Get(string path, CancellationToken token)
        {
            return await SendAsync(HttpMethod.Get, path, null, token);
        }

        public async Task<HttpResponseMessage> PutJson(string path, byte[] json, CancellationToken token)
        {
            ByteArrayContent content = new ByteArrayContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/hap+json");
            return await SendAsync(HttpMethod.Put, path, content, token);
        }

        public async Task<HttpResponseMessage> PostTLVs(string path, CancellationToken token, params TLVValue[] tlvs)
        {
            ByteArrayContent? content = null;
            if (tlvs.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    TLVValue.WriteCollection(tlvs, ms);
                    content = new ByteArrayContent(ms.ToArray());
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/pairing+tlv8");
                }
            }
            return await SendAsync(HttpMethod.Post, path, content, token);
        }

        public async Task ReceiveLoop()
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    string? line = await reader!.ReadLineAsync(token.Token);
                    if (line == null)
                        throw new EndOfStreamException();
                    string[] parts = line.Split(' ', 3);
                    if (parts.Length != 3 || !int.TryParse(parts[1], out int status))
                        throw new HttpRequestException("Invalid Response: " + line);
                    HttpResponseMessage response = new HttpResponseMessage((HttpStatusCode)status);
                    response.ReasonPhrase = parts[2];
                    string protocol = parts[0];
                    int contentLen = 0;
                    string type = "";
                    bool chunked = false;
                    while (line != "" && line != null)
                    {
                        parts = line.Split(':', 2, StringSplitOptions.TrimEntries);
                        if (parts.Length == 2 && parts[0].Equals("Content-Length", StringComparison.InvariantCultureIgnoreCase))
                            contentLen = int.Parse(parts[1]);
                        if (parts.Length == 2 && parts[0].Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
                            type = parts[1];
                        if (parts.Length == 2 && parts[0].Equals("Transfer-Encoding", StringComparison.InvariantCultureIgnoreCase))
                            chunked = parts[1].Equals("chunked", StringComparison.InvariantCultureIgnoreCase);
                        line = await reader.ReadLineAsync(token.Token);
                    }
                    if (line == null)
                        throw new EndOfStreamException();
                    if (contentLen != 0)
                    {
                        byte[] contentBytes = new byte[contentLen];
                        await reader.ReadBytesAsync(contentBytes, contentLen, token.Token);
                        response.Content = new ByteArrayContent(contentBytes);
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                    }
                    else if (chunked)
                    {
                        byte[] chunk = new byte[1024];
                        MemoryStream ms = new MemoryStream();
                        if (!int.TryParse((await reader.ReadLineAsync(token.Token)).Split(' ')[0], NumberStyles.HexNumber, null, out int chunkSize))
                            throw new EndOfStreamException("Truncated chunk read");
                        
                        while (chunkSize > 0)
                        {
                            if (chunkSize > chunk.Length)
                                chunk = new byte[chunkSize];
                            await reader.ReadBytesAsync(chunk, chunkSize, token.Token);
                            ms.Write(chunk, 0, chunkSize);
                            await reader.Seek(2, token.Token); //CRLF after chunk
                            if (!int.TryParse((await reader.ReadLineAsync(token.Token)).Split(' ')[0], NumberStyles.HexNumber, null, out chunkSize))
                                throw new EndOfStreamException("Truncated chunk read");
                        }

                        await reader.Seek(2, token.Token); //CRLF after chunk
                        response.Content = new ByteArrayContent(ms.ToArray());
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                    }
                    if (protocol == "EVENT/1.0")
                        EventReceived?.Invoke(this, response);
                    else
                        responses.Writer.TryWrite(response);
                }
            }
            catch (OperationCanceledException) { } // Ignore
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpMethod method, string path, ByteArrayContent? content, CancellationToken token)
        {
            AssertConnected();
            Stream? contentStream = null;
            if (content != null)
                contentStream = content.ReadAsStream(token);
            StringBuilder msg = new StringBuilder();
            msg.Append(method.ToString());
            msg.Append(' ');
            msg.Append(path);
            msg.Append(" HTTP/1.1\r\n");
            msg.Append(host);
            if (content != null)
            {
                msg.Append($"Content-Length: {contentStream!.Length}\r\n");
                msg.Append($"Content-Type: {content.Headers.ContentType}\r\n");
            }
            msg.Append("\r\n");
            await semaphore.WaitAsync(token);
            try{
                await writer.WriteAsync(Encoding.UTF8.GetBytes(msg.ToString()), token);
                if (contentStream != null)
                    await writer.WriteAsync(contentStream, token);
                await writer.FlushAsync(token);
                return await responses.Reader.ReadAsync(token);
            }
            finally
            {
                semaphore.Release();
            }
        }

        [MemberNotNull(nameof(host), nameof(writer), nameof(reader))]
        private void AssertConnected()
        {
            if (reader == null || writer == null || host == null)
                throw new InvalidOperationException("Connect has not been called");
        }
    }
}
