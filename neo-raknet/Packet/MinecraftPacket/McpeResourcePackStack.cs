using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeResourcePackStack : Packet{

		public bool mustAccept; // = null;
		public ResourcePackIdVersions behaviorpackidversions; // = null;
		public ResourcePackIdVersions resourcepackidversions; // = null;
		public string gameVersion; // = null;
		public Experiments experiments; // = null;
		public bool experimentsPreviouslyToggled; // = null;
		public bool hasEditorPacks; // = null;

		public McpeResourcePackStack()
		{
			Id = 0x07;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(mustAccept);
			Write(behaviorpackidversions);
			Write(resourcepackidversions);
			Write(gameVersion);
			Write(experiments);
			Write(experimentsPreviouslyToggled);
			Write(hasEditorPacks);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			mustAccept = ReadBool();
			behaviorpackidversions = ReadResourcePackIdVersions();
			resourcepackidversions = ReadResourcePackIdVersions();
			gameVersion = ReadString();
			experiments = ReadExperiments();
			experimentsPreviouslyToggled = ReadBool();
			hasEditorPacks = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			mustAccept=default(bool);
			behaviorpackidversions=default(ResourcePackIdVersions);
			resourcepackidversions=default(ResourcePackIdVersions);
			gameVersion=default(string);
			experiments=default(Experiments);
			experimentsPreviouslyToggled=default(bool);
			hasEditorPacks=default(bool);
		}

	}
}