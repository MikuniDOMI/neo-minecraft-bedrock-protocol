using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlaySound : Packet
{
    public BlockCoordinates coordinates; // = null;

    public string name; // = null;
    public float  pitch; // = null;
    public float  volume; // = null;

    public McpePlaySound()
    {
        Id = 0x56;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(name);
        Write(coordinates);
        Write(volume);
        Write(pitch);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        name = ReadString();
        coordinates = ReadBlockCoordinates();
        volume = ReadFloat();
        pitch = ReadFloat();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        name = default;
        coordinates = default(BlockCoordinates);
        volume = default;
        pitch = default;
    }
}