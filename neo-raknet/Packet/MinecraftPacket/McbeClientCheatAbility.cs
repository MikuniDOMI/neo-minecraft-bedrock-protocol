using neo_raknet.Packet.MinecraftStruct;
// Assuming base Packet class is here or adjust accordingly

// Assuming AbilityData, AbilityLayer, etc. are in this namespace

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     ClientCheatAbility 数据包的功能与 UpdateAbilities 相同。目前尚不清楚为什么要将它们分开。
///     已过时：ClientCheatAbility 在 1.20.10 版本中已被弃用。
/// </summary>
public class McpeClientCheatAbility : Packet
{
    /// <summary>
    ///     初始化 McpeClientCheatAbility 类的新实例。
    /// </summary>
    public McpeClientCheatAbility()
    {
        Id = 197; // IDClientCheatAbility
        IsMcpe = true;
    }

    /// <summary>
    ///     AbilityData 表示关于玩家能力的各种数据，例如能力层或权限。
    /// </summary>
    public AbilityData AbilityData { get; set; } = new(); // Initialize with default values

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // Go: pk.AbilityData.Marshal(io)
        // Since there's no direct Write(AbilityData) in methods.txt,
        // we implement the marshalling logic here based on the Go struct fields.
        WriteAbilityData(AbilityData);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // Go: pk.AbilityData.Marshal(io)
        // Since there's no direct ReadAbilityData() in methods.txt,
        // we implement the unmarshalling logic here based on the Go struct fields.
        AbilityData = ReadAbilityData();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        AbilityData = new AbilityData(); // Reset to default state
    }

    #region 补全的方法 (因为 methods.txt 中没有 AbilityData 和 AbilityLayer 的直接读写)

    /// <summary>
    ///     Writes an AbilityData object to the packet buffer.
    ///     This method is added because Write(AbilityData) is not in methods.txt.
    /// </summary>
    /// <param name="data">The AbilityData to write.</param>
    private void WriteAbilityData(AbilityData data)
    {
        if (data == null)
        {
            // Write default values for a null AbilityData struct
            Write(0L); // EntityUniqueID (long)
            Write((byte)0); // PlayerPermissions (byte)
            Write((byte)0); // CommandPermissions (byte)
            WriteUnsignedVarInt(0); // Layers array length (uint)
            // No elements to write for an empty array
            return;
        }

        // Write EntityUniqueID (int64 -> long)
        Write(data.EntityUniqueID);

        // Write PlayerPermissions (uint8 -> byte)
        Write(data.PlayerPermissions);

        // Write CommandPermissions (uint8 -> byte)
        Write(data.CommandPermissions);

        // Write Layers ([]AbilityLayer)
        // This corresponds to protocol.Slice(io, &pk.Layers)
        WriteUnsignedVarInt((uint)(data.Layers?.Length ?? 0)); // Write length as Varuint32
        if (data.Layers != null)
            foreach (var layer in data.Layers)
                // Write each AbilityLayer
                // Since methods.txt has Write(AbilityLayer layer), we can use it.
                Write(layer);
    }

    /// <summary>
    ///     Reads an AbilityData object from the packet buffer.
    ///     This method is added because ReadAbilityData() is not in methods.txt.
    /// </summary>
    /// <returns>The AbilityData that was read.</returns>
    private AbilityData ReadAbilityData()
    {
        // Read EntityUniqueID (int64 -> long)
        var entityUniqueID = ReadLong(); // methods.txt: long ReadLong()

        // Read PlayerPermissions (uint8 -> byte)
        var playerPermissions = ReadByte(); // methods.txt: byte ReadByte()

        // Read CommandPermissions (uint8 -> byte)
        var commandPermissions = ReadByte(); // methods.txt: byte ReadByte()

        // Read Layers ([]AbilityLayer)
        // This corresponds to protocol.Slice(io, &pk.Layers)
        var layersCount = ReadUnsignedVarInt(); // Read length as Varuint32 (methods.txt: uint ReadUnsignedVarInt())
        var layers = new AbilityLayer[layersCount];
        for (var i = 0; i < layersCount; i++)
            // Read each AbilityLayer
            // Since methods.txt has AbilityLayer ReadAbilityLayer(), we can use it.
            layers[i] = ReadAbilityLayer(); // methods.txt: AbilityLayer ReadAbilityLayer()

        return new AbilityData(entityUniqueID, playerPermissions, commandPermissions, layers);
    }

    #endregion
}