namespace neo_raknet.Packet.MinecraftPacket;

public class McpeClientCacheMissResponse : Packet
{
    public Dictionary<ulong, byte[]> blobs;

    public McpeClientCacheMissResponse()
    {
        Id = 0x88;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        blobs = new Dictionary<ulong, byte[]>();
        var count = ReadUnsignedVarInt();
        for (var i = 0; i < count; i++)
        {
            var hash = ReadUlong();
            var blob = ReadByteArray();
            if (blobs.ContainsKey(hash))
            {
            }
            else
            {
                blobs.Add(hash, blob);
            }
        }
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}