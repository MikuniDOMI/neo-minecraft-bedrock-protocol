// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     定义客户端相机瞄准辅助的操作类型。
/// </summary>
public enum ClientCameraAimAssistAction : byte
{
    /// <summary>
    ///     设置瞄准辅助预设。
    /// </summary>
    Set = 0,

    /// <summary>
    ///     清除瞄准辅助预设。
    /// </summary>
    Clear = 1
}

/// <summary>
///     ClientCameraAimAssist 数据包：由服务器发送，用于设置或清除客户端的相机瞄准辅助。
/// </summary>
public class McpeClientCameraAimAssist : Packet
{
    /// <summary>
    ///     初始化 McpeClientCameraAimAssist 类的新实例。
    /// </summary>
    public McpeClientCameraAimAssist()
    {
        Id = 321; // IDClientCameraAimAssist
        IsMcpe = true;
    }

    /// <summary>
    ///     PresetID 是要使用的预设的标识符，该预设先前在 CameraAimAssistPresets 数据包中定义。
    /// </summary>
    public string PresetID { get; set; } = string.Empty; // string

    /// <summary>
    ///     Action 是要对瞄准辅助执行的操作。它是 ClientCameraAimAssistAction 枚举之一。
    /// </summary>
    public ClientCameraAimAssistAction Action { get; set; } // byte -> ClientCameraAimAssistAction

    /// <summary>
    ///     AllowAimAssist 指定客户端是否可以使用瞄准辅助。
    /// </summary>
    public bool AllowAimAssist { get; set; } // bool

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.PresetID)
        Write(PresetID);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Action)
        // 将枚举值转换为底层 byte 类型进行写入
        Write((byte)Action);

        // void Write(bool value) - 对应 Go 的 io.Bool(&pk.AllowAimAssist)
        Write(AllowAimAssist);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.PresetID)
        PresetID = ReadString();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Action)
        // 读取 byte 值并转换为枚举类型
        Action = (ClientCameraAimAssistAction)ReadByte();

        // bool ReadBool() - 对应 Go 的 io.Bool(&pk.AllowAimAssist)
        AllowAimAssist = ReadBool();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        PresetID = string.Empty;
        Action = ClientCameraAimAssistAction.Set; // Reset to default enum value
        AllowAimAssist = false;
    }
}