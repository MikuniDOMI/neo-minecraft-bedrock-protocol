namespace neo_protocol.Packet.MinecraftPacket;

public class McpeClientCacheBlobStatus : Packet
{
    public ulong[] hashHits; // = null;
    public ulong[] hashMisses; // = null;

    public McpeClientCacheBlobStatus()
    {
        Id = 0x87;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt((uint)hashMisses.Length);
        WriteUnsignedVarInt((uint)hashHits.Length);
        WriteSpecial(hashMisses);
        WriteSpecial(hashHits);
    }

    public void WriteSpecial(ulong[] values)
    {
        if (values == null) return;

        if (values.Length == 0) return;
        for (var i = 0; i < values.Length; i++)
        {
            var val = values[i];
            Write(val);
        }
    }

    public ulong[] ReadUlongsSpecial(uint len)
    {
        var values = new ulong[len];
        for (var i = 0; i < values.Length; i++) values[i] = ReadUlong();
        return values;
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        var lenMisses = ReadUnsignedVarInt();
        var lenHits = ReadUnsignedVarInt();

        hashMisses = ReadUlongsSpecial(lenMisses);
        hashHits = ReadUlongsSpecial(lenHits);
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}