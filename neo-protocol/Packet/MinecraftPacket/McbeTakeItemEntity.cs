namespace neo_protocol.Packet.MinecraftPacket;

public class McpeTakeItemEntity : Packet
{
    public long runtimeEntityId; // = null;
    public long target; // = null;

    public McpeTakeItemEntity()
    {
        Id = 0x11;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        WriteUnsignedVarLong(target);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        target = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        target = default;
    }
}