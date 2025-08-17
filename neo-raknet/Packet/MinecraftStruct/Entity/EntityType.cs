using fNbt;

namespace neo_raknet.Packet.MinecraftStruct.Entity;

public enum EntityType
{
    None = 0,

    DroppedItem = 64,
    ExperienceOrb = 69,

    ArmorStand = 61,
    PrimedTnt = 65,
    FallingBlock = 66,

    ThrownBottleoEnchanting = 68,
    EnderEye = 70,
    EnderCrystal = 71,
    FireworksRocket = 72,
    Trident = 73,
    ShulkerBullet = 76,
    FishingRodHook = 77,
    DragonFireball = 79,
    ShotArrow = 80,
    ThrownSnowball = 81,
    ThrownEgg = 82,
    Painting = 83,
    Minecart = 84,
    GhastFireball = 85,
    ThrownSpashPotion = 86,
    ThrownEnderPerl = 87,
    LeashKnot = 88,
    WitherSkull = 89,
    Boat = 90,
    WitherSkullDangerous = 91,
    LightningBolt = 93,
    BlazeFireball = 94,
    AreaEffectCloud = 95,
    HopperMinecart = 96,
    TntMinecart = 97,
    ChestMinecart = 98,
    CommandBlockMinecart = 100,
    LingeringPotion = 101,
    LlamaSpit = 102,
    EvocationFangs = 103,
    IceBomb = 106,
    Balloon = 107,

    Zombie = 32,
    Creeper = 33,
    Skeleton = 34,
    Spider = 35,
    ZombiePigman = 36,
    Slime = 37,
    Enderman = 38,
    Silverfish = 39,
    CaveSpider = 40,
    Ghast = 41,
    MagmaCube = 42,
    Blaze = 43,
    ZombieVillager = 44,
    Witch = 45,
    Stray = 46,
    Husk = 47,
    WitherSkeleton = 48,
    Guardian = 49,
    ElderGuardian = 50,
    Wither = 52,
    Dragon = 53,
    Shulker = 54,
    Endermite = 55,
    Vindicator = 57,
    Phantom = 58,
    Evoker = 104,
    Vex = 105,
    Drowned = 110,
    Pillager = 114,

    Chicken = 10,
    Cow = 11,
    Pig = 12,
    Sheep = 13,
    Wolf = 14,
    Villager = 115,
    MushroomCow = 16,
    Squid = 17,
    Rabbit = 18,
    Bat = 19,
    IronGolem = 20,
    SnowGolem = 21,
    Ocelot = 22,
    Horse = 23,
    Donkey = 24,
    Mule = 25,
    SkeletonHorse = 26,
    ZombieHorse = 27,
    PolarBear = 28,
    Llama = 29,
    Parrot = 30,
    Dolphin = 31,
    Turtle = 74,
    Cat = 75,
    Pufferfish = 108,
    Salmon = 109,
    TropicalFish = 111,
    Fish = 112,
    Panda = 113,

    Player = 63,

    Npc = 51,
    Agent = 56,
    Camera = 62,
    Chalkboard = 78,

    Herobrine = 666
}

public static class EntityHelpers
{
    public static readonly Dictionary<EntityType, string> LegacyEntityTypeIdConverter = new()
    {
        { EntityType.Npc, "minecraft:npc" },
        { EntityType.Player, "minecraft:player" },
        { EntityType.WitherSkeleton, "minecraft:wither_skeleton" },
        { EntityType.Husk, "minecraft:husk" },
        { EntityType.Stray, "minecraft:stray" },
        { EntityType.Witch, "minecraft:witch" },
        { EntityType.ZombieVillager, "minecraft:zombie_villager" },
        { EntityType.Blaze, "minecraft:blaze" },
        { EntityType.MagmaCube, "minecraft:magma_cube" },
        { EntityType.Ghast, "minecraft:ghast" },
        { EntityType.CaveSpider, "minecraft:cave_spider" },
        { EntityType.Silverfish, "minecraft:silverfish" },
        { EntityType.Enderman, "minecraft:enderman" },
        { EntityType.Slime, "minecraft:slime" },
        { EntityType.ZombiePigman, "minecraft:zombie_pigman" },
        { EntityType.Spider, "minecraft:spider" },
        { EntityType.Skeleton, "minecraft:skeleton" },
        { EntityType.Creeper, "minecraft:creeper" },
        { EntityType.Zombie, "minecraft:zombie" },
        { EntityType.SkeletonHorse, "minecraft:skeleton_horse" },
        { EntityType.Mule, "minecraft:mule" },
        { EntityType.Donkey, "minecraft:donkey" },
        { EntityType.Dolphin, "minecraft:dolphin" },
        { EntityType.TropicalFish, "minecraft:tropicalfish" },
        { EntityType.Wolf, "minecraft:wolf" },
        { EntityType.Squid, "minecraft:squid" },
        { EntityType.Drowned, "minecraft:drowned" },
        { EntityType.Sheep, "minecraft:sheep" },
        { EntityType.MushroomCow, "minecraft:mooshroom" },
        { EntityType.Panda, "minecraft:panda" },
        { EntityType.Salmon, "minecraft:salmon" },
        { EntityType.Pig, "minecraft:pig" },
        { EntityType.Villager, "minecraft:villager_v2" },
        { EntityType.Fish, "minecraft:cod" },
        { EntityType.Pufferfish, "minecraft:pufferfish" },
        { EntityType.Cow, "minecraft:cow" },
        { EntityType.Chicken, "minecraft:chicken" },
        { EntityType.Balloon, "minecraft:balloon" },
        { EntityType.Llama, "minecraft:llama" },
        { EntityType.IronGolem, "minecraft:iron_golem" },
        { EntityType.Rabbit, "minecraft:rabbit" },
        { EntityType.SnowGolem, "minecraft:snow_golem" },
        { EntityType.Bat, "minecraft:bat" },
        { EntityType.Ocelot, "minecraft:ocelot" },
        { EntityType.Horse, "minecraft:horse" },
        { EntityType.Cat, "minecraft:cat" },
        { EntityType.PolarBear, "minecraft:polar_bear" },
        { EntityType.ZombieHorse, "minecraft:zombie_horse" },
        { EntityType.Turtle, "minecraft:turtle" },
        { EntityType.Parrot, "minecraft:parrot" },
        { EntityType.Guardian, "minecraft:guardian" },
        { EntityType.ElderGuardian, "minecraft:elder_guardian" },
        { EntityType.Vindicator, "minecraft:vindicator" },
        { EntityType.Wither, "minecraft:wither" },
        { EntityType.Dragon, "minecraft:ender_dragon" },
        { EntityType.Shulker, "minecraft:shulker" },
        { EntityType.Endermite, "minecraft:endermite" },
        { EntityType.Minecart, "minecraft:minecart" },
        { EntityType.HopperMinecart, "minecraft:hopper_minecart" },
        { EntityType.TntMinecart, "minecraft:tnt_minecart" },
        { EntityType.ChestMinecart, "minecraft:chest_minecart" },
        { EntityType.CommandBlockMinecart, "minecraft:command_block_minecart" },
        { EntityType.ArmorStand, "minecraft:armor_stand" },
        { EntityType.DroppedItem, "minecraft:item" },
        { EntityType.PrimedTnt, "minecraft:tnt" },
        { EntityType.FallingBlock, "minecraft:falling_block" },
        { EntityType.ThrownBottleoEnchanting, "minecraft:xp_bottle" },
        { EntityType.ExperienceOrb, "minecraft:xp_orb" },
        { EntityType.EnderEye, "minecraft:eye_of_ender_signal" },
        { EntityType.EnderCrystal, "minecraft:ender_crystal" },
        { EntityType.ShulkerBullet, "minecraft:shulker_bullet" },
        { EntityType.FishingRodHook, "minecraft:fishing_hook" },
        { EntityType.DragonFireball, "minecraft:dragon_fireball" },
        { EntityType.ShotArrow, "minecraft:arrow" },
        { EntityType.ThrownSnowball, "minecraft:snowball" },
        { EntityType.ThrownEgg, "minecraft:egg" },
        { EntityType.Painting, "minecraft:painting" },
        { EntityType.Trident, "minecraft:thrown_trident" },
        { EntityType.GhastFireball, "minecraft:fireball" },
        { EntityType.ThrownSpashPotion, "minecraft:splash_potion" },
        { EntityType.ThrownEnderPerl, "minecraft:ender_pearl" },
        { EntityType.LeashKnot, "minecraft:leash_knot" },
        { EntityType.WitherSkull, "minecraft:wither_skull" },
        { EntityType.WitherSkullDangerous, "minecraft:wither_skull_dangerous" },
        { EntityType.Boat, "minecraft:boat" },
        { EntityType.LightningBolt, "minecraft:lightning_bolt" },
        { EntityType.BlazeFireball, "minecraft:small_fireball" },
        { EntityType.LlamaSpit, "minecraft:llama_spit" },
        { EntityType.AreaEffectCloud, "minecraft:area_effect_cloud" },
        { EntityType.LingeringPotion, "minecraft:lingering_potion" },
        { EntityType.FireworksRocket, "minecraft:fireworks_rocket" },
        { EntityType.EvocationFangs, "minecraft:evocation_fang" },
        { EntityType.Evoker, "minecraft:evocation_illager" },
        { EntityType.Vex, "minecraft:vex" },
        { EntityType.Agent, "minecraft:agent" },
        { EntityType.IceBomb, "minecraft:ice_bomb" },
        { EntityType.Phantom, "minecraft:phantom" },
        { EntityType.Camera, "minecraft:tripod_camera" },
        { EntityType.Pillager, "minecraft:pillager" }
    };

    public static TStore Store<TStore>(this Entity entity) where TStore : new()
    {
        return (TStore)entity.PluginStore.GetOrAdd(typeof(TStore), type => new TStore());
    }

    public static Entity CreateEntity(this short entityTypeId, Level world)
    {
        var entityType = (EntityType)entityTypeId;
        return entityType.Create(world);
    }

    public static NbtList GenerateEntityIdentifiers()
    {
        var list = new NbtList("idlist");

        foreach (var q in LegacyEntityTypeIdConverter)
            list.Add(new NbtCompound
            {
                new NbtString("bid", ":"),
                new NbtByte("experimental", 0),
                new NbtByte("hasspawnegg", 0),
                new NbtString("id", q.Value),
                new NbtInt("rid", (int)q.Key),
                new NbtByte("summonable", 0)
            });

        return list;
    }

    public static string ToStringId(this EntityType type)
    {
        if (LegacyEntityTypeIdConverter.TryGetValue(type, out var value)) return value;

        return ":";
    }

    public static EntityType ToEntityType(string type)
    {
        return LegacyEntityTypeIdConverter.FirstOrDefault(l => l.Value == type).Key;
    }

    public static Entity Create(this EntityType entityType, Level world)
    {
        //TODO Wait for complete
        return null;
    }
}