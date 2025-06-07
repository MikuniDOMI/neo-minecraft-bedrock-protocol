using neo_raknet.Packet;
using neo_raknet.Packet.MinecraftStruct;
namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeTrimData : Packet{

    public List<TrimPattern>  Patterns;
    public List<TrimMaterial> Materials;
        public McpeTrimData()
		{
			Id = 0x12e;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();




			WriteUnsignedVarInt((uint)Patterns.Count);
			foreach (var pattern in Patterns)
			{
				Write(pattern.ItemId);
				Write(pattern.PatternId);
			}

			WriteUnsignedVarInt((uint)Materials.Count);
			foreach (var material in Materials)
			{
				Write(material.MaterialId);
				Write(material.Color);
				Write(material.ItemId);
			}
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			Patterns = new List<TrimPattern>();
			int countPattern = (int)ReadUnsignedVarInt();
			for (int i = 0; i < countPattern; i++)
			{
				TrimPattern pattern = new TrimPattern();
				pattern.ItemId = ReadString();
				pattern.PatternId = ReadString();
				Patterns.Add(pattern);
			}

			Materials = new List<TrimMaterial>();
			int countMaterial = (int)ReadUnsignedVarInt();
			for (int i = 0; i < countMaterial; i++)
			{
				TrimMaterial material = new TrimMaterial();
				material.MaterialId = ReadString();
				material.Color = ReadString();
				material.ItemId = ReadString();
				Materials.Add(material);
			}



		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

		}

	}
}