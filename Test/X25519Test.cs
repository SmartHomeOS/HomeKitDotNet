using HomeKitDotNet.Crypto;

namespace Test;

[TestClass]
public sealed class X25519Test
{
    [TestMethod]
    public void SharedSecretMatchesRfc7748()
    {
        // RFC 7748 section 6.1, Alice's key pair and Bob's public key.
        byte[] arPrivate = Convert.FromHexString("77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a");
        byte[] arPublic = Convert.FromHexString("8520f0098930a754748b7ddcb43ef75a0dbf3a0d26381af4eba4a98eaa9b4e6a");
        byte[] arPeer = Convert.FromHexString("de9edb7d7b7dc1b4d35b61c2ece435373f8343c85b78674dadfc7e146f882b4f");
        byte[] arExpected = Convert.FromHexString("4a5d9d5ba4ce2de1728e3bf480350f25e07e21c947d19e3376f09b3c1e161742");
        X25519 pSession = new X25519();
        pSession.LoadKeys(arPublic, arPrivate);
        CollectionAssert.AreEqual(arExpected, pSession.GetSharedSecret(arPeer));
    }

    [TestMethod]
    public void GeneratedKeyPairsCanBeReloaded()
    {
        // Preserve the original tuple-returning public API and verify symmetric agreement.
        X25519 pAlice = new X25519();
        X25519 pBob = new X25519();
        ValueTuple<byte[], byte[]> pAliceKeys = pAlice.GenerateKeyPair();
        ValueTuple<byte[], byte[]> pBobKeys = pBob.GenerateKeyPair();
        X25519 pReloaded = new X25519();
        pReloaded.LoadKeys(pAliceKeys.Item1, pAliceKeys.Item2);
        CollectionAssert.AreEqual(pBob.GetSharedSecret(pAliceKeys.Item1), pReloaded.GetSharedSecret(pBobKeys.Item1));
    }

    [TestMethod]
    public void InconsistentKeyPairIsRejected()
    {
        // Imported private and public keys must describe the same key pair.
        X25519 pSession = new X25519();
        bool bRejected = false;

        try
        {
            pSession.LoadKeys(new byte[32], new byte[32]);
        }
        catch (ArgumentException)
        {
            bRejected = true;
        }

        Assert.IsTrue(bRejected);
    }
}
