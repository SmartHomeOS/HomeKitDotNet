namespace Test;

internal sealed class FragmentedReadStream : MemoryStream
{
    private readonly int m_nMaxRead;

    public FragmentedReadStream(byte[] arBytes, int nMaxRead) : base(arBytes)
    {
        m_nMaxRead = nMaxRead;
    }

    public override ValueTask<int> ReadAsync(Memory<byte> pBuffer, CancellationToken ct)
    {
        // Force reads to span multiple transport fragments.
        return base.ReadAsync(pBuffer.Slice(0, Math.Min(pBuffer.Length, m_nMaxRead)), ct);
    }
}
