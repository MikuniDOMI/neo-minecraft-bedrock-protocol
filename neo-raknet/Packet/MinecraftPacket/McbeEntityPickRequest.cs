namespace neo_raknet.Packet.MinecraftPacket;

public class McpeEntityPickRequest : Packet
{
    public bool addUserData; // = null;

    public ulong runtimeEntityId; // = null;
    public byte selectedSlot; // = null;

    public McpeEntityPickRequest()
    {
        Id = 0x23;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(runtimeEntityId);
        Write(selectedSlot);
        Write(addUserData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUlong();
        selectedSlot = ReadByte();
        addUserData = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        selectedSlot = default;
        addUserData = default;
    }
}