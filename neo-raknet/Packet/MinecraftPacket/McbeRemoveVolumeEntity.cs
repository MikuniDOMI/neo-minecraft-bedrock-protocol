using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// RemoveVolumeEntity 数据包：指示从服务器到客户端移除一个体积实体。
    /// </summary>
    public class McpeRemoveVolumeEntity : Packet
    {
        /// <summary>
        /// EntityRuntimeID 是要移除的体积实体的运行时 ID。
        /// </summary>
        public ulong EntityRuntimeID { get; set; } // uint64 -> ulong

        /// <summary>
        /// Dimension 是体积实体所在的维度。
        /// </summary>
        public int Dimension { get; set; } // int32 -> int

        /// <summary>
        /// 初始化 McpeRemoveVolumeEntity 类的新实例。
        /// </summary>
        public McpeRemoveVolumeEntity()
        {
            Id = 167; // IDRemoveVolumeEntity
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(ulong value) - 对应 Go 的 io.Uint64(&pk.EntityRuntimeID)
            Write(EntityRuntimeID);

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Dimension)
            // 注意：Go 的 Varint32 对应 C# 的 SignedVarInt 方法。
            WriteSignedVarInt(Dimension);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // ulong ReadUlong() - 对应 Go 的 io.Uint64(&pk.EntityRuntimeID)
            EntityRuntimeID = ReadUlong();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Dimension)
            Dimension = ReadSignedVarInt();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            EntityRuntimeID = 0;
            Dimension = 0;
        }
    }
}