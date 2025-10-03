namespace neo_protocol.Packet.MinecraftPacket;

public class McpeMapCreateLockedCopy : Packet
{
    public McpeMapCreateLockedCopy()
    {
        Id = 0x83;
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