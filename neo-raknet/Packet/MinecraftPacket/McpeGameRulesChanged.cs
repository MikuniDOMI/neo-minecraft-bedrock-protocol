using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeGameRulesChanged : Packet{

		public GameRules rules; // = null;

		public McpeGameRulesChanged()
		{
			Id = 0x48;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(rules);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			rules = ReadGameRules();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			rules=default(GameRules);
		}

	}
}