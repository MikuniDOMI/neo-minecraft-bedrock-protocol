using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSubChunkRequestPacket : Packet
{
    public BlockCoordinates basePosition; // = null;

    public int                      dimension; // = null;
    public SubChunkPositionOffset[] offsets; // = null;

    public McpeSubChunkRequestPacket()
    {
        Id = 0xaf;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteVarInt(dimension);
        Write(basePosition);
        Write(offsets);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        dimension = ReadVarInt();
        basePosition = ReadBlockCoordinates();
        offsets = ReadSubChunkPositionOffsets();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        dimension = default;
        basePosition = default(BlockCoordinates);
        offsets = default;
    }
}