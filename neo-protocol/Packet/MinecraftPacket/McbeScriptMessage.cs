// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     ScriptMessage 数据包：用于在客户端和服务器之间传递自定义消息。
///     虽然名称可能暗示此数据包用于已弃用的脚本 API，但它更可能是为 GameTest 框架准备的。
/// </summary>
public class McpeScriptMessage : Packet
{
    /// <summary>
    ///     初始化 McpeScriptMessage 类的新实例。
    /// </summary>
    public McpeScriptMessage()
    {
        Id = 177; // IDScriptMessage
        IsMcpe = true;
    }

    /// <summary>
    ///     Identifier 是消息的标识符，由任一方用来识别发送的消息数据。
    /// </summary>
    public string Identifier { get; set; } = string.Empty; // string

    /// <summary>
    ///     Data 包含消息的数据。
    /// </summary>
    public byte[] Data { get; set; } = new byte[0]; // []byte -> byte[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(string value) - 对应 Go 的 io.String(&pk.Identifier)
        Write(Identifier);

        // void Write(byte[] value) - 对应 Go 的 io.ByteSlice(&pk.Data)
        // methods.txt 中的 Write(byte[]) 用于写入字节数组。
        WriteByteArray(Data);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // string ReadString() - 对应 Go 的 io.String(&pk.Identifier)
        Identifier = ReadString();

        // byte[] ReadBytes(int count, bool slurp) 或 byte[] ReadByteArray(bool slurp) - 对应 Go 的 io.ByteSlice(&pk.Data)
        // Go 的 protocol.IO.ByteSlice 读取剩余的所有字节。
        // C# methods.txt 中有 byte[] ReadByteArray(bool slurp) 和 byte[] ReadBytes(int count, bool slurp)。
        // 为了读取所有剩余的字节（类似 Go 的 ByteSlice 行为），使用 ReadByteArray(true)。
        // slurp=true 模式会读取从当前位置到缓冲区末尾的所有字节。
        Data = ReadByteArray(true); // true for slurp mode
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Identifier = string.Empty;
        Data = new byte[0];
    }
}