using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpePlayerAction : Packet
{
    public int actionId; // = null;
    public BlockCoordinates coordinates; // = null;
    public int face; // = null;
    public BlockCoordinates resultCoordinates; // = null;

    public long runtimeEntityId; // = null;

    public McpePlayerAction()
    {
        Id = 0x24;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        WriteSignedVarInt(actionId);
        Write(coordinates);
        Write(resultCoordinates);
        WriteSignedVarInt(face);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        actionId = ReadSignedVarInt();
        coordinates = ReadBlockCoordinates();
        resultCoordinates = ReadBlockCoordinates();
        face = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        actionId = default;
        coordinates = default;
        resultCoordinates = default;
        face = default;
    }
}