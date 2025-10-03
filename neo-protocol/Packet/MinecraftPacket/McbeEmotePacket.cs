namespace neo_protocol.Packet.MinecraftPacket;

public class McpeEmotePacket : Packet
{
    public string emoteId; // = null;
    public byte flags; // = null;
    public string platformId; // = null;

    public long runtimeEntityId; // = null;
    public uint tick; // = null;
    public string xuid; // = null;

    public McpeEmotePacket()
    {
        Id = 0x8a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(emoteId);
        WriteUnsignedVarInt(tick);
        Write(xuid);
        Write(platformId);
        Write(flags);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        emoteId = ReadString();
        tick = ReadUnsignedVarInt();
        xuid = ReadString();
        platformId = ReadString();
        flags = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        xuid = default;
        platformId = default;
        emoteId = default;
        tick = default;
        flags = default;
    }
}