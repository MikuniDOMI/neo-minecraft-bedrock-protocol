using System.Numerics;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeCorrectPlayerMovement : Packet
{
    public bool OnGround; // = null;
    public Vector3 Postition; // = null;
    public long Tick; // = null;

    public byte Type; // = null;
    public Vector3 Velocity; // = null;

    public McpeCorrectPlayerMovement()
    {
        Id = 0xA1;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(Type);
        Write(Postition);
        Write(Velocity);
        Write(OnGround);
        WriteUnsignedVarLong(Tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        Type = ReadByte();
        Postition = ReadVector3();
        Velocity = ReadVector3();
        OnGround = ReadBool();
        Tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        Type = default;
        Postition = default;
        Velocity = default;
        OnGround = default;
        Tick = default;
    }
}