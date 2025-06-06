using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeInventorySlot : Packet{

		public uint inventoryId; // = null;
		public uint slot; // = null;
		public FullContainerName ContainerName = new FullContainerName();
		public Item storageItem; // = null;
		public Item item; // = null;

		public McpeInventorySlot()
		{
			Id = 0x32;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarInt(inventoryId);
			WriteUnsignedVarInt(slot);
			Write(ContainerName);
			Write(storageItem);
			Write(item);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			inventoryId = ReadUnsignedVarInt();
			slot = ReadUnsignedVarInt();
			ContainerName = readFullContainerName();
			storageItem = ReadItem();
			item = ReadItem();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			inventoryId=default(uint);
			slot=default(uint);
			ContainerName=default(FullContainerName);
			storageItem = default(Item);
			item =default(Item);
		}

	}
}