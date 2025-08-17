// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     定义了 CodeBuilder 操作类型。
/// </summary>
public static class CodeBuilderOperation
{
    /// <summary>
    ///     无操作。
    /// </summary>
    public const byte None = 0; // iota

    /// <summary>
    ///     获取操作。
    /// </summary>
    public const byte Get = 1;

    /// <summary>
    ///     设置操作。
    /// </summary>
    public const byte Set = 2;

    /// <summary>
    ///     重置操作。
    /// </summary>
    public const byte Reset = 3;
}

/// <summary>
///     定义了 CodeBuilder 操作类别。
/// </summary>
public static class CodeBuilderCategory
{
    /// <summary>
    ///     无类别。
    /// </summary>
    public const byte None = 0; // iota

    /// <summary>
    ///     状态类别。
    /// </summary>
    public const byte Status = 1;

    /// <summary>
    ///     实例化类别。
    /// </summary>
    public const byte Instantiation = 2;
}

/// <summary>
///     定义了 CodeBuilder 状态。
/// </summary>
public static class CodeBuilderStatus
{
    /// <summary>
    ///     无状态。
    /// </summary>
    public const byte None = 0; // iota

    /// <summary>
    ///     尚未开始。
    /// </summary>
    public const byte NotStarted = 1;

    /// <summary>
    ///     进行中。
    /// </summary>
    public const byte InProgress = 2;

    /// <summary>
    ///     已暂停。
    /// </summary>
    public const byte Paused = 3;

    /// <summary>
    ///     错误。
    /// </summary>
    public const byte Error = 4;

    /// <summary>
    ///     成功。
    /// </summary>
    public const byte Succeeded = 5;
}

/// <summary>
///     CodeBuilderSource 数据包：这是一个 Education Edition 数据包，
///     由客户端发送到服务器，用于使用代码生成器运行操作。
/// </summary>
public class McpeCodeBuilderSource : Packet
{
    /// <summary>
    ///     初始化 McpeCodeBuilderSource 类的新实例。
    /// </summary>
    public McpeCodeBuilderSource()
    {
        Id = 178; // IDCodeBuilderSource
        IsMcpe = true;
    }

    /// <summary>
    ///     Operation 用于区分所执行的操作。它始终是上面列出的常量之一。
    /// </summary>
    public byte Operation { get; set; } // uint8 -> byte

    /// <summary>
    ///     Category 用于区分所执行操作的类别。它始终是上面列出的常量之一。
    /// </summary>
    public byte Category { get; set; } // uint8 -> byte

    /// <summary>
    ///     CodeStatus 是代码生成器的状态。它始终是上面列出的常量之一。
    /// </summary>
    public byte CodeStatus { get; set; } // uint8 -> byte

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Operation)
        Write(Operation);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Category)
        Write(Category);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.CodeStatus)
        Write(CodeStatus);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Operation)
        Operation = ReadByte();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Category)
        Category = ReadByte();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.CodeStatus)
        CodeStatus = ReadByte();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Operation = CodeBuilderOperation.None;
        Category = CodeBuilderCategory.None;
        CodeStatus = CodeBuilderStatus.None;
    }
}