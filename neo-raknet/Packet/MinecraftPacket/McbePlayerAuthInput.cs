using System.Numerics;
using neo_protocol.Packet.MinecraftStruct.Block;
using neo_protocol.Packet.MinecraftStruct.Item;
using neo_protocol.Utils;

namespace neo_protocol.Packet.MinecraftPacket;
// �������Ѿ�������Щ���ͣ�
// public struct Item { ... }
// public struct BlockPos { ... }
// public struct Vector3 { ... } (��ʹ����ѡ�����ѧ���� System.Numerics.Vector3)

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
///     ��ʾ��ҷ�����������ݽṹ
/// </summary>
public struct PlayerBlockAction
{
    /// <summary>
    ///     Ҫִ�еĲ������ͣ�ʹ��Ԥ����ĳ���ֵ��
    /// </summary>
    public int Action { get; set; }

    /// <summary>
    ///     ���������������λ��
    /// </summary>
    public BlockCoordinates BlockPos { get; set; }

    /// <summary>
    ///     �������ķ����棨0-5��Ӧ���¶����ϱ���
    /// </summary>
    public int Face { get; set; }

    /// <summary>
    ///     ��ʼ����ҷ������
    /// </summary>
    /// <param name="action">��������</param>
    /// <param name="blockPos">����λ��</param>
    /// <param name="face">������</param>
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
    ///     �ؾ���ת�Ƕȣ�ʹ��Vector2��ʾ��
    /// </summary>
    public Vector2 VehicleRotation { get; set; }

    /// <summary>
    ///     �ͻ���Ԥ����ؾ�ΨһID
    /// </summary>
    public long ClientPredictedVehicle { get; set; }

    /// <summary>
    ///     ģ���ƶ�����������X/Zֵ��ϣ�
    /// </summary>
    public Vector2 AnalogueMoveVector { get; set; }

    /// <summary>
    ///     �����������������ά��
    /// </summary>
    public Vector3 CameraOrientation { get; set; }

    /// <summary>
    ///     ԭʼ�ƶ�������δ������������ֵ��
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

        // WriteBitset ��Ҫ���Լ�ʵ��
        WriteBitset(InputData, PlayerAuthInputBitsetSize);

        WriteUnsignedVarInt(InputMode);
        WriteUnsignedVarInt(PlayMode);
        WriteUnsignedVarInt(InteractionModel);
        Write(InteractPitch);
        Write(InteractYaw);
        WriteUnsignedVarLong(Tick);
        Write(Delta);

        // ������д��
        if (InputData.Load((int)InputFlags.InputFlagPerformItemInteraction))
            WriteUseItemTransactionData(ItemInteractionData);

        if (InputData.Load((int)InputFlags.InputFlagPerformItemStackRequest))
            // methods.txt ���� Write(ItemStackRequests requests)
            Write(ItemStack);

        if (InputData.Load((int)InputFlags.InputFlagPerformBlockActions))
        {
            // ��Ӧ Go �� protocol.SliceVarint32Length(io, &pk.BlockActions)
            // 1. д�����鳤�� (varint32)
            WriteSignedVarInt(PlayerBlockAction_?.Length ?? 0);
            // 2. ������д��ÿ��Ԫ��
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

        // ReadBitset ��Ҫ���Լ�ʵ��
        InputData = ReadBitset(PlayerAuthInputBitsetSize);

        InputMode = ReadUnsignedVarInt();
        PlayMode = ReadUnsignedVarInt();
        InteractionModel = ReadUnsignedVarInt();
        InteractPitch = ReadFloat();
        InteractYaw = ReadFloat();
        Tick = ReadUnsignedVarLong();
        Delta = ReadVector3();

        // �����Զ�ȡ
        if (InputData.Load((int)InputFlags.InputFlagPerformItemInteraction))
            ItemInteractionData = ReadUseItemTransactionData();

        // ����ѡ������ΪĬ��ֵ�򱣳�ԭ��
        if (InputData.Load((int)InputFlags.InputFlagPerformItemStackRequest))
            // methods.txt ���� ItemStackRequests ReadItemStackRequests(bool single)
            ItemStack = ReadItemStackRequests(true); // �� false��ȡ���ھ���Э��
        else
            ItemStack = new ItemStackRequests();

        if (InputData.Load((int)InputFlags.InputFlagPerformBlockActions))
        {
            // ��Ӧ Go �� protocol.SliceVarint32Length(io, &pk.BlockActions)
            // 1. ��ȡ���鳤�� (varint32)
            var blockActionsCount = ReadSignedVarInt();
            // 2. �������鲢��ȡԪ��
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
        // �ṹ��ͨ������Ĭ��ֵ������������Ҫ��ʽ����
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
    // ����Ҫ����֮ǰ�ĶԻ�ʵ�� WriteBitset �� ReadBitset
    // private void WriteBitset(Bitset bitset, int size) { ... }
    // private Bitset ReadBitset(int size) { ... }


    // --- UseItemTransactionData ---
    private void WriteUseItemTransactionData(UseItemTransactionData data)
    {
        // д�� LegacyRequestID (int32)
        WriteSignedVarInt(data.LegacyRequestID);

        // д�� LegacySetItemSlots ([]LegacySetItemSlot)
        WriteSignedVarInt(data.LegacySetItemSlots?.Length ?? 0);
        if (data.LegacySetItemSlots != null)
            foreach (var slot in data.LegacySetItemSlots)
                WriteLegacySetItemSlot(slot);

        // д�� Actions ([]InventoryAction)
        WriteSignedVarInt(data.Actions?.Length ?? 0);
        if (data.Actions != null)
            foreach (var action in data.Actions)
                WriteInventoryAction(action);

        // д�� ActionType (uint32)
        WriteUnsignedVarInt(data.ActionType);

        // д�� TriggerType (uint32)
        WriteUnsignedVarInt(data.TriggerType);

        // д�� BlockPosition (BlockCoordinates)
        // methods.txt ���� Write(BlockCoordinates coord)
        Write(data.BlockPosition);

        // д�� BlockFace (int32)
        WriteSignedVarInt(data.BlockFace);

        // д�� HotBarSlot (int32)
        WriteSignedVarInt(data.HotBarSlot);

        // д�� HeldItem (Item)
        // methods.txt ���� Write(Item stack, bool writeUniqueId)
        Write(data.HeldItem); // Adjust 'true' if needed based on Item definition

        // д�� Position (Vector3)
        Write(data.Position);

        // д�� ClickedPosition (Vector3)
        Write(data.ClickedPosition);

        // д�� BlockRuntimeID (uint32)
        WriteUnsignedVarInt(data.BlockRuntimeID);

        // д�� ClientPrediction (uint32)
        WriteUnsignedVarInt(data.ClientPrediction);
    }

    private UseItemTransactionData ReadUseItemTransactionData()
    {
        // ��ȡ LegacyRequestID (int32)
        var legacyRequestID = ReadSignedVarInt();

        // ��ȡ LegacySetItemSlots ([]LegacySetItemSlot)
        var legacySlotsCount = ReadSignedVarInt();
        var legacySlots = new LegacySetItemSlot[legacySlotsCount];
        for (var i = 0; i < legacySlotsCount; i++) legacySlots[i] = ReadLegacySetItemSlot();

        // ��ȡ Actions ([]InventoryAction)
        var actionsCount = ReadSignedVarInt();
        var actions = new InventoryAction[actionsCount];
        for (var i = 0; i < actionsCount; i++) actions[i] = ReadInventoryAction();

        // ��ȡ ActionType (uint32)
        var actionType = ReadUnsignedVarInt();

        // ��ȡ TriggerType (uint32)
        var triggerType = ReadUnsignedVarInt();

        // ��ȡ BlockPosition (BlockCoordinates)
        // methods.txt ���� BlockCoordinates ReadBlockCoordinates()
        var blockPosition = ReadBlockCoordinates();

        // ��ȡ BlockFace (int32)
        var blockFace = ReadSignedVarInt();

        // ��ȡ HotBarSlot (int32)
        var hotBarSlot = ReadSignedVarInt();

        // ��ȡ HeldItem (Item)
        // methods.txt ���� Item ReadItem(bool readUniqueId)
        var heldItem = ReadItem(); // Adjust 'true' if needed

        // ��ȡ Position (Vector3)
        var position = ReadVector3();

        // ��ȡ ClickedPosition (Vector3)
        var clickedPosition = ReadVector3();

        // ��ȡ BlockRuntimeID (uint32)
        var blockRuntimeID = ReadUnsignedVarInt();

        // ��ȡ ClientPrediction (uint32)
        var clientPrediction = ReadUnsignedVarInt();

        // ʹ�ù��캯������������ʵ��
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
        // д�� ContainerID (byte)
        Write(slot.ContainerID);

        // д�� Slots ([]byte)
        WriteUnsignedVarInt((uint)(slot.Slots?.Length ?? 0));
        if (slot.Slots != null)
            foreach (var s in slot.Slots)
                Write(s); // Write(byte)
    }

    private LegacySetItemSlot ReadLegacySetItemSlot()
    {
        // ��ȡ ContainerID (byte)
        var containerID = ReadByte(); // methods.txt: byte ReadByte()

        // ��ȡ Slots ([]byte)
        var slotsCount = ReadUnsignedVarInt(); // ��ȡ����
        var slots = new byte[slotsCount];
        for (var i = 0; i < slotsCount; i++) slots[i] = ReadByte(); // ��ȡÿ�� byte

        // ʹ�ù��캯������������ʵ��
        return new LegacySetItemSlot(containerID, slots);
    }


    // --- InventoryAction ---
    private void WriteInventoryAction(InventoryAction action)
    {
        // д�� SourceType (uint32)
        WriteUnsignedVarInt(action.SourceType);

        // д�� WindowID (int32)
        WriteSignedVarInt(action.WindowID);

        // д�� SourceFlags (uint32)
        WriteUnsignedVarInt(action.SourceFlags);

        // д�� InventorySlot (uint32)
        WriteUnsignedVarInt(action.InventorySlot);

        // д�� OldItem (Item)
        // methods.txt ���� Write(Item stack, bool writeUniqueId)
        Write(action.OldItem); // Adjust 'true' if needed

        // д�� NewItem (Item)
        Write(action.NewItem); // Adjust 'true' if needed
    }

    private InventoryAction ReadInventoryAction()
    {
        // ��ȡ SourceType (uint32)
        var sourceType = ReadUnsignedVarInt();

        // ��ȡ WindowID (int32)
        var windowID = ReadSignedVarInt();

        // ��ȡ SourceFlags (uint32)
        var sourceFlags = ReadUnsignedVarInt();

        // ��ȡ InventorySlot (uint32)
        var inventorySlot = ReadUnsignedVarInt();

        // ��ȡ OldItem (Item)
        // methods.txt ���� Item ReadItem(bool readUniqueId)
        var oldItem = ReadItem(); // Adjust 'true' if needed

        // ��ȡ NewItem (Item)
        var newItem = ReadItem(); // Adjust 'true' if needed

        // ʹ�ù��캯������������ʵ��
        return new InventoryAction(sourceType, windowID, sourceFlags, inventorySlot, oldItem, newItem);
    }


    // --- PlayerBlockAction ---
    private void WritePlayerBlockAction(PlayerBlockAction action)
    {
        // д�� Action (int32)
        WriteSignedVarInt(action.Action);

        // д�� BlockPos (BlockCoordinates)
        // methods.txt ���� Write(BlockCoordinates coord)
        Write(action.BlockPos);

        // д�� Face (int32)
        WriteSignedVarInt(action.Face);
    }

    private PlayerBlockAction ReadPlayerBlockAction()
    {
        // ��ȡ Action (int32)
        var action = ReadSignedVarInt();

        // ��ȡ BlockPos (BlockCoordinates)
        // methods.txt ���� BlockCoordinates ReadBlockCoordinates()
        var blockPos = ReadBlockCoordinates();

        // ��ȡ Face (int32)
        var face = ReadSignedVarInt();

        // ʹ�ù��캯������������ʵ��
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