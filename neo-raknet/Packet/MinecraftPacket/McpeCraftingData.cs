using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeCraftingData : Packet{

		public Recipes recipes; // = null;
		public PotionTypeRecipe[] potionTypeRecipes; // = null;
		public PotionContainerChangeRecipe[] potionContainerRecipes; // = null;
		public MaterialReducerRecipe[] materialReducerRecipes; // = null;
		public bool isClean; // = null;

		public McpeCraftingData()
		{
			Id = 0x34;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(recipes);
			Write(potionTypeRecipes);
			Write(potionContainerRecipes);
			WriteUnsignedVarInt(0);
			Write(isClean);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			recipes = ReadRecipes();
			potionTypeRecipes = ReadPotionTypeRecipes();
			potionContainerRecipes = ReadPotionContainerChangeRecipes();
			materialReducerRecipes = ReadMaterialReducerRecipes();
			isClean = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			recipes=default(Recipes);
			potionTypeRecipes=default(PotionTypeRecipe[]);
			potionContainerRecipes=default(PotionContainerChangeRecipe[]);
			materialReducerRecipes=default(MaterialReducerRecipe[]);
			isClean=default(bool);
		}

	}
}