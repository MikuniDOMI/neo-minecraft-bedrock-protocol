using System.Numerics;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeLevelEvent : Packet
{
    public int data; // = null;

    public int     eventId; // = null;
    public Vector3 position; // = null;

    public McpeLevelEvent()
    {
        Id = 0x19;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(eventId);
        Write(position);
        WriteSignedVarInt(data);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        eventId = ReadSignedVarInt();
        position = ReadVector3();
        data = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        eventId = default;
        position = default(Vector3);
        data = default;
    }
}