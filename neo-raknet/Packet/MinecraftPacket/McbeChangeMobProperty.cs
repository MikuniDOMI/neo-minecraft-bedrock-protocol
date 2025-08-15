using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// ChangeMobProperty 数据包：从服务器发送到客户端，用于更改客户端一侧的生物实体属性。
    /// </summary>
    public class McpeChangeMobProperty : Packet
    {
        /// <summary>
        /// EntityUniqueID 是其属性正在被更改的实体的唯一 ID。
        /// </summary>
        public ulong EntityUniqueID { get; set; } // uint64 -> ulong

        /// <summary>
        /// Property 是正在更新的属性的名称。
        /// </summary>
        public string Property { get; set; } = string.Empty; // string

        /// <summary>
        /// BoolValue 如果属性值是 bool 类型则设置此字段。如果类型不是 bool，则忽略此字段。
        /// </summary>
        public bool BoolValue { get; set; } // bool

        /// <summary>
        /// StringValue 如果属性值是 string 类型则设置此字段。如果类型不是 string，则忽略此字段。
        /// </summary>
        public string StringValue { get; set; } = string.Empty; // string

        /// <summary>
        /// IntValue 如果属性值是 int 类型则设置此字段。如果类型不是 int，则忽略此字段。
        /// </summary>
        public int IntValue { get; set; } // int32 -> int

        /// <summary>
        /// FloatValue 如果属性值是 float 类型则设置此字段。如果类型不是 float，则忽略此字段。
        /// </summary>
        public float FloatValue { get; set; } // float32 -> float

        /// <summary>
        /// 初始化 McpeChangeMobProperty 类的新实例。
        /// </summary>
        public McpeChangeMobProperty()
        {
            Id = 182; // IDChangeMobProperty
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(ulong value) - 对应 Go 的 io.Uint64(&pk.EntityUniqueID)
            Write(EntityUniqueID);

            // void Write(string value) - 对应 Go 的 io.String(&pk.Property)
            Write(Property);

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.BoolValue)
            Write(BoolValue);

            // void Write(string value) - 对应 Go 的 io.String(&pk.StringValue)
            Write(StringValue);

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.IntValue)
            WriteSignedVarInt(IntValue);

            // void Write(float value) - 对应 Go 的 io.Float32(&pk.FloatValue)
            Write(FloatValue);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // ulong ReadUlong() - 对应 Go 的 io.Uint64(&pk.EntityUniqueID)
            EntityUniqueID = ReadUlong();

            // string ReadString() - 对应 Go 的 io.String(&pk.Property)
            Property = ReadString();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.BoolValue)
            BoolValue = ReadBool();

            // string ReadString() - 对应 Go 的 io.String(&pk.StringValue)
            StringValue = ReadString();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.IntValue)
            IntValue = ReadSignedVarInt();

            // float ReadFloat() - 对应 Go 的 io.Float32(&pk.FloatValue)
            FloatValue = ReadFloat();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            EntityUniqueID = 0;
            Property = string.Empty;
            BoolValue = false;
            StringValue = string.Empty;
            IntValue = 0;
            FloatValue = 0.0f;
        }
    }
}