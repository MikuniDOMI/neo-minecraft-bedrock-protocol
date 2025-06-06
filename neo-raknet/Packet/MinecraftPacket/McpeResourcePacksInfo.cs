using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeResourcePacksInfo : Packet{

		public bool mustAccept; // = null;
		public bool hasAddons; // = null;
		public bool hasScripts; // = null;
		public UUID templateUUID; // = null;
		public string templateVersion; // = null;
		public TexturePackInfos texturepacks; // = null;

		public McpeResourcePacksInfo()
		{
			Id = 0x06;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(mustAccept);
			Write(hasAddons);
			Write(hasScripts);
			Write(templateUUID);
			Write(templateVersion);
			Write(texturepacks);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			mustAccept = ReadBool();
			hasAddons = ReadBool();
			hasScripts = ReadBool();
			templateUUID = ReadUUID();
			templateVersion = ReadString();
			texturepacks = ReadTexturePackInfos();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			mustAccept=default(bool);
			hasAddons=default(bool);
			hasScripts=default(bool);
			templateUUID=default(UUID);
			templateVersion=default(string);
			texturepacks =default(TexturePackInfos);
		}

	}
}