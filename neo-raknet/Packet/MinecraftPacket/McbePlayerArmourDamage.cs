namespace neo_raknet.Packet.MinecraftPacket;
/// <summary>
/// PlayerArmourDamageEntry 代表对玩家护甲槽位的伤害信息。
/// </summary>
public struct PlayerArmourDamageEntry
{
    /// <summary>
    /// ArmourSlot 是要损坏的护甲槽位的索引。
    /// </summary>
    public byte ArmourSlot { get; set; } // uint8 -> byte

    /// <summary>
    /// Damage 是要对指定槽位中的护甲应用的伤害量。
    /// </summary>
    public short Damage { get; set; } // int16 -> short

    /// <summary>
    /// 初始化 PlayerArmourDamageEntry 结构的新实例。
    /// </summary>
    /// <param name="armourSlot">护甲槽位索引。</param>
    /// <param name="damage">伤害量。</param>
    public PlayerArmourDamageEntry(byte armourSlot, short damage)
    {
        ArmourSlot = armourSlot;
        Damage = damage;
    }
}
public class McbePlayerArmourDamage : Packet
{
    /// <summary>
    ///     Flags indicating which armor pieces should take damage in the HurtArmor packet.
    /// </summary>
    [Flags]
    public enum PlayerArmorDamageFlags : byte
    {
       

        /// <summary>
        ///     Helmet will take damage.
        /// </summary>
        Helmet = 0,

        /// <summary>
        ///     Chestplate will take damage.
        /// </summary>
        Chestplate =  1,

        /// <summary>
        ///     Leggings will take damage.
        /// </summary>
        Leggings = 2, 

        /// <summary>
        ///     Boots will take damage.
        /// </summary>
        Boots = 3, 

        /// <summary>
        ///     Body (e.g. horse armor) will take damage.
        /// </summary>
        Body = 4 
    }

    public List<PlayerArmourDamageEntry> playerArmourDamageEntries;

    public McbePlayerArmourDamage()
    {
        Id = 148;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        int count = playerArmourDamageEntries?.Count ?? 0;
        WriteVarInt(count);
        foreach (var entry in playerArmourDamageEntries)
        {
                Write(entry.ArmourSlot);
                Write(entry.Damage);
        }
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        playerArmourDamageEntries = new List<PlayerArmourDamageEntry>();
        int count = ReadVarInt();
        for (int i = 0; i < count; i++)
        {
            byte armourSlot = ReadByte();
            short damage = ReadShort();
            playerArmourDamageEntries.Add(new PlayerArmourDamageEntry(armourSlot, damage));
        }
    }

    protected override void ResetPacket()
    {
        base.ResetPacket();
        playerArmourDamageEntries = default;
    }
}