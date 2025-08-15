using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// 定义了模拟类型。
    /// </summary>
    public static class SimulationTypes // 或者可以使用 enum byte，但 Go 中是常量 iota，C# 中用 static class 对应
    {
        /// <summary>
        /// 游戏模拟类型。
        /// </summary>
        public const byte Game = 0;

        /// <summary>
        /// 编辑器模拟类型。
        /// </summary>
        public const byte Editor = 1;

        /// <summary>
        /// 测试模拟类型。
        /// </summary>
        public const byte Test = 2;

        /// <summary>
        /// 无效的模拟类型。
        /// </summary>
        public const byte Invalid = 3;
    }

    /*
    // 或者使用枚举 (Enum) 的方式，这通常更符合 C# 习惯
    /// <summary>
    /// 定义了模拟类型。
    /// </summary>
    public enum SimulationTypeType : byte
    {
        /// <summary>
        /// 游戏模拟类型。
        /// </summary>
        Game = 0,

        /// <summary>
        /// 编辑器模拟类型。
        /// </summary>
        Editor = 1,

        /// <summary>
        /// 测试模拟类型。
        /// </summary>
        Test = 2,

        /// <summary>
        /// 无效的模拟类型。
        /// </summary>
        Invalid = 3
    }
    */

    /// <summary>
    /// SimulationType 是一个正在进行中的数据包。我们目前尚不清楚其具体用途。
    /// </summary>
    public class McpeSimulationType : Packet
    {
        /// <summary>
        /// SimulationType 是所选的模拟类型。
        /// </summary>
        public byte SimulationType { get; set; } // byte

        /*
        // 如果使用枚举，则字段定义为：
        // public SimulationTypeType SimulationType { get; set; }
        */

        /// <summary>
        /// 初始化 McpeSimulationType 类的新实例。
        /// </summary>
        public McpeSimulationType()
        {
            Id = 168; // IDSimulationType (根据你之前提供的 ID 列表)
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.SimulationType)
            Write(SimulationType);
            /*
            // 如果使用枚举，则写入时需要转换：
            // Write((byte)SimulationType);
            */
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.SimulationType)
            SimulationType = ReadByte();
            /*
            // 如果使用枚举，则读取时需要转换：
            // SimulationType = (SimulationTypeType)ReadByte();
            */
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            SimulationType = SimulationTypes.Game; // 或 0 // Reset to default value
            /*
            // 如果使用枚举，则重置为：
            // SimulationType = SimulationTypeType.Game;
            */
        }
    }
}