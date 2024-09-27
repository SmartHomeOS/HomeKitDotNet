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

namespace HomeKitDotNet.Crypto
{
    internal class ECCKey : ECDiffieHellmanPublicKey
    {
        byte[] _pub;
        byte[]? _priv;
        public ECCKey(byte[] pub, byte[]? priv = null)
        {
            _pub = pub;
            _priv = priv;
        }

        public override ECParameters ExportParameters()
        {
            return new ECParameters()
            {
                Curve = X25519.Curve25519,
                D = _priv,
                Q = new ECPoint()
                {
                    X = _pub,
                    Y = new byte[32]
                }
            };
        }
    }
}
