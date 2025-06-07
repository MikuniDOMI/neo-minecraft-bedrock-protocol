using neo_raknet.Packet.MinecraftStruct.Item;
using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeInventorySlot : Packet
{
    public FullContainerName ContainerName = new FullContainerName();

    public uint inventoryId; // = null;
    public Item item; // = null;
    public uint slot; // = null;
    public Item storageItem; // = null;

    public McpeInventorySlot()
    {
        Id = 0x32;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(inventoryId);
        WriteUnsignedVarInt(slot);
        Write(ContainerName);
        Write(storageItem);
        Write(item);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        inventoryId = ReadUnsignedVarInt();
        slot = ReadUnsignedVarInt();
        ContainerName = readFullContainerName();
        storageItem = ReadItem();
        item = ReadItem();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        inventoryId = default;
        slot = default;
        ContainerName = default(FullContainerName);
        storageItem = default(Item);
        item = default(Item);
    }
}