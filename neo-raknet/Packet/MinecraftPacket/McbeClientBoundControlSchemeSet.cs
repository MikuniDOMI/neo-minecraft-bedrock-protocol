// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     Represents the different control schemes available.
/// </summary>
public enum ControlSchemeType : byte
{
    /// <summary>
    ///     默认行为，当客户端处于自定义相机时无法设置。
    /// </summary>
    LockedPlayerRelativeStrafe = 0,

    /// <summary>
    ///     使移动相对于相机的变换，客户端的旋转相对于客户端的移动。
    /// </summary>
    CameraRelative = 1,

    /// <summary>
    ///     使移动相对于相机的变换，客户端的旋转被锁定。
    /// </summary>
    CameraRelativeStrafe = 2,

    /// <summary>
    ///     使移动相对于玩家的变换，意味着按住左/右会使玩家转圈。
    /// </summary>
    PlayerRelative = 3,

    /// <summary>
    ///     使移动与默认行为相同，但可以在自定义相机中使用。
    /// </summary>
    PlayerRelativeStrafe = 4
}

/// <summary>
///     ClientBoundControlSchemeSet 数据包：由服务器在客户端请求或使用原版 /controlscheme 命令时发送。
///     它用于设置客户端的控制方案，通常与自定义相机结合使用。
/// </summary>
public class McpeClientBoundControlSchemeSet : Packet
{
    /// <summary>
    ///     初始化 McpeClientBoundControlSchemeSet 类的新实例。
    /// </summary>
    public McpeClientBoundControlSchemeSet()
    {
        Id = 327; // IDClientBoundControlSchemeSet (根据你之前提供的 ID 列表)
        IsMcpe = true;
    }

    /// <summary>
    ///     ControlScheme 是客户端应使用的控制方案。
    /// </summary>
    public byte ControlScheme { get; set; } // uint8 -> byte

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.ControlScheme)
        Write(ControlScheme);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.ControlScheme)
        ControlScheme = ReadByte();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        ControlScheme = 0;
    }
}