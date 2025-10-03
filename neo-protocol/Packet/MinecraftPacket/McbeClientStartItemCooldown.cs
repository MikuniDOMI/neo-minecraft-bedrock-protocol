// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     ClientStartItemCooldown 数据包：由服务器发送到客户端，用于启动某个物品的冷却时间。
/// </summary>
public class McpeClientStartItemCooldown : Packet
{
    /// <summary>
    ///     初始化 McpeClientStartItemCooldown 类的新实例。
    /// </summary>
    public McpeClientStartItemCooldown()
    {
        Id = 176; // IDClientStartItemCooldown
        IsMcpe = true;
    }

    /// <summary>
    ///     Category 是要开始冷却的物品的类别。
    /// </summary>
    public string Category { get; set; } = string.Empty; // string

    /// <summary>
    ///     Duration 是冷却时间应持续的刻数 (ticks)。
    /// </summary>
    public int Duration { get; set; } // int32 -> int

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.Category)
        Write(Category);

        // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Duration)
        WriteSignedVarInt(Duration);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.Category)
        Category = ReadString();

        // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Duration)
        Duration = ReadSignedVarInt();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Category = string.Empty;
        Duration = 0;
    }
}