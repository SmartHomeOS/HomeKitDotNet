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

using System;
using System.Buffers.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HomeKitDotNet
{
    public class EncryptedStreamReader
    {
        private Stream stream;
        private ChaCha20Poly1305? decrypter;
        private Memory<byte> buffer = new byte[1042];
        private ulong counter;
        private int readPos, buffEnd;

        public EncryptedStreamReader(Stream stream)
        {
            this.stream = stream;
        }

        public async Task<string> ReadLineAsync()
        {
            int newLine = -1;
            if (decrypter != null && buffEnd <= readPos)
                await ReadEncrypted();
            if (buffEnd > 0)
                newLine = FindReturn(buffer.Slice(readPos, buffEnd - readPos).Span);
            if (decrypter == null)
            {
                while (newLine == -1)
                {
                    if (readPos != 0)
                    {
                        if (readPos != buffEnd)
                            buffer.Slice(readPos, buffEnd - readPos).CopyTo(buffer);
                        buffEnd -= readPos;
                        readPos = 0;
                    }
                    buffEnd += await stream.ReadAsync(buffer.Slice(buffEnd));
                    newLine = FindReturn(buffer.Slice(readPos, buffEnd - readPos).Span);
                }
            }
            else if (newLine == -1)
            {
                throw new InvalidDataException("Unable to find newline in decoded data");
            }
            string ret = Encoding.UTF8.GetString(buffer.Slice(readPos, newLine - 2).Span);
            readPos += newLine;
            return ret;
        }

        public async Task ReadBytesAsync(byte[] bytes)
        {
            if (decrypter == null)
                await ReadBytesStream(bytes);
            else
            {
                int len, writePos = 0;
                if (readPos != buffEnd)
                {
                    len = Math.Min(bytes.Length, buffEnd - readPos);
                    buffer.Slice(readPos, len).CopyTo(bytes);
                    writePos += len;
                    readPos += len;
                }
                while (writePos < bytes.Length)
                {
                    await ReadEncrypted();
                    len = Math.Min(bytes.Length - writePos, buffEnd);
                    buffer.Slice(0, buffEnd).Span.CopyTo(bytes.AsSpan().Slice(writePos));
                    writePos += len;
                    readPos += len;
                }
            }
        }

        private async Task ReadBytesStream(byte[] bytes)
        {
            int pos = 0;
            if (readPos != buffEnd)
            {
                buffer.Slice(readPos, buffEnd - readPos).CopyTo(bytes);
                pos += (buffEnd - readPos);
                buffEnd = 0;
                readPos = 0;
            }
            while (pos < bytes.Length - 1)
                pos += await stream.ReadAsync(bytes, pos, bytes.Length - pos);
        }

        private async Task ReadEncrypted() //read line
        {
            await stream.ReadExactlyAsync(buffer.Slice(0, 2));
            ushort len = BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(0, 2).Span);
            await stream.ReadExactlyAsync(buffer.Slice(2, len + 16));
            byte[] nonce = new byte[12];
            BinaryPrimitives.WriteUInt64LittleEndian(nonce.AsSpan().Slice(4), counter++);
            decrypter!.Decrypt(nonce.AsSpan(), buffer.Slice(2, len).Span, buffer.Slice(2 + len, 16).Span, buffer.Slice(0, len).Span, buffer.Slice(0, 2).Span);
            Console.WriteLine("Decrypted " + len);
            buffEnd = len;
            readPos = 0;
        }

        internal void EnableDecryption(ChaCha20Poly1305 decrypter)
        {
            this.decrypter = decrypter;
            readPos = 0;
            buffEnd = 0;
        }

        private int FindReturn(Span<byte> buff)
        {
            for (int i = 0; i < buff.Length; i++)
            {
                if (buff[i] == '\n')
                    return i + 1;
            }
            return -1;
        }
    }
}
