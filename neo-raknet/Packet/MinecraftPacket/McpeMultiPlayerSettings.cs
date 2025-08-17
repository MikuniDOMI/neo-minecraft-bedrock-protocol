namespace neo_raknet.Packet.MinecraftPacket;

public class McpeMultiPlayerSettings : Packet
{
    /// <summary>
    ///     定义多玩家设置操作类型的枚举。
    /// </summary>
    public enum Action
    {
        EnableMultiPlayer = 0, // 启用多人游戏
        DisableMultiPlayer = 1, // 禁用多人游戏
        RefreshJoinCode = 2 // 刷新加入码
    }

    public McpeMultiPlayerSettings()
    {
        Id = 139;
        IsMcpe = true;
    }

    /// <summary>
    ///     操作类型，表示客户端请求执行的动作。
    /// </summary>
    public int ActionType { get; set; }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        WriteSignedVarInt(ActionType);
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        ActionType = ReadSignedVarInt();
    }
}