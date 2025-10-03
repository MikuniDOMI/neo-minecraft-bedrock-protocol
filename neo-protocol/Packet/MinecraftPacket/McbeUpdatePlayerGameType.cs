namespace neo_protocol.Packet.MinecraftPacket;

public class McpeUpdatePlayerGameType : Packet
{
    public McpeUpdatePlayerGameType()
    {
        Id = 0x97;
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