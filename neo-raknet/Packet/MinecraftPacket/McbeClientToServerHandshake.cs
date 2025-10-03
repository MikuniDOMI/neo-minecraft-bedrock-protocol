namespace neo_protocol.Packet.MinecraftPacket;

public class McpeClientToServerHandshake : Packet
{
    public McpeClientToServerHandshake()
    {
        Id = 0x04;
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