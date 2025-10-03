using System.Numerics;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeSetEntityMotion : Packet
{
    public long runtimeEntityId; // = null;
    public long tick; // = null;
    public Vector3 velocity; // = null;

    public McpeSetEntityMotion()
    {
        Id = 0x28;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(velocity);
        WriteUnsignedVarLong(tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        velocity = ReadVector3();
        tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        velocity = default;
        tick = default;
    }
}