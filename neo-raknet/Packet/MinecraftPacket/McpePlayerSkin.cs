using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpePlayerSkin : Packet{

		public UUID uuid; // = null;
		public Skin skin; // = null;
		public string skinName; // = null;
		public string oldSkinName; // = null;
		public bool isVerified; // = null;

		public McpePlayerSkin()
		{
			Id = 0x5d;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(uuid);
			Write(skin);
			Write(skinName);
			Write(oldSkinName);
			Write(isVerified);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			uuid = ReadUUID();
			skin = ReadSkin();
			skinName = ReadString();
			oldSkinName = ReadString();
			isVerified = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			uuid=default(UUID);
			skin=default(Skin);
			skinName=default(string);
			oldSkinName=default(string);
			isVerified=default(bool);
		}

	}
}