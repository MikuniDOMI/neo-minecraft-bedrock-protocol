namespace neo_raknet.Packet.MinecraftPacket;

public class DetectLostConnections : Packet
{
    public DetectLostConnections()
    {
        Id = 0x04;
        IsMcpe = false;
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