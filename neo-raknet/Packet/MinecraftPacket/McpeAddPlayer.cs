using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeAddPlayer : Packet{

		public UUID uuid; // = null;
		public string username; // = null;
		public long runtimeEntityId; // = null;
		public string platformChatId; // = null;
		public float x; // = null;
		public float y; // = null;
		public float z; // = null;
		public float speedX; // = null;
		public float speedY; // = null;
		public float speedZ; // = null;
		public float pitch; // = null;
		public float yaw; // = null;
		public float headYaw; // = null;
		public Item item; // = null;
		public uint gameType; // = null;
		public MetadataDictionary metadata; // = null;
		public PropertySyncData syncdata; // = null;
		public long entityIdSelf; // = null;
		public byte playerPermissions; // = null;
		public byte commandPermissions; // = null;
		public AbilityLayers layers; // = null;
		public EntityLinks links; // = null;
		public string deviceId; // = null;
		public int deviceOs; // = null;

		public McpeAddPlayer()
		{
			Id = 0x0c;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();
			 

			Write(uuid);
			Write(username);
			WriteUnsignedVarLong(runtimeEntityId);
			Write(platformChatId);
			Write(x);
			Write(y);
			Write(z);
			Write(speedX);
			Write(speedY);
			Write(speedZ);
			Write(pitch);
			Write(yaw);
			Write(headYaw);
			Write(item);
			WriteUnsignedVarInt(gameType);
			Write(metadata);
			Write(syncdata);
			Write((ulong)entityIdSelf);
			Write(playerPermissions);
			Write(commandPermissions);
			Write(layers);
			Write(links);
			Write(deviceId);
			Write(deviceOs);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			uuid = ReadUUID();
			username = ReadString();
			runtimeEntityId = ReadUnsignedVarLong();
			platformChatId = ReadString();
			x = ReadFloat();
			y = ReadFloat();
			z = ReadFloat();
			speedX = ReadFloat();
			speedY = ReadFloat();
			speedZ = ReadFloat();
			pitch = ReadFloat();
			yaw = ReadFloat();
			headYaw = ReadFloat();
			item = ReadItem();
			gameType = ReadUnsignedVarInt();
			metadata = ReadMetadataDictionary();
			syncdata = ReadPropertySyncData();
			entityIdSelf = ReadSignedVarLong();
			playerPermissions = ReadByte();
			commandPermissions = ReadByte();
			layers = ReadAbilityLayers();
			links = ReadEntityLinks();
			deviceId = ReadString();
			deviceOs = ReadInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			uuid=default(UUID);
			username=default(string);
			runtimeEntityId=default(long);
			platformChatId=default(string);
			x=default(float);
			y=default(float);
			z=default(float);
			speedX=default(float);
			speedY=default(float);
			speedZ=default(float);
			pitch=default(float);
			yaw=default(float);
			headYaw=default(float);
			item=default(Item);
			gameType=default(uint);
			metadata=default(MetadataDictionary);
			syncdata=default(PropertySyncData);
			entityIdSelf=default(long);
			playerPermissions=default(byte);
			commandPermissions=default(byte);
			layers=default(AbilityLayers);
			links=default(EntityLinks);
			deviceId=default(string);
			deviceOs=default(int);
		}

	}
}