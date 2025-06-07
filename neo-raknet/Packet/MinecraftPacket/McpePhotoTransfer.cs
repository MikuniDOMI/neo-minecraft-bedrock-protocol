namespace neo_raknet.Packet.MinecraftPacket;

public class McpePhotoTransfer : Packet
{
    public string fileName; // = null;
    public string imageData; // = null;
    public string unknown2; // = null;

    public McpePhotoTransfer()
    {
        Id = 0x63;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(fileName);
        Write(imageData);
        Write(unknown2);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        fileName = ReadString();
        imageData = ReadString();
        unknown2 = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        fileName = default;
        imageData = default;
        unknown2 = default;
    }
}