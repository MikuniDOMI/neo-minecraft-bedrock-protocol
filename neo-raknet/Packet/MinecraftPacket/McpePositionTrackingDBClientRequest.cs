using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    public class McpePositionTrackingDBClientRequest : Packet
    {
        /// <summary>
        /// 定义位置追踪数据库请求操作类型的枚举。
        /// </summary>
        public enum Action
        {
            Query = 0 // 查询：请求指定 TrackingID 的位置信息
        }

        /// <summary>
        /// 请求操作，指定收到数据包后应执行的操作。
        /// </summary>
        public byte RequestAction { get; set; }

        /// <summary>
        /// 用于标识请求的唯一 ID。
        /// 服务器在 PositionTrackingDBServerBroadcast 数据包中返回相同的 ID。
        /// </summary>
        public int TrackingID { get; set; }

        /// <summary>
        /// 构造函数，设置数据包 ID 并标记为 MCPE 包。
        /// </summary>
        public McpePositionTrackingDBClientRequest()
        {
            Id = 154;      // IDPositionTrackingDBClientRequest
            IsMcpe = true; // 标记为 MCPE 协议包
        }

        /// <summary>
        /// 将数据包编码为字节流。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket(); // 调用基类的 EncodePacket 方法

            Write(RequestAction);
            WriteSignedVarInt(TrackingID);
        }

        /// <summary>
        /// 从字节流中解码数据包。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket(); // 调用基类的 DecodePacket 方法

            RequestAction = ReadByte();
            TrackingID = ReadSignedVarInt();
        }
    }
}
