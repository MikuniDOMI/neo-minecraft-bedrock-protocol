using neo_raknet.Packet.MinecraftStruct.NBT;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpePositionTrackingDBServerBroadcast : Packet
{
    /// <summary>
    ///     定义位置追踪数据库广播操作类型的枚举。
    /// </summary>
    public enum Action
    {
        Update = 0, // 更新：成功找到并返回位置
        Destroy = 1, // 销毁：该位置的方块（如指南针）已被破坏
        NotFound = 2 // 未找到：该位置没有对应的追踪数据
    }

    /// <summary>
    ///     构造函数，设置数据包 ID 并标记为 MCPE 包。
    /// </summary>
    public McpePositionTrackingDBServerBroadcast()
    {
        Id = 153; // IDPositionTrackingDBServerBroadcast
        IsMcpe = true; // 标记为MCPE 协议包
    }

    /// <summary>
    ///     广播操作，指定位置追踪数据库响应的状态。
    /// </summary>
    public byte BroadcastAction { get; set; }

    /// <summary>
    ///     此数据包响应的 PositionTrackingDBClientRequest 数据包的 ID。
    /// </summary>
    public int TrackingID { get; set; }

    /// <summary>
    ///     从位置追踪数据库检索到的数据，为一个 NBT 标签。
    /// </summary>
    public Nbt Payload { get; set; }

    /// <summary>
    ///     将数据包编码为字节流。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket(); // 调用基类的 EncodePacket 方法

        Write(BroadcastAction);
        WriteSignedVarInt(TrackingID);

        // 使用 Write(Nbt nbt) 方法写入 NBT 数据
        Write(Payload ?? new Nbt()); // 如果 Payload 为 null，写入一个空的 NBT（通常是 TAG_End）
    }

    /// <summary>
    ///     从字节流中解码数据包。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket(); // 调用基类的 DecodePacket 方法

        BroadcastAction = ReadByte();
        TrackingID = ReadSignedVarInt();

        // 使用 ReadNbt() 方法读取 NBT 数据，它会自动处理网络小端序 (NetworkLittleEndian)
        Payload = ReadNbt();
    }
}