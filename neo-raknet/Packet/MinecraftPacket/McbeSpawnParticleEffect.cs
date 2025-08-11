using System.Numerics;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSpawnParticleEffect : Packet
{
    public byte    dimensionId; // = null;
    public long    entityId; // = null;
    public string  molangVariablesJson; // = null;
    public string  particleName; // = null;
    public Vector3 position; // = null;

    public McpeSpawnParticleEffect()
    {
        Id = 0x76;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(dimensionId);
        WriteSignedVarLong(entityId);
        Write(position);
        Write(particleName);
        Write(molangVariablesJson);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        dimensionId = ReadByte();
        entityId = ReadSignedVarLong();
        position = ReadVector3();
        particleName = ReadString();
        molangVariablesJson = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        dimensionId = default;
        entityId = default;
        position = default(Vector3);
        particleName = default;
        molangVariablesJson = default;
    }
}