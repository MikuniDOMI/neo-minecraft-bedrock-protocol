using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// CreatePhoto 数据包：允许玩家将作品集中的照片导出为背包中的物品。
    /// 此数据包仅在 Minecraft 教育版中有效。
    /// </summary>
    public class McpeCreatePhoto : Packet
    {
        /// <summary>
        /// EntityUniqueID 是实体的唯一 ID。
        /// </summary>
        public long EntityUniqueID { get; set; } // int64 -> long

        /// <summary>
        /// PhotoName 是照片的名称。
        /// </summary>
        public string PhotoName { get; set; } = string.Empty; // string

        /// <summary>
        /// ItemName 是照片作为物品时的名称。
        /// </summary>
        public string ItemName { get; set; } = string.Empty; // string

        /// <summary>
        /// 初始化 McpeCreatePhoto 类的新实例。
        /// </summary>
        public McpeCreatePhoto()
        {
            Id = 171; // IDCreatePhoto
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(long value) - 对应 Go 的 io.Int64(&pk.EntityUniqueID)
            Write(EntityUniqueID);

            // void Write(string value) - 对应 Go 的 io.String(&pk.PhotoName)
            Write(PhotoName);

            // void Write(string value) - 对应 Go 的 io.String(&pk.ItemName)
            Write(ItemName);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // long ReadLong() - 对应 Go 的 io.Int64(&pk.EntityUniqueID)
            EntityUniqueID = ReadLong();

            // string ReadString() - 对应 Go 的 io.String(&pk.PhotoName)
            PhotoName = ReadString();

            // string ReadString() - 对应 Go 的 io.String(&pk.ItemName)
            ItemName = ReadString();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            EntityUniqueID = 0;
            PhotoName = string.Empty;
            ItemName = string.Empty;
        }
    }
}