namespace neo_raknet.Packet.MinecraftPacket;

public class McpeNetworkSettings : Packet
{
    public enum Compression
    {
        Nothing = 0,
        Everything = 1
    }

    public bool clientThrottleEnabled; // = null;
    public float clientThrottleScalar; // = null;
    public byte clientThrottleThreshold; // = null;
    public short compressionAlgorithm; // = null;

    public short compressionThreshold; // = null;

    public McpeNetworkSettings()
    {
        Id = 0x8f;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(compressionThreshold);
        Write(compressionAlgorithm);
        Write(clientThrottleEnabled);
        Write(clientThrottleThreshold);
        Write(clientThrottleScalar);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        compressionThreshold = ReadShort();
        compressionAlgorithm = ReadShort();
        clientThrottleEnabled = ReadBool();
        clientThrottleThreshold = ReadByte();
        clientThrottleScalar = ReadFloat();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        compressionThreshold = default;
        compressionAlgorithm = default;
        clientThrottleEnabled = default;
        clientThrottleThreshold = default;
        clientThrottleScalar = default;
    }
}