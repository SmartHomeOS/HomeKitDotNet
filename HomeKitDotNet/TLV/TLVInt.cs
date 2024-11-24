using HomeKitDotNet.TLV.Enums;
using System.Buffers.Binary;

namespace HomeKitDotNet.TLV
{
    public class TLVInt : TLVValue
    {
        private uint data;

        public TLVInt(TLVType type, uint data)
        {
            this.type = type;
            if (data <= byte.MaxValue)
                len = 1;
            else if (len <= ushort.MaxValue)
                len = 2;
            else
                len = 4;
            this.data = data;
        }
        internal TLVInt(TLVType type, byte len, Stream stream) : base(type, len, stream)
        {
            this.type = type;
            this.len = len;
            Span<byte> buff  = stackalloc byte[len];
            stream.ReadExactly(buff);
            if (len == 1)
                data = buff[0];
            else if (len == 2)
                data = BinaryPrimitives.ReadUInt16LittleEndian(buff);
            else
                data = BinaryPrimitives.ReadUInt32LittleEndian(buff);
        }

        public uint Value { get { return data; } }

        public override void write(Stream stream)
        {
            base.write(stream);
            Span<byte> buff = stackalloc byte[len];
            if (len == 1)
                buff[0] = (byte)data;
            else if (len == 2)
                BinaryPrimitives.WriteUInt16LittleEndian(buff, (ushort)data);
            else
                BinaryPrimitives.WriteUInt32LittleEndian(buff, data);
            stream.Write(buff);
        }
    }
}
