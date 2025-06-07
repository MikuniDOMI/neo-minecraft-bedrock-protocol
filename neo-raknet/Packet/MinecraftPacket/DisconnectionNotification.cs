namespace neo_raknet.Packet.MinecraftPacket;

public class DisconnectionNotification : Packet
{
    public DisconnectionNotification()
    {
        Id = 0x15;
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