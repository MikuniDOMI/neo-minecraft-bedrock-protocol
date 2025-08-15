using System;
using System.Numerics; // For Vector3 (mgl32.Vec3) - ADJUST BASED ON YOUR PROJECT
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// 定义了可以被 UpdateClientInputLocks 数据包锁定的客户端输入类型。
    /// </summary>
    public static class ClientInputLocks
    {
        /// <summary>
        /// 锁定相机。如果相机被锁定，玩家无法改变其俯仰角(Pitch)或偏航角(Yaw)。
        /// 对应 Go 中的 ClientInputLockCamera = 1 << (0 + 1) = 1 << 1 = 2
        /// </summary>
        public const uint Camera = 1 << (0 + 1); // 2

        /// <summary>
        /// 锁定移动。如果移动被锁定，玩家无法向任何方向移动，无法跳跃、潜行，
        /// 也无法爬上或爬下任何实体。
        /// 对应 Go 中的 ClientInputLockMovement = 1 << (1 + 1) = 1 << 2 = 4
        /// </summary>
        public const uint Movement = 1 << (1 + 1); // 4
    }

    /// <summary>
    /// UpdateClientInputLocks 数据包：由服务器发送给客户端，用于锁定客户端的相机或物理移动。
    /// </summary>
    public class McpeUpdateClientInputLocks : Packet
    {
        /// <summary>
        /// Locks 是一个位集，用于控制哪些锁定是激活的。它是上面常量的组合。
        /// 如果相机被锁定，那么玩家无法改变他们的俯仰角或偏航角。
        /// 如果移动被锁定，玩家无法向任何方向移动，他们无法跳跃、潜行或爬上/爬下任何实体。
        /// </summary>
        public uint Locks { get; set; } // uint32 -> uint

        /// <summary>
        /// Position 是服务器在发送数据包时的客户端位置。尚不清楚此字段的确切用途。
        /// </summary>
        public Vector3 Position { get; set; } // mgl32.Vec3 -> Vector3

        /// <summary>
        /// 初始化 McpeUpdateClientInputLocks 类的新实例。
        /// </summary>
        public McpeUpdateClientInputLocks()
        {
            Id = 196; // IDUpdateClientInputLocks
            IsMcpe = true;
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // void WriteUnsignedVarInt(uint value) - 对应 Go 的 io.Varuint32(&pk.Locks)
            WriteUnsignedVarInt(Locks);

            // void Write(Vector3 vec) - 对应 Go 的 io.Vec3(&pk.Position)
            Write(Position);
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // uint ReadUnsignedVarInt() - 对应 Go 的 io.Varuint32(&pk.Locks)
            Locks = ReadUnsignedVarInt();

            // Vector3 ReadVector3() - 对应 Go 的 io.Vec3(&pk.Position)
            Position = ReadVector3();
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Locks = 0;
            Position = Vector3.Zero;
        }
    }
}