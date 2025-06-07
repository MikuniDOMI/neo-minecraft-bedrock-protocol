using neo_raknet.Packet.MinecraftStruct.NBT;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeLevelEventGeneric : Packet
{
    public Nbt eventData; // = null;

    public int eventId; // = null;

    public McpeLevelEventGeneric()
    {
        Id = 0x7c;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(eventId);
        Write(eventData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        eventId = ReadSignedVarInt();
        //eventData = ReadNbt(); todo wrong
        for (byte i = 0; i < 60; i++) //shhhh
            ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        eventId = default;
        eventData = default(Nbt);
    }
}