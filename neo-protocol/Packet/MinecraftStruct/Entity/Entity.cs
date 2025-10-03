using System.Collections.Concurrent;
using System.Numerics;

namespace neo_protocol.Packet.MinecraftStruct.Entity;

public class Entity
{
    public enum MetadataFlags
    {
        EntityFlags = 0,
        StructuralInt = 1,
        Variant = 2,
        Color = 3,
        NameTag = 4,
        Owner = 5,
        Target = 6,
        AvailableAir = 7,
        PotionColor = 8,
        Unknown = 9,
        Unknown2 = 10,
        Hurt = 11,
        HurtDirection = 12,
        RowTimeLeft = 13,
        RowTimeRight = 14,
        ExperienceValue = 15,
        TileRuntimeId = 16,
        Offset = 17,
        CustomDisplay = 18,
        Swell = 19,
        OldSwel = 20,
        SwellDirection = 21,
        ChargeAmount = 22,
        CarryBlockRumtimeId = 23,
        EntityAge = 24,
        UsingItem = 25,
        PlayerFlags = 26,
        PlayerIndex = 27,
        BedPosition = 28,
        XPower = 29,
        YPower = 30,
        ZPower = 31,
        AuxPower = 32,
        FishX = 33,
        FishY = 34,
        FishAngle = 35,
        AuxValueData = 36,
        LeashHolder = 37,
        Scale = 38,
        HasNpc = 39,
        NpcData = 40,
        Actions = 41,
        MaxAir = 42,
        Markings = 43,
        ContainerType = 44,
        ContainerSize = 45,
        ContainerStrenght = 46,
        BlockTarget = 47,
        InvulnerableTicks = 48,
        TargetA = 49,
        TargetB = 50,
        TargetC = 51,
        AerialAttack = 52,
        CollisionBoxWidth = 53,
        CollisionBoxHeight = 54,
        DataFuseLength = 55,
        RiderSeatPosition = 56,
        RiderRotationLocked = 57,
        RiderMaxRotation = 58,
        RiderMinRotation = 59,
        RiderRotationOffset = 60,
        DataRadius = 61,
        DataWaiting = 62,
        DataParticle = 63,
        PeekId = 64,
        AttachFace = 65,
        Attached = 66,
        AttachPos = 67,
        TradeTarget = 68,
        Career = 69,
        HasCommandBlock = 70,
        CommandName = 71,
        LastCommandOutput = 72,
        TrackCommandOutput = 73,
        Unknown5 = 74,
        Strenght = 75,
        MaxStrenght = 76,
        DataCastingColor = 77,
        DataLifetimeTicks = 78,
        PoseIndex = 79,
        DataTickOffset = 80,
        AlwaysShowNameTag = 81,
        Color2Index = 82,
        AuthorName = 83,
        Score = 84,
        BalloonAnchor = 86,
        BubbleTime = 87,
        Agent = 88,
        SittingAmount = 89,
        SittingAmountPrevious = 90,
        EatingCounter = 91,
        EntityFlags2 = 92,
        LayingAmount = 93,
        LayingAmountPrevious = 94,
        DataDuration = 95,
        DataSpawnTime = 96,
        DataChangeRate = 97,
        DataChangeOnPickup = 98,
        DataPickupCount = 99,
        InteractTect = 100,
        TradeTier = 101,
        MaxTradeTier = 102,
        TradeExperience = 103,
        SkinIn = 104,
        SpawningFrames = 105,
        CommandBockTickDelay = 106,
        CommandBlockOnFirstTick = 107,
        AmbientSoundInterval = 108,
        AmbientSoundIntervalRange = 109,
        AmbientSoundEventName = 110,
        FallDamageMultiplier = 111,
        NameRawText = 112,
        CanRideTarget = 113,
        LowCuredDiscount = 114,
        HighCuredDiscount = 115,
        NearbyCuredDiscount = 116,
        NearbyCuredDiscountTime = 117,
        Hitbox = 118,
        IsBuoyant = 119,
        FreezingEffectStrenght = 120,
        BuoyancyData = 121,
        GoatHornCount = 122,
        BaseRuntimeId = 123,
        MovementSoundDistanceOffset = 124,
        HeartbeatSoundDistanceOffset = 125,
        HeartbeatSoundEvent = 126,
        LastDeathPosition = 127,
        LastDeathDimension = 128,
        HasDied = 129,
        CollisionBox = 130,
        VisibleMobEffects = 131,
        FilteredName = 132,
        EnterBedPosition = 133,
        Count = 134
    }

    public Entity(string entityTypeId, Level level)
    {
        EntityId = 0; //TODO: wait for complete 
        EntityTypeId = entityTypeId;
        KnownPosition = new PlayerLocation();
        LastSentPosition = new PlayerLocation();
    }

    public Entity(EntityType entityTypeId, Level level) : this(entityTypeId.ToStringId(), level)
    {
    }

    public Entity(int entityTypeId, Level level) : this((EntityType)entityTypeId, level)
    {
    }

    public string EntityTypeId { get; protected set; }
    public long EntityId { get; set; }
    public bool IsSpawned { get; set; }
    public bool CanDespawn { get; set; } = true;

    public DateTime LastUpdatedTime { get; set; }
    public PlayerLocation KnownPosition { get; set; }
    public Vector3 Velocity { get; set; }
    public float PositionOffset { get; set; }
    public bool IsOnGround { get; set; } = true;

    public PlayerLocation LastSentPosition { get; set; }

    public string NameTag { get; set; }

    public bool IsPanicking { get; set; }

    public bool NoAi { get; set; }
    public bool HideNameTag { get; set; } = true;
    public bool Silent { get; set; }
    public bool IsInWater { get; set; } = false;
    public bool IsOutOfWater => !IsInWater;
    public int PotionColor { get; set; }
    public int Variant { get; set; }
    public long Age { get; set; }
    public double Scale { get; set; } = 1.0;
    public virtual double Height { get; set; } = 1;
    public virtual double Width { get; set; } = 1;
    public virtual double Length { get; set; } = 1;
    public double Drag { get; set; } = 0.02;
    public double Gravity { get; set; } = 0.08;
    public int AttackDamage { get; set; } = 2;
    public int Data { get; set; }

    public long PortalDetected { get; set; }

    public Vector3 RiderSeatPosition { get; set; }
    public bool RiderRotationLocked { get; set; }
    public double RiderMaxRotation { get; set; }
    public double RiderMinRotation { get; set; }

    public ConcurrentDictionary<Type, object> PluginStore { get; set; } = new();
}