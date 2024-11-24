using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace HomeKitDotNet.Crypto
{
    public class SRP
    {
        private static BigInteger N = new BigInteger(Convert.FromHexString("FFFFFFFFFFFFFFFFC90FDAA22168C234C4C6628B80DC1CD129024E088A67CC74020BBEA63B139B22514A08798E3404DDEF9519B3CD3A431B302B0A6DF25F14374FE1356D6D51C245E485B576625E7EC6F44C42E9A637ED6B0BFF5CB6F406B7EDEE386BFB5A899FA5AE9F24117C4B1FE649286651ECE45B3DC2007CB8A163BF0598DA48361C55D39A69163FA8FD24CF5F83655D23DCA3AD961C62F356208552BB9ED529077096966D670C354E4ABC9804F1746C08CA18217C32905E462E36CE3BE39E772C180E86039B2783A2EC07A28FB5C55DF06F4C52C9DE2BCBF6955817183995497CEA956AE515D2261898FA051015728E5A8AAAC42DAD33170D04507A33A85521ABDF1CBA64ECFB850458DBEF0A8AEA71575D060C7DB3970F85A6E1E4C7ABF5AE8CDB0933D71E8C94E04A25619DCEE3D2261AD2EE6BF12FFA06D98A0864D87602733EC86A64521F2B18177B200CBBE117577A615D6C770988C0BAD946E208E24FA074E5AB3143DB5BFCE0FD108E4B82D120A93AD2CAFFFFFFFFFFFFFFFF"), true, true);
        private static BigInteger g = BigInteger.Parse("05");

        private BigInteger A;
        private BigInteger a;

        public BigInteger GenerateAValues()
        {
            // a = random()
            a = new BigInteger(RandomNumberGenerator.GetBytes(32), true, true);

            // A = g^a
            A = BigInteger.ModPow(g, a, N);

            return A;
        }

        public BigInteger GenerateAValues(BigInteger a)
        {
            this.a = a;
            A = BigInteger.ModPow(g, a, N);
            return A;
        }

        public BigInteger ComputePremasterSecret(string I, string P, byte[] s, BigInteger B)
        {
            var u = new BigInteger(SHA512.HashData(BufferUtil.Concat(A.ToByteArray(true, true), B.ToByteArray(true, true))), true, true);
            var x = GeneratePrivateKey(I, P, s);

            var NBytes = N.ToByteArray(true, true);
            var gPadded = PadBytes(BitConverter.GetBytes((int)g).Reverse().ToArray(), NBytes.Length);
            var k = new BigInteger(SHA512.HashData(BufferUtil.Concat(NBytes, gPadded)), true, true);

            // S = (B - kg ^ x) ^ (a + ux)
            return BigInteger.ModPow(mod(B - BigInteger.ModPow(g, x, N) * k % N, N), a + u * x, N);
        }

        public BigInteger ComputeSessionKey(string I, string P, byte[] s, BigInteger B)
        {
            byte[] SBytes = ComputePremasterSecret(I, P, s, B).ToByteArray(true, true);
            return new BigInteger(SHA512.HashData(SBytes), true, true);
        }

        public BigInteger GenerateClientProof(string I, byte[] s, BigInteger A, BigInteger B, BigInteger K)
        {
            byte[] HN = SHA512.HashData(N.ToByteArray(true, true));
            byte[] Hg = SHA512.HashData(g.ToByteArray(true, true));
            byte[] HI = SHA512.HashData(Encoding.UTF8.GetBytes(I));
            for (int i = 0; i < HN.Length; i++)
                HN[i] ^= Hg[i];

            var padLength = N.ToByteArray(true, true).Length;

            return new BigInteger(SHA512.HashData(HN.Concat(HI).Concat(s)
                                          .Concat(A.ToByteArray(true, true))
                                          .Concat(B.ToByteArray(true, true))
                                          .Concat(K.ToByteArray(true, true))
                                          .ToArray()), true, true);
        }

        public bool ValidateServerProof(BigInteger M2, BigInteger M1, BigInteger K)
        {
            var padLength = N.ToByteArray(true, true).Length;

            // M2 = H( A | M1 | S )
            return M2 == new BigInteger(SHA512.HashData(BufferUtil.Concat(A.ToByteArray(true, true), M1.ToByteArray(true, true), K.ToByteArray(true, true))), true, true);
        }

        private BigInteger GeneratePrivateKey(string I, string P, byte[] s)
        {
            // x = H(s | H(I | ":" | P))
            return new BigInteger(SHA512.HashData(BufferUtil.Concat(s, SHA512.HashData(Encoding.UTF8.GetBytes(I + ":" + P)))), true, true);
        }

        private static BigInteger mod(BigInteger x, BigInteger m)
        {
            return (x % m + m) % m;
        }

        public static byte[] PadBytes(byte[] bytes, int length)
        {
            var paddedBytes = new byte[length];
            Array.Copy(bytes, 0, paddedBytes, length - bytes.Length, bytes.Length);

            return paddedBytes;
        }
    }
}
