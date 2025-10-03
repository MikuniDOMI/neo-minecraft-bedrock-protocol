namespace neo_protocol.Packet.MinecraftStruct.Entity
{
	public class AbilityLayers : List<AbilityLayer>
	{

	}
    public class AbilityData
    {
        /// <summary>
        /// Unique identifier of the player. It appears it is not required to fill this field
        /// with a correct value. Simply writing 0 seems to work.
        /// </summary>
        public long EntityUniqueID { get; set; }

        /// <summary>
        /// Permission level of the player as it shows up in the player list built up using
        /// the PlayerList packet.
        /// </summary>
        public byte PlayerPermissions { get; set; }

        /// <summary>
        /// Set of permissions that specify what commands a player is allowed to execute.
        /// </summary>
        public byte CommandPermissions { get; set; }

        /// <summary>
        /// Contains all ability layers and their potential values. This should at least have
        /// one entry, being the base layer.
        /// </summary>
        public AbilityLayer[] Layers { get; set; }
        public AbilityData(){}
        public AbilityData(long entityUniqueID, byte playerPermissions, byte commandPermissions, AbilityLayer[] layers)
        {
            EntityUniqueID = entityUniqueID;
            PlayerPermissions = playerPermissions;
            CommandPermissions = commandPermissions;
            Layers = layers;
        }
    }
    }
    public class AbilityLayer
	{
		public AbilityLayerType Type;
		public PlayerAbility Abilities;
		public uint Values;
		public float FlySpeed;
		public float WalkSpeed;
		public float VerticalFlySpeed;
	}
    public static class AbilityDefaults
    {
        public const double BaseFlySpeed = 0.05;
        public const double BaseWalkSpeed = 0.1;
        public const double BaseVerticalFlySpeed = 1.0;
    }
    public enum AbilityLayerType : ushort
    {
        CustomCache = 0,
        Base = 1,
        Spectator = 2,
        Commands = 3,
        Editor = 4,
        LoadingScreen = 5  // 补全缺失的LoadingScreen值
    }

    [Flags]
    public enum PlayerAbility : uint
    {
        Build = 1 << 0,
        Mine = 1 << 1,
        DoorsAndSwitches = 1 << 2,
        OpenContainers = 1 << 3,
        AttackPlayers = 1 << 4,
        AttackMobs = 1 << 5,
        OperatorCommands = 1 << 6,
        Teleport = 1 << 7,
        Invulnerable = 1 << 8,
        Flying = 1 << 9,
        MayFly = 1 << 10,
        InstantBuild = 1 << 11,
        Lightning = 1 << 12,
        FlySpeed = 1 << 13,
        WalkSpeed = 1 << 14,
        Muted = 1 << 15,
        WorldBuilder = 1 << 16,
        NoClip = 1 << 17,
        PrivilegedBuilder = 1 << 18,
        VerticalFlySpeed = 1 << 19,  // 补全缺失的垂直飞行速度能力
        Count = 1 << 20,             // 补全缺失的Count值

        // 修正All的值，包含所有能力标志
        All = (1 << 20) - 1
    }
