using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeUpdateAbilities : Packet{

		public long entityUniqueId; // = null;
		public byte playerPermissions; // = null;
		public byte commandPermissions; // = null;
		public AbilityLayers layers; // = null;

		public McpeUpdateAbilities()
		{
			Id = 0xbb;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(entityUniqueId);
			Write(playerPermissions);
			Write(commandPermissions);
			Write(layers);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			entityUniqueId = ReadLong();
			playerPermissions = ReadByte();
			commandPermissions = ReadByte();
			layers = ReadAbilityLayers();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			entityUniqueId=default(long);
			playerPermissions=default(byte);
			commandPermissions=default(byte);
			layers=default(AbilityLayers);
		}

	}
}