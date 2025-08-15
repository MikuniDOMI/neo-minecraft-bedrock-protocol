using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly
using System;
using neo_raknet.Packet.MinecraftStruct;

// Assuming BlockCoordinates is defined in your project, e.g.:
// using neo_raknet.Packet.MinecraftStruct; 

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// 定义了 GameTest 请求的旋转角度。
    /// </summary>
    public enum GameTestRequestRotation : byte // uint8 in Go
    {
        /// <summary>
        /// 0 度旋转。
        /// </summary>
        Rotation0 = 0,

        /// <summary>
        /// 90 度旋转。
        /// </summary>
        Rotation90 = 1,

        /// <summary>
        /// 180 度旋转。
        /// </summary>
        Rotation180 = 2,

        /// <summary>
        /// 270 度旋转。
        /// </summary>
        Rotation270 = 3,

        /// <summary>
        /// 360 度旋转（等同于 0 度）。
        /// </summary>
        Rotation360 = 4
    }

    /// <summary>
    /// GameTestRequest 数据包：用于请求运行一个游戏测试 (GameTest)。
    /// </summary>
    public class McpeGameTestRequest : Packet
    {
        /// <summary>
        /// Name 表示测试的名称。
        /// </summary>
        public string Name { get; set; } = string.Empty; // string

        /// <summary>
        /// Rotation 表示测试的旋转角度。它是上面 GameTestRequestRotation 枚举中的一个值。
        /// </summary>
        public GameTestRequestRotation Rotation { get; set; } // uint8 -> GameTestRequestRotation (enum based on byte)

        /// <summary>
        /// Repetitions 表示测试将运行的次数。
        /// </summary>
        public int Repetitions { get; set; } // int32 -> int

        /// <summary>
        /// Position 是测试将被执行的位置。
        /// </summary>
        public BlockCoordinates Position { get; set; } // BlockCoordinates

        /// <summary>
        /// StopOnError 指示当遇到错误时测试是否应立即停止。
        /// </summary>
        public bool StopOnError { get; set; } // bool

        /// <summary>
        /// TestsPerRow ...
        /// </summary>
        public int TestsPerRow { get; set; } // int32 -> int

        /// <summary>
        /// MaxTestsPerBatch ...
        /// </summary>
        public int MaxTestsPerBatch { get; set; } // int32 -> int

        /// <summary>
        /// 初始化 McpeGameTestRequest 类的新实例。
        /// </summary>
        public McpeGameTestRequest()
        {
            Id = 194; // IDGameTestRequest
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.MaxTestsPerBatch)
            WriteSignedVarInt(MaxTestsPerBatch);

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.Repetitions)
            WriteSignedVarInt(Repetitions);

            // void Write(byte value) - 对应 Go 的 io.Uint8(&pk.Rotation)
            // 将枚举值转换为底层 byte 类型进行写入
            Write((byte)Rotation);

            // void Write(bool value) - 对应 Go 的 io.Bool(&pk.StopOnError)
            Write(StopOnError);

            // void Write(BlockCoordinates coord) - 对应 Go 的 io.BlockCoordinates(&pk.Position)
            Write(Position);

            // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.TestsPerRow)
            WriteSignedVarInt(TestsPerRow);

            // void Write(string value) - 对应 Go 的 io.String(&pk.Name)
            Write(Name);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.MaxTestsPerBatch)
            MaxTestsPerBatch = ReadSignedVarInt();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.Repetitions)
            Repetitions = ReadSignedVarInt();

            // byte ReadByte() - 对应 Go 的 io.Uint8(&pk.Rotation)
            // 读取 byte 值并转换为枚举类型
            Rotation = (GameTestRequestRotation)ReadByte();

            // bool ReadBool() - 对应 Go 的 io.Bool(&pk.StopOnError)
            StopOnError = ReadBool();

            // BlockCoordinates ReadBlockCoordinates() - 对应 Go 的 io.BlockCoordinates(&pk.Position)
            Position = ReadBlockCoordinates();

            // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.TestsPerRow)
            TestsPerRow = ReadSignedVarInt();

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
            Rotation = GameTestRequestRotation.Rotation0; // Reset to default enum value
            Repetitions = 0;
            Position = new BlockCoordinates(0, 0, 0); // Or default(BlockCoordinates) if it's a struct
            StopOnError = false;
            TestsPerRow = 0;
            MaxTestsPerBatch = 0;
        }
    }

    // --- 假设的 BlockCoordinates 定义 ---
    // 如果你的项目中没有这个类型，你需要提供它。
    // 这是一个常见的简单定义：
    /*
    public struct BlockCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public BlockCoordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    */
    // --- End of assumed BlockCoordinates definition ---
}