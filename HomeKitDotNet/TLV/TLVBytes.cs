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

using HomeKitDotNet.TLV.Enums;

namespace HomeKitDotNet.TLV
{
    public class TLVBytes : TLVValue
    {
        private byte[] data;
        public TLVBytes(TLVType type, byte[] bytes)
        {
            this.type = type;
            this.len = bytes.Length;
            this.data = bytes;
        }
        internal TLVBytes(TLVType type, byte len, Stream stream) : base(type, len, stream)
        {
            this.type = type;
            this.len = len;
            this.data = new byte[len];
            stream.ReadExactly(this.data, 0, len);
        }

        public byte[] Value { get { return data; } }

        public override void write(Stream stream)
        {
            if (len <= 255)
            {
                base.write(stream);
                stream.Write(data);
            }
            else
            {
                int pos = 0;
                int remain = len;
                while (remain > 0)
                {
                    int segmentLen = Math.Min(255, remain);
                    stream.WriteByte((byte)type);
                    stream.WriteByte((byte)segmentLen);
                    stream.Write(data, pos, segmentLen);
                    pos += segmentLen;
                    remain -= segmentLen;
                }
            }
        }
    }
}
