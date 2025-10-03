using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeCommandBlockUpdate : Packet
{
    public string command; // = null;
    public uint commandBlockMode; // = null;
    public BlockCoordinates coordinates; // = null;

    public bool isBlock; // = null;
    public bool isConditional; // = null;
    public bool isRedstoneMode; // = null;
    public string lastOutput; // = null;
    public long minecartEntityId; // = null;
    public string name; // = null;
    public bool shouldTrackOutput; // = null;

    public McpeCommandBlockUpdate()
    {
        Id = 0x4e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(isBlock);

        if (isBlock)
        {
            Write(coordinates);
            WriteUnsignedVarInt(commandBlockMode);
            Write(isRedstoneMode);
            Write(isConditional);
        }
        else
        {
            WriteUnsignedVarLong(minecartEntityId);
        }

        Write(command);
        Write(lastOutput);
        Write(name);
        Write(shouldTrackOutput);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        isBlock = ReadBool();

        if (isBlock)
        {
            coordinates = ReadBlockCoordinates();
            commandBlockMode = ReadUnsignedVarInt();
            isRedstoneMode = ReadBool();
            isConditional = ReadBool();
        }
        else
        {
            minecartEntityId = ReadUnsignedVarLong();
        }

        command = ReadString();
        lastOutput = ReadString();
        name = ReadString();
        shouldTrackOutput = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
        coordinates = default;
        commandBlockMode = default;
        isRedstoneMode = default;
        isConditional = default;
        minecartEntityId = default;
        command = default;
        lastOutput = default;
        name = default;
        shouldTrackOutput = default;
        isBlock = default;
    }
}