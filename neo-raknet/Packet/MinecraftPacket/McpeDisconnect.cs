namespace neo_raknet.Packet.MinecraftPacket;

public class McpeDisconnect : Packet
{
    public uint   failReason; // = null;
    public string filteredMessage; // = null

    public bool   hideDisconnectReason; // = null;
    public string message; // = null;

    public McpeDisconnect()
    {
        Id = 0x05;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(0); //todo
        Write(hideDisconnectReason);
        Write(message);
        Write(filteredMessage);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        failReason = ReadUnsignedVarInt();
        hideDisconnectReason = ReadBool();
        message = ReadString();
        filteredMessage = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        hideDisconnectReason = default;
        message = default;
        failReason = default(int);
    }
}