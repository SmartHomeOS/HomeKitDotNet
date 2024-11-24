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

using System.Security.Cryptography;
using System.Text;

namespace HomeKitDotNet
{
    public class QRParser
    {
        public QRParser(string code)
        {
            if (!code.StartsWith("X-HM://") || code.Length < 20)
                throw new ArgumentException("Invalid QR Code");
            SetupID = code.Substring(16, 4);
            code = code.Substring(7, 9);
            long lc = decode(code);
            Version = (byte)((lc >> 43) & 0xFF);
            AccessoryCategory = (byte)((lc >> 31) & 0xFF);
            BTLE = (lc & 0x20000000) == 0x20000000;
            IP = (lc & 0x10000000) == 0x10000000;
            NFC = (lc & 0x8000000) == 0x8000000;
            SetupPin = lc & 0x7FFFFFF;
        }

        public byte Version {  get; set; }
        public byte AccessoryCategory { get; set; }
        public bool BTLE {  get; set; }
        public bool NFC { get; set; }
        public bool IP { get; set; }
        public string SetupID { get; set; }
        public long SetupPin { get; set; }

        public string ComputeHash(string deviceId)
        {
            byte[] devId = Encoding.UTF8.GetBytes(deviceId.ToUpper());
            byte[] source = new byte[devId.Length + 4];
            Encoding.UTF8.GetBytes(SetupID, 0, 4, source, 0);
            Array.Copy(devId, 0, source, 4, devId.Length);
            byte[] result = SHA512.HashData(source);
            return Convert.ToHexString(result, 0, 4);
        }

        private static long decode(string sIn)
        {
            const string map = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            long ret = map.IndexOf(sIn[0]);
            for (int i = 1; i < sIn.Length; i++)
                ret = ret * 36 + map.IndexOf(sIn[i]);
            return ret;
        }
    }
}
