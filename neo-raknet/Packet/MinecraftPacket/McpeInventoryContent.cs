using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeInventoryContent : Packet{

		public uint inventoryId; // = null;
		public ItemStacks input; // = null;
		public FullContainerName ContainerName = new FullContainerName();
		public Item storageItem; // = null;

		public McpeInventoryContent()
		{
			Id = 0x31;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarInt(inventoryId);
			Write(input);
			Write(ContainerName);
			Write(storageItem);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			inventoryId = ReadUnsignedVarInt();
			input = ReadItemStacks();
			ContainerName = readFullContainerName();
			storageItem = ReadItem();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			inventoryId=default(uint);
			input=default(ItemStacks);
			storageItem=default(Item);
			ContainerName=default(FullContainerName);
		}

	}
}