// Assuming base Packet class is here or adjust accordingly
// Assuming your Optional<T> type is available in this scope or a referenced namespace

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     Represents the different graphics modes available to the client.
/// </summary>
public enum GraphicsModeType : byte
{
    /// <summary>
    ///     简单图形模式。
    /// </summary>
    Simple = 0,

    /// <summary>
    ///     精美图形模式。
    /// </summary>
    Fancy = 1,

    /// <summary>
    ///     高级图形模式。
    /// </summary>
    Advanced = 2,

    /// <summary>
    ///     光线追踪图形模式。
    /// </summary>
    RayTraced = 3
}

/// <summary>
///     UpdateClientOptions 数据包：当客户端的某些选项（例如图形模式）更新时，由客户端发送。
/// </summary>
public class McpeUpdateClientOptions : Packet
{
    /// <summary>
    ///     初始化 McpeUpdateClientOptions 类的新实例。
    /// </summary>
    public McpeUpdateClientOptions()
    {
        Id = 323; // IDUpdateClientOptions
        IsMcpe = true;
        // GraphicsMode is initialized to its default (unset) state by Optional<T>
    }

    /// <summary>
    ///     GraphicsMode 是客户端正在使用的图形模式。它是 GraphicsModeType 枚举之一。
    /// </summary>
    public Optional<byte> GraphicsMode { get; set; } // protocol.Optional[byte] -> Optional<byte>

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 显式写入 Optional<byte> GraphicsMode
        // 1. 写入是否存在 (bool)
        Write(GraphicsMode.HasValue);
        // 2. 如果存在，则写入实际值 (byte)
        if (GraphicsMode.HasValue) Write(GraphicsMode.Value);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 显式读取 Optional<byte> GraphicsMode
        // 1. 读取是否存在 (bool)
        var hasGraphicsMode = ReadBool();
        // 2. 如果存在，则读取实际值 (byte) 并创建 Optional
        if (hasGraphicsMode)
        {
            var graphicsModeValue = ReadByte();
            GraphicsMode = new Optional<byte>(graphicsModeValue);
        }
        // 如果 ReadBool() 返回 false, GraphicsMode 保持其默认的未设置状态
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        GraphicsMode = new Optional<byte>(); // Reset to default (unset) state
    }
}

// --- 假设这是你的 Optional<T> 类定义 ---
// (你应该已经有了这个定义)
/*
public class Optional<T>
{
    public bool HasValue;
    public T Value;

    public Optional() { }

    public Optional(T value)
    {
        HasValue = true;
        Value = value;
    }
}
*/