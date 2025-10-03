using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeNetworkChunkPublisherUpdate : Packet
{
    public BlockCoordinates coordinates; // = null;
    public uint radius; // = null;
    public int savedChunks; // = null;
    public uint x; // = null;
    public uint z; // = null;

    public McpeNetworkChunkPublisherUpdate()
    {
        Id = 0x79;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(coordinates);
        WriteUnsignedVarInt(radius);
        Write(savedChunks);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        coordinates = ReadBlockCoordinates();
        radius = ReadUnsignedVarInt();
        savedChunks = ReadInt();
        for (var i = 0; i < savedChunks; i++)
        {
            x = ReadUnsignedVarInt();
            z = ReadUnsignedVarInt();
            //todo saved chunk list
        }
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        coordinates = default;
        radius = default;
        savedChunks = default;
        x = default(int);
        z = default(int);
    }
}