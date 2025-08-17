namespace neo_raknet.Packet.MinecraftPacket;

public class McpeRespawn : Packet
{
    public enum RespawnState
    {
        Search = 0,
        Ready = 1,
        ClientReady = 2
    }

    public long runtimeEntityId; // = null;
    public byte state; // = null;

    public float x; // = null;
    public float y; // = null;
    public float z; // = null;

    public McpeRespawn()
    {
        Id = 0x2d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(x);
        Write(y);
        Write(z);
        Write(state);
        WriteUnsignedVarLong(runtimeEntityId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        x = ReadFloat();
        y = ReadFloat();
        z = ReadFloat();
        state = ReadByte();
        runtimeEntityId = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        x = default;
        y = default;
        z = default;
        state = default;
        runtimeEntityId = default;
    }
}