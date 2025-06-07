namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetTitle : Packet
{
    public int    fadeInTime; // = null;
    public int    fadeOutTime; // = null;
    public string filteredString; // = null;
    public string platformOnlineId; // = null;
    public int    stayTime; // = null;
    public string text; // = null;

    public int    type; // = null;
    public string xuid; // = null;

    public McpeSetTitle()
    {
        Id = 0x58;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(type);
        Write(text);
        WriteSignedVarInt(fadeInTime);
        WriteSignedVarInt(stayTime);
        WriteSignedVarInt(fadeOutTime);
        Write(xuid);
        Write(platformOnlineId);
        Write(filteredString);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        type = ReadSignedVarInt();
        text = ReadString();
        fadeInTime = ReadSignedVarInt();
        stayTime = ReadSignedVarInt();
        fadeOutTime = ReadSignedVarInt();
        xuid = ReadString();
        platformOnlineId = ReadString();
        filteredString = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        type = default;
        text = default;
        fadeInTime = default;
        stayTime = default;
        fadeOutTime = default;
        xuid = default;
        platformOnlineId = default;
    }
}