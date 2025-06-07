using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeCraftingData : Packet
{
    public bool                          isClean; // = null;
    public MaterialReducerRecipe[]       materialReducerRecipes; // = null;
    public PotionContainerChangeRecipe[] potionContainerRecipes; // = null;
    public PotionTypeRecipe[]            potionTypeRecipes; // = null;

    public Recipes recipes; // = null;

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

        recipes = default(Recipes);
        potionTypeRecipes = default;
        potionContainerRecipes = default;
        materialReducerRecipes = default;
        isClean = default;
    }
}