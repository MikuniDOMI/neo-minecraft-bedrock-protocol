namespace neo_raknet.Packet.MinecraftPacket;

public class McpeCompletedUsingItem : Packet
{
    /// <summary>
    ///     定义物品使用方式的枚举（UseMethod）。
    /// </summary>
    public enum UseMethodType
    {
        UseItemEquipArmour = 0,
        UseItemEat = 1,
        UseItemAttack = 2,
        UseItemConsume = 3,
        UseItemThrow = 4,
        UseItemShoot = 5,
        UseItemPlace = 6,
        UseItemFillBottle = 7,
        UseItemFillBucket = 8,
        UseItemPourBucket = 9,
        UseItemUseTool = 10,
        UseItemInteract = 11,
        UseItemRetrieved = 12,
        UseItemDyed = 13,
        UseItemTraded = 14,
        UseItemBrushingCompleted = 15,
        UseItemOpenedVault = 16
    }

    public McpeCompletedUsingItem()
    {
        Id = 141; // 对应 Go 的 PacketIDCompletedUsingItem
        IsMcpe = true;
    }

    /// <summary>
    ///     客户端完成使用的物品的 ID（通常是手中持有的物品 ID）。
    /// </summary>
    public short UsedItemID { get; set; }

    /// <summary>
    ///     完成使用的操作类型（使用方式）。
    /// </summary>
    public int UseMethod { get; set; }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        Write(UsedItemID);
        Write(UseMethod);
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        UsedItemID = ReadShort(); // 对应 Go 的 Int16
        UseMethod = ReadInt(); // 对应 Go 的 Int32
    }
}