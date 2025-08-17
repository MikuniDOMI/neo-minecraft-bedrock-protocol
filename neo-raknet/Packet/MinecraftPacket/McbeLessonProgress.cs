// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     定义了课程进度操作类型。
/// </summary>
public enum LessonAction : byte // uint8 in Go
{
    /// <summary>
    ///     开始课程。
    /// </summary>
    Start = 0,

    /// <summary>
    ///     完成课程。
    /// </summary>
    Complete = 1,

    /// <summary>
    ///     重新开始课程。
    /// </summary>
    Restart = 2
}

/// <summary>
///     LessonProgress 数据包：由服务器发送给客户端，用于通知客户端课程进度的更新。
///     此数据包仅在 Minecraft: Education Edition 版本中有效。
/// </summary>
public class McpeLessonProgress : Packet
{
    /// <summary>
    ///     初始化 McpeLessonProgress 类的新实例。
    /// </summary>
    public McpeLessonProgress()
    {
        Id = 183; // IDLessonProgress
        IsMcpe = true;
    }

    /// <summary>
    ///     Identifier 是正在进行进度更新的课程的标识符。
    /// </summary>
    public string Identifier { get; set; } = string.Empty; // string

    /// <summary>
    ///     Action 是客户端为显示进度而应执行的操作。它是上面 LessonAction 枚举中的一个值。
    /// </summary>
    public LessonAction Action { get; set; } // uint8 -> LessonAction (enum based on byte)

    /// <summary>
    ///     Score 是客户端在显示进度时应使用的分数。
    /// </summary>
    public int Score { get; set; } // int32 -> int

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Action)
        // 将枚举值转换为底层 byte 类型进行写入
        Write((byte)Action);

        // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Score)
        WriteSignedVarInt(Score);

        // void Write(string value) - 对应 Go 的 io.String(&pk.Identifier)
        Write(Identifier);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Action)
        // 读取 byte 值并转换为枚举类型
        Action = (LessonAction)ReadByte();

        // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Score)
        Score = ReadSignedVarInt();

        // string ReadString() - 对应 Go 的 io.String(&pk.Identifier)
        Identifier = ReadString();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Identifier = string.Empty;
        Action = LessonAction.Start; // Reset to default enum value
        Score = 0;
    }
}