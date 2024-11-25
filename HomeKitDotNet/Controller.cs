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

using HomeKitDotNet.Crypto;
using HomeKitDotNet.JSON;
using HomeKitDotNet.Models;
using HomeKitDotNet.TLV;
using HomeKitDotNet.TLV.Enums;
using System.Globalization;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace HomeKitDotNet
{
    public class Controller : IDisposable
    {
        private byte[] LTPK;
        private byte[] LTSK;
        private byte[] deviceID;
        private List<HomeKitEndPoint> endpoints = new List<HomeKitEndPoint>();

        /// <summary>
        /// Create a controller with a randomly generated key
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public Controller(out byte[] publicKey, out byte[] privateKey)
        {
            byte[] seed = RandomNumberGenerator.GetBytes(32);
            Ed25519.KeyPairFromSeed(out LTPK, out LTSK, seed);
            deviceID = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture));
            publicKey = LTPK;
            privateKey = LTSK;
        }

        /// <summary>
        /// Create a controller using the provided device ID and keys
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <param name="deviceID"></param>
        public Controller(byte[] privateKey, byte[] publicKey, byte[] deviceID)
        {
            if (privateKey.Length != 64)
                throw new ArgumentException("Invalid Private Key Length: " + privateKey.Length);
            if (publicKey.Length != 32)
                throw new ArgumentException("Invalid Public Key Length: " + publicKey.Length);
            if (deviceID.Length != 36)
                throw new ArgumentException("Invalid Device ID Length: " + deviceID.Length);
            LTPK = publicKey;
            LTSK = privateKey;
            this.deviceID = deviceID;
        }

        public byte[] DeviceID { get { return deviceID; } }

        /// <summary>
        /// Connect to an already paired Accessory
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="accessoryID"></param>
        /// <param name="accessoryLTPK"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<HomeKitEndPoint> Connect(IPEndPoint destination, byte[] accessoryID, byte[] accessoryLTPK, CancellationToken token = default)
        {
            if (accessoryID.Length != 17)
                throw new ArgumentException("Invalid Accessory ID Length: " + accessoryID.Length);
            if (accessoryLTPK.Length != 32)
                throw new ArgumentException("Invalid Accessory LTPK Length: " + accessoryLTPK.Length);

            X25519 session = new X25519();
            var keyPair = session.GenerateKeyPair();

            Connection con = new Connection();
            await con.ConnectAsync(destination, token);

            //Step 1
            HttpResponseMessage msg = await con.PostTLVs("/pair-verify", token, new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M1), new TLVBytes(TLVType.kTLVType_PublicKey, keyPair.Public));
            if (!msg.IsSuccessStatusCode)
            {
                con.Dispose();
                throw new IOException($"Pair Step 1 Failed with {msg.StatusCode}: {msg.ReasonPhrase}");
            }

            List<TLVValue> responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());
            byte[] AccessorySessionPK = TLVValue.Concat(TLVType.kTLVType_PublicKey, responseTLVs);
            ArraySegment<byte> encrypted = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_EncryptedData) as TLVBytes)!.Value;
            byte[] payload = new byte[encrypted.Count - 16];
            byte[] sharedSecret = session.GetSharedSecret(AccessorySessionPK);

            byte[] sessionKey = HKDF.DeriveKey(HashAlgorithmName.SHA512, sharedSecret, 32, Encoding.UTF8.GetBytes("Pair-Verify-Encrypt-Salt"), Encoding.UTF8.GetBytes("Pair-Verify-Encrypt-Info"));

            ChaCha20Poly1305 decrypter = new ChaCha20Poly1305(sessionKey);
            decrypter.Decrypt(Encoding.ASCII.GetBytes("\0\0\0\0PV-Msg02"), encrypted.Slice(0, encrypted.Count - 16), encrypted.Slice(encrypted.Count - 16, 16), payload);
            responseTLVs = TLVValue.CollectionFromStream(new MemoryStream(payload));

            byte[] AccessoryInfo = BufferUtil.Concat(AccessorySessionPK, accessoryID, keyPair.Public);
            byte[] accessorySignature = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_Signature) as TLVBytes)!.Value;
            if (!Ed25519.Verify(accessorySignature, AccessoryInfo, accessoryLTPK))
            {
                con.Dispose();
                throw new IOException("Accessory returned invalid signature");
            }

            byte[] iOSDeviceInfo = BufferUtil.Concat(keyPair.Public, DeviceID, AccessorySessionPK);
            byte[] iOSDeviceSignature = Ed25519.Sign(iOSDeviceInfo, LTSK);
            byte[] encryptedPayload;
            using (MemoryStream encryptionPayload = new MemoryStream())
            {
                TLVValue.WriteCollection([
                    new TLVBytes(TLVType.kTLVType_Signature, iOSDeviceSignature),
                    new TLVBytes(TLVType.kTLVType_Identifier, DeviceID)
                ], encryptionPayload);
                ChaCha20Poly1305 encrypter = new ChaCha20Poly1305(sessionKey);
                encryptedPayload = new byte[encryptionPayload.Length + 16];
                encrypter.Encrypt(Encoding.ASCII.GetBytes("\0\0\0\0PV-Msg03"), encryptionPayload.ToArray(), encryptedPayload.AsSpan().Slice(0, (int)encryptionPayload.Length), encryptedPayload.AsSpan().Slice((int)encryptionPayload.Length, 16));
            }

            msg = await con.PostTLVs("/pair-verify", token, 
                new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M3),
                new TLVBytes(TLVType.kTLVType_EncryptedData, encryptedPayload)
                );
            if (!msg.IsSuccessStatusCode)
            {
                con.Dispose();
                string content = new StreamReader(msg.Content.ReadAsStream()).ReadToEnd();
                throw new IOException($"Verify Step 3 Failed with {msg.StatusCode}: {msg.ReasonPhrase}: {content}");
            }
            responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());

            bool error = responseTLVs.Any(t => t.Type == TLVType.kTLVType_Error);

            if (!error)
            {
                byte[] readKey = HKDF.DeriveKey(HashAlgorithmName.SHA512, sharedSecret, 32, Encoding.UTF8.GetBytes("Control-Salt"), Encoding.UTF8.GetBytes("Control-Read-Encryption-Key"));
                byte[] writeKey = HKDF.DeriveKey(HashAlgorithmName.SHA512, sharedSecret, 32, Encoding.UTF8.GetBytes("Control-Salt"), Encoding.UTF8.GetBytes("Control-Write-Encryption-Key"));
                await con.EnableEncryption(writeKey, readKey);

                HttpResponseMessage resp = await con.Get("/accessories", token);
                AccessoriesJSON? accessories = JsonSerializer.Deserialize<AccessoriesJSON>(resp.Content.ReadAsStream(token));
                HomeKitEndPoint ep;
                if (accessories != null)
                {
                    ep = new HomeKitEndPoint(con, accessories);
                    endpoints.Add(ep);
                    return ep;
                }
                con.Dispose();
                throw new IOException("Empty Accessory List Received");
            }
            con.Dispose();
            throw new UnauthorizedAccessException("Failed to Connect - Authentication Error");
        }

        /// <summary>
        /// Unpair from an already paired accessory
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> UnPair(HomeKitEndPoint endpoint, CancellationToken token = default)
        {
            ArgumentNullException.ThrowIfNull(endpoint, nameof(endpoint));
            HttpResponseMessage msg = await endpoint.Connection.PostTLVs("/pair-setup", token,
                                                                      new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M1), 
                                                                      new TLVInt(TLVType.kTLVType_Method, (byte)Method.RemovePairing),
                                                                      new TLVBytes(TLVType.kTLVType_Identifier, DeviceID));
            if (!msg.IsSuccessStatusCode)
                return false;
            List<TLVValue> responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());
            if (responseTLVs.Any(t => t.Type == TLVType.kTLVType_Error))
                return false;

            endpoints.Remove(endpoint);
            endpoint.Connection.Dispose();
            return true;
        }

        /// <summary>
        /// Request that an unpaired device performs it's identify routine
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> IdentifyUnpaired(IPEndPoint destination, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(destination, nameof(destination));
            using (Connection con = new Connection())
            {
                await con.ConnectAsync(destination, cancellationToken);
                HttpResponseMessage msg = await con.PostTLVs("/identify", cancellationToken);
                return msg.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// Pair to an unpaired accessory
        /// </summary>
        /// <param name="setupPin"></param>
        /// <param name="destination"></param>
        /// <param name="authenticate">True for MFi certified devices</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<AccessoryInfo> Pair(long setupPin, IPEndPoint destination, bool authenticate = true, CancellationToken token = default)
        {
            ArgumentNullException.ThrowIfNull(destination, nameof(destination));
            string I = "Pair-Setup";
            string P = setupPin.ToString("000-00-000");

            using (Connection con = new Connection())
            {
                await con.ConnectAsync(destination, token);

                //Step 1
                HttpResponseMessage msg = await con.PostTLVs("/pair-setup", token, new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M1), new TLVInt(TLVType.kTLVType_Method, authenticate ? (byte)Method.PairSetupWithAuth : (byte)Method.PairSetup));
                if (!msg.IsSuccessStatusCode)
                    throw new IOException($"Pair Step 2 Failed with {msg.StatusCode}: {msg.ReasonPhrase}");
                List<TLVValue> responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());

                //Step 3
                byte[] accessoryPK = TLVValue.Concat(TLVType.kTLVType_PublicKey, responseTLVs);
                if (responseTLVs.Any(t => t.Type == TLVType.kTLVType_Error))
                    throw new IOException("Error Starting Pairing Session: " + (TLVError)(responseTLVs.Find(t => t.Type == TLVType.kTLVType_Error) as TLVInt)!.Value);
                if (accessoryPK.Length == 0)
                    throw new IOException($"Pair Step 3 Failed - Public key is missing");

                BigInteger B = new BigInteger(accessoryPK, true, true);
                byte[] s = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_Salt) as TLVBytes)!.Value;
                SRP srp = new SRP();
                BigInteger A = srp.GenerateAValues();
                BigInteger K = srp.ComputeSessionKey(I, P, s, B);
                BigInteger M1 = srp.GenerateClientProof(I, s, A, B, K);
                msg = await con.PostTLVs("/pair-setup", token,
                    new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M3),
                    new TLVBytes(TLVType.kTLVType_PublicKey, A.ToByteArray(true, true)),
                    new TLVBytes(TLVType.kTLVType_Proof, M1.ToByteArray(true, true))
                    );

                if (!msg.IsSuccessStatusCode)
                {
                    string content = new StreamReader(msg.Content.ReadAsStream()).ReadToEnd();
                    throw new IOException($"Pair Step 4 Failed with {msg.StatusCode}: {msg.ReasonPhrase}: {content}");
                }

                //Step 5
                responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());
                if (responseTLVs.Any(t => t.Type == TLVType.kTLVType_Error))
                    throw new UnauthorizedAccessException("Invalid PIN Code");

                BigInteger M2 = new BigInteger((responseTLVs.Find(t => t.Type == TLVType.kTLVType_Proof) as TLVBytes)!.Value, true, true);
                if (!srp.ValidateServerProof(M2, M1, K))
                    throw new IOException("Invalid Accessory Proof - Session Negotiation Failed");

                byte[] iOSDeviceX = HKDF.DeriveKey(HashAlgorithmName.SHA512, K.ToByteArray(true, true), 32, Encoding.UTF8.GetBytes("Pair-Setup-Controller-Sign-Salt"), Encoding.UTF8.GetBytes("Pair-Setup-Controller-Sign-Info"));
                byte[] SessionKey = HKDF.DeriveKey(HashAlgorithmName.SHA512, K.ToByteArray(true, true), 32, Encoding.UTF8.GetBytes("Pair-Setup-Encrypt-Salt"), Encoding.UTF8.GetBytes("Pair-Setup-Encrypt-Info"));

                byte[] iOSDeviceInfo = BufferUtil.Concat(iOSDeviceX, DeviceID, LTPK);

                byte[] iOSDeviceSignature = Ed25519.Sign(iOSDeviceInfo, LTSK);

                byte[] encryptedPayload;
                using (MemoryStream encryptionPayload = new MemoryStream())
                {
                    TLVValue.WriteCollection([
                        new TLVBytes(TLVType.kTLVType_Identifier, DeviceID),
                    new TLVBytes(TLVType.kTLVType_PublicKey, LTPK),
                    new TLVBytes(TLVType.kTLVType_Signature, iOSDeviceSignature)
                    ], encryptionPayload);
                    ChaCha20Poly1305 encrypter = new ChaCha20Poly1305(SessionKey);
                    encryptedPayload = new byte[encryptionPayload.Length + 16];
                    encrypter.Encrypt(Encoding.ASCII.GetBytes("\0\0\0\0PS-Msg05"), encryptionPayload.ToArray(), encryptedPayload.AsSpan().Slice(0, (int)encryptionPayload.Length), encryptedPayload.AsSpan().Slice((int)encryptionPayload.Length, 16));
                }

                msg = await con.PostTLVs("/pair-setup", token,
                    new TLVInt(TLVType.kTLVType_State, (byte)PairingState.M5),
                    new TLVBytes(TLVType.kTLVType_EncryptedData, encryptedPayload)
                    );

                if (!msg.IsSuccessStatusCode)
                {
                    string content = new StreamReader(msg.Content.ReadAsStream()).ReadToEnd();
                    throw new IOException($"Pair Step 5 Failed with {msg.StatusCode}: {msg.ReasonPhrase}: {content}");
                }
                responseTLVs = TLVValue.CollectionFromStream(msg.Content.ReadAsStream());

                //Step 7
                ArraySegment<byte> encrypted = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_EncryptedData) as TLVBytes)!.Value;
                byte[] payload = new byte[encrypted.Count - 16];
                ChaCha20Poly1305 decrypter = new ChaCha20Poly1305(SessionKey);
                decrypter.Decrypt(Encoding.ASCII.GetBytes("\0\0\0\0PS-Msg06"), encrypted.Slice(0, encrypted.Count - 16), encrypted.Slice(encrypted.Count - 16, 16), payload);
                responseTLVs = TLVValue.CollectionFromStream(new MemoryStream(payload));
                byte[] accessorySignature = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_Signature) as TLVBytes)!.Value;
                byte[] accessoryPairingID = (responseTLVs.Find(t => t.Type == TLVType.kTLVType_Identifier) as TLVBytes)!.Value;
                byte[] AccessoryLTPK = TLVValue.Concat(TLVType.kTLVType_PublicKey, responseTLVs);
                byte[] AccessoryX = HKDF.DeriveKey(HashAlgorithmName.SHA512, K.ToByteArray(true, true), 32, Encoding.UTF8.GetBytes("Pair-Setup-Accessory-Sign-Salt"), Encoding.UTF8.GetBytes("Pair-Setup-Accessory-Sign-Info"));
                byte[] AccessoryInfo = BufferUtil.Concat(AccessoryX, accessoryPairingID, AccessoryLTPK);
                if (!Ed25519.Verify(accessorySignature, AccessoryInfo, AccessoryLTPK))
                    throw new IOException("Accessory returned invalid signature");

                return new AccessoryInfo(accessoryPairingID, AccessoryLTPK);
            }
        }

        public void Dispose()
        {
            foreach (HomeKitEndPoint endPoint in EndPoints)
                endPoint.Connection.Dispose();
            endpoints.Clear();
            LTPK = new byte[0];
            LTSK = new byte[0];
        }

        public HomeKitEndPoint[] EndPoints {get { return endpoints.ToArray(); } }
    }
}
