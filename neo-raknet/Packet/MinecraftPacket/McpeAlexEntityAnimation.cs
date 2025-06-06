using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeAlexEntityAnimation : Packet{

		public long runtimeEntityId; // = null;
		public string boneId; // = null;
		public AnimationKey[] keys; // = null;

		public McpeAlexEntityAnimation()
		{
			Id = 0xe0;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarLong(runtimeEntityId);
			Write(boneId);
			Write(keys);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			runtimeEntityId = ReadUnsignedVarLong();
			boneId = ReadString();
			keys = ReadAnimationKeys();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			runtimeEntityId=default(long);
			boneId=default(string);
			keys=default(AnimationKey[]);
		}

	}
}