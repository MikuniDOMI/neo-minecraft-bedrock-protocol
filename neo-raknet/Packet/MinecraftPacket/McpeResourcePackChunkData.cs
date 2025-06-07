namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePackChunkData : Packet
{
    public uint chunkIndex; // = null;

    public string packageId; // = null;
    public byte[] payload; // = null;
    public ulong  progress; // = null;

    public McpeResourcePackChunkData()
    {
        Id = 0x53;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(packageId);
        Write(chunkIndex);
        Write(progress);
        WriteByteArray(payload);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        packageId = ReadString();
        chunkIndex = ReadUint();
        progress = ReadUlong();
        payload = ReadByteArray();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        packageId = default;
        chunkIndex = default;
        progress = default;
        payload = default;
    }
}