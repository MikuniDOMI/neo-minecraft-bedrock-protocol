using neo_protocol.Packet.MinecraftStruct.Item;
using neo_protocol.Utils;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeInventorySlot : Packet
{
    public FullContainerName ContainerName = new();

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
        ContainerName = default;
        storageItem = default;
        item = default;
    }
}