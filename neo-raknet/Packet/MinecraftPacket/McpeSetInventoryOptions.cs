using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeSetInventoryOptions : Packet{

		public int leftTab; // = null;
		public int rightTab; // = null;
		public bool filtering; // = null;
		public int inventoryLayout; // = null;
		public int craftingLayout; // = null;

		public McpeSetInventoryOptions()
		{
			Id = 0x133;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			leftTab = ReadSignedVarInt();
			rightTab = ReadSignedVarInt();
			filtering = ReadBool();
			inventoryLayout = ReadSignedVarInt();
			craftingLayout = ReadSignedVarInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			leftTab = default(int);
			rightTab = default(int);
			filtering = default(bool);
			inventoryLayout = default(int);
			craftingLayout = default(int);

		}

	}
}