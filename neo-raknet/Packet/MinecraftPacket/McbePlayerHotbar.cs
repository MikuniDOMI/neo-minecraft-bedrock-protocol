namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlayerHotbar : Packet
{
    public uint selectedSlot; // = null;
    public bool selectSlot; // = null;
    public byte windowId; // = null;

    public McpePlayerHotbar()
    {
        Id = 0x30;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(selectedSlot);
        Write(windowId);
        Write(selectSlot);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        selectedSlot = ReadUnsignedVarInt();
        windowId = ReadByte();
        selectSlot = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        selectedSlot = default;
        windowId = default;
        selectSlot = default;
    }
}