// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     DeathInfo 数据包：从服务器发送到客户端，预计在玩家死亡时发送。
///     它包含与玩家死亡相关的信息，这些信息会显示在 v1.19.10 及更高版本的死亡屏幕上。
/// </summary>
public class McpeDeathInfo : Packet
{
    /// <summary>
    ///     初始化 McpeDeathInfo 类的新实例。
    /// </summary>
    public McpeDeathInfo()
    {
        Id = 189; // IDDeathInfo
        IsMcpe = true;
        // Messages is initialized in property declaration
    }

    /// <summary>
    ///     Cause 是玩家死亡的原因，例如 "suffocation"（窒息）或 "suicide"（自杀）。
    /// </summary>
    public string Cause { get; set; } = string.Empty; // string

    /// <summary>
    ///     Messages 是要显示在死亡屏幕上的死亡信息列表。
    /// </summary>
    public string[] Messages { get; set; } = new string[0]; // []string -> string[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.Cause)
        Write(Cause);

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Messages, io.String)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(Messages?.Length ?? 0));
        // 2. 遍历并写入每个 string 元素
        if (Messages != null)
            foreach (var message in Messages)
                // void Write(string value) - 对应 Go 的 io.String (在 FuncSlice 的函数参数中)
                Write(message ?? string.Empty);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.Cause)
        Cause = ReadString();

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Messages, io.String)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 string 元素
        Messages = new string[count];
        for (var i = 0; i < count; i++)
            // string ReadString() - 对应 Go 的 io.String (在 FuncSlice 的函数参数中)
            Messages[i] = ReadString();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Cause = string.Empty;
        Messages = new string[0];
    }
}