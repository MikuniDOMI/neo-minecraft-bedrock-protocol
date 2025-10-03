namespace neo_protocol.Packet.MinecraftPacket;

public class McpeBlockPickRequest : Packet
{
    public bool addUserData; // = null;
    public byte selectedSlot; // = null;

    public int x; // = null;
    public int y; // = null;
    public int z; // = null;

    public McpeBlockPickRequest()
    {
        Id = 0x22;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(x);
        WriteSignedVarInt(y);
        WriteSignedVarInt(z);
        Write(addUserData);
        Write(selectedSlot);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        x = ReadSignedVarInt();
        y = ReadSignedVarInt();
        z = ReadSignedVarInt();
        addUserData = ReadBool();
        selectedSlot = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        x = default;
        y = default;
        z = default;
        addUserData = default;
        selectedSlot = default;
    }
}