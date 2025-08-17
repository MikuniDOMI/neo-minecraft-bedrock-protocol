namespace neo_raknet.Packet.MinecraftPacket;

public enum SubChunkRequestMode
{
    SubChunkRequestModeLegacy,
    SubChunkRequestModeLimitless,
    SubChunkRequestModeLimited
}

public class McpeLevelChunk : Packet
{
    public ulong[] blobHashes = null;
    public bool cacheEnabled;
    public byte[] chunkData;

    public int chunkX; // = null;
    public int chunkZ; // = null;
    public uint count;

    public int dimension; // = null;

    //public bool subChunkRequestsEnabled;
    public uint subChunkCount;
    public SubChunkRequestMode subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLegacy;

    public McpeLevelChunk()
    {
        Id = 0x3a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(chunkX);
        WriteSignedVarInt(chunkZ);
        WriteSignedVarInt(0); //dimension id. TODO if dimensions will ever be added back again....

        switch (subChunkRequestMode)
        {
            case SubChunkRequestMode.SubChunkRequestModeLegacy:
            {
                WriteUnsignedVarInt(subChunkCount);

                break;
            }

            case SubChunkRequestMode.SubChunkRequestModeLimitless:
            {
                WriteUnsignedVarInt(uint.MaxValue);
                break;
            }

            case SubChunkRequestMode.SubChunkRequestModeLimited:
            {
                WriteUnsignedVarInt(uint.MaxValue - 1);
                Write((ushort)subChunkCount);
                break;
            }
        }

        Write(cacheEnabled);

        if (cacheEnabled)
            foreach (var blobHashe in blobHashes)
                Write(blobHashe);

        WriteByteArray(chunkData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        chunkX = ReadSignedVarInt();
        chunkZ = ReadSignedVarInt();
        dimension = ReadSignedVarInt();

        var subChunkCountButNotReally = ReadUnsignedVarInt();

        switch (subChunkCountButNotReally)
        {
            case uint.MaxValue:
                subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLimitless;
                break;
            case uint.MaxValue - 1:
                subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLimited;
                subChunkCount = ReadUshort();
                break;
            default:
                subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLegacy;
                subChunkCount = subChunkCountButNotReally;
                break;
        }

        cacheEnabled = ReadBool();

        if (cacheEnabled)
        {
            count = ReadUnsignedVarInt();
            for (var i = 0; i < count; i++) blobHashes[i] = ReadUlong();
        }

        chunkData = ReadByteArray();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        chunkX = default;
        chunkZ = default;
        dimension = default;
    }
}