namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePackChunkRequest : Packet
{
    public uint chunkIndex; // = null;

    public string packageId; // = null;

    public McpeResourcePackChunkRequest()
    {
        Id = 0x54;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(packageId);
        Write(chunkIndex);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        packageId = ReadString();
        chunkIndex = ReadUint();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        packageId = default;
        chunkIndex = default;
    }
}