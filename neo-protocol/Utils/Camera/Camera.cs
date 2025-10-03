namespace neo_protocol.Utils.Camera;

public struct CameraAimAssistPriority
{
    // Identifier is the identifier of a target to define the priority for.
    public string Identifier;

    // Priority is the priority for this specific target.
    public int Priority;

    public CameraAimAssistPriority(string identifier, int priority)
    {
        Identifier = identifier;
        Priority = priority;
    }
}

public struct CameraAimAssistPriorities
{
    // Entities is a list of priorities for specific entity identifiers.
    public CameraAimAssistPriority[] Entities;

    // Blocks is a list of priorities for specific block identifiers.
    public CameraAimAssistPriority[] Blocks;

    // EntityDefault is the default priority for entities.
    public Optional<int> EntityDefault;

    // BlockDefault is the default priority for blocks.
    public Optional<int> BlockDefault;

    public CameraAimAssistPriorities(
        CameraAimAssistPriority[] entities,
        CameraAimAssistPriority[] blocks,
        Optional<int> entityDefault,
        Optional<int> blockDefault)
    {
        Entities = entities;
        Blocks = blocks;
        EntityDefault = entityDefault;
        BlockDefault = blockDefault;
    }
}

public struct CameraAimAssistCategory
{
    // Name is the name of the category which can be used by a CameraAimAssistPreset.
    public string Name;

    // Priorities represents the block and entity specific priorities as well as the default priorities for
    // this category.
    public CameraAimAssistPriorities Priorities;

    public CameraAimAssistCategory(string name, CameraAimAssistPriorities priorities)
    {
        Name = name;
        Priorities = priorities;
    }
}

public struct CameraAimAssistItemSettings
{
    // Item is the identifier of the item to apply the settings to.
    public string Item;

    // Category is the identifier of a category to use which has been defined by a CameraAimAssistCategory.
    // Only categories defined in the Categories slice used by the CameraAimAssistPreset can be
    // used here.
    public string Category;

    public CameraAimAssistItemSettings(string item, string category)
    {
        Item = item;
        Category = category;
    }
}

public struct CameraAimAssistPreset
{
    // Identifier represents the identifier of this preset.
    public string Identifier;

    // BlockExclusions is a list of block identifiers that should be ignored by the aim assist.
    public string[] BlockExclusions;

    // LiquidTargets is a list of entity identifiers that should be targetted when inside of a liquid.
    public string[] LiquidTargets;

    // ItemSettings is a list of settings for specific item identifiers. If an item is not listed here, it
    // will fallback to DefaultItemSettings or HandSettings if no item is held.
    public CameraAimAssistItemSettings[] ItemSettings;

    // DefaultItemSettings is the identifier of a category to use when the player is not holding an item
    // listed in ItemSettings. This must be the identifier of a category within the Categories slice.
    public Optional<string> DefaultItemSettings;

    // HandSettings is the identifier of a category to use when the player is not holding an item. This must
    // be the identifier of a category within Categories slice.
    public Optional<string> HandSettings;

    public CameraAimAssistPreset(
        string identifier,
        string[] blockExclusions,
        string[] liquidTargets,
        CameraAimAssistItemSettings[] itemSettings,
        Optional<string> defaultItemSettings,
        Optional<string> handSettings)
    {
        Identifier = identifier;
        BlockExclusions = blockExclusions;
        LiquidTargets = liquidTargets;
        ItemSettings = itemSettings;
        DefaultItemSettings = defaultItemSettings;
        HandSettings = handSettings;
    }
}