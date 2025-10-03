// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     ServerStats 数据包：从服务器发送到客户端，用于更新客户端的服务器统计信息。
///     它纯粹用于遥测。
/// </summary>
public class McpeServerStats : Packet
{
    /// <summary>
    ///     初始化 McpeServerStats 类的新实例。
    /// </summary>
    public McpeServerStats()
    {
        Id = 192; // IDServerStats
        IsMcpe = true;
    }

    /// <summary>
    ///     ServerTime ...
    /// </summary>
    public float ServerTime { get; set; } // float32 -> float

    /// <summary>
    ///     NetworkTime ...
    /// </summary>
    public float NetworkTime { get; set; } // float32 -> float

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(float value) - 对应 Go 的 io.Float32(&pk.ServerTime)
        Write(ServerTime);

        // void Write(float value) - 对应 Go 的 io.Float32(&pk.NetworkTime)
        Write(NetworkTime);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // float ReadFloat() - 对应 Go 的 io.Float32(&pk.ServerTime)
        ServerTime = ReadFloat();

        // float ReadFloat() - 对应 Go 的 io.Float32(&pk.NetworkTime)
        NetworkTime = ReadFloat();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        ServerTime = 0.0f;
        NetworkTime = 0.0f;
    }
}