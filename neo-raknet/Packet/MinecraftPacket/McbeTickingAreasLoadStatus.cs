using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// TickingAreasLoadStatus 数据包：由服务器发送给客户端，用于通知客户端某个常加载区域的加载状态。
    /// </summary>
    public class McpeTickingAreasLoadStatus : Packet
    {
        /// <summary>
        /// Preload 如果服务器正在等待该区域的预加载，则为 true。
        /// </summary>
        public bool Preload { get; set; } // bool

        /// <summary>
        /// 初始化 McpeTickingAreasLoadStatus 类的新实例。
        /// </summary>
        public McpeTickingAreasLoadStatus()
        {
            Id = 179; // IDTickingAreasLoadStatus
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.Preload)
            Write(Preload);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.Preload)
            Preload = ReadBool();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Preload = false;
        }
    }
}