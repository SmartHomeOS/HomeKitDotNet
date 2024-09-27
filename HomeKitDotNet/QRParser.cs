namespace HomeKitDotNet
{
    public class QRParser
    {
        public QRParser(string code)
        {
            if (!code.StartsWith("X-HM://") || code.Length != 20)
                throw new ArgumentException("Invalid QR Code");
            SetupCode = code.Substring(16);
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
        public string SetupCode { get; set; }
        public long SetupPin { get; set; }

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
