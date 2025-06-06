using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeCorrectPlayerMovement : Packet{

		public byte Type; // = null;
		public Vector3 Postition; // = null;
		public Vector3 Velocity; // = null;
		public bool OnGround; // = null;
		public long Tick; // = null;

		public McpeCorrectPlayerMovement()
		{
			Id = 0xA1;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(Type);
			Write(Postition);
			Write(Velocity);
			Write(OnGround);
			WriteUnsignedVarLong(Tick);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			Type = ReadByte();
			Postition = ReadVector3();
			Velocity = ReadVector3();
			OnGround = ReadBool();
			Tick = ReadUnsignedVarLong();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			Type = default(byte);
			Postition = default(Vector3);
			Velocity = default(Vector3);
			OnGround = default(bool);
			Tick = default(long);

		}
	}
}