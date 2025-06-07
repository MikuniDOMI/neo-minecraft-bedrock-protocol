using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeAlexEntityAnimation : Packet
{
    public string         boneId; // = null;
    public AnimationKey[] keys; // = null;

    public long runtimeEntityId; // = null;

    public McpeAlexEntityAnimation()
    {
        Id = 0xe0;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(boneId);
        Write(keys);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        boneId = ReadString();
        keys = ReadAnimationKeys();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        boneId = default;
        keys = default;
    }
}