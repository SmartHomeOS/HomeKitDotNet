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

using System.Buffers.Binary;
using System.Security.Cryptography;

namespace HomeKitDotNet
{
    public class EncryptedStreamWriter
    {
        byte[] buffer = new byte[1024];
        private int writePos;
        private Stream stream;
        ChaCha20Poly1305? encrypter;
        ulong counter;
        byte[] tag = new byte[16];

        public EncryptedStreamWriter(Stream stream)
        {
            this.stream = stream;
        }

        public void EnableEncryption(ChaCha20Poly1305 encrypter)
        {
            this.encrypter = encrypter;
        }

        public async Task WriteAsync(byte[] payload, CancellationToken token)
        {
            int len, readPos = 0;
            while (readPos < payload.Length)
            {
                len = Math.Min(payload.Length - readPos, buffer.Length - writePos);
                Array.Copy(payload, readPos, buffer, writePos, len);
                readPos += len;
                writePos += len;
                await flushIfNeeded(token);
            }
        }

        public async Task WriteAsync(Stream stream, CancellationToken token)
        {
            while (stream.Position < stream.Length)
            {
                writePos += stream.Read(buffer, writePos, buffer.Length - writePos);
                await flushIfNeeded(token);
            }
        }

        private async Task flushIfNeeded(CancellationToken token)
        {
            if (writePos == buffer.Length)
                await FlushAsync(token);
        }

        public async Task FlushAsync(CancellationToken token)
        {
            if (encrypter == null)
            {
                await stream.WriteAsync(buffer, 0, writePos, token);
            }
            else
            {
                byte[] len = new byte[2];
                BinaryPrimitives.WriteUInt16LittleEndian(len, (ushort)writePos);
                byte[] nonce = new byte[12];
                BinaryPrimitives.WriteUInt64LittleEndian(nonce.AsSpan().Slice(4), counter++);
                encrypter.Encrypt(nonce, buffer.AsSpan().Slice(0, writePos), buffer.AsSpan().Slice(0, writePos), tag, len);
                stream.Write(len);
                await stream.WriteAsync(buffer, 0, writePos, token);
                await stream.WriteAsync(tag, token);
            }
            writePos = 0;
        }
    }
}
