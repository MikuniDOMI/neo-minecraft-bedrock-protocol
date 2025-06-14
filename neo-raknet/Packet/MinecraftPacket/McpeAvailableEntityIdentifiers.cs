using neo_raknet.Packet.MinecraftStruct.NBT;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeAvailableEntityIdentifiers : Packet
{
    public Nbt namedtag; // = null;

    public McpeAvailableEntityIdentifiers()
    {
        Id = 0x77;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(namedtag);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        namedtag = ReadNbt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        namedtag = default;
    }
}