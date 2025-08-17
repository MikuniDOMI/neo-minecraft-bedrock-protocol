// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     CurrentStructureFeature 数据包：由服务器发送，用于告知客户端玩家当前所在的结构特征名称。
/// </summary>
public class McpeCurrentStructureFeature : Packet
{
    /// <summary>
    ///     初始化 McpeCurrentStructureFeature 类的新实例。
    /// </summary>
    public McpeCurrentStructureFeature()
    {
        Id = 314; // IDCurrentStructureFeature
        IsMcpe = true;
    }

    /// <summary>
    ///     CurrentFeature 是玩家当前所在的结构特征的标识符。
    ///     如果玩家没有处于任何结构特征中，则此字段为空。
    /// </summary>
    public string CurrentFeature { get; set; } = string.Empty; // string

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.CurrentFeature)
        Write(CurrentFeature);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.CurrentFeature)
        CurrentFeature = ReadString();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        CurrentFeature = string.Empty;
    }
}