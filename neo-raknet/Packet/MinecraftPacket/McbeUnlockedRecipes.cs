// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     定义了已解锁配方列表的更新类型。
/// </summary>
public enum UnlockedRecipesType : uint
{
    /// <summary>
    ///     空操作。
    /// </summary>
    Empty = 0,

    /// <summary>
    ///     最初解锁的配方。
    /// </summary>
    InitiallyUnlocked = 1,

    /// <summary>
    ///     新解锁的配方。
    /// </summary>
    NewlyUnlocked = 2,

    /// <summary>
    ///     移除已解锁的配方。
    /// </summary>
    RemoveUnlocked = 3,

    /// <summary>
    ///     移除所有已解锁的配方。
    /// </summary>
    RemoveAllUnlocked = 4
}

/// <summary>
///     UnlockedRecipes 数据包：向客户端提供已解锁的配方列表，限制配方书中显示的配方。
/// </summary>
public class McpeUnlockedRecipes : Packet
{
    /// <summary>
    ///     初始化 McpeUnlockedRecipes 类的新实例。
    /// </summary>
    public McpeUnlockedRecipes()
    {
        Id = 199; // IDUnlockedRecipes
        IsMcpe = true;
        // Recipes is initialized in property declaration
    }

    /// <summary>
    ///     UnlockType 是数据包所代表的解锁类型，可以是添加或移除配方列表。
    ///     它是 UnlockedRecipesType 枚举中的一个值。
    /// </summary>
    public UnlockedRecipesType UnlockType { get; set; } // uint32 -> UnlockedRecipesType (enum based on uint)

    /// <summary>
    ///     Recipes 是已解锁的配方名称列表。
    /// </summary>
    public string[] Recipes { get; set; } = new string[0]; // []string -> string[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(uint value) - 对应 Go 的 io.Uint32(&pk.UnlockType)
        // 将枚举值转换为底层 uint 类型进行写入
        Write((uint)UnlockType);

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Recipes, io.String)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(Recipes?.Length ?? 0));
        // 2. 遍历并写入每个 string 元素
        if (Recipes != null)
            foreach (var recipe in Recipes)
                // void Write(string value) - 对应 Go 的 io.String
                Write(recipe ?? string.Empty);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // uint ReadUint() - 对应 Go 的 io.Uint32(&pk.UnlockType)
        // 读取 uint 值并转换为枚举类型
        UnlockType = (UnlockedRecipesType)ReadUint();

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Recipes, io.String)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 string 元素
        Recipes = new string[count];
        for (var i = 0; i < count; i++)
            // string ReadString() - 对应 Go 的 io.String
            Recipes[i] = ReadString();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        UnlockType = UnlockedRecipesType.Empty; // Reset to default enum value
        Recipes = new string[0];
    }
}