using neo_raknet.Packet.MinecraftStruct.NBT;

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     Represents an entry for an item in the ItemRegistry packet.
/// </summary>
public class ItemEntry
{
    /// <summary>
    ///     Name is the name of the item, which is a name like 'minecraft:stick'.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     RuntimeID is the ID that is used to identify the item over network. After sending all items in the
    ///     StartGame packet, items will then be identified using these numerical IDs.
    /// </summary>
    public short RuntimeID { get; set; } // Go 的 int16 对应 C# 的 short

    /// <summary>
    ///     ComponentBased specifies if the item was created using components, meaning the item is a custom item.
    /// </summary>
    public bool ComponentBased { get; set; }

    /// <summary>
    ///     Version is the version of the item entry which is used by the client to determine how to handle the
    ///     item entry. It is one of the constants above.
    /// </summary>
    public int Version { get; set; } // Go 的 int32 对应 C# 的 int

    /// <summary>
    ///     Data is a map containing the components and properties of the item, if the item is component based.
    ///     在 C# 中，map[string]any 通常用 Dictionary<string, object> 表示。
    /// </summary>
    public Nbt Data { get; set; } // Go 的 map[string]any 对应 C# 的 Dictionary<string, object>
}

public class McpeItemRegistry : Packet
{
    /// <summary>
    ///     构造函数，设置数据包 ID 并标记为 MCPE 包。
    /// </summary>
    public McpeItemRegistry()
    {
        Id = 162; // IDItemRegistry
        IsMcpe = true; // 标记为 MCPE 协议包
    }

    /// <summary>
    ///     游戏中所有可用物品的列表，包含它们的旧版 ID。
    ///     未能发送游戏中存在的任何物品将导致移动端客户端崩溃。
    ///     自定义组件也附加在此列表的物品上。
    /// </summary>
    public List<ItemEntry> Items { get; set; } = new();

    /// <summary>
    ///     将数据包编码为字节流。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket(); // 调用基类的 EncodePacket 方法
        WriteUnsignedVarInt((uint)Items.Count);
        foreach (var item in Items)
        {
            Write(item.Name);
            Write(item.RuntimeID);
            Write(item.ComponentBased);
            WriteVarInt(item.Version);
            Write(item.Data);
        }
    }

    /// <summary>
    ///     从字节流中解码数据包。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket(); // 调用基类的 DecodePacket 方法

        Items.Clear(); // 清空现有列表以准备读取新数据
        var count = ReadUnsignedVarInt(); // 读取物品数量 (uint)
        Items.Capacity = (int)count; // 预分配容量以提高性能

        for (var i = 0; i < count; i++)
        {
            var item = new ItemEntry(); // 创建新的 ItemEntry 实例
            item.Name = ReadString(); // 读取物品名称 (string)
            item.RuntimeID = ReadShort(); // 读取运行时 ID (short, 假设小端)
            item.ComponentBased = ReadBool(); // 读取是否基于组件 (bool)
            item.Version = ReadVarInt(); // 读取版本 (int, 假设小端)
            item.Data = ReadNbt(); // 读取 NBT 数据 (Nbt) - 使用 methods.txt 中的 ReadNbt() 方法
            Items.Add(item); // 将读取的物品添加到列表中
        }
    }
}