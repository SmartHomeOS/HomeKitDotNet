﻿//Public Domain

namespace HomeKitDotNet.Crypto.Internal
{
    internal static partial class Ed25519Operations
    {
        public static bool crypto_sign_verify(
            byte[] sig, int sigoffset,
            byte[] m, int moffset, int mlen,
            byte[] pk, int pkoffset)
        {
            byte[] h;
            byte[] checkr = new byte[32];
            GroupElementP3 A;
            GroupElementP2 R;

            if ((sig[sigoffset + 63] & 224) != 0) return false;
            if (GroupOperations.ge_frombytes_negate_vartime(out A, pk, pkoffset) != 0)
                return false;

            var hasher = new Sha512();
            hasher.Update(sig, sigoffset, 32);
            hasher.Update(pk, pkoffset, 32);
            hasher.Update(m, moffset, mlen);
            h = hasher.Finish();

            ScalarOperations.sc_reduce(h);

            var sm32 = new byte[32];//todo: remove allocation
            Array.Copy(sig, sigoffset + 32, sm32, 0, 32);
            GroupOperations.ge_double_scalarmult_vartime(out R, h, ref A, sm32);
            GroupOperations.ge_tobytes(checkr, 0, ref R);
            var result = CryptoBytes.ConstantTimeEquals(checkr, 0, sig, sigoffset, 32);
            CryptoBytes.Wipe(h);
            CryptoBytes.Wipe(checkr);
            return result;
        }
    }
}