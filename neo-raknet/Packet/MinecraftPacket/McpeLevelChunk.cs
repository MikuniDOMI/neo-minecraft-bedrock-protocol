using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
    public enum SubChunkRequestMode
    {
        SubChunkRequestModeLegacy,
        SubChunkRequestModeLimitless,
        SubChunkRequestModeLimited
    }
    public partial class McpeLevelChunk : Packet{

		public int     chunkX; // = null;
		public int     chunkZ; // = null;
		public int     dimension; // = null;
        public ulong[] blobHashes = null;
        public byte[]  chunkData  = null;
        public bool    cacheEnabled;
        //public bool subChunkRequestsEnabled;
        public uint                subChunkCount;
        public uint                count;
        public SubChunkRequestMode subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLegacy;

        public McpeLevelChunk()
		{
			Id = 0x3a;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(chunkX);
			WriteSignedVarInt(chunkZ);
			WriteSignedVarInt(0);  //dimension id. TODO if dimensions will ever be added back again....

            switch (subChunkRequestMode)
            {
                case SubChunkRequestMode.SubChunkRequestModeLegacy:
                {
                    WriteUnsignedVarInt(subChunkCount);

                    break;
                }

                case SubChunkRequestMode.SubChunkRequestModeLimitless:
                {
                    WriteUnsignedVarInt(uint.MaxValue);
                    break;
                }

                case SubChunkRequestMode.SubChunkRequestModeLimited:
                {
                    WriteUnsignedVarInt(uint.MaxValue - 1);
                    Write((ushort)subChunkCount);
                    break;
                }
            }

            Write(cacheEnabled);

            if (cacheEnabled)
            {
                foreach (var blobHashe in blobHashes)
                {
                    Write(blobHashe);
                }
            }

            WriteByteArray(chunkData);
        }

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			chunkX = ReadSignedVarInt();
			chunkZ = ReadSignedVarInt();
			dimension = ReadSignedVarInt();

            var subChunkCountButNotReally = ReadUnsignedVarInt();

            switch (subChunkCountButNotReally)
            {
                case uint.MaxValue:
                    subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLimitless;
                    break;
                case uint.MaxValue - 1:
                    subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLimited;
                    subChunkCount = (uint)ReadUshort();
                    break;
                default:
                    subChunkRequestMode = SubChunkRequestMode.SubChunkRequestModeLegacy;
                    subChunkCount = subChunkCountButNotReally;
                    break;
            }

            cacheEnabled = ReadBool();

            if (cacheEnabled)
            {
                count = ReadUnsignedVarInt();
                for (int i = 0; i < count; i++)
                {
                    blobHashes[i] = ReadUlong();
                }
            }

            chunkData = ReadByteArray();
        }

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			chunkX=default(int);
			chunkZ=default(int);
			dimension=default(int);
		}

	}
}