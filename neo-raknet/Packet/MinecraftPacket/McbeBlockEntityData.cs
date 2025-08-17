using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.NBT;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeBlockEntityData : Packet
{
    public BlockCoordinates coordinates; // = null;
    public Nbt namedtag; // = null;

    public McpeBlockEntityData()
    {
        Id = 0x38;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(coordinates);
        Write(namedtag);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        coordinates = ReadBlockCoordinates();
        namedtag = ReadNbt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        coordinates = default;
        namedtag = default;
    }
}