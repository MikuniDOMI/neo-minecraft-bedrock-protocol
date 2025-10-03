// For List<T> if needed, though arrays are used below

// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     定义了可以被 SetHud 数据包控制的 HUD 元素。
/// </summary>
public static class HudElement
{
    /// <summary>
    ///     玩家模型（纸娃娃）。
    /// </summary>
    public const int PaperDoll = 0;

    /// <summary>
    ///     护甲值。
    /// </summary>
    public const int Armour = 1;

    /// <summary>
    ///     工具提示。
    /// </summary>
    public const int ToolTips = 2;

    /// <summary>
    ///     触摸控制。
    /// </summary>
    public const int TouchControls = 3;

    /// <summary>
    ///     准星。
    /// </summary>
    public const int Crosshair = 4;

    /// <summary>
    ///     快捷栏。
    /// </summary>
    public const int HotBar = 5;

    /// <summary>
    ///     生命值。
    /// </summary>
    public const int Health = 6;

    /// <summary>
    ///     进度条（例如，经验值）。
    /// </summary>
    public const int ProgressBar = 7;

    /// <summary>
    ///     饥饿值。
    /// </summary>
    public const int Hunger = 8;

    /// <summary>
    ///     氧气气泡（水下）。
    /// </summary>
    public const int AirBubbles = 9;

    /// <summary>
    ///     马的生命值。
    /// </summary>
    public const int HorseHealth = 10;

    /// <summary>
    ///     状态效果（例如，药水效果）。
    /// </summary>
    public const int StatusEffects = 11;

    /// <summary>
    ///     物品文本（例如，持有的物品名称）。
    /// </summary>
    public const int ItemText = 12;
}

/// <summary>
///     定义了 HUD 元素的可见性状态。
/// </summary>
public static class HudVisibility
{
    /// <summary>
    ///     隐藏指定的 HUD 元素。
    /// </summary>
    public const int Hide = 0;

    /// <summary>
    ///     将指定的 HUD 元素的可见性重置为默认设置。
    /// </summary>
    public const int Reset = 1;
}

/// <summary>
///     SetHud 数据包：由服务器发送，用于设置客户端上各个 HUD 元素的可见性。
/// </summary>
public class McpeSetHud : Packet
{
    /// <summary>
    ///     初始化 McpeSetHud 类的新实例。
    /// </summary>
    public McpeSetHud()
    {
        Id = 308; // IDSetHud
        IsMcpe = true;
        // Elements is initialized in property declaration
    }

    /// <summary>
    ///     Elements 是正在被修改的 HUD 元素列表。值可以是 HudElement 常量中的任何一个。
    /// </summary>
    public int[] Elements { get; set; } = new int[0]; // []int32 -> int[]

    /// <summary>
    ///     Visibility 表示指定 Elements 的新可见性。它可以是 HudVisibility 常量中的任何一个。
    /// </summary>
    public int Visibility { get; set; } // int32 -> int

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Elements, io.Varint32)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(Elements?.Length ?? 0));
        // 2. 遍历并写入每个 int32 元素，使用 Varint32 编码
        if (Elements != null)
            foreach (var element in Elements)
                // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32
                WriteSignedVarInt(element);

        // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Visibility)
        WriteSignedVarInt(Visibility);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 对应 Go 的 protocol.FuncSlice(io, &pk.Elements, io.Varint32)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 int32 元素，使用 Varint32 解码
        Elements = new int[count];
        for (var i = 0; i < count; i++)
            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32
            Elements[i] = ReadSignedVarInt();

        // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Visibility)
        Visibility = ReadSignedVarInt();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Elements = new int[0];
        Visibility = HudVisibility.Reset; // Or 0, or another default
    }
}