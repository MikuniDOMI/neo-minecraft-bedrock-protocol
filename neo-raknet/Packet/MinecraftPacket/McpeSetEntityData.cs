using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeSetEntityData : Packet{

		public long runtimeEntityId; // = null;
		public MetadataDictionary metadata; // = null;
		public PropertySyncData syncdata; // = null;
		public long tick; // = null;

		public McpeSetEntityData()
		{
			Id = 0x27;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarLong(runtimeEntityId);
			Write(metadata);
			Write(syncdata);
			WriteUnsignedVarLong(tick);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			runtimeEntityId = ReadUnsignedVarLong();
			metadata = ReadMetadataDictionary();
			syncdata = ReadPropertySyncData();
			tick = ReadUnsignedVarLong();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			runtimeEntityId=default(long);
			metadata=default(MetadataDictionary);
			syncdata=default(PropertySyncData);
			tick=default(long);
		}

	}
}