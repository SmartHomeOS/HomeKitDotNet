﻿// HomeKitDotNet Copyright (C) 2024 
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
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace HomeKitDotNet
{
    public class Connection
    {
        TcpClient client;
        EncryptedStreamWriter writer;
        EncryptedStreamReader reader;
        readonly string host;
        SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public Connection(IPEndPoint ep)
        {
            host = $"Host: http://{ep.Address}:{ep.Port}\r\n";
            client = new TcpClient();
            client.ReceiveTimeout = 30000;
            client.Connect(ep.Address, ep.Port);
            writer = new EncryptedStreamWriter(client.GetStream());
            reader = new EncryptedStreamReader(client.GetStream());
        }

        public void EnableEncryption(byte[] writeKey, byte[] readKey)
        {

            writer.EnableEncryption(new ChaCha20Poly1305(writeKey));
            reader.EnableDecryption(new ChaCha20Poly1305(readKey));
        }

        public async Task<HttpResponseMessage> Get(string path)
        {
            return await SendAsync(HttpMethod.Get, path, null);
        }

        public async Task<HttpResponseMessage> Put(string path, byte[] json)
        {
            ByteArrayContent content = new ByteArrayContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/hap+json\r\n");
            return await SendAsync(HttpMethod.Put, path, content);
        }

        public async Task<HttpResponseMessage> Post(string path, params TLVValue[] tlvs)
        {
            ByteArrayContent content;
            using (MemoryStream ms = new MemoryStream())
            {
                TLVValue.WriteCollection(tlvs, ms);
                content = new ByteArrayContent(ms.ToArray());
                content.Headers.ContentType = new MediaTypeHeaderValue("application/pairing+tlv8");
            }
            return await SendAsync(HttpMethod.Post, path, content);
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpMethod method, string path, ByteArrayContent? content)
        {
            Stream? contentStream = null;
            if (content != null)
                contentStream = content.ReadAsStream();
            StringBuilder msg = new StringBuilder();
            msg.Append(method.ToString());
            msg.Append(' ');
            msg.Append(path);
            msg.Append(" HTTP/1.1\r\n");
            msg.Append(host);
            if (content != null)
            {
                msg.Append($"Content-Length: {contentStream!.Length}\r\n");
                msg.Append("Content-Type: ");
                msg.Append(content.Headers.ContentType);
                msg.Append("\r\n");
            }
            msg.Append("\r\n");
            await semaphore.WaitAsync();
            try{
                await writer.WriteAsync(Encoding.UTF8.GetBytes(msg.ToString()));
                if (contentStream != null)
                    await writer.WriteAsync(contentStream);
                await writer.FlushAsync();

                string? line = await reader.ReadLineAsync();
                if (line == null)
                    throw new EndOfStreamException();
                string[] parts = line.Split(' ', 3);
                if (parts.Length != 3 || !int.TryParse(parts[1], out int status))
                    throw new HttpRequestException("Invalid Response: " + line);
                HttpResponseMessage response = new HttpResponseMessage((HttpStatusCode)status);
                response.ReasonPhrase = parts[2];
                int contentLen = 0;
                string type = "";
                while (line != "" && line != null)
                {
                    parts = line.Split(':', StringSplitOptions.TrimEntries);
                    if (parts.Length == 2 && parts[0].Equals("content-length", StringComparison.InvariantCultureIgnoreCase))
                        contentLen = int.Parse(parts[1]);
                    if (parts.Length == 2 && parts[0].Equals("content-type", StringComparison.InvariantCultureIgnoreCase))
                        type = parts[1];
                    line = await reader.ReadLineAsync();
                }
                if (line == null)
                    throw new EndOfStreamException();
                if (contentLen != 0)
                {
                    byte[] contentBytes = new byte[contentLen];
                    await reader.ReadBytesAsync(contentBytes);
                    response.Content = new ByteArrayContent(contentBytes);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                }
                return response;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}