using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeBlockEvent : Packet
{
    public int case1; // = null;
    public int case2; // = null;

    public BlockCoordinates coordinates; // = null;

    public McpeBlockEvent()
    {
        Id = 0x1a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(coordinates);
        WriteSignedVarInt(case1);
        WriteSignedVarInt(case2);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        coordinates = ReadBlockCoordinates();
        case1 = ReadSignedVarInt();
        case2 = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        coordinates = default;
        case1 = default;
        case2 = default;
    }
}