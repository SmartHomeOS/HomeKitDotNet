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
    public class TLVNull : TLVValue
    {
        public TLVNull(TLVType type)
        {
            this.type = type;
            this.len = 0;
        }
        internal TLVNull(TLVType type, byte len, Stream stream) : base(type, len, stream)
        {
            this.type = type;
            this.len = len;
        }

        public override void write(Stream stream)
        {
            base.write(stream);
        }
    }
}
