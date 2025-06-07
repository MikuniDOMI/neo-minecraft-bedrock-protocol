namespace neo_raknet.Packet.MinecraftPacket;

public class McpeMobEffect : Packet
{
    public int  amplifier; // = null;
    public int  duration; // = null;
    public int  effectId; // = null;
    public byte eventId; // = null;
    public bool particles; // = null;

    public long runtimeEntityId; // = null;
    public long tick; // = null;

    public McpeMobEffect()
    {
        Id = 0x1c;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(eventId);
        WriteSignedVarInt(effectId);
        WriteSignedVarInt(amplifier);
        Write(particles);
        WriteSignedVarInt(duration);
        WriteUnsignedVarLong(tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        eventId = ReadByte();
        effectId = ReadSignedVarInt();
        amplifier = ReadSignedVarInt();
        particles = ReadBool();
        duration = ReadSignedVarInt();
        tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        eventId = default;
        effectId = default;
        amplifier = default;
        particles = default;
        duration = default;
        tick = default;
    }
}