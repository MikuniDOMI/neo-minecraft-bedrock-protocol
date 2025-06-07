using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeClientCacheMissResponse : Packet{

    public Dictionary<ulong, byte[]> blobs;
        public McpeClientCacheMissResponse()
		{
			Id = 0x88;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 


			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();




            blobs = new Dictionary<ulong, byte[]>();
            var count = ReadUnsignedVarInt();
            for (int i = 0; i < count; i++)
            {
                ulong hash = ReadUlong();
                byte[] blob = ReadByteArray();
                if (blobs.ContainsKey(hash))
                {
                   continue;
                }
                else
                {
                    blobs.Add(hash, blob);
                }
            }
        }

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

		}

	}
}