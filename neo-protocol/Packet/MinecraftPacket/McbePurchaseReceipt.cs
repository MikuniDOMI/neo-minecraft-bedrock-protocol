namespace neo_protocol.Packet.MinecraftPacket;

public class McpePurchaseReceipt : Packet
{
    public McpePurchaseReceipt()
    {
        Id = 0x5c;
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