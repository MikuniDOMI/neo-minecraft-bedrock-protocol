using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeRequestAbility : Packet{

		public int ability; // = null;

		public McpeRequestAbility()
		{
			Id = 0xb8;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteVarInt(ability);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			ability = ReadVarInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			ability=default(int);
		}

	}
}