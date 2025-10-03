using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeAddPainting : Packet
{
    public BlockCoordinates coordinates; // = null;
    public int direction; // = null;

    public long entityIdSelf; // = null;
    public long runtimeEntityId; // = null;
    public string title; // = null;

    public McpeAddPainting()
    {
        Id = 0x16;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(entityIdSelf);
        WriteUnsignedVarLong(runtimeEntityId);
        WritePaintingCoordinates(coordinates);
        WriteSignedVarInt(direction);
        Write(title);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entityIdSelf = ReadSignedVarLong();
        runtimeEntityId = ReadUnsignedVarLong();
        coordinates = ReadBlockCoordinates();
        direction = ReadSignedVarInt();
        title = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entityIdSelf = default;
        runtimeEntityId = default;
        coordinates = default;
        direction = default;
        title = default;
    }
}