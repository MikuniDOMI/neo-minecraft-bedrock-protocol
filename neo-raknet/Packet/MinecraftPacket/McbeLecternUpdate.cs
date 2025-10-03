namespace neo_protocol.Packet.MinecraftPacket;

public class McpeLecternUpdate : Packet
{
    public McpeLecternUpdate()
    {
        Id = 0x7d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}