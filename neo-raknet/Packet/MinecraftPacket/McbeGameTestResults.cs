using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// GameTestResults 数据包：作为对 GameTestRequest 数据包的响应发送，
    /// 其中包含一个布尔值，指示测试是否成功，以及如果测试失败时的错误字符串。
    /// </summary>
    public class McpeGameTestResults : Packet
    {
        /// <summary>
        /// Name 表示测试的名称。
        /// </summary>
        public string Name { get; set; } = string.Empty; // string

        /// <summary>
        /// Succeeded 指示测试是否成功。
        /// </summary>
        public bool Succeeded { get; set; } // bool

        /// <summary>
        /// Error 是发生的错误。如果 Succeeded 为 true，则此字段为空。
        /// </summary>
        public string Error { get; set; } = string.Empty; // string

        /// <summary>
        /// 初始化 McpeGameTestResults 类的新实例。
        /// </summary>
        public McpeGameTestResults()
        {
            Id = 195; // IDGameTestResults
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.Succeeded)
            Write(Succeeded);

            // void Write(string value) - 对应 Go 的 io.String(&pk.Error)
            Write(Error);

            // void Write(string value) - 对应 Go 的 io.String(&pk.Name)
            Write(Name);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.Succeeded)
            Succeeded = ReadBool();

            // string ReadString() - 对应 Go 的 io.String(&pk.Error)
            Error = ReadString();

            // string ReadString() - 对应 Go 的 io.String(&pk.Name)
            Name = ReadString();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Name = string.Empty;
            Succeeded = false;
            Error = string.Empty;
        }
    }
}