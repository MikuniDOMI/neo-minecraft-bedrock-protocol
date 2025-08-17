// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     ClientBoundCloseForm 数据包：由服务器发送，用于清除客户端的整个表单堆栈。
///     这意味着当前打开的所有表单都将被关闭。这不会影响背包和其他容器。
/// </summary>
public class McpeClientBoundCloseForm : Packet
{
    /// <summary>
    ///     初始化 McpeClientBoundCloseForm 类的新实例。
    /// </summary>
    public McpeClientBoundCloseForm()
    {
        Id = 310; // IDClientBoundCloseForm
        IsMcpe = true;
    }

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();
        // 此数据包没有有效载荷，因此不需要写入任何额外数据。
        // 对应 Go 的 Marshal 方法体为空。
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();
        // 此数据包没有有效载荷，因此不需要读取任何额外数据。
        // 对应 Go 的 Marshal 方法体为空。
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        // 此数据包没有字段需要重置。
    }
}