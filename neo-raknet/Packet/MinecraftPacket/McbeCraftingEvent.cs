using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeCraftingEvent : Packet
{
    public enum RecipeTypes
    {
        Shapeless = 0,
        Shaped = 1,
        Furnace = 2,
        FurnaceData = 3,
        Multi = 4,
        ShulkerBox = 5,
        ChemistryShapeless = 6,
        ChemistryShaped = 7,
        SmithingTransform = 8,
        SmithingTrim = 9
    }

    public ItemStacks input; // = null;
    public UUID recipeId; // = null;
    public int recipeType; // = null;
    public ItemStacks result; // = null;

    public byte windowId; // = null;

    public McpeCraftingEvent()
    {
        Id = 0x35;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(windowId);
        WriteSignedVarInt(recipeType);
        Write(recipeId);
        Write(input);
        Write(result);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        windowId = ReadByte();
        recipeType = ReadSignedVarInt();
        recipeId = ReadUUID();
        input = ReadItemStacks();
        result = ReadItemStacks();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        windowId = default;
        recipeType = default;
        recipeId = default;
        input = default;
        result = default;
    }
}