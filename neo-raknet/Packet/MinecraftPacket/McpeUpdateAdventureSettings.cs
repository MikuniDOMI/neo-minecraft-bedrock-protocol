using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeUpdateAdventureSettings : Packet{

		public bool noPvm; // = null;
		public bool noMvp; // = null;
		public bool immutableWorld; // = null;
		public bool showNametags; // = null;
		public bool autoJump; // = null;

		public McpeUpdateAdventureSettings()
		{
			Id = 0xbc;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(noPvm);
			Write(noMvp);
			Write(immutableWorld);
			Write(showNametags);
			Write(autoJump);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			noPvm = ReadBool();
			noMvp = ReadBool();
			immutableWorld = ReadBool();
			showNametags = ReadBool();
			autoJump = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			noPvm=default(bool);
			noMvp=default(bool);
			immutableWorld=default(bool);
			showNametags=default(bool);
			autoJump=default(bool);
		}

	}
}