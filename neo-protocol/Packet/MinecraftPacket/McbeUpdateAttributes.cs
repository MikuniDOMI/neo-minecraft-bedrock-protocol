using neo_protocol.Packet.MinecraftStruct.Entity;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeUpdateAttributes : Packet
{
    public PlayerAttributes attributes; // = null;

    public long runtimeEntityId; // = null;
    public long tick; // = null;

    public McpeUpdateAttributes()
    {
        Id = 0x1d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(attributes);
        WriteUnsignedVarLong(tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        attributes = ReadPlayerAttributes();
        tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        attributes = default;
        tick = default;
    }
}