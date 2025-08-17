namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetDisplayObjective : Packet
{
    public string criteriaName; // = null;
    public string displayName; // = null;

    public string displaySlot; // = null;
    public string objectiveName; // = null;
    public int sortOrder; // = null;

    public McpeSetDisplayObjective()
    {
        Id = 0x6b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(displaySlot);
        Write(objectiveName);
        Write(displayName);
        Write(criteriaName);
        WriteSignedVarInt(sortOrder);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        displaySlot = ReadString();
        objectiveName = ReadString();
        displayName = ReadString();
        criteriaName = ReadString();
        sortOrder = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        displaySlot = default;
        objectiveName = default;
        displayName = default;
        criteriaName = default;
        sortOrder = default;
    }
}