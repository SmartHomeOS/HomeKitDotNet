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

namespace HomeKitDotNet
{
    public static class BufferUtil
    {

        public static byte[] Concat(byte[] data1, byte[] data2)
        {
            byte[] result = new byte[data1.Length + data2.Length];
            Array.Copy(data1, result, data1.Length);
            Array.Copy(data2, 0, result, data1.Length, data2.Length);
            return result;
        }
        public static byte[] Concat(byte[] data1, byte[] data2, byte[] data3)
        {
            byte[] result = new byte[data1.Length + data2.Length + data3.Length];
            Array.Copy(data1, result, data1.Length);
            Array.Copy(data2, 0, result, data1.Length, data2.Length);
            Array.Copy(data3, 0, result, data1.Length + data2.Length, data3.Length);
            return result;
        }
    }
}
