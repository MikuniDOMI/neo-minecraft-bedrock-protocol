namespace neo_protocol.Packet.MinecraftPacket;

public class ConnectedPong : Packet
{
    public long sendpingtime; // = null;
    public long sendpongtime; // = null;

    public ConnectedPong()
    {
        Id = 0x03;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(sendpingtime);
        Write(sendpongtime);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        sendpingtime = ReadLong();
        sendpongtime = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        sendpingtime = default;
        sendpongtime = default;
    }
}