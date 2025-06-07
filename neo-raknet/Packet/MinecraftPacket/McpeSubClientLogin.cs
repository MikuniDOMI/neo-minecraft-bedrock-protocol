namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSubClientLogin : Packet
{
    public McpeSubClientLogin()
    {
        Id = 0x5e;
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