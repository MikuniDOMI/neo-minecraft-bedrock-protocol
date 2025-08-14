using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly
using System;
using System.Numerics;
using neo_raknet.Utils; // For Bitset's BigInteger if needed in the Bitset class itself
// Assuming your Bitset class is available in this scope or a referenced namespace
// using YourNamespace.Bitset; 

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// ClientMovementPredictionSync 数据包：如果客户端收到了来自服务器的移动修正，
    /// 客户端会定期将其发送给服务器，其中包含与移动相关的客户端预测信息。
    /// </summary>
    public class McpeClientMovementPredictionSync : Packet
    {
        // 假设 protocol.EntityDataFlagCount 的值在 Go 中是已知的常量
        // 你需要根据实际情况替换这个值。例如，如果 Go 中是 120:
        private const int EntityDataFlagCount = 125; // Placeholder - Replace with actual value from Go

        /// <summary>
        /// ActorFlags 是当前为客户端设置的所有标志位的位集。
        /// </summary>
        public Bitset ActorFlags { get; set; } = new Bitset(EntityDataFlagCount, BigInteger.Zero); // Initialize with correct size

        /// <summary>
        /// BoundingBoxScale 是客户端边界框的比例。
        /// </summary>
        public float BoundingBoxScale { get; set; } // float32 -> float

        /// <summary>
        /// BoundingBoxWidth 是客户端边界框的宽度。
        /// </summary>
        public float BoundingBoxWidth { get; set; } // float32 -> float

        /// <summary>
        /// BoundingBoxHeight 是客户端边界框的高度。
        /// </summary>
        public float BoundingBoxHeight { get; set; } // float32 -> float

        /// <summary>
        /// MovementSpeed 是移动速度属性，如果未设置则为 0。
        /// </summary>
        public float MovementSpeed { get; set; } // float32 -> float

        /// <summary>
        /// UnderwaterMovementSpeed 是水下移动速度属性，如果未设置则为 0。
        /// </summary>
        public float UnderwaterMovementSpeed { get; set; } // float32 -> float

        /// <summary>
        /// LavaMovementSpeed 是岩浆移动速度属性，如果未设置则为 0。
        /// </summary>
        public float LavaMovementSpeed { get; set; } // float32 -> float

        /// <summary>
        /// JumpStrength 是跳跃强度属性，如果未设置则为 0。
        /// </summary>
        public float JumpStrength { get; set; } // float32 -> float

        /// <summary>
        /// Health 是生命值属性，如果未设置则为 0。
        /// </summary>
        public float Health { get; set; } // float32 -> float

        /// <summary>
        /// Hunger 是饥饿值属性，如果未设置则为 0。
        /// </summary>
        public float Hunger { get; set; } // float32 -> float

        /// <summary>
        /// EntityUniqueID 是实体的唯一 ID。唯一 ID 是一个在相同世界的不同会话中保持一致的值。
        /// </summary>
        public long EntityUniqueID { get; set; } // int64 -> long

        /// <summary>
        /// Flying 指定客户端当前是否正在飞行。
        /// </summary>
        public bool Flying { get; set; } // bool

        /// <summary>
        /// 初始化 McpeClientMovementPredictionSync 类的新实例。
        /// </summary>
        public McpeClientMovementPredictionSync()
        {
            Id = 322; // IDClientMovementPredictionSync
            IsMcpe = true;
            // ActorFlags is initialized in the property declaration
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void WriteBitset(Bitset bitset, int size) - 对应 Go 的 io.Bitset(&pk.ActorFlags, protocol.EntityDataFlagCount)
            // 假设你已经将 WriteBitset 方法添加到了 Packet 类中
            WriteBitset(ActorFlags, EntityDataFlagCount);

            // void Write(float value) - 对应 Go 的 io.Float32
            Write(BoundingBoxScale);
            Write(BoundingBoxWidth);
            Write(BoundingBoxHeight);
            Write(MovementSpeed);
            Write(UnderwaterMovementSpeed);
            Write(LavaMovementSpeed);
            Write(JumpStrength);
            Write(Health);
            Write(Hunger);

            // void WriteSignedVarLong(long value) - 对应 Go 的 io.Varint64(&pk.EntityUniqueID)
            WriteSignedVarLong(EntityUniqueID);

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.Flying)
            Write(Flying);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // Bitset ReadBitset(int size) - 对应 Go 的 io.Bitset(&pk.ActorFlags, protocol.EntityDataFlagCount)
            // 假设你已经将 ReadBitset 方法添加到了 Packet 类中
            ActorFlags = ReadBitset(EntityDataFlagCount);

            // float ReadFloat() - 对应 Go 的 io.Float32
            BoundingBoxScale = ReadFloat();
            BoundingBoxWidth = ReadFloat();
            BoundingBoxHeight = ReadFloat();
            MovementSpeed = ReadFloat();
            UnderwaterMovementSpeed = ReadFloat();
            LavaMovementSpeed = ReadFloat();
            JumpStrength = ReadFloat();
            Health = ReadFloat();
            Hunger = ReadFloat();

            // long ReadSignedVarLong() - 对应 Go 的 io.Varint64(&pk.EntityUniqueID)
            EntityUniqueID = ReadSignedVarLong();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.Flying)
            Flying = ReadBool();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            // Reset Bitset to zero value with correct size
            ActorFlags = new Bitset(EntityDataFlagCount, BigInteger.Zero);
            BoundingBoxScale = 0.0f;
            BoundingBoxWidth = 0.0f;
            BoundingBoxHeight = 0.0f;
            MovementSpeed = 0.0f;
            UnderwaterMovementSpeed = 0.0f;
            LavaMovementSpeed = 0.0f;
            JumpStrength = 0.0f;
            Health = 0.0f;
            Hunger = 0.0f;
            EntityUniqueID = 0;
            Flying = false;
        }
    }
}