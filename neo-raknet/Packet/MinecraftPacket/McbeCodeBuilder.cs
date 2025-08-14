using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    public class McpeCodeBuilder : Packet
    {
        /// <summary>
        /// 指向 Code Builder（WebSocket）服务器的 URL。
        /// 例如：ws://localhost:8080 或 http://codeconnection.io
        /// </summary>
        public string URL { get; set; } = "";

        /// <summary>
        /// 指示客户端是否应自动打开 Code Builder 应用。
        /// 如果为 true，客户端将尝试使用 Code Builder 应用连接到上述 URL 的服务器。
        /// </summary>
        public bool ShouldOpenCodeBuilder { get; set; }

        /// <summary>
        /// 构造函数，设置数据包 ID 并标记为 MCPE 包。
        /// </summary>
        public McpeCodeBuilder()
        {
            Id = 149;      // 设置数据包 ID
            IsMcpe = true; // 标记为 MCPE 协议包
        }

        /// <summary>
        /// 将数据包编码为字节流。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket(); // 调用基类的 EncodePacket 方法

            Write(URL);
            Write(ShouldOpenCodeBuilder);
        }

        /// <summary>
        /// 从字节流中解码数据包。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket(); // 调用基类的 DecodePacket 方法

            URL = ReadString();
            ShouldOpenCodeBuilder = ReadBool();
        }
    }
}
