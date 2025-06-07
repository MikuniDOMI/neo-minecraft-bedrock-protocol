namespace neo_raknet.Packet.MinecraftPacket;

public class McpeBookEdit : Packet
{
    public McpeBookEdit()
    {
        Id = 0x61;
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