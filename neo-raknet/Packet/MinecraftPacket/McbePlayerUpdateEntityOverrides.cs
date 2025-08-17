// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     PlayerUpdateEntityOverrides 数据包：由服务器发送，用于单独修改实体的属性。
/// </summary>
public class McpePlayerUpdateEntityOverrides : Packet
{
    public enum PlayerUpdate : byte
    {
        /// <summary>
        ///     清除所有覆盖。
        /// </summary>
        PlayerUpdateEntityOverridesTypeClearAll = 0,

        /// <summary>
        ///     移除指定属性的覆盖。
        /// </summary>
        PlayerUpdateEntityOverridesTypeRemove = 1,

        /// <summary>
        ///     将属性设置为一个新的整数值。
        /// </summary>
        PlayerUpdateEntityOverridesTypeInt = 2,

        /// <summary>
        ///     将属性设置为一个新的浮点数值。
        /// </summary>
        PlayerUpdateEntityOverridesTypeFloat = 3
    }

    /// <summary>
    ///     初始化 McpePlayerUpdateEntityOverrides 类的新实例。
    /// </summary>
    public McpePlayerUpdateEntityOverrides()
    {
        Id = 325; // IDPlayerUpdateEntityOverrides
        IsMcpe = true;
    }

    /// <summary>
    ///     EntityRuntimeID 是实体的运行时 ID。运行时 ID 在每个世界会话中都是唯一的，
    ///     通常在数据包中使用此运行时 ID 来标识实体。
    /// </summary>
    public long EntityRuntimeID { get; set; } // uint64 -> ulong

    /// <summary>
    ///     PropertyIndex 是要修改的属性的索引。该索引对于实体的每个属性都是唯一的。
    /// </summary>
    public uint PropertyIndex { get; set; } // uint32 -> uint

    /// <summary>
    ///     Type 是要对属性执行的操作类型。它是上面的常量之一。
    /// </summary>
    public byte Type { get; set; } // uint8 -> byte

    /// <summary>
    ///     IntValue 是属性的新整数值。仅当 Type 设置为 PlayerUpdateEntityOverridesTypeInt 时使用。
    /// </summary>
    public int IntValue { get; set; } // int32 -> int

    /// <summary>
    ///     FloatValue 是属性的新浮点数值。仅当 Type 设置为 PlayerUpdateEntityOverridesTypeFloat 时使用。
    /// </summary>
    public float FloatValue { get; set; } // float32 -> float

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void WriteUnsignedVarLong(ulong value) - 对应 Go 的 io.Varuint64(&pk.EntityRuntimeID)
        WriteUnsignedVarLong(EntityRuntimeID);

        // void WriteUnsignedVarInt(uint value) - 对应 Go 的 io.Varuint32(&pk.PropertyIndex)
        WriteUnsignedVarInt(PropertyIndex);

        // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Type)
        Write(Type);

        if (Type == (byte)PlayerUpdate.PlayerUpdateEntityOverridesTypeInt)
            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.IntValue)
            // methods.txt 中的 Write(int, bool) 用于 int32。假设小端序 (false)。
            Write(IntValue);
        else if (Type == (byte)PlayerUpdate.PlayerUpdateEntityOverridesTypeFloat)
            // void Write(float value) - 对应 Go 的 io.Float32(&pk.FloatValue)
            Write(FloatValue);
        // 如果 Type 是 PlayerUpdateEntityOverridesTypeClearAll 或 PlayerUpdateEntityOverridesTypeRemove,
        // 则不发送 IntValue 或 FloatValue。
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // ulong ReadUnsignedVarLong() - 对应 Go 的 io.Varuint64(&pk.EntityRuntimeID)
        EntityRuntimeID = ReadUnsignedVarLong();

        // uint ReadUnsignedVarInt() - 对应 Go 的 io.Varuint32(&pk.PropertyIndex)
        PropertyIndex = ReadUnsignedVarInt();

        // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Type)
        Type = ReadByte();

        // 重置条件字段为默认值，以防数据包对象被重用且当前 Type 不需要它们。
        IntValue = 0;
        FloatValue = 0.0f;

        if (Type == (byte)PlayerUpdate.PlayerUpdateEntityOverridesTypeInt)
            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.IntValue)
            // methods.txt 中的 ReadInt(bool) 用于读取 int32。假设小端序 (false)。
            IntValue = ReadInt();
        else if (Type == (byte)PlayerUpdate.PlayerUpdateEntityOverridesTypeFloat)
            // float ReadFloat() - 对应 Go 的 io.Float32(&pk.FloatValue)
            FloatValue = ReadFloat();
        // 如果 Type 是其他值，则 IntValue 和 FloatValue 保持默认值。
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        EntityRuntimeID = 0;
        PropertyIndex = 0;
        Type = 0;
        IntValue = 0;
        FloatValue = 0.0f;
    }
}