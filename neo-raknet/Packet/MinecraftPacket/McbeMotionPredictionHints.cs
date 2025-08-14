using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    using System.Numerics;

    public class McpeMotionPredictionHints : Packet
    {
        /// <summary>
        /// 服务器发送其速度给客户端的实体的运行时 ID。
        /// </summary>
        public long EntityRuntimeID { get; set; }

        /// <summary>
        /// 在发送数据包时，服务器计算出的实体速度。
        /// </summary>
        public Vector3 Velocity { get; set; }

        /// <summary>
        /// 指定服务器当前是否认为该实体在地面上。
        /// </summary>
        public bool OnGround { get; set; }

        /// <summary>
        /// 构造函数，设置数据包 ID 并标记为 MCPE 包。
        /// </summary>
        public McpeMotionPredictionHints()
        {
            Id = 157;      // IDMotionPredictionHints
            IsMcpe = true; // 标记为 MCPE 协议包
        }

        /// <summary>
        /// 将数据包编码为字节流。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket(); // 调用基类的 EncodePacket 方法

            WriteUnsignedVarLong(EntityRuntimeID);
            Write(Velocity);
            Write(OnGround);
        }

        /// <summary>
        /// 从字节流中解码数据包。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket(); // 调用基类的 DecodePacket 方法

            EntityRuntimeID = ReadUnsignedVarLong();
            Velocity = ReadVector3();
            OnGround = ReadBool();
        }
    }
}
