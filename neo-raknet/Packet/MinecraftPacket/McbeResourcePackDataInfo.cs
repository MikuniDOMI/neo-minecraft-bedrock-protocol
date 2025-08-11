namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePackDataInfo : Packet
{
    public uint   chunkCount; // = null;
    public ulong  compressedPackageSize; // = null;
    public byte[] hash; // = null;
    public bool   isPremium; // = null;
    public uint   maxChunkSize; // = null;

    public string packageId; // = null;
    public byte   packType; // = null;

    public McpeResourcePackDataInfo()
    {
        Id = 0x52;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(packageId);
        Write(maxChunkSize);
        Write(chunkCount);
        Write(compressedPackageSize);
        WriteByteArray(hash);
        Write(isPremium);
        Write(packType);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        packageId = ReadString();
        maxChunkSize = ReadUint();
        chunkCount = ReadUint();
        compressedPackageSize = ReadUlong();
        hash = ReadByteArray();
        isPremium = ReadBool();
        packType = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        packageId = default;
        maxChunkSize = default;
        chunkCount = default;
        compressedPackageSize = default;
        hash = default;
        isPremium = default;
        packType = default;
    }
}