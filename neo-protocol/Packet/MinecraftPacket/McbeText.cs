namespace neo_protocol.Packet.MinecraftPacket;

public class McpeText : Packet
{
    public enum ChatTypes
    {
        Raw = 0,
        Chat = 1,
        Translation = 2,
        Popup = 3,
        Jukeboxpopup = 4,
        Tip = 5,
        System = 6,
        Whisper = 7,
        Announcement = 8,
        Json = 9,
        Jsonwhisper = 10,
        Jsonannouncement = 11
    }

    public string filteredMessage; // = null
    public string message; // = null;
    public bool needsTranslation; // = null
    public string[] parameters; // = null
    public string platformChatId; // = null
    public string source; // = null;

    public byte type; // = null;
    public string xuid; // = null

    public McpeText()
    {
        Id = 0x09;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(type);

        Write(needsTranslation);
        var chatType = (ChatTypes)type;
        switch (chatType)
        {
            case ChatTypes.Chat:
            case ChatTypes.Whisper:
            case ChatTypes.Announcement:
                Write(source);
                goto case ChatTypes.Raw;
            case ChatTypes.Raw:
            case ChatTypes.Tip:
            case ChatTypes.System:
            case ChatTypes.Json:
                Write(message);
                break;
            case ChatTypes.Popup:
            case ChatTypes.Translation:
            case ChatTypes.Jukeboxpopup:
                Write(message);
                if (parameters == null)
                {
                    WriteUnsignedVarInt(0);
                }
                else
                {
                    WriteUnsignedVarInt((uint)parameters.Length);
                    foreach (var parameter in parameters) Write(parameter);
                }

                break;
        }

        Write(xuid);
        Write(platformChatId);
        Write(filteredMessage);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        type = ReadByte();

        needsTranslation = ReadBool();

        var chatType = (ChatTypes)type;
        switch (chatType)
        {
            case ChatTypes.Chat:
            case ChatTypes.Whisper:
            case ChatTypes.Announcement:
                source = ReadString();
                message = ReadString();
                break;
            case ChatTypes.Raw:
            case ChatTypes.Tip:
            case ChatTypes.System:
            case ChatTypes.Json:
            case ChatTypes.Jsonwhisper:
            case ChatTypes.Jsonannouncement:
                message = ReadString();
                break;

            case ChatTypes.Popup:
            case ChatTypes.Translation:
            case ChatTypes.Jukeboxpopup:
                message = ReadString();
                parameters = new string[ReadUnsignedVarInt()];
                for (var i = 0; i < parameters.Length; ++i) parameters[i] = ReadString();
                break;
        }

        xuid = ReadString();
        platformChatId = ReadString();
        filteredMessage = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        type = 0;
        source = null;
        message = null;
        type = default;
    }
}