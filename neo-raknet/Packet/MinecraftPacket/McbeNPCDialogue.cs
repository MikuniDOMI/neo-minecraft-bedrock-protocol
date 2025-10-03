// Assuming base Packet class is here or adjust accordingly

namespace neo_protocol.Packet.MinecraftPacket;

/// <summary>
///     定义了 NPC 对话框的操作类型。
/// </summary>
public static class NPCDialogueActionType // 或者使用 enum int (更推荐)
{
    /// <summary>
    ///     打开 NPC 对话框。
    /// </summary>
    public const int Open = 0; // int32

    /// <summary>
    ///     关闭 NPC 对话框。
    /// </summary>
    public const int Close = 1; // int32
}

/*
// 推荐使用枚举方式
/// <summary>
/// 定义了 NPC 对话框的操作类型。
/// </summary>
public enum NPCDialogueAction : int // Go's int32, C#'s int is most common for enums
{
    /// <summary>
    /// 打开 NPC 对话框。
    /// </summary>
    Open = 0,

    /// <summary>
    /// 关闭 NPC 对话框。
    /// </summary>
    Close = 1
}
*/

/// <summary>
///     NPCDialogue 数据包：允许客户端显示用于与 NPC 交互的对话框。
/// </summary>
public class McpeNPCDialogue : Packet
{
    /// <summary>
    ///     初始化 McpeNPCDialogue 类的新实例。
    /// </summary>
    public McpeNPCDialogue()
    {
        Id = 169; // IDNPCDialogue
        IsMcpe = true;
    }

    /// <summary>
    ///     EntityUniqueID 是被请求的 NPC 的唯一 ID。
    /// </summary>
    public ulong EntityUniqueID { get; set; } // uint64 -> ulong

    /// <summary>
    ///     ActionType 是数据包的操作类型。
    /// </summary>
    public int ActionType { get; set; } // int32 -> int
    // 如果使用枚举，类型为: public NPCDialogueAction ActionType { get; set; }

    /// <summary>
    ///     Dialogue 是客户端应看到的文本。
    /// </summary>
    public string Dialogue { get; set; } = string.Empty; // string

    /// <summary>
    ///     SceneName 是场景的标识符。如果留空，客户端将使用上次发送给它的场景。
    ///     https://docs.microsoft.com/en-us/minecraft/creator/documents/npcdialogue
    /// </summary>
    public string SceneName { get; set; } = string.Empty; // string

    /// <summary>
    ///     NPCName 是要显示给客户端的 NPC 名称。
    /// </summary>
    public string NPCName { get; set; } = string.Empty; // string

    /// <summary>
    ///     ActionJSON 是服务器可以执行的按钮/操作的 JSON 字符串。
    /// </summary>
    public string ActionJSON { get; set; } = string.Empty; // string

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(ulong value) - 对应 Go 的 io.Uint64(&pk.EntityUniqueID)
        Write(EntityUniqueID);

        // void WriteSignedVarInt(int value) - 对应 Go 的 io.Varint32(&pk.ActionType)
        WriteSignedVarInt(ActionType);
        // 如果使用枚举: WriteSignedVarInt((int)ActionType);

        // void Write(string value) - 对应 Go 的 io.String(&pk.Dialogue)
        Write(Dialogue);

        // void Write(string value) - 对应 Go 的 io.String(&pk.SceneName)
        Write(SceneName);

        // void Write(string value) - 对应 Go 的 io.String(&pk.NPCName)
        Write(NPCName);

        // void Write(string value) - 对应 Go 的 io.String(&pk.ActionJSON)
        Write(ActionJSON);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // ulong ReadUlong() - 对应 Go 的 io.Uint64(&pk.EntityUniqueID)
        EntityUniqueID = ReadUlong();

        // int ReadSignedVarInt() - 对应 Go 的 io.Varint32(&pk.ActionType)
        ActionType = ReadSignedVarInt();
        // 如果使用枚举: ActionType = (NPCDialogueAction)ReadSignedVarInt();

        // string ReadString() - 对应 Go 的 io.String(&pk.Dialogue)
        Dialogue = ReadString();

        // string ReadString() - 对应 Go 的 io.String(&pk.SceneName)
        SceneName = ReadString();

        // string ReadString() - 对应 Go 的 io.String(&pk.NPCName)
        NPCName = ReadString();

        // string ReadString() - 对应 Go 的 io.String(&pk.ActionJSON)
        ActionJSON = ReadString();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        EntityUniqueID = 0;
        ActionType = NPCDialogueActionType.Open; // 或 0 // Reset to default value
        // 如果使用枚举: ActionType = NPCDialogueAction.Open;
        Dialogue = string.Empty;
        SceneName = string.Empty;
        NPCName = string.Empty;
        ActionJSON = string.Empty;
    }
}