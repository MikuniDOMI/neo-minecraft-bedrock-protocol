namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetEntityLink : Packet
{
    public byte linkType; // = null;

    public long  riddenId; // = null;
    public long  riderId; // = null;
    public byte  unknown; // = null;
    public float vehicleAngularVelocity; // = null;

    public enum LinkActions
    {
        Remove    = 0,
        Ride      = 1,
        Passenger = 2
    }

    public McpeSetEntityLink()
    {
        Id = 0x29;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(riddenId);
        WriteSignedVarLong(riderId);
        Write(linkType);
        Write(unknown);
        Write(false);
        Write(vehicleAngularVelocity);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        riddenId = ReadSignedVarLong();
        riderId = ReadSignedVarLong();
        linkType = ReadByte();
        unknown = ReadByte();
        vehicleAngularVelocity = ReadFloat();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        riddenId = default;
        riderId = default;
        linkType = default;
        unknown = default;
        vehicleAngularVelocity = default;
    }
}