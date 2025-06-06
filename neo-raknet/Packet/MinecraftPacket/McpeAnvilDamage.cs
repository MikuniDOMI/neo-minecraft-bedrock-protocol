using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeAnvilDamage : Packet{

		public byte damageAmount; // = null;
		public BlockCoordinates coordinates; // = null;

		public McpeAnvilDamage()
		{
			Id = 0x8D;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(damageAmount);
			Write(coordinates);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			damageAmount = ReadByte();
			coordinates = ReadBlockCoordinates();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			damageAmount = default(byte);
			coordinates = default(BlockCoordinates);

		}
	}
}