namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSettingsCommand : Packet
{
    public McpeSettingsCommand()
    {
        Id = 140;
        IsMcpe = true;
    }

    /// <summary>
    ///     客户端更改设置后发送到服务器的完整命令行。
    ///     例如："/gamerule showcoordinates true"
    /// </summary>
    public string CommandLine { get; set; }

    /// <summary>
    ///     指示客户端是否请求抑制命令执行结果的输出。
    ///     通常为 true，因为客户端不需要确认消息。
    /// </summary>
    public bool SuppressOutput { get; set; }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        Write(CommandLine);
        Write(SuppressOutput);
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        CommandLine = ReadString();
        SuppressOutput = ReadBool();
    }
}