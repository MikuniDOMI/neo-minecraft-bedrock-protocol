namespace neo_raknet.Packet.MinecraftPacket;

public class McpeCameraShake : Packet
{
    /// <summary>
    ///     定义相机抖动操作的枚举。
    /// </summary>
    public enum ShakeAction : byte
    {
        Add = 0, // 添加抖动效果
        Stop = 1 // 停止抖动效果
    }

    /// <summary>
    ///     定义相机抖动类型的枚举。
    /// </summary>
    public enum ShakeType : byte
    {
        Positional = 0, // 位置抖动
        Rotational = 1 // 旋转抖动
    }

    /// <summary>
    ///     构造函数，设置数据包 ID 并标记为 MCPE 包。
    /// </summary>
    public McpeCameraShake()
    {
        Id = 158; // IDCameraShake
        IsMcpe = true; // 标记为 MCPE 协议包
    }

    /// <summary>
    ///     抖动的强度。客户端将此值限制为 4，因此更高的值可能无效。
    /// </summary>
    public float Intensity { get; set; }

    /// <summary>
    ///     相机抖动的持续时间（秒）。
    /// </summary>
    public float Duration { get; set; }

    /// <summary>
    ///     抖动类型，影响游戏中抖动的视觉效果。
    /// </summary>
    public ShakeType Type { get; set; }

    /// <summary>
    ///     要执行的操作，用于添加或停止客户端抖动。
    /// </summary>
    public ShakeAction Action { get; set; }

    /// <summary>
    ///     将数据包编码为字节流。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket(); // 调用基类的 EncodePacket 方法

        Write(Intensity);
        Write(Duration);
        Write((byte)Type);
        Write((byte)Action);
    }

    /// <summary>
    ///     从字节流中解码数据包。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket(); // 调用基类的 DecodePacket 方法

        Intensity = ReadFloat();
        Duration = ReadFloat();
        Type = (ShakeType)ReadByte();
        Action = (ShakeAction)ReadByte();
    }
}