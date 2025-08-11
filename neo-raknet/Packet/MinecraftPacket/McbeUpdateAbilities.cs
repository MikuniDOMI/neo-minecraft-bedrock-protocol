using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeUpdateAbilities : Packet
{
    public byte commandPermissions; // = null;

    public long          entityUniqueId; // = null;
    public AbilityLayers layers; // = null;
    public byte          playerPermissions; // = null;

    public McpeUpdateAbilities()
    {
        Id = 0xbb;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(entityUniqueId);
        Write(playerPermissions);
        Write(commandPermissions);
        Write(layers);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entityUniqueId = ReadLong();
        playerPermissions = ReadByte();
        commandPermissions = ReadByte();
        layers = ReadAbilityLayers();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entityUniqueId = default;
        playerPermissions = default;
        commandPermissions = default;
        layers = default(AbilityLayers);
    }
}