using System.Numerics;
// Example for Vector2 (mgl32.Vec2) - ADJUST BASED ON YOUR PROJECT

// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     定义相机瞄准辅助的操作类型。
/// </summary>
public enum CameraAimAssistAction : byte
{
    /// <summary>
    ///     设置瞄准辅助配置。
    /// </summary>
    Set = 0,

    /// <summary>
    ///     清除瞄准辅助配置。
    /// </summary>
    Clear = 1
}

/// <summary>
///     CameraAimAssist 数据包：由服务器发送给客户端，用于为客户端的相机设置瞄准辅助。
/// </summary>
public class McpeCameraAimAssist : Packet
{
    /// <summary>
    ///     初始化 McpeCameraAimAssist 类的新实例。
    /// </summary>
    public McpeCameraAimAssist()
    {
        Id = 316; // IDCameraAimAssist (根据你之前提供的 ID 列表)
        IsMcpe = true;
    }
    // --- Constants for TargetMode (assuming these exist in your protocol) ---
    // These would typically be defined elsewhere, e.g., in a static class or enum.
    // Placeholder values, replace with actual protocol constants if different.
    // public const byte AimAssistTargetModeAngle = 0;
    // public const byte AimAssistTargetModeDistance = 1;


    /// <summary>
    ///     Preset 是先前在 CameraAimAssistPresets 数据包中定义的预设的 ID。
    /// </summary>
    public string Preset { get; set; } = string.Empty; // string

    /// <summary>
    ///     Angle 是围绕玩家光标的最大角度，如果 TargetMode 设置为 AimAssistTargetModeAngle，
    ///     瞄准辅助应在此范围内检查目标。 (mgl32.Vec2 -> Vector2)
    /// </summary>
    public Vector2 Angle { get; set; } // mgl32.Vec2 -> Vector2

    /// <summary>
    ///     Distance 是从玩家光标开始检查目标的最大距离，如果 TargetMode 设置为 AimAssistTargetModeDistance。
    /// </summary>
    public float Distance { get; set; } // float32 -> float

    /// <summary>
    ///     TargetMode 是相机用于检测目标的模式。目前是 AimAssistTargetModeAngle 或 AimAssistTargetModeDistance 之一。
    /// </summary>
    public byte TargetMode { get; set; } // uint8 -> byte

    /// <summary>
    ///     Action 是应针对瞄准辅助执行的操作。它是上面的常量之一。
    /// </summary>
    public CameraAimAssistAction Action { get; set; } // uint8 -> CameraAimAssistAction

    /// <summary>
    ///     ShowDebugRender 指定是否应显示调试渲染。
    /// </summary>
    public bool ShowDebugRender { get; set; } // bool

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.Preset)
        Write(Preset);

        // void Write(Vector2 vec) - 对应 Go 的 io.Vec2(&pk.Angle)
        Write(Angle);

        // void Write(float value) - 对应 Go 的 io.Float32(&pk.Distance)
        Write(Distance);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.TargetMode)
        Write(TargetMode);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Action)
        // 将枚举值转换为底层 byte 类型进行写入
        Write((byte)Action);

        // void Write(bool value) - 对应 Go 的 io.Bool(&pk.ShowDebugRender)
        Write(ShowDebugRender);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.Preset)
        Preset = ReadString();

        // Vector2 ReadVector2() - 对应 Go 的 io.Vec2(&pk.Angle)
        Angle = ReadVector2();

        // float ReadFloat() - 对应 Go 的 io.Float32(&pk.Distance)
        Distance = ReadFloat();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.TargetMode)
        TargetMode = ReadByte();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Action)
        // 读取 byte 值并转换为枚举类型
        Action = (CameraAimAssistAction)ReadByte();

        // bool ReadBool() - 对应 Go 的 io.Bool(&pk.ShowDebugRender)
        ShowDebugRender = ReadBool();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Preset = string.Empty;
        Angle = Vector2.Zero;
        Distance = 0.0f;
        TargetMode = 0; // Or a default constant if available
        Action = CameraAimAssistAction.Set; // Reset to default enum value
        ShowDebugRender = false;
    }
}