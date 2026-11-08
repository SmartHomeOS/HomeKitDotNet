using HomeKitDotNet;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Test;

[TestClass]
public sealed class EncryptedStreamReaderTest
{
    [TestMethod]
    public async Task FragmentedHeaderAndSingleByteBodyAreReadCompletely()
    {
        // Exercise the final byte and headers split across transport reads.
        using FragmentedReadStream pStream = new FragmentedReadStream(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\n\r\nX"), 1);
        EncryptedStreamReader pReader = new EncryptedStreamReader(pStream);
        Assert.AreEqual("HTTP/1.1 200 OK", await pReader.ReadLineAsync(CancellationToken.None));
        Assert.AreEqual("", await pReader.ReadLineAsync(CancellationToken.None));
        byte[] arBody = new byte[1];
        await pReader.ReadBytesAsync(arBody, 1, CancellationToken.None);
        Assert.AreEqual((byte)'X', arBody[0]);
    }

    [TestMethod]
    public async Task BufferedBodyPreservesTheNextResponse()
    {
        // Both responses arrive in one read, but consuming the body must leave the next header intact.
        using MemoryStream pStream = new MemoryStream(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\n\r\nabcHTTP/1.1 204 No Content\r\n"));
        EncryptedStreamReader pReader = new EncryptedStreamReader(pStream);
        await pReader.ReadLineAsync(CancellationToken.None);
        await pReader.ReadLineAsync(CancellationToken.None);
        byte[] arBody = new byte[8];
        await pReader.ReadBytesAsync(arBody, 3, CancellationToken.None);
        Assert.AreEqual("abc", Encoding.ASCII.GetString(arBody, 0, 3));
        Assert.AreEqual("HTTP/1.1 204 No Content", await pReader.ReadLineAsync(CancellationToken.None));
    }

    [TestMethod]
    public async Task TruncatedBodyThrowsInsteadOfWaitingForever()
    {
        // EOF must be reported even when only the last requested byte is missing.
        using MemoryStream pStream = new MemoryStream(new byte[] { 1, 2 });
        EncryptedStreamReader pReader = new EncryptedStreamReader(pStream);
        bool bRejected = false;

        try
        {
            await pReader.ReadBytesAsync(new byte[3], 3, CancellationToken.None);
        }
        catch (EndOfStreamException)
        {
            bRejected = true;
        }

        Assert.IsTrue(bRejected);
    }

    [TestMethod]
    public async Task EncryptedLinesCanSpanFramesAndPreserveBufferedBytes()
    {
        // Split CRLF between encrypted frames and keep the next header in the same final frame.
        byte[] arKey = new byte[32];
        using MemoryStream pStream = new MemoryStream();
        EncryptedStreamWriter pWriter = new EncryptedStreamWriter(pStream);
        using ChaCha20Poly1305 pEncrypter = new ChaCha20Poly1305(arKey);
        pWriter.EnableEncryption(pEncrypter);
        await pWriter.WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r"), CancellationToken.None);
        await pWriter.FlushAsync(CancellationToken.None);
        await pWriter.WriteAsync(Encoding.ASCII.GetBytes("\nNext: value\r\n"), CancellationToken.None);
        await pWriter.FlushAsync(CancellationToken.None);
        pStream.Position = 0;
        EncryptedStreamReader pReader = new EncryptedStreamReader(pStream);
        using ChaCha20Poly1305 pDecrypter = new ChaCha20Poly1305(arKey);
        MethodInfo pEnable = typeof(EncryptedStreamReader).GetMethod("EnableDecryption", BindingFlags.Instance | BindingFlags.NonPublic)!;
        pEnable.Invoke(pReader, new object[] { pDecrypter });
        Assert.AreEqual("HTTP/1.1 200 OK", await pReader.ReadLineAsync(CancellationToken.None));
        Assert.AreEqual("Next: value", await pReader.ReadLineAsync(CancellationToken.None));
    }
}
