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
        private Task m_pReceiveTask = Task.CompletedTask;
        private int m_nDisposed;

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
            m_pReceiveTask = Task.Run(ReceiveLoop);
        }

        public void Dispose()
        {
            // Close pending response waits as well as the socket, allowing repeated disposal.
            if (Interlocked.Exchange(ref m_nDisposed, 1) == 0)
            {
                token.Cancel();
                client.Dispose();
                responses.Writer.TryComplete(new IOException("The HAP connection was closed."));
            }
        }

        public async Task EnableEncryption(byte[] writeKey, byte[] readKey)
        {
            AssertConnected();
            // Await the plaintext reader before enabling encrypted framing.
            token.Cancel();
            await m_pReceiveTask;
            ObjectDisposedException.ThrowIf(Volatile.Read(ref m_nDisposed) != 0, this);
            token.Dispose();

            writer.EnableEncryption(new ChaCha20Poly1305(writeKey));
            reader.EnableDecryption(new ChaCha20Poly1305(readKey));

            token = new CancellationTokenSource();
            m_pReceiveTask = Task.Run(ReceiveLoop);
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
            // Keep the token belonging to this loop during an encryption transition.
            CancellationToken cancellationToken = token.Token;

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    string? line = await reader!.ReadLineAsync(cancellationToken);
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
                        {
                            foreach (string encoding in parts[1].Split(',', StringSplitOptions.TrimEntries))
                            {
                                if (encoding.Equals("chunked", StringComparison.OrdinalIgnoreCase))
                                    chunked = true;
                            }

                        }
                        line = await reader.ReadLineAsync(cancellationToken);
                    }
                    if (line == null)
                        throw new EndOfStreamException();
                    // Chunked framing includes extensions, a final terminator and optional trailers.
                    if (chunked)
                    {
                        response.Content = new ByteArrayContent(await ReadChunkedBodyAsync(cancellationToken));
                    }
                    else if (contentLen != 0)
                    {
                        byte[] contentBytes = new byte[contentLen];
                        await reader.ReadBytesAsync(contentBytes, contentLen, cancellationToken);
                        response.Content = new ByteArrayContent(contentBytes);
                    }

                    if (MediaTypeHeaderValue.TryParse(type, out MediaTypeHeaderValue? contentType))
                        response.Content.Headers.ContentType = contentType;

                    if (protocol == "EVENT/1.0")
                    {
                        // Subscribers read from the beginning; the connection owns the response.
                        try
                        {
                            Delegate[] arHandlers = EventReceived?.GetInvocationList() ?? [];

                            foreach (Delegate pHandler in arHandlers)
                            {
                                Stream pContent = response.Content.ReadAsStream();
                                pContent.Position = 0;
                                ((EventHandler<HttpResponseMessage>)pHandler).Invoke(this, response);
                            }

                        }
                        finally
                        {
                            response.Dispose();
                        }
                    }
                    else
                    {
                        responses.Writer.TryWrite(response);
                    }
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { } // Ignore
            catch (Exception e)
            {
                // Propagate reader failures instead of leaving requests waiting indefinitely.
                responses.Writer.TryComplete(e);
                Dispose();
            }
        }

        private async Task<byte[]> ReadChunkedBodyAsync(CancellationToken cancellationToken)
        {
            // Reassemble chunks and consume trailers before reading the next response.
            const int nMaxBodyLength = 16 * 1024 * 1024;
            using MemoryStream pBody = new MemoryStream();
            int nLength;

            do
            {
                string sLine = await reader!.ReadLineAsync(cancellationToken);
                int nExtension = sLine.IndexOf(';');
                string sSize = nExtension >= 0 ? sLine.Substring(0, nExtension) : sLine;

                if (!int.TryParse(sSize, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out nLength) || nLength < 0 || nLength > nMaxBodyLength - pBody.Length)
                    throw new InvalidDataException("Invalid HAP HTTP chunk size.");

                if (nLength > 0)
                {
                    byte[] arChunk = new byte[nLength];
                    await reader.ReadBytesAsync(arChunk, nLength, cancellationToken);
                    pBody.Write(arChunk);

                    if ((await reader.ReadLineAsync(cancellationToken)).Length != 0)
                        throw new InvalidDataException("Invalid HAP HTTP chunk terminator.");
                }
            }
            while (nLength != 0);

            while ((await reader!.ReadLineAsync(cancellationToken)).Length != 0)
            {
            }

            return pBody.ToArray();
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
            // Cancelled or timed-out requests must not leave a reusable, desynchronized session.
            using CancellationTokenSource pLifetime = CancellationTokenSource.CreateLinkedTokenSource(token, this.token.Token);
            await semaphore.WaitAsync(pLifetime.Token);
            pLifetime.CancelAfter(TimeSpan.FromSeconds(15));
            using CancellationTokenRegistration pRegistration = pLifetime.Token.Register(Dispose);

            try{
                await writer.WriteAsync(Encoding.UTF8.GetBytes(msg.ToString()), pLifetime.Token);
                if (contentStream != null)
                    await writer.WriteAsync(contentStream, pLifetime.Token);
                await writer.FlushAsync(pLifetime.Token);
                return await responses.Reader.ReadAsync(pLifetime.Token);
            }
            catch
            {
                Dispose();
                throw;
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
