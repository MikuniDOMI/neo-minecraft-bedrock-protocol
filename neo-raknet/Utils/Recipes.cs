﻿using neo_raknet.Packet.MinecraftStruct.Item;

namespace neo_raknet.Utils;

public class Recipes : List<Recipe>
{
}

public abstract class Recipe
{
    public UUID Id { get; set; } = new(Guid.NewGuid().ToString());
    public string Block { get; set; }
}

/// <summary>
///     These are recipe keys to indicate special recipe actions that doesn't
///     fit into normal recipes.
/// </summary>
public class MultiRecipe : Recipe
{
    // From PMMP
    //public const TYPE_REPAIR_ITEM = "00000000-0000-0000-0000-000000000001";
    //public const TYPE_MAP_EXTENDING = "D392B075-4BA1-40AE-8789-AF868D56F6CE";
    //public const TYPE_MAP_EXTENDING_CARTOGRAPHY = "8B36268C-1829-483C-A0F1-993B7156A8F2";
    //public const TYPE_MAP_CLONING = "85939755-BA10-4D9D-A4CC-EFB7A8E943C4";
    //public const TYPE_MAP_CLONING_CARTOGRAPHY = "442D85ED-8272-4543-A6F1-418F90DED05D";
    //public const TYPE_MAP_UPGRADING = "AECD2294-4B94-434B-8667-4499BB2C9327";
    //public const TYPE_MAP_UPGRADING_CARTOGRAPHY = "98C84B38-1085-46BD-B1CE-DD38C159E6CC";
    //public const TYPE_BOOK_CLONING = "D1CA6B84-338E-4F2F-9C6B-76CC8B4BD98D";
    //public const TYPE_BANNER_DUPLICATE = "B5C5D105-75A2-4076-AF2B-923EA2BF4BF0";
    //public const TYPE_BANNER_ADD_PATTERN = "D81AAEAF-E172-4440-9225-868DF030D27B";
    //public const TYPE_FIREWORKS = "00000000-0000-0000-0000-000000000002";
    //public const TYPE_MAP_LOCKING_CARTOGRAPHY = "602234E4-CAC1-4353-8BB7-B1EBFF70024B";

    public int UniqueId { get; set; }
}

public class ShapelessRecipe : Recipe
{
    public ShapelessRecipe()
    {
        Input = new List<Item>();
        Result = new List<Item>();
    }

    public ShapelessRecipe(List<Item> result, List<Item> input, string block = null) : this()
    {
        Result = result;
        Input = input;
        Block = block;
    }

    public ShapelessRecipe(Item result, List<Item> input, string block = null) : this()
    {
        Result.Add(result);
        Input = input;
        Block = block;
    }

    public int UniqueId { get; set; }
    public List<Item> Input { get; private set; }
    public List<Item> Result { get; }
}

public class ShapedRecipe : Recipe
{
    public ShapedRecipe(int width, int height)
    {
        Width = width;
        Height = height;
        Input = new Item[Width * height];
        Result = new List<Item>();
    }

    public ShapedRecipe(int width, int height, Item result, Item[] input, string block = null) : this(width, height)
    {
        Result.Add(result);
        Input = input;
        Block = block;
    }

    public ShapedRecipe(int width, int height, List<Item> result, Item[] input, string block = null) : this(width,
        height)
    {
        Result = result;
        Input = input;
        Block = block;
    }

    public int UniqueId { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Item[] Input { get; set; }
    public List<Item> Result { get; set; }
}

public class SmeltingRecipe : Recipe
{
    public SmeltingRecipe()
    {
    }

    public SmeltingRecipe(Item result, Item input, string block = null) : this()
    {
        Result = result;
        Input = input;
        Block = block;
    }

    public Item Input { get; set; }
    public Item Result { get; set; }
}

public class SmithingTransformRecipe : Recipe
{
    public SmithingTransformRecipe()
    {
    }

    public SmithingTransformRecipe(string recipeid, Item output, Item template, Item input, Item addition,
        string block) : this()
    {
        RecipeId = recipeid;
        Output = output;
        Template = template;
        Input = input;
        Addition = addition;
        Block = block;
    }

    public string RecipeId { get; set; }
    public int UniqueId { get; set; }
    public Item Template { get; set; }
    public Item Input { get; set; }
    public Item Addition { get; set; }
    public Item Output { get; set; }
}

public class SmithingTrimRecipe : Recipe
{
    public SmithingTrimRecipe()
    {
    }

    public SmithingTrimRecipe(string recipeid, Item output, Item template, Item input, Item addition, string block) :
        this()
    {
        RecipeId = recipeid;
        Output = output;
        Template = template;
        Input = input;
        Addition = addition;
        Block = block;
    }

    public string RecipeId { get; set; }
    public int UniqueId { get; set; }
    public Item Template { get; set; }
    public Item Input { get; set; }
    public Item Addition { get; set; }
    public Item Output { get; set; }
}

public class PotionContainerChangeRecipe
{
    public int Input { get; set; }
    public int Ingredient { get; set; }
    public int Output { get; set; }
}

public class PotionTypeRecipe
{
    public int Input { get; set; }
    public int InputMeta { get; set; }
    public int Ingredient { get; set; }
    public int IngredientMeta { get; set; }
    public int Output { get; set; }
    public int OutputMeta { get; set; }
}

public class MaterialReducerRecipe
{
    public MaterialReducerRecipe()
    {
    }

    public MaterialReducerRecipe(int inputId, int inputMeta, params MaterialReducerRecipeOutput[] outputs)
    {
        Input = inputId;
        InputMeta = inputMeta;

        Output = outputs;
    }

    public int Input { get; set; }
    public int InputMeta { get; set; }

    public MaterialReducerRecipeOutput[] Output { get; set; }

    public class MaterialReducerRecipeOutput
    {
        public MaterialReducerRecipeOutput()
        {
        }

        public MaterialReducerRecipeOutput(int itemId, int itemCount)
        {
            ItemId = itemId;
            ItemCount = itemCount;
        }

        public int ItemId { get; set; }
        public int ItemCount { get; set; }
    }
}