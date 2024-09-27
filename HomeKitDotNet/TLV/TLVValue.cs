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
    public abstract class TLVValue
    {
        protected TLVType type;
        protected int len;

        protected TLVValue() { }
        protected TLVValue(TLVType type, byte len, Stream stream) { }

        public virtual void write(Stream stream)
        {
            stream.WriteByte((byte)type);
            stream.WriteByte((byte)len);
        }

        public static List<TLVValue> CollectionFromStream(Stream stream)
        {
            List<TLVValue> list = new List<TLVValue>();
            byte[] buff = new byte[2];
            while (stream.CanRead && stream.Position < stream.Length - 1)
            {
                stream.ReadExactly(buff, 0, 2);
                TLVType type = (TLVType)buff[0];
                switch (type)
                {
                    case TLVType.kTLVType_Method:
                    case TLVType.kTLVType_State:
                    case TLVType.kTLVType_Error:
                    case TLVType.kTLVType_RetryDelay:
                    case TLVType.kTLVType_Permissions:
                    case TLVType.kTLVType_Flags:
                        list.Add(new TLVInt(type, buff[1], stream));
                        break;
                    case TLVType.kTLVType_Separator:
                        list.Add(new TLVNull(type, buff[1], stream));
                        break;
                    default:
                        list.Add(new TLVBytes(type, buff[1], stream));
                        break;
                }
            }
            return list;
        }

        public static byte[] Concat(TLVType type, List<TLVValue> values)
        {
            int len = 0;
            foreach (TLVValue v in values)
            {
                if (v.type == type)
                    len += v.len;
            }
            int pos = 0;
            byte[] bytes = new byte[len];
            foreach (TLVValue v in values)
            {
                if (v.type == type)
                {
                    Array.Copy(((TLVBytes)v).Value, 0, bytes, pos, v.len);
                    pos += v.len;
                }
            }
            return bytes;
        }

        public static void WriteCollection(TLVValue[] list, Stream stream)
        {
            foreach (TLVValue tlv in list)
                tlv.write(stream);
        }

        public TLVType Type { get { return type; } }
    }
}
