using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly
using neo_raknet.Packet.MinecraftStruct.NBT; // Assuming Nbt type is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// JigsawStructureData 数据包：由服务器发送，用于告知客户端所有关于拼图结构的规则。
    /// </summary>
    public class McpeJigsawStructureData : Packet
    {
        /// <summary>
        /// StructureData 是一个网络 NBT 序列化的复合标签，包含了服务器上定义的所有拼图结构规则。
        /// </summary>
        public Nbt StructureData { get; set; } // 使用 Nbt 类型而不是 byte[]

        /// <summary>
        /// 初始化 McpeJigsawStructureData 类的新实例。
        /// </summary>
        public McpeJigsawStructureData()
        {
            Id = 313; // IDJigsawStructureData
            IsMcpe = true;
            // StructureData is initialized to null or a default Nbt value
            // Depending on your Nbt library, you might initialize it differently
            // e.g., StructureData = new NbtCompound(); or StructureData = null;
            StructureData = null; // Or new NbtCompound() if a default empty compound is preferred
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(Nbt nbt) - 对应 Go 的 io.Bytes(&pk.StructureData)
            // 这里假设 StructureData 是一个 Nbt 对象，可以直接写入。
            // Write(Nbt) 方法会处理 NBT 的序列化。
            Write(StructureData); // 使用 methods.txt 中的 void Write(Nbt nbt)
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // Nbt ReadNbt() - 对应 Go 的 io.Bytes(&pk.StructureData)
            // ReadNbt() 方法会从数据包中读取字节并反序列化为 Nbt 对象。
            StructureData = ReadNbt(); // 使用 methods.txt 中的 Nbt ReadNbt()
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            // Reset Nbt object. Depending on your Nbt library and usage pattern:
            // Option 1: Set to null
            StructureData = null;
            // Option 2: Create a new empty compound
            // StructureData = new NbtCompound();
            // Option 3: Clear the existing Nbt object if it's mutable and has a Clear method
            // StructureData?.Clear(); // If Nbt type supports this
        }
    }
}