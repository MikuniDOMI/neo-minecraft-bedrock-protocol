using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeMoveEntityDelta : Packet
{
    public const int HasX     = 0x01;
    public const int HasY     = 0x02;
    public const int HasZ     = 0x04;
    public const int HasRotX  = 0x08;
    public const int HasRotY  = 0x10;
    public const int HasRotZ  = 0x20;
    public const int OnGround = 0x40;

    private float _dX;
    private float _dY;
    private float _dZ;

    public PlayerLocation currentPosition; // = null;
    public ushort         flags; // = null;
    public bool           isOnGround; // = null;
    public PlayerLocation prevSentPosition; // = null;

    public long runtimeEntityId; // = null;

    public McpeMoveEntityDelta()
    {
        Id = 0x6f;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        var shouldSend = flags != 0 || SetFlags();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(flags);

        // write the values
        if ((flags & 0x1) != 0) Write(_dX);
        if ((flags & 0x2) != 0) Write(_dY);
        if ((flags & 0x4) != 0) Write(_dZ);

        var d = 256f / 360f;
        if ((flags & 0x8) != 0) Write((byte)Math.Round(currentPosition.Pitch * d)); // 256/360

        if ((flags & 0x10) != 0) Write((byte)Math.Round(currentPosition.Yaw * d)); // 256/360

        if ((flags & 0x20) != 0) Write((byte)Math.Round(currentPosition.HeadYaw * d)); // 256/360
    }

    public bool SetFlags()
    {
        flags = 0;

        if (currentPosition == null || prevSentPosition == null) return false;

        _dX = currentPosition.X;
        _dY = currentPosition.Y;
        _dZ = currentPosition.Z;

        if (_dX != 0) flags |= HasX;
        if (_dY != 0) flags |= HasY;
        if (_dZ != 0) flags |= HasZ;

        if (prevSentPosition.Pitch != currentPosition.Pitch) flags |= HasRotX;
        if (prevSentPosition.Yaw != currentPosition.Yaw) flags |= HasRotY;
        if (prevSentPosition.HeadYaw != currentPosition.HeadYaw) flags |= HasRotZ;

        if (flags != 0 && isOnGround) flags |= OnGround;

        return flags != 0;
    }

    public PlayerLocation GetCurrentPosition(PlayerLocation previousPosition)
    {
        var pos = previousPosition;
        pos.X = (flags & HasX) != 0 ? currentPosition.X : previousPosition.X;
        pos.Y = (flags & HasY) != 0 ? currentPosition.Y : previousPosition.Y;
        pos.Z = (flags & HasZ) != 0 ? currentPosition.Z : previousPosition.Z;

        pos.HeadYaw = (flags & HasRotZ) != 0 ? -currentPosition.HeadYaw : previousPosition.HeadYaw;
        pos.Yaw = (flags & HasRotY) != 0 ? -currentPosition.Yaw : previousPosition.Yaw;
        pos.Pitch = (flags & HasRotX) != 0 ? -currentPosition.Pitch : previousPosition.Pitch;

        //pos.OnGround = this.isOnGround;
        return pos;
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        flags = ReadUshort();

        currentPosition = new PlayerLocation();

        if ((flags & HasX) != 0) currentPosition.X = ReadFloat();
        if ((flags & HasY) != 0) currentPosition.Y = ReadFloat();
        if ((flags & HasZ) != 0) currentPosition.Z = ReadFloat();

        var d = 1f / (256f / 360f);
        if ((flags & HasRotX) != 0) currentPosition.Pitch = ReadByte() * d;

        if ((flags & HasRotY) != 0) currentPosition.Yaw = ReadByte() * d;

        if ((flags & HasRotZ) != 0) currentPosition.HeadYaw = ReadByte() * d;

        if ((flags & OnGround) != 0) isOnGround = true;
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        flags = default;
    }
}