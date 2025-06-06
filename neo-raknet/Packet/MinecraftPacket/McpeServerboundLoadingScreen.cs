using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeServerboundLoadingScreen : Packet{
		public int ScreenType; // = null;
		public int? ScreenId; // = null;

		public McpeServerboundLoadingScreen()
		{
			Id = 0x138;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(ScreenType);
			Write(ScreenId.HasValue);
			if (ScreenId.HasValue)
			{
				Write(ScreenId.Value);
			}

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			ScreenType = ReadSignedVarInt();
			if (ReadBool())
			{
				ScreenId = ReadInt();
			}

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			ScreenType = default(int);
			ScreenId = default(int);
		}

	}
}