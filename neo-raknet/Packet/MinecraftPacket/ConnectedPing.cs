namespace neo_raknet.Packet.MinecraftPacket;

public class ConnectedPing : Packet
{
    public long sendpingtime; // = null;

    public ConnectedPing()
    {
        Id = 0x00;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(sendpingtime);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        sendpingtime = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        sendpingtime = default;
    }
}