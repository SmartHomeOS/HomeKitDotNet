using HomeKitDotNet;
using HomeKitDotNet.JSON;
using HomeKitDotNet.Models;
using HomeKitDotNet.TLV.Enums;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace Test;

[TestClass]
public sealed class ConnectionTest
{
    private readonly List<string> m_lstEventPayloads = new List<string>();

    [TestMethod]
    public async Task ChunkExtensionsAndTrailersPreserveTheNextResponse()
    {
        // A complete chunked response must not consume or corrupt the following response.
        using CancellationTokenSource pTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using TcpListener pListener = new TcpListener(IPAddress.Loopback, 0);
        pListener.Start();
        using Connection pConnection = new Connection();
        await pConnection.ConnectAsync((IPEndPoint)pListener.LocalEndpoint, pTimeout.Token);
        using TcpClient pPeer = await pListener.AcceptTcpClientAsync(pTimeout.Token);
        Task<HttpResponseMessage> pPending = pConnection.Get("/first", pTimeout.Token);
        await ReadRequestAsync(pPeer, pTimeout.Token);
        string sResponse = "HTTP/1.1 200 OK\r\nTransfer-Encoding: chunked\r\nContent-Type: text/plain\r\n\r\n3;extension=value\r\nabc\r\n0\r\nX-Trailer: value\r\n\r\nHTTP/1.1 200 OK\r\nContent-Length: 1\r\n\r\nZ";
        await pPeer.GetStream().WriteAsync(Encoding.ASCII.GetBytes(sResponse), pTimeout.Token);
        using HttpResponseMessage pFirst = await pPending.WaitAsync(pTimeout.Token);
        Assert.AreEqual("abc", await pFirst.Content.ReadAsStringAsync());
        using HttpResponseMessage pSecond = await pConnection.Get("/second", pTimeout.Token);
        Assert.AreEqual("Z", await pSecond.Content.ReadAsStringAsync());
        await ReadRequestAsync(pPeer, pTimeout.Token);
    }

    [TestMethod]
    public async Task EncryptionTransitionUsesOnlyOneReceiveLoop()
    {
        // Finish a plaintext request, then exchange another response using HAP encryption.
        using CancellationTokenSource pTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using TcpListener pListener = new TcpListener(IPAddress.Loopback, 0);
        pListener.Start();
        using Connection pConnection = new Connection();
        await pConnection.ConnectAsync((IPEndPoint)pListener.LocalEndpoint, pTimeout.Token);
        using TcpClient pPeer = await pListener.AcceptTcpClientAsync(pTimeout.Token);
        Task<HttpResponseMessage> pPlainPending = pConnection.Get("/plaintext", pTimeout.Token);
        await ReadRequestAsync(pPeer, pTimeout.Token);
        await pPeer.GetStream().WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 204 No Content\r\n\r\n"), pTimeout.Token);
        using HttpResponseMessage pPlainResponse = await pPlainPending.WaitAsync(pTimeout.Token);
        byte[] arWriteKey = new byte[32];
        byte[] arReadKey = new byte[32];
        arReadKey[0] = 1;
        await pConnection.EnableEncryption(arWriteKey, arReadKey).WaitAsync(pTimeout.Token);
        Task<HttpResponseMessage> pEncryptedPending = pConnection.Get("/encrypted", pTimeout.Token);

        // Decrypt the outgoing request as well, so the complete round trip is exercised.
        EncryptedStreamReader pServerReader = new EncryptedStreamReader(pPeer.GetStream());
        using ChaCha20Poly1305 pDecrypter = new ChaCha20Poly1305(arWriteKey);
        System.Reflection.MethodInfo pEnable = typeof(EncryptedStreamReader).GetMethod("EnableDecryption", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!;
        pEnable.Invoke(pServerReader, new object[] { pDecrypter });
        Assert.AreEqual("GET /encrypted HTTP/1.1", await pServerReader.ReadLineAsync(pTimeout.Token));

        while ((await pServerReader.ReadLineAsync(pTimeout.Token)).Length != 0)
        {
        }

        EncryptedStreamWriter pServerWriter = new EncryptedStreamWriter(pPeer.GetStream());
        using ChaCha20Poly1305 pEncrypter = new ChaCha20Poly1305(arReadKey);
        pServerWriter.EnableEncryption(pEncrypter);
        await pServerWriter.WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 2\r\n\r\nOK"), pTimeout.Token);
        await pServerWriter.FlushAsync(pTimeout.Token);
        using HttpResponseMessage pEncryptedResponse = await pEncryptedPending.WaitAsync(pTimeout.Token);
        Assert.AreEqual("OK", await pEncryptedResponse.Content.ReadAsStringAsync());
    }

    [TestMethod]
    public async Task ClosedSocketCompletesPendingRequests()
    {
        // Transport failure must wake the caller without waiting for its cancellation token.
        using CancellationTokenSource pTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using TcpListener pListener = new TcpListener(IPAddress.Loopback, 0);
        pListener.Start();
        using Connection pConnection = new Connection();
        await pConnection.ConnectAsync((IPEndPoint)pListener.LocalEndpoint, pTimeout.Token);
        using TcpClient pPeer = await pListener.AcceptTcpClientAsync(pTimeout.Token);
        Task<HttpResponseMessage> pPending = pConnection.Get("/closed", pTimeout.Token);
        await ReadRequestAsync(pPeer, pTimeout.Token);
        pPeer.Dispose();
        bool bClosed = false;

        try
        {
            await pPending.WaitAsync(pTimeout.Token);
        }
        catch (ChannelClosedException)
        {
            bClosed = true;
        }

        Assert.IsTrue(bClosed);
        pConnection.Dispose();
    }

    [TestMethod]
    public async Task EventSubscribersEachReadTheCompleteBody()
    {
        // Two subscribers consume the event stream before an ordinary response is delivered.
        using CancellationTokenSource pTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using TcpListener pListener = new TcpListener(IPAddress.Loopback, 0);
        pListener.Start();
        using Connection pConnection = new Connection();
        pConnection.EventReceived += ReadFirstEvent;
        pConnection.EventReceived += ReadSecondEvent;
        await pConnection.ConnectAsync((IPEndPoint)pListener.LocalEndpoint, pTimeout.Token);
        using TcpClient pPeer = await pListener.AcceptTcpClientAsync(pTimeout.Token);
        Task<HttpResponseMessage> pPending = pConnection.Get("/events", pTimeout.Token);
        await ReadRequestAsync(pPeer, pTimeout.Token);
        string sResponse = "EVENT/1.0 200 OK\r\nContent-Length: 3\r\n\r\nabcHTTP/1.1 204 No Content\r\n\r\n";
        await pPeer.GetStream().WriteAsync(Encoding.ASCII.GetBytes(sResponse), pTimeout.Token);
        using HttpResponseMessage pResponse = await pPending.WaitAsync(pTimeout.Token);
        CollectionAssert.AreEqual(new string[] { "abc", "abc" }, m_lstEventPayloads);
        Assert.AreEqual(HttpStatusCode.NoContent, pResponse.StatusCode);
    }

    [TestMethod]
    [DataRow((byte)PairingState.M1, false)]
    [DataRow((byte)PairingState.M2, true)]
    public async Task UnPairRequiresM2Acknowledgment(byte nState, bool bExpected)
    {
        // Use the real HTTP path and TLV parser, without a physical accessory.
        using CancellationTokenSource pTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using TcpListener pListener = new TcpListener(IPAddress.Loopback, 0);
        pListener.Start();
        using Connection pConnection = new Connection();
        await pConnection.ConnectAsync((IPEndPoint)pListener.LocalEndpoint, pTimeout.Token);
        using TcpClient pPeer = await pListener.AcceptTcpClientAsync(pTimeout.Token);
        using Controller pController = new Controller(out byte[] arPublic, out byte[] arPrivate);
        HomeKitEndPoint pEndpoint = new HomeKitEndPoint(pConnection, new AccessoriesJSON { Accessories = [] });
        Task<bool> pPending = pController.UnPair(pEndpoint, pTimeout.Token);
        string sRequest = await ReadRequestAsync(pPeer, pTimeout.Token);
        Assert.AreEqual("POST /pairings HTTP/1.1", sRequest);
        await pPeer.GetStream().WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 3\r\n\r\n"), pTimeout.Token);
        await pPeer.GetStream().WriteAsync(new byte[] { (byte)TLVType.kTLVType_State, 1, nState }, pTimeout.Token);
        Assert.AreEqual(bExpected, await pPending.WaitAsync(pTimeout.Token));
    }

    private static async Task<string> ReadRequestAsync(TcpClient pPeer, CancellationToken ct)
    {
        // Consume the complete request so closing the peer does not discard unread bytes.
        EncryptedStreamReader pReader = new EncryptedStreamReader(pPeer.GetStream());
        string sRequest = await pReader.ReadLineAsync(ct);
        string sLine;
        int nLength = 0;

        while ((sLine = await pReader.ReadLineAsync(ct)).Length != 0)
        {
            if (sLine.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                nLength = int.Parse(sLine.Substring("Content-Length:".Length));
        }

        if (nLength > 0)
            await pReader.ReadBytesAsync(new byte[nLength], nLength, ct);

        return sRequest;
    }

    private void ReadFirstEvent(object? sender, HttpResponseMessage pResponse)
    {
        // Leave response ownership with the connection.
        using StreamReader pReader = new StreamReader(pResponse.Content.ReadAsStream(), Encoding.UTF8, false, 1024, true);
        m_lstEventPayloads.Add(pReader.ReadToEnd());
    }

    private void ReadSecondEvent(object? sender, HttpResponseMessage pResponse)
    {
        // The second subscriber must see the same content from the beginning.
        using StreamReader pReader = new StreamReader(pResponse.Content.ReadAsStream(), Encoding.UTF8, false, 1024, true);
        m_lstEventPayloads.Add(pReader.ReadToEnd());
    }
}
