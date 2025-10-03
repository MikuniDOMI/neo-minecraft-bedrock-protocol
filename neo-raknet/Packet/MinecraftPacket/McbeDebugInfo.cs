namespace neo_protocol.Packet.MinecraftPacket;

public class McpeDebugInfo : Packet
{
    /// <summary>
    ///     构造函数，设置数据包 ID 并标记为 MCPE 包。
    /// </summary>
    public McpeDebugInfo()
    {
        Id = 155; // IDDebugInfo
        IsMcpe = true; // 标记为 MCPE 协议包
    }

    /// <summary>
    ///     该数据包发送给的玩家的唯一 ID。
    /// </summary>
    public long PlayerUniqueID { get; set; }

    /// <summary>
    ///     调试数据。
    /// </summary>
    public byte[] Data { get; set; } = new byte[0];

    /// <summary>
    ///     将数据包编码为字节流。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket(); // 调用基类的 EncodePacket 方法

        WriteSignedVarLong(PlayerUniqueID);
        WriteByteArray(Data);
    }

    /// <summary>
    ///     从字节流中解码数据包。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket(); // 调用基类的 DecodePacket 方法

        PlayerUniqueID = ReadSignedVarLong();
        Data = ReadByteArray(); // 根据 methods.txt，ReadByteArray(bool slurp)
    }
}