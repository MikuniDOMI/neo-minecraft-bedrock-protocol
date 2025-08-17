// Assuming base Packet class is here or adjust accordingly
// Assuming GenerationFeature is defined in your project, e.g.:
// using neo_raknet.Protocol;

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     GenerationFeature 代表一个世界生成特征。
/// </summary>
public class GenerationFeature
{
    /// <summary>
    ///     Name 是特征的名称。
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     JSON 是编码后的 JSON 数据，用于指导客户端如何生成该特征。
    /// </summary>
    public byte[] JSON { get; set; } = new byte[0];
}

/// <summary>
///     FeatureRegistry 数据包：用于通知客户端服务器当前正在使用的世 界生成特征。
///     这与 v1.19.20 中引入的客户端世界生成系统结合使用，
///     允许客户端在不依赖服务器的情况下完全生成世界的区块。
/// </summary>
public class McpeFeatureRegistry : Packet
{
    /// <summary>
    ///     初始化 McpeFeatureRegistry 类的新实例。
    /// </summary>
    public McpeFeatureRegistry()
    {
        Id = 191; // IDFeatureRegistry
        IsMcpe = true;
        // Features is initialized in property declaration
    }

    /// <summary>
    ///     Features 是所有已注册的世界生成特征的列表。
    /// </summary>
    public GenerationFeature[] Features { get; set; } =
        new GenerationFeature[0]; // []protocol.GenerationFeature -> GenerationFeature[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.Features)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(Features?.Length ?? 0));
        // 2. 遍历并写入每个 GenerationFeature 元素
        if (Features != null)
            foreach (var feature in Features)
            {
                // methods.txt 中没有直接写入 GenerationFeature 的方法，
                // 因此需要在此类中手动序列化其字段。
                Write(feature.Name ?? string.Empty); // Write string
                WriteByteArray(feature.JSON ?? new byte[0]); // Write byte[] (methods.txt: void Write(byte[] value))
            }
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.Features)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 GenerationFeature 元素
        Features = new GenerationFeature[count];
        for (var i = 0; i < count; i++)
        {
            // methods.txt 中没有直接读取 GenerationFeature 的方法，
            // 因此需要在此类中手动反序列化其字段。
            var name = ReadString(); // Read string (methods.txt: string ReadString())
            var json = ReadByteArray(true); // Read byte[] (methods.txt: byte[] ReadByteArray(bool slurp))
            // 假设 JSON 占据数据流的剩余部分直到下一个特征或数据包结束。
            // 如果 JSON 有明确的长度前缀，则需要先读取长度。

            Features[i] = new GenerationFeature
            {
                Name = name,
                JSON = json
            };
        }
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Features = new GenerationFeature[0];
    }
}