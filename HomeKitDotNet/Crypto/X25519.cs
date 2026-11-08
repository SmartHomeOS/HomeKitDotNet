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
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace HomeKitDotNet.Crypto
{
    public class X25519
    {
        private X25519PrivateKeyParameters? m_pPrivateKey;
        internal static ECCurve Curve25519 = new ECCurve()
        {
            CurveType = ECCurve.ECCurveType.PrimeMontgomery,
            B = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            A = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x07, 0x6d, 0x06 },
            G = new ECPoint()
            {
                X = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                Y = new byte[] { 0x20, 0xae, 0x19, 0xa1, 0xb8, 0xa0, 0x86, 0xb4, 0xe0, 0x1e, 0xdd, 0x2c, 0x77, 0x48, 0xd1, 0x4c, 0x92, 0x3d, 0x4d, 0x7e, 0x6d, 0x7c, 0x61, 0xb2, 0x29, 0xe9, 0xc5, 0xa2, 0x7e, 0xce, 0xd3, 0xd9 }
            },
            Prime = new byte[] { 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xed },
            Order = new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0xde, 0xf9, 0xde, 0xa2, 0xf7, 0x9c, 0xd6, 0x58, 0x12, 0x63, 0x1a, 0x5c, 0xf5, 0xd3, 0xed },
            Cofactor = new byte[] { 8 }
        };

        public (byte[] Public, byte[] Private) GenerateKeyPair()
        {
            // Generate keys independently of the operating-system cryptographic provider.
            X25519PrivateKeyParameters pPrivateKey = new X25519PrivateKeyParameters(new SecureRandom());
            m_pPrivateKey = pPrivateKey;
            return (pPrivateKey.GeneratePublicKey().GetEncoded(), pPrivateKey.GetEncoded());
        }

        public void LoadKeys(byte[] @public, byte[] @private)
        {
            ArgumentNullException.ThrowIfNull(@public);
            ArgumentNullException.ThrowIfNull(@private);

            if (@private.Length != X25519PrivateKeyParameters.KeySize)
                throw new ArgumentException("Invalid X25519 private key length.", nameof(@private));

            // Reject inconsistent key pairs before using them for Pair Verify.
            X25519PrivateKeyParameters pPrivateKey = new X25519PrivateKeyParameters(@private, 0);

            if (!@public.AsSpan().SequenceEqual(pPrivateKey.GeneratePublicKey().GetEncoded()))
                throw new ArgumentException("The X25519 public key does not match the private key.", nameof(@public));

            m_pPrivateKey = pPrivateKey;
        }

        public byte[] GetSharedSecret(byte[] otherPublic)
        {
            ArgumentNullException.ThrowIfNull(otherPublic);

            if (otherPublic.Length != X25519PublicKeyParameters.KeySize)
                throw new ArgumentException("Invalid X25519 public key length.", nameof(otherPublic));

            // Derive the same X25519 shared secret on Windows and Linux.
            X25519PrivateKeyParameters pPrivateKey = m_pPrivateKey ?? throw new InvalidOperationException("No X25519 private key is available.");
            X25519PublicKeyParameters pPeer = new X25519PublicKeyParameters(otherPublic, 0);
            byte[] arSecret = new byte[X25519PrivateKeyParameters.SecretSize];
            pPrivateKey.GenerateSecret(pPeer, arSecret, 0);
            return arSecret;
        }
    }
}
