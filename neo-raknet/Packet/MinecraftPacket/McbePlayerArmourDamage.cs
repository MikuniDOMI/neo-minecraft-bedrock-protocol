using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    public class McbePlayerArmourDamage : Packet
    {/// <summary>
        /// Flags indicating which armor pieces should take damage in the HurtArmor packet.
        /// </summary>
        [Flags]
        public enum PlayerArmorDamageFlags : byte
        {
            /// <summary>
            /// No armor piece is damaged.
            /// </summary>
            None = 0,

            /// <summary>
            /// Helmet will take damage.
            /// </summary>
            Helmet = 1 << 0, // 1

            /// <summary>
            /// Chestplate will take damage.
            /// </summary>
            Chestplate = 1 << 1, // 2

            /// <summary>
            /// Leggings will take damage.
            /// </summary>
            Leggings = 1 << 2, // 4

            /// <summary>
            /// Boots will take damage.
            /// </summary>
            Boots = 1 << 3, // 8

            /// <summary>
            /// Body (e.g. horse armor) will take damage.
            /// </summary>
            Body = 1 << 4, // 16
        }
        /// <summary>
        /// Bitset representing damage types or flags (e.g., which armor pieces to damage).
        /// </summary>
        public byte Bitset;

        /// <summary>
        /// The amount of damage that should be dealt to the helmet.
        /// </summary>
        public int HelmetDamage;

        /// <summary>
        /// The amount of damage that should be dealt to the chestplate.
        /// </summary>
        public int ChestplateDamage;

        /// <summary>
        /// The amount of damage that should be dealt to the leggings.
        /// </summary>
        public int LeggingsDamage;

        /// <summary>
        /// The amount of damage that should be dealt to the boots.
        /// </summary>
        public int BootsDamage;

        /// <summary>
        /// The amount of damage that should be dealt to the body (used in some cases like horse armor).
        /// </summary>
        public int BodyDamage;

        public McbePlayerArmourDamage()
        {
            Id = 148;
            IsMcpe = true;
        }

        protected override void EncodePacket()
        {
            base.EncodePacket();
            Write(Bitset);

            // 根据 Bitset 的标志位，有选择地写入各部位伤害值（使用 Signed VarInt 编码）
            if ((Bitset & (byte)PlayerArmorDamageFlags.Helmet) != 0)
            {
                WriteSignedVarInt(HelmetDamage);
            }
            else
            {
                HelmetDamage = 0; // 可选：确保未设置时值为 0
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Chestplate) != 0)
            {
                WriteSignedVarInt(ChestplateDamage);
            }
            else
            {
                ChestplateDamage = 0;
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Leggings) != 0)
            {
                WriteSignedVarInt(LeggingsDamage);
            }
            else
            {
                LeggingsDamage = 0;
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Boots) != 0)
            {
                WriteSignedVarInt(BootsDamage);
            }
            else
            {
                BootsDamage = 0;
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Body) != 0)
            {
                WriteSignedVarInt(BodyDamage);
            }
            else
            {
                BodyDamage = 0;
            }

        }
        protected override void DecodePacket()
        {
            base.DecodePacket();
            Bitset = ReadByte();
            if ((Bitset & (byte)PlayerArmorDamageFlags.Helmet) != 0)
            {
                HelmetDamage = ReadSignedVarInt();
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Chestplate) != 0)
            {
                ChestplateDamage = ReadSignedVarInt();
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Leggings) != 0)
            {
                LeggingsDamage = ReadSignedVarInt();
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Boots) != 0)
            {
                BootsDamage = ReadSignedVarInt();
            }

            if ((Bitset & (byte)PlayerArmorDamageFlags.Body) != 0)
            {
                BodyDamage = ReadSignedVarInt();
            }
        }
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Bitset = default;
            HelmetDamage = default;
            ChestplateDamage = default;
            LeggingsDamage = default;
            BootsDamage = default;
            BodyDamage = default;
        }
}
