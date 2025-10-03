using neo_protocol.Packet.MinecraftStruct.Entity;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeMoveEntity : Packet
{
    public byte flags; // = null;
    public PlayerLocation position; // = null;

    public long runtimeEntityId; // = null;

    public McpeMoveEntity()
    {
        Id = 0x12;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(flags);
        Write(position);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        flags = ReadByte();
        position = ReadPlayerLocation();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        flags = default;
        position = default;
    }
}