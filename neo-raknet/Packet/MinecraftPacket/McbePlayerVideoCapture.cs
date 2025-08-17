// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     Defines the actions that can be performed with player video capture.
/// </summary>
public enum PlayerVideoCaptureAction : byte
{
    /// <summary>
    ///     停止视频捕获。
    /// </summary>
    Stop = 0,

    /// <summary>
    ///     开始视频捕获。
    /// </summary>
    Start = 1
}

/// <summary>
///     PlayerVideoCapture 数据包：由服务器发送，用于为玩家启动或停止视频录制。
///     此数据包仅在开发版本中有效，在零售版本中无效。
///     录制时，客户端会将单个帧保存到 '/LocalCache/minecraftpe'，格式如下所述。
/// </summary>
public class McpePlayerVideoCapture : Packet
{
    /// <summary>
    ///     初始化 McpePlayerVideoCapture 类的新实例。
    /// </summary>
    public McpePlayerVideoCapture()
    {
        Id = 324; // IDPlayerVideoCapture
        IsMcpe = true;
    }

    /// <summary>
    ///     Action 是要对视频捕获执行的操作。它是 PlayerVideoCaptureAction 枚举之一。
    /// </summary>
    public PlayerVideoCaptureAction Action { get; set; } // byte -> PlayerVideoCaptureAction

    /// <summary>
    ///     FrameRate 是视频录制的帧率。仅当 Action 为 PlayerVideoCaptureAction.Start 时使用。
    ///     更高的帧率会导致录制更多帧，但也会明显增加延迟。
    /// </summary>
    public int FrameRate { get; set; } // int32 -> int

    /// <summary>
    ///     FilePrefix 是用于保存帧的文件名前缀。
    ///     帧将被保存为 'FilePrefix%d.png' 格式，其中 %d 是帧索引。
    /// </summary>
    public string FilePrefix { get; set; } = string.Empty; // string

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Action)
        // 将枚举值转换为底层 byte 类型进行写入
        Write((byte)Action);

        if (Action == PlayerVideoCaptureAction.Start)
        {
            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.FrameRate)
            // methods.txt 中的 Write(int, bool) 用于 int32。假设小端序 (false)。
            Write(FrameRate);

            // void Write(string value) - 对应 Go 的 io.String(&pk.FilePrefix)
            Write(FilePrefix);
        }
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Action)
        // 读取 byte 值并转换为枚举类型
        Action = (PlayerVideoCaptureAction)ReadByte();

        // 重置条件字段为默认值，以防数据包对象被重用且当前 Action 不需要它们。
        FrameRate = 0;
        FilePrefix = string.Empty;

        if (Action == PlayerVideoCaptureAction.Start)
        {
            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.FrameRate)
            // methods.txt 中的 ReadInt(bool) 用于读取 int32。假设小端序 (false)。
            FrameRate = ReadInt();

            // string ReadString() - 对应 Go 的 io.String(&pk.FilePrefix)
            FilePrefix = ReadString();
        }
        // 如果 Action 不是 PlayerVideoCaptureAction.Start，则 FrameRate 和 FilePrefix 不会被读取，
        // 并保持它们在 Decode 开始时设置的默认值或之前可能存在的值。
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Action = PlayerVideoCaptureAction.Stop; // Reset to default enum value
        FrameRate = 0;
        FilePrefix = string.Empty;
    }
}