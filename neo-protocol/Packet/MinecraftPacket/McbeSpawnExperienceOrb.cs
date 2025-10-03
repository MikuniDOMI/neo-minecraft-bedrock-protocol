using System.Numerics;

namespace neo_protocol.Packet.MinecraftPacket;

public partial class McpeSpawnExperienceOrb : Packet //Deprecated, todo remove, looks like not even working anymore
{
    public int count; // = null;

    public Vector3 position; // = null;

    public McpeSpawnExperienceOrb()
    {
        Id = 0x42;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();

        BeforeEncode();

        Write(position);
        WriteSignedVarInt(count);

        AfterEncode();
    }

    partial void BeforeEncode();
    partial void AfterEncode();

    protected override void DecodePacket()
    {
        base.DecodePacket();

        BeforeDecode();

        position = ReadVector3();
        count = ReadSignedVarInt();

        AfterDecode();
    }

    partial void BeforeDecode();
    partial void AfterDecode();

    protected override void ResetPacket()
    {
        base.ResetPacket();

        position = default;
        count = default;
    }
}