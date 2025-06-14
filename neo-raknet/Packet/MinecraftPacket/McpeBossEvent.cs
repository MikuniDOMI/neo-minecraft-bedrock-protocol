namespace neo_raknet.Packet.MinecraftPacket;

public class McpeBossEvent : Packet
{
    public long   bossEntityId; // = null;
    public uint   color = 0xff00ff00;
    public uint   eventType; // = null;
    public float  healthPercent;
    public uint   overlay = 0xff00ff00;
    public long   playerId;
    public string title;
    public ushort unknown6;

    public enum Type
    {
        AddBoss        = 0,
        AddPlayer      = 1,
        RemoveBoss     = 2,
        RemovePlayer   = 3,
        UpdateProgress = 4,
        UpdateName     = 5,
        UpdateOptions  = 6,
        UpdateStyle    = 7,
        Query          = 8
    }

    public McpeBossEvent()
    {
        Id = 0x4a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(bossEntityId);
        WriteUnsignedVarInt(eventType);

        switch ((Type)eventType)
        {
            case Type.AddPlayer:
            case Type.RemovePlayer:
                WriteSignedVarLong(playerId);
                break;

            case Type.UpdateProgress:
                Write(healthPercent);
                break;

            case Type.UpdateName:
                Write(title);
                break;

            case Type.AddBoss:
                Write(title);
                Write(healthPercent);
                goto case Type.UpdateOptions;
            case Type.UpdateOptions:
                Write(unknown6);
                goto case Type.UpdateStyle;
            case Type.UpdateStyle:
                WriteUnsignedVarInt(color);
                WriteUnsignedVarInt(overlay);
                break;
            case Type.Query:
                WriteEntityId(playerId);
                break;
        }
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        bossEntityId = ReadSignedVarLong();
        eventType = ReadUnsignedVarInt();

        switch ((Type)eventType)
        {
            case Type.AddPlayer:
            case Type.RemovePlayer:
                // Entity Unique ID
                playerId = ReadSignedVarLong();
                break;
            case Type.UpdateProgress:
                // float
                healthPercent = ReadFloat();
                break;
            case Type.UpdateName:
                // string
                title = ReadString();
                break;
            case Type.AddBoss:
                // string
                title = ReadString();
                // float
                healthPercent = ReadFloat();
                goto case Type.UpdateOptions;
            case Type.UpdateOptions:
                // ushort?
                unknown6 = ReadUshort();
                goto case Type.UpdateStyle;
            case Type.UpdateStyle:
                // NOOP
                color = ReadUnsignedVarInt();
                overlay = ReadUnsignedVarInt();
                break;
            case Type.Query:
                playerId = ReadSignedVarLong();
                break;
        }
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        bossEntityId = default;
        eventType = default;
    }
}