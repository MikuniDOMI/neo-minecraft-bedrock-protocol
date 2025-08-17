// Assuming base Packet class is here or adjust accordingly
// 假设 CameraPreset 在你的协议命名空间中定义
// using neo_raknet.Protocol;

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     CameraPresets 数据包：向客户端提供自定义相机预设列表。
/// </summary>
public class McpeCameraPresets : Packet
{
    /// <summary>
    ///     初始化 McpeCameraPresets 类的新实例。
    /// </summary>
    public McpeCameraPresets()
    {
        Id = 198; // IDCameraPresets
        IsMcpe = true;
        // Presets is initialized in property declaration
    }

    /// <summary>
    ///     Presets 是一个相机预设列表，可被其他相机使用。此列表的顺序很重要，
    ///     因为预设的索引将作为指针在 CameraInstruction 数据包中使用。
    /// </summary>
    public CameraPreset[] Presets { get; set; } = new CameraPreset[0]; // []protocol.CameraPreset -> CameraPreset[]

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.Presets)
        // 1. 写入数组/列表的长度 (Varuint32)
        WriteUnsignedVarInt((uint)(Presets?.Length ?? 0));
        // 2. 遍历并写入每个 CameraPreset 元素
        if (Presets != null)
            foreach (var preset in Presets)
                // methods.txt 中没有 Write(CameraPreset)，所以在此类中补全
                WriteCameraPreset(preset);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 对应 Go 的 protocol.Slice(io, &pk.Presets)
        // 1. 读取数组/列表的长度 (Varuint32)
        var count = ReadUnsignedVarInt();
        // 2. 创建数组并读取每个 CameraPreset 元素
        Presets = new CameraPreset[count];
        for (var i = 0; i < count; i++)
            // methods.txt 中没有 ReadCameraPreset()，所以在此类中补全
            Presets[i] = ReadCameraPreset();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Presets = new CameraPreset[0];
    }

    #region 补全的方法 (因为 methods.txt 中没有)

    /// <summary>
    ///     Writes a CameraPreset object to the packet buffer.
    ///     This method is added because Write(CameraPreset) is not in methods.txt.
    ///     The implementation depends on the actual structure of CameraPreset.
    ///     This is a placeholder based on common CameraPreset fields.
    ///     You MUST update this based on the real definition of protocol.CameraPreset in Go.
    /// </summary>
    /// <param name="preset">The CameraPreset to write.</param>
    private void WriteCameraPreset(CameraPreset preset)
    {
        if (preset == null)
        {
            // Write default/empty values for a null preset
            // The actual default serialization depends on the Go definition.
            // Common approach: write empty strings and default values.
            Write(string.Empty); // Name
            Write(string.Empty); // Parent
            // Write other fields with their defaults...
            // e.g., Write(0.0f); for float fields, Write(false); for bool fields
            // For complex nested types, write their "empty" state (e.g., count=0 for slices)
            // Example for a hypothetical 'pos' Vector3 field:
            // Write(Vector3.Zero); // Or Write(new Vector3(0, 0, 0));
            // Example for a hypothetical 'inertia' float field:
            // Write(0.0f);
            // Example for a hypothetical 'listeners' slice (handled like Presets):
            // WriteUnsignedVarInt(0); // Length 0
            return;
        }

        // --- 你需要根据 Go 中 protocol.CameraPreset 的实际字段来调整以下写入逻辑 ---

        // Example fields (replace with actual ones):
        Write(preset.Name ?? string.Empty);
        Write(preset.Parent ?? string.Empty);

        // Example for a Vector3 field named 'Pos':
        // Write(preset.Pos);

        // Example for a float field named 'Inertia':
        // Write(preset.Inertia);

        // Example for a nested struct/slice, e.g., 'Listeners []CameraPreset':
        // WriteUnsignedVarInt((uint)(preset.Listeners?.Length ?? 0));
        // if (preset.Listeners != null)
        // {
        //     foreach (var listener in preset.Listeners)
        //     {
        //         WriteCameraPreset(listener); // Recursive call
        //     }
        // }

        // Example for an Optional field (using the pattern you specified):
        // Write(preset.SomeOptionalValue.HasValue);
        // if (preset.SomeOptionalValue.HasValue)
        // {
        //     Write(preset.SomeOptionalValue.Value);
        // }

        // --- End of example fields ---
    }

    /// <summary>
    ///     Reads a CameraPreset object from the packet buffer.
    ///     This method is added because ReadCameraPreset() is not in methods.txt.
    ///     The implementation depends on the actual structure of CameraPreset.
    ///     This is a placeholder based on common CameraPreset fields.
    ///     You MUST update this based on the real definition of protocol.CameraPreset in Go.
    /// </summary>
    /// <returns>The CameraPreset that was read.</returns>
    private CameraPreset ReadCameraPreset()
    {
        var preset = new CameraPreset(); // Or obtain from a pool if applicable

        // --- 你需要根据 Go 中 protocol.CameraPreset 的实际字段来调整以下读取逻辑 ---

        // Example fields (replace with actual ones):
        preset.Name = ReadString();
        preset.Parent = ReadString();

        // Example for a Vector3 field named 'Pos':
        // preset.Pos = ReadVector3();

        // Example for a float field named 'Inertia':
        // preset.Inertia = ReadFloat();

        // Example for a nested struct/slice, e.g., 'Listeners []CameraPreset':
        // uint listenersCount = ReadUnsignedVarInt();
        // preset.Listeners = new CameraPreset[listenersCount];
        // for (int i = 0; i < listenersCount; i++)
        // {
        //     preset.Listeners[i] = ReadCameraPreset(); // Recursive call
        // }

        // Example for an Optional field (using the pattern you specified):
        // bool hasSomeOptionalValue = ReadBool();
        // if (hasSomeOptionalValue)
        // {
        //     preset.SomeOptionalValue = new Optional<TheType>(ReadTheType()); // Replace TheType and ReadTheType()
        // }

        // --- End of example fields ---

        return preset;
    }

    #endregion
}

// --- 假设的 CameraPreset 定义 ---
// 你需要将此替换为你项目中实际的 CameraPreset 类定义。
// 此处仅作示例，展示了可能需要序列化的字段类型。
public class CameraPreset
{
    public string Name { get; set; } = string.Empty;

    public string Parent { get; set; } = string.Empty;
    // public Vector3 Pos { get; set; } // Example
    // public float Inertia { get; set; } // Example
    // public CameraPreset[] Listeners { get; set; } = new CameraPreset[0]; // Example nested slice
    // public Optional<SomeType> SomeOptionalValue { get; set; } // Example optional
    // Add other fields as defined in Go's protocol.CameraPreset
}
// --- End of assumed CameraPreset definition ---