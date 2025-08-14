using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// 定义可用的移动效果类型。
    /// </summary>
    public enum MovementEffectType : int // Go 中是 int32 (iota 默认生成 int)
    {
        /// <summary>
        /// 滑翔加速效果（例如，使用烟花火箭）。
        /// </summary>
        GlideBoost = 0
    }

    /// <summary>
    /// MovementEffect 数据包：由服务器发送给客户端，用于更新特定的移动效果，
    /// 以允许客户端预测其移动。例如，滑翔时使用的烟花会发送此数据包，
    /// 以告知客户端加速的确切持续时间。
    /// </summary>
    public class McpeMovementEffect : Packet
    {
        /// <summary>
        /// EntityRuntimeID 是实体的运行时 ID。运行时 ID 在每个世界会话中都是唯一的，
        /// 通常在数据包中使用此运行时 ID 来标识实体。
        /// </summary>
        public long EntityRuntimeID { get; set; } // uint64 -> ulong

        /// <summary>
        /// Type 是正在更新的移动效果的类型。它是 MovementEffectType 枚举之一。
        /// </summary>
        public MovementEffectType Type { get; set; } // int32 -> MovementEffectType (enum based on int)

        /// <summary>
        /// Duration 是效果的持续时间，以刻 (ticks) 为单位。
        /// </summary>
        public int Duration { get; set; } // int32 -> int

        /// <summary>
        /// Tick 是发送数据包时的服务器刻。它与 CorrectPlayerMovePrediction 数据包相关。
        /// </summary>
        public long Tick { get; set; } // uint64 -> ulong

        /// <summary>
        /// 初始化 McpeMovementEffect 类的新实例。
        /// </summary>
        public McpeMovementEffect()
        {
            Id = 318; // IDMovementEffect
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void WriteUnsignedVarLong(ulong value) - 对应 Go 的 io.Varuint64(&pk.EntityRuntimeID)
            WriteUnsignedVarLong(EntityRuntimeID);

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Type)
            // 注意：Go 的 Varint32 对应 C# 的 SignedVarInt 方法。
            WriteSignedVarInt((int)Type); // 将枚举转换为 int

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Duration)
            WriteSignedVarInt(Duration);

            // void WriteUnsignedVarLong(ulong value) - 对应 Go 的 io.Varuint64(&pk.Tick)
            WriteUnsignedVarLong(Tick);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // ulong ReadUnsignedVarLong() - 对应 Go 的 io.Varuint64(&pk.EntityRuntimeID)
            EntityRuntimeID = ReadUnsignedVarLong();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Type)
            // 注意：Go 的 Varint32 对应 C# 的 SignedVarInt 方法。
            Type = (MovementEffectType)ReadSignedVarInt(); // 读取 int 并转换为枚举

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Duration)
            Duration = ReadSignedVarInt();

            // ulong ReadUnsignedVarLong() - 对应 Go 的 io.Varuint64(&pk.Tick)
            Tick = ReadUnsignedVarLong();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            EntityRuntimeID = 0;
            Type = MovementEffectType.GlideBoost; // Reset to default enum value
            Duration = 0;
            Tick = 0;
        }
    }
}