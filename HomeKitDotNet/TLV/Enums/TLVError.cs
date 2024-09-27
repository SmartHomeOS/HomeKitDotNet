namespace HomeKitDotNet.TLV.Enums
{
    public enum TLVError
    {
        kTLVError_Unknown = 0x1,
        kTLVError_Authentication = 0x2,
        kTLVError_Backoff = 0x3,
        kTLVError_MaxPeers = 0x4,
        kTLVError_MaxTries = 0x5,
        kTLVError_Unavailable = 0x6,
        kTLVError_Busy = 0x7
    }
}
