using neo_protocol.Packet.MinecraftStruct.NBT;
// For map[string]any -> Dictionary<string, object>
// Assuming base Packet class is here or adjust accordingly

// Assuming Nbt and related types are here or adjust accordingly
// The Go code imports "github.com/sandertv/gophertunnel/minecraft/nbt"
// You might need to adjust the using statement above based on where your NBT library's types are located.

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     EditorNetwork 数据包：从服务器发送到客户端，反之亦然，用于传递与编辑器模式相关的信息。
///     它携带一个包含相关信息的单一复合标签(NBT)。
/// </summary>
public class McpeEditorNetwork : Packet
{
    /// <summary>
    ///     初始化 McpeEditorNetwork 类的新实例。
    /// </summary>
    public McpeEditorNetwork()
    {
        Id = 190; // IDEditorNetwork
        IsMcpe = true;
    }

    /// <summary>
    ///     RouteToManager ...
    /// </summary>
    public bool RouteToManager { get; set; } // bool

    /// <summary>
    ///     Payload 是一个网络小端序的复合标签(NBT)，包含与编辑器相关的数据。
    ///     在 C# 中，Go 的 map[string]any 通常表示为 Dictionary
    ///     <string, object>
    ///         。
    ///         假设 Nbt 类型（或类似类型）可以表示这种动态的 NBT 复合标签。
    /// </summary>
    public Nbt
        Payload
    {
        get;
        set;
    } // map[string]any -> Nbt (or Dictionary<string, object> if Nbt type cannot hold compound directly)

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(bool value) - 对应 Go 的 io.Bool(&pk.RouteToManager)
        Write(RouteToManager);

        // void Write(Nbt nbt) - 对应 Go 的 io.NBT(&pk.Payload, nbt.NetworkLittleEndian)
        // 注意：Go 代码明确指定了 nbt.NetworkLittleEndian 编码。
        // 你的 C# NBT 库和 Write(Nbt) 方法需要确保使用相同的编码格式。
        // 如果 Write(Nbt) 默认不是 NetworkLittleEndian，你可能需要查找库中指定编码的方法，
        // 或者在将 Payload 转换为 Nbt 对象时就指定编码。
        Write(Payload);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // bool ReadBool() - 对应 Go 的 io.Bool(&pk.RouteToManager)
        RouteToManager = ReadBool();

        // Nbt ReadNbt() - 对应 Go 的 io.NBT(&pk.Payload, nbt.NetworkLittleEndian)
        // 注意：Go 代码明确指定了 nbt.NetworkLittleEndian 编码。
        // 你的 C# NBT 库和 ReadNbt() 方法需要确保使用相同的解码格式。
        // 如果 ReadNbt() 默认不是 NetworkLittleEndian，你可能需要查找库中指定编码的方法。
        Payload = ReadNbt();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        RouteToManager = false;
        // Reset NBT payload. Depending on your NBT library:
        // Option 1: Set to null
        Payload = null;
        // Option 2: Create a new empty compound if that's the expected default
        // Payload = new NbtCompound(); // Or equivalent for your NBT lib
    }
}