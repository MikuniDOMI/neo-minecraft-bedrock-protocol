using neo_raknet.Packet.MinecraftPacket;
using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.Item;
using System.Numerics;

namespace neo_raknet.Utils
{
	public class ItemStackRequests : List<ItemStackActionList>
	{
	}

	public class ItemStackActionList : List<ItemStackAction>
	{
		public int RequestId { get; set; }
        public List<string> filteredString { get; set; } = new List<string>();
		public int FilterCause { get; set; }
    }
    public abstract class ItemStackAction
	{
	}

	public class StackRequestSlotInfo
	{
		public byte ContainerId { get; set; }
		public byte Slot { get; set; }
		public int StackNetworkId { get; set; }
		public int DynamicId { get; set; }
	}

	public class TakeAction : ItemStackAction
	{
		public byte Count { get; set; }
		public StackRequestSlotInfo Source { get; set; }
		public StackRequestSlotInfo Destination { get; set; }
	}

	public class PlaceAction : ItemStackAction
	{
		public byte Count { get; set; }
		public StackRequestSlotInfo Source { get; set; }
		public StackRequestSlotInfo Destination { get; set; }
	}

	public class SwapAction : ItemStackAction
	{
		public StackRequestSlotInfo Source { get; set; }
		public StackRequestSlotInfo Destination { get; set; }
	}

	public class DropAction : ItemStackAction
	{
		public byte Count { get; set; }
		public StackRequestSlotInfo Source { get; set; }
		public bool Randomly { get; set; }
	}

	public class DestroyAction : ItemStackAction
	{
		public byte Count { get; set; }
		public StackRequestSlotInfo Source { get; set; }
	}

	public class ConsumeAction : ItemStackAction
	{
		public byte Count { get; set; }
		public StackRequestSlotInfo Source { get; set; }
	}

	public class CreateAction : ItemStackAction
	{
		public byte ResultSlot { get; set; }
	}

	public class LabTableCombineAction : ItemStackAction
	{
	}

	public class BeaconPaymentAction : ItemStackAction
	{
		public int PrimaryEffect { get; set; }
		public int SecondaryEffect { get; set; }
	}

	public class CraftAction : ItemStackAction
	{
		public uint RecipeNetworkId { get; set; }
		public byte TimesCrafted { get; set; }
	}

	public class CraftAutoAction : ItemStackAction
	{
		public uint RecipeNetworkId { get; set; }
		public byte TimesCrafted { get; set; }
		public byte TimesCrafted2 { get; set; }
		public List<Item> Ingredients { get; set; } = new List<Item>();
	}

	public class CraftCreativeAction : ItemStackAction
	{
		public uint CreativeItemNetworkId { get; set; }
		public byte ClientPredictedResult { get; set; }
	}

	public class CraftRecipeOptionalAction : ItemStackAction
	{
		public uint RecipeNetworkId { get; set; }
		public int FilteredStringIndex { get; set; }
	}

	public class GrindstoneStackRequestAction : ItemStackAction
	{
		public uint RecipeNetworkId { get; set; }
		public int RepairCost { get; set; }
		public byte TimesCrafted { get; set; }
	}

	public class LoomStackRequestAction : ItemStackAction
	{
		public string PatternId { get; set; }
		public byte TimesCrafted { get; set; }
	}

	public class PlaceIntoBundleAction : ItemStackAction
	{

	}

	public class TakeFromBundleAction : ItemStackAction
	{

	}

	public class CraftNotImplementedDeprecatedAction : ItemStackAction
	{
		// nothing
	}

	public class CraftResultDeprecatedAction : ItemStackAction
	{
		public ItemStacks ResultItems { get; set; } = new ItemStacks();
		public byte TimesCrafted { get; set; }
	}

	public class MineBlockAction : ItemStackAction
	{
		public int Slot { get; set; }
		public int Durability { get; set; }
		public int stackNetworkId { get; set; }
	}

	public class ItemStackResponses : List<ItemStackResponse>
	{
	}

	public class ItemStackResponse
	{
		public int RequestId { get; set; }
		public StackResponseStatus Result { get; set; } = StackResponseStatus.Ok;
		public List<StackResponseContainerInfo> ResponseContainerInfos { get; set; } = new List<StackResponseContainerInfo>();
	}

	public enum StackResponseStatus
	{
		Ok = 0x00,
		Error = 0x01
	}

	public class StackResponseContainerInfo
	{
		public byte ContainerId { get; set; }
		public int DynamicId { get; set; }
		public List<StackResponseSlotInfo> Slots { get; set; } = new List<StackResponseSlotInfo>();
	}

	public class StackResponseSlotInfo
	{
		public byte Slot { get; set; }
		public byte HotbarSlot { get; set; }
		public byte Count { get; set; }
		public int StackNetworkId { get; set; }
		public string CustomName { get; set; }
		public string FilteredCustomName { get; set; }
		public int DurabilityCorrection { get; set; }
	}


	/// <summary>
	/// Old transactions
	/// </summary>

	public abstract class Transaction
	{
		public bool HasNetworkIds { get; set; } = false;

		public int RequestId { get; set; }
		public List<RequestRecord> RequestRecords { get; set; } = new List<RequestRecord>();
		public List<TransactionRecord> TransactionRecords { get; set; } = new List<TransactionRecord>();
	}

	public class RequestRecord
	{
		public byte ContainerId { get; set; }
		public List<byte> Slots { get; set; } = new List<byte>();
	}

	public class NormalTransaction : Transaction
	{
	}
	public class InventoryMismatchTransaction : Transaction
	{
	}
	public class ItemUseTransaction : Transaction
	{
		public McpeInventoryTransaction.ItemUseAction ActionType { get; set; }
		public McpeInventoryTransaction.TriggerType TriggerType { get; set; }
		public BlockCoordinates Position { get; set; }
		public int Face { get; set; }
		public int Slot { get; set; }
		public Item Item { get; set; }
		public Vector3 FromPosition { get; set; }
		public Vector3 ClickPosition { get; set; }
		public uint BlockRuntimeId { get; set; }
		public uint ClientPredictedResult { get; set; }
	}
	public class ItemUseOnEntityTransaction : Transaction
	{
		public long EntityId { get; set; }
		public McpeInventoryTransaction.ItemUseOnEntityAction ActionType { get; set; }
		public int Slot { get; set; }
		public Item Item { get; set; }
		public Vector3 FromPosition { get; set; }
		public Vector3 ClickPosition { get; set; }
	}
	public class ItemReleaseTransaction : Transaction
	{
		public McpeInventoryTransaction.ItemReleaseAction ActionType { get; set; }
		public int Slot { get; set; }
		public Item Item { get; set; }
		public Vector3 FromPosition { get; set; }
	}

	public abstract class TransactionRecord
	{
		public int StackNetworkId { get; set; }

		public int Slot { get; set; }
		public Item OldItem { get; set; }
		public Item NewItem { get; set; }
	}

	public class ContainerTransactionRecord : TransactionRecord
	{
		public int InventoryId { get; set; }
	}

	public class GlobalTransactionRecord : TransactionRecord
	{
	}

	public class WorldInteractionTransactionRecord : TransactionRecord
	{
		public int Flags { get; set; } // NoFlag = 0 WorldInteractionRandom = 1
	}

	public class CreativeTransactionRecord : TransactionRecord
	{
		public int InventoryId { get; set; } = 0x79; // Creative
	}

	public class CraftTransactionRecord : TransactionRecord
	{
		public McpeInventoryTransaction.CraftingAction Action { get; set; }
	}

    public static class ContainerSlotIds // Go 中是 iota 从 0 开始的常量
    {
        public const byte ContainerAnvilInput = 0;
        public const byte ContainerAnvilMaterial = 1;
        public const byte ContainerAnvilResultPreview = 2;
        public const byte ContainerSmithingTableInput = 3;
        public const byte ContainerSmithingTableMaterial = 4;
        public const byte ContainerSmithingTableResultPreview = 5;
        public const byte ContainerArmor = 6;
        public const byte ContainerLevelEntity = 7;
        public const byte ContainerBeaconPayment = 8;
        public const byte ContainerBrewingStandInput = 9;
        public const byte ContainerBrewingStandResult = 10;
        public const byte ContainerBrewingStandFuel = 11;
        public const byte ContainerCombinedHotBarAndInventory = 12;
        public const byte ContainerCraftingInput = 13;
        public const byte ContainerCraftingOutputPreview = 14;
        public const byte ContainerRecipeConstruction = 15;
        public const byte ContainerRecipeNature = 16;
        public const byte ContainerRecipeItems = 17;
        public const byte ContainerRecipeSearch = 18;
        public const byte ContainerRecipeSearchBar = 19;
        public const byte ContainerRecipeEquipment = 20;
        public const byte ContainerRecipeBook = 21;
        public const byte ContainerEnchantingInput = 22;
        public const byte ContainerEnchantingMaterial = 23;
        public const byte ContainerFurnaceFuel = 24;
        public const byte ContainerFurnaceIngredient = 25;
        public const byte ContainerFurnaceResult = 26;
        public const byte ContainerHorseEquip = 27;
        public const byte ContainerHotBar = 28;
        public const byte ContainerInventory = 29;
        public const byte ContainerShulkerBox = 30;
        public const byte ContainerTradeIngredientOne = 31;
        public const byte ContainerTradeIngredientTwo = 32;
        public const byte ContainerTradeResultPreview = 33;
        public const byte ContainerOffhand = 34;
        public const byte ContainerCompoundCreatorInput = 35;
        public const byte ContainerCompoundCreatorOutputPreview = 36;
        public const byte ContainerElementConstructorOutputPreview = 37;
        public const byte ContainerMaterialReducerInput = 38;
        public const byte ContainerMaterialReducerOutput = 39;
        public const byte ContainerLabTableInput = 40;
        public const byte ContainerLoomInput = 41;
        public const byte ContainerLoomDye = 42;
        public const byte ContainerLoomMaterial = 43;
        public const byte ContainerLoomResultPreview = 44;
        public const byte ContainerBlastFurnaceIngredient = 45;
        public const byte ContainerSmokerIngredient = 46;
        public const byte ContainerTradeTwoIngredientOne = 47;
        public const byte ContainerTradeTwoIngredientTwo = 48;
        public const byte ContainerTradeTwoResultPreview = 49;
        public const byte ContainerGrindstoneInput = 50;
        public const byte ContainerGrindstoneAdditional = 51;
        public const byte ContainerGrindstoneResultPreview = 52;
        public const byte ContainerStonecutterInput = 53;
        public const byte ContainerStonecutterResultPreview = 54;
        public const byte ContainerCartographyInput = 55;
        public const byte ContainerCartographyAdditional = 56;
        public const byte ContainerCartographyResultPreview = 57;
        public const byte ContainerBarrel = 58;
        public const byte ContainerCursor = 59;
        public const byte ContainerCreatedOutput = 60;
        public const byte ContainerSmithingTableTemplate = 61;
        public const byte ContainerCrafterLevelEntity = 62;
        public const byte ContainerDynamic = 63;
        // ... (根据需要继续添加)
    }

    /// <summary>
    /// 定义了各种容器类型的常量。
    /// 注意：Go 中的 iota - 1 从 -1 开始。
    /// </summary>
    public static class ContainerTypes // Go 中是 iota - 1 从 -1 开始的常量
    {
        public const sbyte ContainerTypeInventory = -1;
        public const sbyte ContainerTypeContainer = 0;
        public const sbyte ContainerTypeWorkbench = 1;
        public const sbyte ContainerTypeFurnace = 2;
        public const sbyte ContainerTypeEnchantment = 3;
        public const sbyte ContainerTypeBrewingStand = 4;
        public const sbyte ContainerTypeAnvil = 5;
        public const sbyte ContainerTypeDispenser = 6;
        public const sbyte ContainerTypeDropper = 7;
        public const sbyte ContainerTypeHopper = 8;
        public const sbyte ContainerTypeCauldron = 9;
        public const sbyte ContainerTypeCartChest = 10;
        public const sbyte ContainerTypeCartHopper = 11;
        public const sbyte ContainerTypeHorse = 12;
        public const sbyte ContainerTypeBeacon = 13;
        public const sbyte ContainerTypeStructureEditor = 14;
        public const sbyte ContainerTypeTrade = 15;
        public const sbyte ContainerTypeCommandBlock = 16;
        public const sbyte ContainerTypeJukebox = 17;
        public const sbyte ContainerTypeArmour = 18;
        public const sbyte ContainerTypeHand = 19;
        public const sbyte ContainerTypeCompoundCreator = 20;
        public const sbyte ContainerTypeElementConstructor = 21;
        public const sbyte ContainerTypeMaterialReducer = 22;
        public const sbyte ContainerTypeLabTable = 23;
        public const sbyte ContainerTypeLoom = 24;
        public const sbyte ContainerTypeLectern = 25;
        public const sbyte ContainerTypeGrindstone = 26;
        public const sbyte ContainerTypeBlastFurnace = 27;
        public const sbyte ContainerTypeSmoker = 28;
        public const sbyte ContainerTypeStonecutter = 29;
        public const sbyte ContainerTypeCartography = 30;
        public const sbyte ContainerTypeHUD = 31;
        public const sbyte ContainerTypeJigsawEditor = 32;
        public const sbyte ContainerTypeSmithingTable = 33;
        public const sbyte ContainerTypeChestBoat = 34;
        public const sbyte ContainerTypeDecoratedPot = 35;
        public const sbyte ContainerTypeCrafter = 36;
        // ... (根据需要继续添加)
    }

    /// <summary>
    /// FullContainerName 包含识别 StackRequestSlotInfo 中容器所需的信息。
    /// </summary>
    public class FullContainerName
    {
        /// <summary>
        /// ContainerID 是槽位所在容器的 ID。
        /// </summary>
        public byte ContainerID { get; set; } // uint8 -> byte

        /// <summary>
        /// DynamicContainerID 是容器的动态 ID（如果容器是动态的）。
        /// 如果容器不是动态的，则此字段应保持未设置状态。
        /// 值为 0 的非可选值被假定为非空。
        /// </summary>
        public Optional<uint> DynamicContainerID { get; set; } // protocol.Optional[uint32] -> Optional<uint> (assuming uint maps to uint32)

        /// <summary>
        /// 初始化 FullContainerName 类的新实例。
        /// </summary>
        public FullContainerName()
        {
            // Optional<T> fields are initialized to their default (unset) state by the Optional<T> struct itself.
        }

        /// <summary>
        /// 初始化 FullContainerName 类的新实例，并指定容器 ID。
        /// </summary>
        /// <param name="containerId">容器 ID。</param>
        public FullContainerName(byte containerId)
        {
            ContainerID = containerId;
        }

        /// <summary>
        /// 初始化 FullContainerName 类的新实例，并指定容器 ID 和动态容器 ID。
        /// </summary>
        /// <param name="containerId">容器 ID。</param>
        /// <param name="dynamicContainerId">动态容器 ID。</param>
        public FullContainerName(byte containerId, uint dynamicContainerId)
        {
            ContainerID = containerId;
            DynamicContainerID = new Optional<uint>(dynamicContainerId);
        }
    }
}
