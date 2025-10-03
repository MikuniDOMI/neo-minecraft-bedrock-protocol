namespace neo_protocol.Packet.MinecraftPacket;

public class McpeChunkRadiusUpdate : Packet
{
    public int chunkRadius; // = null;

    public McpeChunkRadiusUpdate()
    {
        Id = 0x46;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(chunkRadius);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        chunkRadius = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        chunkRadius = default;
    }
}