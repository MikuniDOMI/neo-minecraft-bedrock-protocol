using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeContainerOpen : Packet
{
    public BlockCoordinates coordinates; // = null;
    public long runtimeEntityId; // = null;
    public byte type; // = null;

    public byte windowId; // = null;

    public McpeContainerOpen()
    {
        Id = 0x2e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(windowId);
        Write(type);
        Write(coordinates);
        WriteSignedVarLong(runtimeEntityId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        windowId = ReadByte();
        type = ReadByte();
        coordinates = ReadBlockCoordinates();
        runtimeEntityId = ReadSignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        windowId = default;
        type = default;
        coordinates = default;
        runtimeEntityId = default;
    }
}