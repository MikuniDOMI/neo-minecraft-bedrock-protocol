namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSimpleEvent : Packet
{
    public ushort eventType; // = null;

    public McpeSimpleEvent()
    {
        Id = 0x40;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(eventType);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        eventType = ReadUshort();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        eventType = default;
    }
}