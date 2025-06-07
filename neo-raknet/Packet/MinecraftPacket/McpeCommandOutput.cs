using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class CommandOutputMessage
{
    public bool IsInternal { get; set; }
    public string MessageId { get; set; }
    public string[] Parameters { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        switch (MessageId)
        {
            case "commands.generic.unknown":
                return $"Unknown command: {Parameters[0]}";
        }

        return $"{{MessageId={MessageId}, IsInternal={IsInternal}, Parameters={string.Join(',', Parameters)}}}";
    }
}

public enum CommandOutputType
{
    Last    = 1,
    Silent  = 2,
    All     = 3,
    DataSet = 4
}

public class McpeCommandOutput : Packet
{
    public McpeCommandOutput()
    {
        Id = 0x4f;
        IsMcpe = true;
    }

    public CommandOriginData OriginData { get; set; }
    public CommandOutputType OutputType { get; set; }
    public uint SuccessCount { get; set; }
    public CommandOutputMessage[] Messages { get; set; }
    public string UnknownString { get; set; }

    protected override void EncodePacket()
    {
        base.EncodePacket();
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        OriginData = ReadOriginData();
        OutputType = (CommandOutputType)ReadByte();
        SuccessCount = ReadUnsignedVarInt();

        var messageCount = ReadUnsignedVarInt();
        Messages = new CommandOutputMessage[messageCount];

        for (var i = 0; i < Messages.Length; i++) Messages[i] = ReadCommandOutputMessage();

        if (OutputType == CommandOutputType.DataSet) UnknownString = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }

    private CommandOriginData ReadOriginData()
    {
        var type = (CommandOriginType)ReadUnsignedVarInt();
        var uuid = ReadUUID();
        var requestId = ReadString();
        var entityId = 0L;
        if (type == CommandOriginType.DevConsole || type == CommandOriginType.Test) entityId = ReadVarLong();

        return new CommandOriginData(type, uuid, requestId, entityId);
    }

    private CommandOutputMessage ReadCommandOutputMessage()
    {
        var result = new CommandOutputMessage();
        result.IsInternal = ReadBool();
        result.MessageId = ReadString();

        var count = ReadUnsignedVarInt();
        result.Parameters = new string[count];

        for (var i = 0; i < result.Parameters.Length; i++) result.Parameters[i] = ReadString();

        return result;
    }
}