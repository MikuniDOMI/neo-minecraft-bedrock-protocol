using neo_raknet.Packet.MinecraftStruct.Item;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeMobEquipment : Packet
{
    public Item item; // = null;

    public long runtimeEntityId; // = null;
    public byte selectedSlot; // = null;
    public byte slot; // = null;
    public byte windowsId; // = null;

    public McpeMobEquipment()
    {
        Id = 0x1f;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(item);
        Write(slot);
        Write(selectedSlot);
        Write(windowsId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        item = ReadItem();
        slot = ReadByte();
        selectedSlot = ReadByte();
        windowsId = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        item = default(Item);
        slot = default;
        selectedSlot = default;
        windowsId = default;
    }
}