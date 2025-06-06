using neo_raknet.Packet.MinecraftPacket;
using neo_raknet.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct
{
    public class PlayerData : EntityData
    {
		public IPEndPoint EndPoint { get; private set; }

		private Dictionary<ChunkCoordinates, McpeWrapper> _chunksUsed = new Dictionary<ChunkCoordinates, McpeWrapper>();
		private ChunkCoordinates _currentChunkPosition;

		internal IInventory _openInventory;
		public PlayerInventory Inventory { get; set; }
		public ItemStackInventoryManager ItemStackInventoryManager { get; set; }

		public PlayerLocation SpawnPosition { get; set; }
		public bool IsSleeping { get; set; } = false;

		public int MaxViewDistance { get; set; } = 22;
		public int MoveRenderDistance { get; set; } = 1;

		public GameMode GameMode { get; set; }
		public bool UseCreativeInventory { get; set; } = true;
		public bool IsConnected { get; set; }
		public CertificateData CertificateData { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public long ClientId { get; set; }
		public long CurrentTick { get; set; }
		public UUID ClientUuid { get; set; }
		public string ServerAddress { get; set; }
		public PlayerInfo PlayerInfo { get; set; }

		public Skin Skin { get; set; }

		public float MovementSpeed { get; set; } = 0.1f;
		public ConcurrentDictionary<EffectType, Effect> Effects { get; set; } = new ConcurrentDictionary<EffectType, Effect>();

		public HungerManager HungerManager { get; set; }
		public ExperienceManager ExperienceManager { get; set; }

		public bool IsFalling { get; set; }
		public bool IsFlyingHorizontally { get; set; }
		public AuthInputFlags lastAuthInputFlag { get; set; }

		public Entity LastAttackTarget { get; set; }

		public List<Popup> Popups { get; set; } = new List<Popup>();

		public Session Session { get; set; }

		public DamageCalculator DamageCalculator { get; set; } = new DamageCalculator();

		public TexturePackInfos PlayerPackData { get; set; } = new TexturePackInfos();
		public ResourcePackInfos PlayerPackDataB { get; set; } = new ResourcePackInfos();
		public Dictionary<string, PlayerPackMapData> PlayerPackMap = new Dictionary<string, PlayerPackMapData>();

		public PlayerData(string entityTypeId, Level level) : base(entityTypeId, level)
		{
		}

		protected Form CurrentForm { get; set; } = null;
	}
}
