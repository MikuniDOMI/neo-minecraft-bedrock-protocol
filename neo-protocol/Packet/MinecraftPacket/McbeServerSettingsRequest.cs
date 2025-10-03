namespace neo_protocol.Packet.MinecraftPacket;

public class McpeServerSettingsRequest : Packet
{
    public McpeServerSettingsRequest()
    {
        Id = 0x66;
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