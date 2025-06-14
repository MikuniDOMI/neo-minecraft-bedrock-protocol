using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeUpdateBlock : Packet
{
    public uint blockPriority; // = null;
    public uint blockRuntimeId; // = null;

    public BlockCoordinates coordinates; // = null;
    public uint             storage; // = null;

    public enum Flags
    {
        None        = 0,
        Neighbors   = 1,
        Network     = 2,
        Nographic   = 4,
        Priority    = 8,
        All         = Neighbors | Network,
        AllPriority = All | Priority
    }

    public McpeUpdateBlock()
    {
        Id = 0x15;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(coordinates);
        WriteUnsignedVarInt(blockRuntimeId);
        WriteUnsignedVarInt(blockPriority);
        WriteUnsignedVarInt(storage);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        coordinates = ReadBlockCoordinates();
        blockRuntimeId = ReadUnsignedVarInt();
        blockPriority = ReadUnsignedVarInt();
        storage = ReadUnsignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        coordinates = default(BlockCoordinates);
        blockRuntimeId = default;
        blockPriority = default;
        storage = default;
    }
}