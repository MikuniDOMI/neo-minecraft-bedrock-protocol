namespace neo_protocol.Packet.MinecraftPacket;

public class McpeMovePlayer : Packet
{
    public enum Mode
    {
        Normal = 0,
        Reset = 1,
        Teleport = 2,
        Rotation = 3
    }

    public enum Teleportcause
    {
        Unknown = 0,
        Projectile = 1,
        ChorusFruit = 2,
        Command = 3,
        Behavior = 4,
        Count = 5
    }

    public float headYaw; // = null;
    public byte mode; // = null;
    public bool onGround; // = null;
    public long otherRuntimeEntityId; // = null;
    public float pitch; // = null;

    public long runtimeEntityId; // = null;
    public long tick;
    public float x; // = null;
    public float y; // = null;
    public float yaw; // = null;
    public float z; // = null;

    public McpeMovePlayer()
    {
        Id = 0x13;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(x);
        Write(y);
        Write(z);
        Write(pitch);
        Write(yaw);
        Write(headYaw);
        Write(mode);
        Write(onGround);
        WriteUnsignedVarLong(otherRuntimeEntityId);
        if (mode == 2)
        {
            Write(0);
            Write(0);
        }

        WriteUnsignedVarLong(tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        x = ReadFloat();
        y = ReadFloat();
        z = ReadFloat();
        pitch = ReadFloat();
        yaw = ReadFloat();
        headYaw = ReadFloat();
        mode = ReadByte();
        onGround = ReadBool();
        otherRuntimeEntityId = ReadUnsignedVarLong();
        if (mode == 2)
        {
            ReadInt();
            ReadInt();
        }

        tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        x = default;
        y = default;
        z = default;
        pitch = default;
        yaw = default;
        headYaw = default;
        mode = default;
        onGround = default;
        otherRuntimeEntityId = default;
    }
}