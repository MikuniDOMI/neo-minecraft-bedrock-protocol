// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     定义了 Agent 可以执行的操作类型。
/// </summary>
public static class AgentActionType
{
    /// <summary>
    ///     攻击。
    /// </summary>
    public const int Attack = 1; // iota + 1

    /// <summary>
    ///     收集。
    /// </summary>
    public const int Collect = 2;

    /// <summary>
    ///     破坏。
    /// </summary>
    public const int Destroy = 3;

    /// <summary>
    ///     检测红石。
    /// </summary>
    public const int DetectRedstone = 4;

    /// <summary>
    ///     检测障碍物。
    /// </summary>
    public const int DetectObstacle = 5;

    /// <summary>
    ///     丢弃物品。
    /// </summary>
    public const int Drop = 6;

    /// <summary>
    ///     丢弃所有物品。
    /// </summary>
    public const int DropAll = 7;

    /// <summary>
    ///     检查。
    /// </summary>
    public const int Inspect = 8;

    /// <summary>
    ///     检查数据。
    /// </summary>
    public const int InspectData = 9;

    /// <summary>
    ///     检查物品数量。
    /// </summary>
    public const int InspectItemCount = 10;

    /// <summary>
    ///     检查物品详情。
    /// </summary>
    public const int InspectItemDetail = 11;

    /// <summary>
    ///     检查物品空间。
    /// </summary>
    public const int InspectItemSpace = 12;

    /// <summary>
    ///     交互。
    /// </summary>
    public const int Interact = 13;

    /// <summary>
    ///     移动。
    /// </summary>
    public const int Move = 14;

    /// <summary>
    ///     放置方块。
    /// </summary>
    public const int PlaceBlock = 15;

    /// <summary>
    ///     耕地。
    /// </summary>
    public const int Till = 16;

    /// <summary>
    ///     转移物品到。
    /// </summary>
    public const int TransferItemTo = 17;

    /// <summary>
    ///     转向。
    /// </summary>
    public const int Turn = 18;
}

/// <summary>
///     AgentAction 数据包：这是一个 Education Edition 数据包，
///     由服务器发送到客户端，用于返回先前请求操作的响应。
/// </summary>
public class McpeAgentAction : Packet
{
    /// <summary>
    ///     初始化 McpeAgentAction 类的新实例。
    /// </summary>
    public McpeAgentAction()
    {
        Id = 181; // IDAgentAction
        IsMcpe = true;
    }

    /// <summary>
    ///     Identifier 是初始操作中引用的 JSON 标识符。
    /// </summary>
    public string Identifier { get; set; } = string.Empty; // string

    /// <summary>
    ///     Action 表示被请求的操作类型。它是上面 AgentActionType 常量中的一个值。
    /// </summary>
    public int Action { get; set; } // int32 -> int

    /// <summary>
    ///     Response 是一个包含操作响应的 JSON 字符串（在 Go 中为 []byte）。
    /// </summary>
    public byte[] Response { get; set; } = new byte[0]; // []byte -> byte[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.Identifier)
        Write(Identifier);

        // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Action)
        WriteSignedVarInt(Action);

        // void Write(byte[] value) - 对应 Go 的 io.ByteArray(&pk.Response)
        // 注意：Go 代码中是 io.ByteArrary，但标准库通常是 io.Bytes 或类似。
        // 在 C# methods.txt 中，Write(byte[]) 存在，用于写入字节数组。
        WriteByteArray(Response);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.Identifier)
        Identifier = ReadString();

        // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Action)
        Action = ReadSignedVarInt();

        // byte[] ReadBytes(int count, bool slurp) 或 byte[] ReadByteArray(bool slurp) - 对应 Go 的 io.ByteArray(&pk.Response)
        // Go 的 io.ByteArray 通常读取剩余的所有字节或直到分隔符。
        // C# methods.txt 中有 byte[] ReadByteArray(bool slurp) 和 byte[] ReadBytes(int count, bool slurp)。
        // 如果 Response 占据数据包的剩余部分，ReadByteArray(true) 或 ReadBytes(0, true) 可能是合适的。
        // 但更常见的是，如果它是变长的且是最后的字段，或者有长度前缀。
        // 由于 Go 代码简单地使用 io.ByteArray，我们假设它读取所有剩余的字节。
        // methods.txt 中的 ReadByteArray(bool slurp) 最符合这个行为，slurp=true 读取所有剩余内容。
        Response = ReadByteArray(true); // true for slurp mode, reads all remaining bytes
        // 或者，如果知道确切长度，可以使用 ReadBytes(length, false)
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Identifier = string.Empty;
        Action = 0; // Or AgentActionType.Attack as default?
        Response = new byte[0];
    }
}