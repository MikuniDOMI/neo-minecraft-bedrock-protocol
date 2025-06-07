namespace neo_raknet.Packet.MinecraftPacket;

public class McpeStructureBlockUpdate : Packet
{
    public McpeStructureBlockUpdate()
    {
        Id = 0x5a;
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