namespace neo_raknet.Packet.MinecraftPacket;

public class McpeTelemetryEvent : Packet
{
    public byte[] auxData; // = null;
    public int    eventData; // = null;
    public byte   eventType; // = null;

    public long runtimeEntityId; // = null;

    public McpeTelemetryEvent()
    {
        Id = 0x41;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        WriteSignedVarInt(eventData);
        Write(eventType);
        Write(auxData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        eventData = ReadSignedVarInt();
        eventType = ReadByte();
        auxData = ReadBytes(0, true);
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        eventData = default;
        eventType = default;
        auxData = default;
    }
}