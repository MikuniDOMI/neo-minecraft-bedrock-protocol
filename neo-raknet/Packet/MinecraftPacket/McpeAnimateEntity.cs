using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeAnimateEntity : Packet{

		public string animationName; // = null;
		public string nextState; // = null;
		public string stopExpression; // = null;
		public int molangVersion; // = null;
		public string controllerName; // = null;
		public float blendOutTime; // = null;
		public long[] entities; // = null;

		public McpeAnimateEntity()
		{
			Id = 0x9e;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(animationName);
			Write(nextState);
			Write(stopExpression);
			Write(molangVersion);
			Write(controllerName);
			Write(blendOutTime);
			WriteUnsignedVarInt((uint)entities.Count());
			for (int i = 0; i < entities.Count(); i++)
			{
				WriteUnsignedVarLong(entities[i]);
			}

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			animationName = ReadString();
			nextState = ReadString();
			stopExpression = ReadString();
			molangVersion = ReadInt();
			controllerName = ReadString();
			blendOutTime = ReadFloat();
			for (int i = 0; i < ReadUnsignedVarInt(); i++)
			{
				entities[i] = ReadUnsignedVarLong();
			}

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			animationName = default(string);
			nextState = default(string);
			stopExpression = default(string);
			molangVersion = default(int);
			controllerName = default(string);
			blendOutTime = default(float);
			entities = default(long[]);
		}
	}
}