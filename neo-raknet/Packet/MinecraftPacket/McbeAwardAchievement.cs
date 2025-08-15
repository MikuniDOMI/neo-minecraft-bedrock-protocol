using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// AwardAchievement 数据包：由服务器发送，用于向玩家授予一个成就。
    /// </summary>
    public class McpeAwardAchievement : Packet
    {
        /// <summary>
        /// AchievementID 是应授予玩家的成就的 ID。这些 ID 的具体值目前未知。
        /// </summary>
        public int AchievementID { get; set; } // int32 -> int

        /// <summary>
        /// 初始化 McpeAwardAchievement 类的新实例。
        /// </summary>
        public McpeAwardAchievement()
        {
            Id = 309; // IDAwardAchievement
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.AchievementID)
            // methods.txt 中的 Write(int, bool) 用于处理 32 位整数。
            // Go 的 protocol.IO 默认使用小端序 (Little Endian)，所以这里传递 false。
            Write(AchievementID, false); // Write int32 as little-endian
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.AchievementID)
            // methods.txt 中的 ReadInt(bool) 用于读取 32 位整数。
            // Go 的 protocol.IO 默认使用小端序 (Little Endian)，所以这里传递 false。
            AchievementID = ReadInt(false); // Read int32 as little-endian
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            AchievementID = 0;
        }
    }
}