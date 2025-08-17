using System.Numerics;
using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.Item;
using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;
// 假设您已经有了这些类型：
// public struct Item { ... }
// public struct BlockPos { ... }
// public struct Vector3 { ... } (或使用您选择的数学库如 System.Numerics.Vector3)

public readonly struct LegacySetItemSlot
{
    public byte ContainerID { get; }
    public byte[] Slots { get; }

    public LegacySetItemSlot(byte containerID, byte[] slots)
    {
        ContainerID = containerID;
        Slots = slots ?? Array.Empty<byte>();
    }
}

public readonly struct InventoryAction
{
    public uint SourceType { get; }
    public int WindowID { get; }
    public uint SourceFlags { get; }
    public uint InventorySlot { get; }
    public Item OldItem { get; }
    public Item NewItem { get; }

    public InventoryAction(uint sourceType, int windowID, uint sourceFlags,
        uint inventorySlot, Item oldItem, Item newItem)
    {
        SourceType = sourceType;
        WindowID = windowID;
        SourceFlags = sourceFlags;
        InventorySlot = inventorySlot;
        OldItem = oldItem;
        NewItem = newItem;
    }
}

public readonly struct UseItemTransactionData
{
    public int LegacyRequestID { get; }
    public LegacySetItemSlot[] LegacySetItemSlots { get; }
    public InventoryAction[] Actions { get; }
    public uint ActionType { get; }
    public uint TriggerType { get; }
    public BlockCoordinates BlockPosition { get; }
    public int BlockFace { get; }
    public int HotBarSlot { get; }
    public Item HeldItem { get; }
    public Vector3 Position { get; }
    public Vector3 ClickedPosition { get; }
    public uint BlockRuntimeID { get; }
    public uint ClientPrediction { get; }

    public UseItemTransactionData(
        int legacyRequestID,
        LegacySetItemSlot[] legacySetItemSlots,
        InventoryAction[] actions,
        uint actionType,
        uint triggerType,
        BlockCoordinates blockPosition,
        int blockFace,
        int hotBarSlot,
        Item heldItem,
        Vector3 position,
        Vector3 clickedPosition,
        uint blockRuntimeID,
        uint clientPrediction)
    {
        LegacyRequestID = legacyRequestID;
        LegacySetItemSlots = legacySetItemSlots ?? Array.Empty<LegacySetItemSlot>();
        Actions = actions ?? Array.Empty<InventoryAction>();
        ActionType = actionType;
        TriggerType = triggerType;
        BlockPosition = blockPosition;
        BlockFace = blockFace;
        HotBarSlot = hotBarSlot;
        HeldItem = heldItem;
        Position = position;
        ClickedPosition = clickedPosition;
        BlockRuntimeID = blockRuntimeID;
        ClientPrediction = clientPrediction;
    }
}

/// <summary>
///     表示玩家方块操作的数据结构
/// </summary>
public struct PlayerBlockAction
{
    /// <summary>
    ///     要执行的操作类型（使用预定义的常量值）
    /// </summary>
    public int Action { get; set; }

    /// <summary>
    ///     被交互方块的坐标位置
    /// </summary>
    public BlockCoordinates BlockPos { get; set; }

    /// <summary>
    ///     被交互的方块面（0-5对应上下东西南北）
    /// </summary>
    public int Face { get; set; }

    /// <summary>
    ///     初始化玩家方块操作
    /// </summary>
    /// <param name="action">操作类型</param>
    /// <param name="blockPos">方块位置</param>
    /// <param name="face">方块面</param>
    public PlayerBlockAction(int action, BlockCoordinates blockPos, int face)
    {
        Action = action;
        BlockPos = blockPos;
        Face = face;
    }
}

public class McpePlayerAuthInput : Packet
{
    public enum InputFlags
    {
        InputFlagAscend,
        InputFlagDescend,
        InputFlagNorthJump,
        InputFlagJumpDown,
        InputFlagSprintDown,
        InputFlagChangeHeight,
        InputFlagJumping,
        InputFlagAutoJumpingInWater,
        InputFlagSneaking,
        InputFlagSneakDown,
        InputFlagUp,
        InputFlagDown,
        InputFlagLeft,
        InputFlagRight,
        InputFlagUpLeft,
        InputFlagUpRight,
        InputFlagWantUp,
        InputFlagWantDown,
        InputFlagWantDownSlow,
        InputFlagWantUpSlow,
        InputFlagSprinting,
        InputFlagAscendBlock,
        InputFlagDescendBlock,
        InputFlagSneakToggleDown,
        InputFlagPersistSneak,
        InputFlagStartSprinting,
        InputFlagStopSprinting,
        InputFlagStartSneaking,
        InputFlagStopSneaking,
        InputFlagStartSwimming,
        InputFlagStopSwimming,
        InputFlagStartJumping,
        InputFlagStartGliding,
        InputFlagStopGliding,
        InputFlagPerformItemInteraction,
        InputFlagPerformBlockActions,
        InputFlagPerformItemStackRequest,
        InputFlagHandledTeleport,
        InputFlagEmoting,
        InputFlagMissedSwing,
        InputFlagStartCrawling,
        InputFlagStopCrawling,
        InputFlagStartFlying,
        InputFlagStopFlying,
        InputFlagClientAckServerData,
        InputFlagClientPredictedVehicle,
        InputFlagPaddlingLeft,
        InputFlagPaddlingRight,
        InputFlagBlockBreakingDelayEnabled,
        InputFlagHorizontalCollision,
        InputFlagVerticalCollision,
        InputFlagDownLeft,
        InputFlagDownRight,
        InputFlagStartUsingItem,
        InputFlagCameraRelativeMovementEnabled,
        InputFlagRotControlledByMoveDirection,
        InputFlagStartSpinAttack,
        InputFlagStopSpinAttack,
        InputFlagIsHotbarTouchOnly,
        InputFlagJumpReleasedRaw,
        InputFlagJumpPressedRaw,
        InputFlagJumpCurrentRaw,
        InputFlagSneakReleasedRaw,
        InputFlagSneakPressedRaw,
        InputFlagSneakCurrentRaw
    }

    public enum InputModes
    {
        InputModeMouse = 1,
        InputModeTouch,
        InputModeGamePad,
        InputModeMotionController
    }

    public enum InteractionModels
    {
        InteractionModelTouch,
        InteractionModelCrosshair,
        InteractionModelClassic
    }

    public enum PlayModes
    {
        PlayModeNormal,
        PlayModeTeaser,
        PlayModeScreen,
        PlayModeViewer,
        PlayModeReality,
        PlayModePlacement,
        PlayModeLivingRoom,
        PlayModeExitLevel,
        PlayModeExitLevelLivingRoom,
        PlayModeNumModes
    }

    public const int PlayerAuthInputBitsetSize = 65;
    public float HeadYaw;

    public Bitset InputData;

    public UseItemTransactionData ItemInteractionData;
    public ItemStackRequests ItemStack = new();

    public Vector2 MoveVector;

    public float Pitch, Yaw;

    public PlayerBlockAction[] PlayerBlockAction_;
    public Vector3 Position;

    public McpePlayerAuthInput()
    {
        Id = 0x90;
        IsMcpe = true;
    }

    /// <summary>
    ///     Specifies the input mode the player is using
    /// </summary>
    public uint InputMode { get; set; }

    /// <summary>
    ///     Specifies the way that the player is playing
    /// </summary>
    public uint PlayMode { get; set; }

    /// <summary>
    ///     Represents the interaction model the player is using
    /// </summary>
    public uint InteractionModel { get; set; }

    /// <summary>
    ///     The pitch angle for interactions (may differ from view pitch in VR/custom cameras)
    /// </summary>
    public float InteractPitch { get; set; }

    /// <summary>
    ///     The yaw angle for interactions (may differ from view yaw in VR/custom cameras)
    /// </summary>
    public float InteractYaw { get; set; }

    /// <summary>
    ///     The server tick at which the packet was sent
    /// </summary>
    public long Tick { get; set; }

    /// <summary>
    ///     The delta between old and new position (can be calculated server-side)
    /// </summary>
    public Vector3 Delta { get; set; }

    /// <summary>
    ///     载具旋转角度（使用Vector2表示）
    /// </summary>
    public Vector2 VehicleRotation { get; set; }

    /// <summary>
    ///     客户端预测的载具唯一ID
    /// </summary>
    public long ClientPredictedVehicle { get; set; }

    /// <summary>
    ///     模拟移动方向向量（X/Z值组合）
    /// </summary>
    public Vector2 AnalogueMoveVector { get; set; }

    /// <summary>
    ///     摄像机方向向量（三维）
    /// </summary>
    public Vector3 CameraOrientation { get; set; }

    /// <summary>
    ///     原始移动向量（未经处理的输入值）
    /// </summary>
    public Vector2 RawMoveVector { get; set; }

    protected override void EncodePacket()
    {
        base.EncodePacket();

        Write(Pitch);
        Write(Yaw);
        Write(Position);
        Write(MoveVector);
        Write(HeadYaw);

        // WriteBitset 需要你自己实现
        WriteBitset(InputData, PlayerAuthInputBitsetSize);

        WriteUnsignedVarInt(InputMode);
        WriteUnsignedVarInt(PlayMode);
        WriteUnsignedVarInt(InteractionModel);
        Write(InteractPitch);
        Write(InteractYaw);
        WriteUnsignedVarLong(Tick);
        Write(Delta);

        // 条件性写入
        if (InputData.Load((int)InputFlags.InputFlagPerformItemInteraction))
            WriteUseItemTransactionData(ItemInteractionData);

        if (InputData.Load((int)InputFlags.InputFlagPerformItemStackRequest))
            // methods.txt 中有 Write(ItemStackRequests requests)
            Write(ItemStack);

        if (InputData.Load((int)InputFlags.InputFlagPerformBlockActions))
        {
            // 对应 Go 的 protocol.SliceVarint32Length(io, &pk.BlockActions)
            // 1. 写入数组长度 (varint32)
            WriteSignedVarInt(PlayerBlockAction_?.Length ?? 0);
            // 2. 遍历并写入每个元素
            if (PlayerBlockAction_ != null)
                foreach (var action in PlayerBlockAction_)
                    WritePlayerBlockAction(action);
        }

        if (InputData.Load((int)InputFlags.InputFlagClientPredictedVehicle))
        {
            Write(VehicleRotation);
            WriteSignedVarLong(ClientPredictedVehicle);
        }

        Write(AnalogueMoveVector);
        Write(CameraOrientation);
        Write(RawMoveVector);
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();

        Pitch = ReadFloat();
        Yaw = ReadFloat();
        Position = ReadVector3();
        MoveVector = ReadVector2();
        HeadYaw = ReadFloat();

        // ReadBitset 需要你自己实现
        InputData = ReadBitset(PlayerAuthInputBitsetSize);

        InputMode = ReadUnsignedVarInt();
        PlayMode = ReadUnsignedVarInt();
        InteractionModel = ReadUnsignedVarInt();
        InteractPitch = ReadFloat();
        InteractYaw = ReadFloat();
        Tick = ReadUnsignedVarLong();
        Delta = ReadVector3();

        // 条件性读取
        if (InputData.Load((int)InputFlags.InputFlagPerformItemInteraction))
            ItemInteractionData = ReadUseItemTransactionData();

        // 可以选择重置为默认值或保持原样
        if (InputData.Load((int)InputFlags.InputFlagPerformItemStackRequest))
            // methods.txt 中有 ItemStackRequests ReadItemStackRequests(bool single)
            ItemStack = ReadItemStackRequests(true); // 或 false，取决于具体协议
        else
            ItemStack = new ItemStackRequests();

        if (InputData.Load((int)InputFlags.InputFlagPerformBlockActions))
        {
            // 对应 Go 的 protocol.SliceVarint32Length(io, &pk.BlockActions)
            // 1. 读取数组长度 (varint32)
            var blockActionsCount = ReadSignedVarInt();
            // 2. 创建数组并读取元素
            PlayerBlockAction_ = new PlayerBlockAction[blockActionsCount];
            for (var i = 0; i < blockActionsCount; i++) PlayerBlockAction_[i] = ReadPlayerBlockAction();
        }
        else
        {
            PlayerBlockAction_ = Array.Empty<PlayerBlockAction>();
        }

        if (InputData.Load((int)InputFlags.InputFlagClientPredictedVehicle))
        {
            VehicleRotation = ReadVector2();
            ClientPredictedVehicle = ReadSignedVarLong();
        }
        else
        {
            VehicleRotation = Vector2.Zero;
            ClientPredictedVehicle = 0;
        }

        AnalogueMoveVector = ReadVector2();
        CameraOrientation = ReadVector3();
        RawMoveVector = ReadVector2();
    }

    protected override void ResetPacket()
    {
        base.ResetPacket();

        Pitch = 0.0f;
        Yaw = 0.0f;
        Position = Vector3.Zero;
        MoveVector = Vector2.Zero;
        HeadYaw = 0.0f;
        // Bitset reset logic depends on its implementation
        // InputData = new Bitset(PlayerAuthInputBitsetSize);
        InputMode = (uint)InputModes.InputModeMouse;
        PlayMode = (uint)PlayModes.PlayModeNormal;
        InteractionModel = (uint)InteractionModels.InteractionModelTouch;
        InteractPitch = 0.0f;
        InteractYaw = 0.0f;
        Tick = 0;
        Delta = Vector3.Zero;
        // 结构体通常依赖默认值，引用类型需要显式重置
        // ItemInteractionData = default(UseItemTransactionData);
        ItemStack = new ItemStackRequests();
        PlayerBlockAction_ = Array.Empty<PlayerBlockAction>();
        VehicleRotation = Vector2.Zero;
        ClientPredictedVehicle = 0;
        AnalogueMoveVector = Vector2.Zero;
        CameraOrientation = Vector3.Zero;
        RawMoveVector = Vector2.Zero;
    }


    // --- Bitset ---
    // 你需要根据之前的对话实现 WriteBitset 和 ReadBitset
    // private void WriteBitset(Bitset bitset, int size) { ... }
    // private Bitset ReadBitset(int size) { ... }


    // --- UseItemTransactionData ---
    private void WriteUseItemTransactionData(UseItemTransactionData data)
    {
        // 写入 LegacyRequestID (int32)
        WriteSignedVarInt(data.LegacyRequestID);

        // 写入 LegacySetItemSlots ([]LegacySetItemSlot)
        WriteSignedVarInt(data.LegacySetItemSlots?.Length ?? 0);
        if (data.LegacySetItemSlots != null)
            foreach (var slot in data.LegacySetItemSlots)
                WriteLegacySetItemSlot(slot);

        // 写入 Actions ([]InventoryAction)
        WriteSignedVarInt(data.Actions?.Length ?? 0);
        if (data.Actions != null)
            foreach (var action in data.Actions)
                WriteInventoryAction(action);

        // 写入 ActionType (uint32)
        WriteUnsignedVarInt(data.ActionType);

        // 写入 TriggerType (uint32)
        WriteUnsignedVarInt(data.TriggerType);

        // 写入 BlockPosition (BlockCoordinates)
        // methods.txt 中有 Write(BlockCoordinates coord)
        Write(data.BlockPosition);

        // 写入 BlockFace (int32)
        WriteSignedVarInt(data.BlockFace);

        // 写入 HotBarSlot (int32)
        WriteSignedVarInt(data.HotBarSlot);

        // 写入 HeldItem (Item)
        // methods.txt 中有 Write(Item stack, bool writeUniqueId)
        Write(data.HeldItem); // Adjust 'true' if needed based on Item definition

        // 写入 Position (Vector3)
        Write(data.Position);

        // 写入 ClickedPosition (Vector3)
        Write(data.ClickedPosition);

        // 写入 BlockRuntimeID (uint32)
        WriteUnsignedVarInt(data.BlockRuntimeID);

        // 写入 ClientPrediction (uint32)
        WriteUnsignedVarInt(data.ClientPrediction);
    }

    private UseItemTransactionData ReadUseItemTransactionData()
    {
        // 读取 LegacyRequestID (int32)
        var legacyRequestID = ReadSignedVarInt();

        // 读取 LegacySetItemSlots ([]LegacySetItemSlot)
        var legacySlotsCount = ReadSignedVarInt();
        var legacySlots = new LegacySetItemSlot[legacySlotsCount];
        for (var i = 0; i < legacySlotsCount; i++) legacySlots[i] = ReadLegacySetItemSlot();

        // 读取 Actions ([]InventoryAction)
        var actionsCount = ReadSignedVarInt();
        var actions = new InventoryAction[actionsCount];
        for (var i = 0; i < actionsCount; i++) actions[i] = ReadInventoryAction();

        // 读取 ActionType (uint32)
        var actionType = ReadUnsignedVarInt();

        // 读取 TriggerType (uint32)
        var triggerType = ReadUnsignedVarInt();

        // 读取 BlockPosition (BlockCoordinates)
        // methods.txt 中有 BlockCoordinates ReadBlockCoordinates()
        var blockPosition = ReadBlockCoordinates();

        // 读取 BlockFace (int32)
        var blockFace = ReadSignedVarInt();

        // 读取 HotBarSlot (int32)
        var hotBarSlot = ReadSignedVarInt();

        // 读取 HeldItem (Item)
        // methods.txt 中有 Item ReadItem(bool readUniqueId)
        var heldItem = ReadItem(); // Adjust 'true' if needed

        // 读取 Position (Vector3)
        var position = ReadVector3();

        // 读取 ClickedPosition (Vector3)
        var clickedPosition = ReadVector3();

        // 读取 BlockRuntimeID (uint32)
        var blockRuntimeID = ReadUnsignedVarInt();

        // 读取 ClientPrediction (uint32)
        var clientPrediction = ReadUnsignedVarInt();

        // 使用构造函数创建并返回实例
        return new UseItemTransactionData(
            legacyRequestID,
            legacySlots,
            actions,
            actionType,
            triggerType,
            blockPosition,
            blockFace,
            hotBarSlot,
            heldItem,
            position,
            clickedPosition,
            blockRuntimeID,
            clientPrediction
        );
    }


    // --- LegacySetItemSlot ---
    private void WriteLegacySetItemSlot(LegacySetItemSlot slot)
    {
        // 写入 ContainerID (byte)
        Write(slot.ContainerID);

        // 写入 Slots ([]byte)
        WriteUnsignedVarInt((uint)(slot.Slots?.Length ?? 0));
        if (slot.Slots != null)
            foreach (var s in slot.Slots)
                Write(s); // Write(byte)
    }

    private LegacySetItemSlot ReadLegacySetItemSlot()
    {
        // 读取 ContainerID (byte)
        var containerID = ReadByte(); // methods.txt: byte ReadByte()

        // 读取 Slots ([]byte)
        var slotsCount = ReadUnsignedVarInt(); // 读取长度
        var slots = new byte[slotsCount];
        for (var i = 0; i < slotsCount; i++) slots[i] = ReadByte(); // 读取每个 byte

        // 使用构造函数创建并返回实例
        return new LegacySetItemSlot(containerID, slots);
    }


    // --- InventoryAction ---
    private void WriteInventoryAction(InventoryAction action)
    {
        // 写入 SourceType (uint32)
        WriteUnsignedVarInt(action.SourceType);

        // 写入 WindowID (int32)
        WriteSignedVarInt(action.WindowID);

        // 写入 SourceFlags (uint32)
        WriteUnsignedVarInt(action.SourceFlags);

        // 写入 InventorySlot (uint32)
        WriteUnsignedVarInt(action.InventorySlot);

        // 写入 OldItem (Item)
        // methods.txt 中有 Write(Item stack, bool writeUniqueId)
        Write(action.OldItem); // Adjust 'true' if needed

        // 写入 NewItem (Item)
        Write(action.NewItem); // Adjust 'true' if needed
    }

    private InventoryAction ReadInventoryAction()
    {
        // 读取 SourceType (uint32)
        var sourceType = ReadUnsignedVarInt();

        // 读取 WindowID (int32)
        var windowID = ReadSignedVarInt();

        // 读取 SourceFlags (uint32)
        var sourceFlags = ReadUnsignedVarInt();

        // 读取 InventorySlot (uint32)
        var inventorySlot = ReadUnsignedVarInt();

        // 读取 OldItem (Item)
        // methods.txt 中有 Item ReadItem(bool readUniqueId)
        var oldItem = ReadItem(); // Adjust 'true' if needed

        // 读取 NewItem (Item)
        var newItem = ReadItem(); // Adjust 'true' if needed

        // 使用构造函数创建并返回实例
        return new InventoryAction(sourceType, windowID, sourceFlags, inventorySlot, oldItem, newItem);
    }


    // --- PlayerBlockAction ---
    private void WritePlayerBlockAction(PlayerBlockAction action)
    {
        // 写入 Action (int32)
        WriteSignedVarInt(action.Action);

        // 写入 BlockPos (BlockCoordinates)
        // methods.txt 中有 Write(BlockCoordinates coord)
        Write(action.BlockPos);

        // 写入 Face (int32)
        WriteSignedVarInt(action.Face);
    }

    private PlayerBlockAction ReadPlayerBlockAction()
    {
        // 读取 Action (int32)
        var action = ReadSignedVarInt();

        // 读取 BlockPos (BlockCoordinates)
        // methods.txt 中有 BlockCoordinates ReadBlockCoordinates()
        var blockPos = ReadBlockCoordinates();

        // 读取 Face (int32)
        var face = ReadSignedVarInt();

        // 使用构造函数创建并返回实例
        return new PlayerBlockAction(action, blockPos, face);
    }
}

//public class PlayerBlockActions
//{
//    public List<PlayerBlockActionData> PlayerBlockAction = new();
//}

//public class PlayerBlockActionData
//{
//    public BlockCoordinates BlockCoordinates;
//    public int              Facing;
//    public PlayerAction     PlayerActionType;
//}