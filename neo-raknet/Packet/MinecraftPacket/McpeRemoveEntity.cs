namespace neo_raknet.Packet.MinecraftPacket;

public class McpeRemoveEntity : Packet
{
    public long entityIdSelf; // = null;

    public McpeRemoveEntity()
    {
        Id = 0x0e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(entityIdSelf);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entityIdSelf = ReadSignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entityIdSelf = default;
    }
}