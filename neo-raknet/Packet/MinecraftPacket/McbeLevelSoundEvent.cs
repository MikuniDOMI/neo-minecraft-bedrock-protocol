using System.Numerics;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeLevelSoundEvent : Packet
{
    public int blockId; // = null;
    public long entityId = -1;
    public string entityType; // = null;
    public bool isBabyMob; // = null;
    public bool isGlobal; // = null;
    public Vector3 position; // = null;

    public uint soundId; // = null;

    public McpeLevelSoundEvent()
    {
        Id = 0x7b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(soundId);
        Write(position);
        WriteSignedVarInt(blockId);
        Write(entityType);
        Write(isBabyMob);
        Write(isGlobal);
        Write(entityId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        soundId = ReadUnsignedVarInt();
        position = ReadVector3();
        blockId = ReadSignedVarInt();
        entityType = ReadString();
        isBabyMob = ReadBool();
        isGlobal = ReadBool();
        entityId = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        soundId = default;
        position = default;
        blockId = default;
        entityType = default;
        isBabyMob = default;
        isGlobal = default;
        entityId = default;
    }
}