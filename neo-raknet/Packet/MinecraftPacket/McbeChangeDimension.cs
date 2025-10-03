using System.Numerics;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeChangeDimension : Packet
{
    public int dimension; // = null;
    public Vector3 position; // = null;
    public bool respawn; // = null;

    public McpeChangeDimension()
    {
        Id = 0x3d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(dimension);
        Write(position);
        Write(respawn);
        Write(false);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        dimension = ReadSignedVarInt();
        position = ReadVector3();
        respawn = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        dimension = default;
        position = default;
        respawn = default;
    }
}