namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetLastHurtBy : Packet
{
    public int unknown; // = null;

    public McpeSetLastHurtBy()
    {
        Id = 0x60;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteVarInt(unknown);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        unknown = ReadVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        unknown = default;
    }
}