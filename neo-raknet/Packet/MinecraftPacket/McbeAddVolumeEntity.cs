// 假设必要的命名空间用于 Vector3/BlockPos。
// 您可能需要根据实际使用的向量/位置库调整 'using' 或类型名称。
// 对于 BlockPos，我们假设它是一个您定义的自定义结构/类型。
using neo_raknet.Packet; // 假设基类 Packet 在这里，或进行相应调整
using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.NBT; // 假设 Nbt 和相关类型在这里
using System;
using System.Collections.Generic;

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// AddVolumeEntity 数据包：将体积实体的定义和元数据从服务器发送到客户端。
    /// </summary>
    public class McpeAddVolumeEntity : Packet
    {
        /// <summary>
        /// EntityRuntimeID 是该体积实体的运行时 ID。运行时 ID 在每个世界会话中都是唯一的，
        /// 通常在数据包中使用此运行时 ID 来标识实体。
        /// </summary>
        public ulong EntityRuntimeID { get; set; } // uint64 -> ulong

        /// <summary>
        /// EntityMetadata 是实体元数据的映射，其中包括标志和数据属性，
        /// 这些属性会改变体积实体的功能或外观。
        /// 在 C# 中，这表示为 NBT 复合体，通常是一个等效的 Dictionary 或特定的 NBT 类型。
        /// 假设 Nbt 类型可以容纳 map[string]any 数据。
        /// </summary>
        public Nbt EntityMetadata { get; set; } // map[string]any -> Nbt

        /// <summary>
        /// EncodingIdentifier 是该体积实体的唯一标识符。其格式必须为 'namespace:name'，
        /// 其中 namespace 不能是 'minecraft'。
        /// </summary>
        public string EncodingIdentifier { get; set; } = string.Empty; // string

        /// <summary>
        /// InstanceIdentifier 是一个迷雾定义的标识符。
        /// </summary>
        public string InstanceIdentifier { get; set; } = string.Empty; // string

        /// <summary>
        /// Bounds 表示体积实体的边界。第一个值是最小边界，第二个值是最大边界。
        /// 假设 BlockPos 是一个已定义的结构/类型。
        /// </summary>
        public BlockCoordinates[] Bounds { get; set; } = new BlockCoordinates[2]; // [2]protocol.BlockPos -> BlockPos[2]

        /// <summary>
        /// Dimension 是该体积实体存在的维度。
        /// </summary>
        public int Dimension { get; set; } // int32 -> int

        /// <summary>
        /// EngineVersion 是该实体使用的引擎版本，例如 '1.17.0'。
        /// </summary>
        public string EngineVersion { get; set; } = string.Empty; // string

        /// <summary>
        /// 初始化 McpeAddVolumeEntity 类的新实例。
        /// </summary>
        public McpeAddVolumeEntity()
        {
            Id = 166; // IDAddVolumeEntity
            IsMcpe = true;
            // Bounds 数组在字段声明中初始化
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(ulong value)
            Write(EntityRuntimeID);

            // void Write(Nbt nbt)
            // 注意：Go 代码使用 nbt.NetworkLittleEndian 编码。
            // 你的 C# NBT 库和 Write(Nbt) 方法需要确保使用相同的编码格式。
            Write(EntityMetadata);

            // void Write(string value)
            Write(EncodingIdentifier);
            Write(InstanceIdentifier);

           
                Write(Bounds[0]); // 写入第一个 BlockPos
                Write(Bounds[1]); // 写入第二个 BlockPos
        

            // void WriteSignedVarInt(int value) - 用于写入 Go 的 int32
            WriteSignedVarInt(Dimension);

            Write(EngineVersion);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // ulong ReadUlong()
            EntityRuntimeID = ReadUlong();

            // Nbt ReadNbt()
            // 注意：Go 代码使用 nbt.NetworkLittleEndian 编码。
            // 你的 C# NBT 库和 ReadNbt() 方法需要确保使用相同的解码格式。
            EntityMetadata = ReadNbt();

            // string ReadString()
            EncodingIdentifier = ReadString();
            InstanceIdentifier = ReadString();

            // 为 Bounds 读取两个 BlockPos 元素。
            // Go 的 protocol.UBlockPos 对应读取无符号 VarInt 坐标。
            // C# methods.txt 中的 ReadBlockCoordinates() 可能默认是读取带符号 VarInt。
            // 如果你的 BlockPos 与 BlockCoordinates 兼容，直接使用 ReadBlockCoordinates。
            // 否则，需要分别读取 X, Y, Z 为 uint (ReadUnsignedVarInt)。
            // 这里假设 BlockPos 可以直接使用 ReadBlockCoordinates() 方法。
            // 如果不行，需要替换为 ReadUnsignedBlockPos 辅助方法。
           
                Bounds = new BlockCoordinates[2]; // 确保数组有空间
            
            Bounds[0] = ReadBlockCoordinates(); // 读取第一个 BlockPos
            Bounds[1] = ReadBlockCoordinates(); // 读取第二个 BlockPos

            // int ReadSignedVarInt() - 用于读取 Go 的 int32
            Dimension = ReadSignedVarInt();

            // string ReadString()
            EngineVersion = ReadString();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            EntityRuntimeID = 0;
            EntityMetadata = null; // 或 new NbtCompound() / 适当的默认 NBT 值
            EncodingIdentifier = string.Empty;
            InstanceIdentifier = string.Empty;
            Dimension = 0;
            EngineVersion = string.Empty;
        }
    }
}