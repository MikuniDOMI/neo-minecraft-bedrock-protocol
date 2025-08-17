using neo_raknet.Utils;


// Assuming base Packet class is here or adjust accordingly
// Assuming your FullContainerName class/type is available in this scope or a referenced namespace
// using YourNamespace.Protocol; // Or wherever FullContainerName is defined

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     ContainerRegistryCleanup 数据包：由服务器发送，以触发客户端动态容器注册表的清理。
/// </summary>
public class McpeContainerRegistryCleanup : Packet
{
    /// <summary>
    ///     初始化 McpeContainerRegistryCleanup 类的新实例。
    /// </summary>
    public McpeContainerRegistryCleanup()
    {
        Id = 317; // IDContainerRegistryCleanup
        IsMcpe = true;
        // RemovedContainers is initialized in property declaration
    }

    /// <summary>
    ///     RemovedContainers 是一个 protocol.FullContainerName 列表，
    ///     这些容器应从客户端的容器注册表中移除。
    /// </summary>
    public FullContainerName[] RemovedContainers { get; set; } =
        new FullContainerName[0]; // []protocol.FullContainerName -> array/list of structs/classes

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.RemovedContainers)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(RemovedContainers?.Length ?? 0));
        // 2. 遍历并写入每个 FullContainerName 元素
        if (RemovedContainers != null)
            foreach (var containerName in RemovedContainers)
                // 使用 methods.txt 中存在的 Write(FullContainerName name) 方法
                Write(containerName);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.RemovedContainers)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 FullContainerName 元素
        RemovedContainers = new FullContainerName[count];
        for (var i = 0; i < count; i++)
            // 使用 methods.txt 中存在的 readFullContainerName() 方法
            // 注意：方法名在 methods.txt 中是 readFullContainerName() (小写 r)
            // 我们假设 Packet 类中有一个对应的 ReadFullContainerName() 方法 (大写 R)
            // 或者直接使用 readFullContainerName() 如果它是公共的。
            // 这里我们使用标准的 C# 命名约定 ReadFullContainerName()
            RemovedContainers[i] = readFullContainerName(); // 或 this.readFullContainerName() 如果后者是公共方法
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        RemovedContainers = new FullContainerName[0];
    }
}