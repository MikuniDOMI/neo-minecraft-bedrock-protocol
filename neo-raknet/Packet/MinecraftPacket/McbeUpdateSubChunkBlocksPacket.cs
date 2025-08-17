using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeUpdateSubChunkBlocksPacket : Packet
{
    public UpdateSubChunkBlocksPacketEntry[] layerOneUpdates; // = null;
    public UpdateSubChunkBlocksPacketEntry[] layerZeroUpdates; // = null;

    public BlockCoordinates subchunkCoordinates; // = null;

    public McpeUpdateSubChunkBlocksPacket()
    {
        Id = 0xac;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(subchunkCoordinates);
        Write(layerZeroUpdates);
        Write(layerOneUpdates);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        subchunkCoordinates = ReadBlockCoordinates();
        layerZeroUpdates = ReadUpdateSubChunkBlocksPacketEntrys();
        layerOneUpdates = ReadUpdateSubChunkBlocksPacketEntrys();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        subchunkCoordinates = default;
        layerZeroUpdates = default;
        layerOneUpdates = default;
    }
}