using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetSpawnPosition : Packet
{
    public BlockCoordinates coordinates; // = null;
    public int dimension; // = null;

    public int spawnType; // = null;
    public BlockCoordinates unknownCoordinates; // = null;

    public McpeSetSpawnPosition()
    {
        Id = 0x2b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(spawnType);
        Write(coordinates);
        WriteSignedVarInt(dimension);
        Write(unknownCoordinates);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        spawnType = ReadSignedVarInt();
        coordinates = ReadBlockCoordinates();
        dimension = ReadSignedVarInt();
        unknownCoordinates = ReadBlockCoordinates();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        spawnType = default;
        coordinates = default;
        dimension = default;
        unknownCoordinates = default;
    }
}