using System.Numerics;
// Example for Vector3 (mgl32.Vec3) - ADJUST BASED ON YOUR PROJECT

// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     PlayerLocation 数据包：由服务器发送给客户端，用于在定位器栏上更新玩家位置或将其完全移除。
///     客户端将根据自身与 Position 的距离来决定如何在定位器栏上渲染玩家。
/// </summary>
public class McpePlayerLocation : Packet
{
    public enum PlayerLocation
    {
        // --- Constants (matching Go iota) ---
        /// <summary>
        ///     使用坐标更新玩家位置。
        /// </summary>
        PlayerLocationTypeCoordinates = 0,

        /// <summary>
        ///     从定位器栏上隐藏玩家。
        /// </summary>
        PlayerLocationTypeHide = 1
    }

    /// <summary>
    ///     初始化 McpePlayerLocation 类的新实例。
    /// </summary>
    public McpePlayerLocation()
    {
        Id = 326; // IDPlayerLocation
        IsMcpe = true;
    }

    /// <summary>
    ///     Type 是正在执行的操作。它是上面的常量之一。
    /// </summary>
    public int Type { get; set; } // int32 -> int

    /// <summary>
    ///     EntityUniqueID 是实体的唯一 ID。唯一 ID 是一个在相同世界的不同会话中保持一致的值。
    /// </summary>
    public long EntityUniqueID { get; set; } // int64 -> long

    /// <summary>
    ///     Position 是用于定位器栏上的玩家位置。仅当 Type 为 PlayerLocationTypeCoordinates 时才设置。
    /// </summary>
    public Vector3 Position { get; set; } // mgl32.Vec3 -> Vector3

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.Type)
        // methods.txt 中的 Write(int, bool) 用于 int32。假设小端序 (false)。
        Write(Type);

        // void WriteSignedVarLong(long value) - 对应 Go 的 io.Varint64(&pk.EntityUniqueID)
        WriteSignedVarLong(EntityUniqueID);

        if (Type == (int)PlayerLocation.PlayerLocationTypeCoordinates)
            // void Write(Vector3 vec) - 对应 Go 的 io.Vec3(&pk.Position)
            Write(Position);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.Type)
        // methods.txt 中的 ReadInt(bool) 用于读取 int32。假设小端序 (false)。
        Type = ReadInt();

        // long ReadSignedVarLong() - 对应 Go 的 io.Varint64(&pk.EntityUniqueID)
        EntityUniqueID = ReadSignedVarLong();

        if (Type == (int)PlayerLocation.PlayerLocationTypeCoordinates)
            // Vector3 ReadVector3() - 对应 Go 的 io.Vec3(&pk.Position)
            Position = ReadVector3();
        else
            // 如果 Type 不是 Coordinates，则 Position 字段不会被发送。
            // 为了安全起见，可以将其重置为默认值（如果数据包对象被重用）。
            Position = Vector3.Zero;
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Type = 0;
        EntityUniqueID = 0;
        Position = Vector3.Zero;
    }
}