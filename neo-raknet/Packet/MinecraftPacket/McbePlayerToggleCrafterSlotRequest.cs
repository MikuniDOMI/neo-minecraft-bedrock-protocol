using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// PlayerToggleCrafterSlotRequest 数据包：当客户端尝试切换合成器(Crafter)内某个槽位的状态时，由客户端发送。
    /// </summary>
    public class McpePlayerToggleCrafterSlotRequest : Packet
    {
        /// <summary>
        /// PosX 是被修改的合成器的 X 坐标。
        /// </summary>
        public int PosX { get; set; } // int32 -> int

        /// <summary>
        /// PosY 是被修改的合成器的 Y 坐标。
        /// </summary>
        public int PosY { get; set; } // int32 -> int

        /// <summary>
        /// PosZ 是被修改的合成器的 Z 坐标。
        /// </summary>
        public int PosZ { get; set; } // int32 -> int

        /// <summary>
        /// Slot 是被切换的槽位的索引。这个值应该在 0 到 8 之间。
        /// </summary>
        public byte Slot { get; set; } // uint8 -> byte

        /// <summary>
        /// Disabled 是槽位的新状态。如果为 true，则槽位被禁用；如果为 false，则槽位被启用。
        /// </summary>
        public bool Disabled { get; set; } // bool

        /// <summary>
        /// 初始化 McpePlayerToggleCrafterSlotRequest 类的新实例。
        /// </summary>
        public McpePlayerToggleCrafterSlotRequest()
        {
            Id = 306; // IDPlayerToggleCrafterSlotRequest
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosX)
            // methods.txt 中的 Write(int, bool) 用于处理 32 位整数。假设小端序 (false)。
            Write(PosX, false);

            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosY)
            Write(PosY, false);

            // void Write(int value, bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosZ)
            Write(PosZ, false);

            // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Slot)
            Write(Slot);

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.Disabled)
            Write(Disabled);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosX)
            // methods.txt 中的 ReadInt(bool) 用于读取 32 位整数。假设小端序 (false)。
            PosX = ReadInt(false);

            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosY)
            PosY = ReadInt(false);

            // int ReadInt(bool bigEndian) - 对应 Go 的 io.Int32(&pk.PosZ)
            PosZ = ReadInt(false);

            // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Slot)
            Slot = ReadByte();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.Disabled)
            Disabled = ReadBool();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            PosX = 0;
            PosY = 0;
            PosZ = 0;
            Slot = 0;
            Disabled = false;
        }
    }
}