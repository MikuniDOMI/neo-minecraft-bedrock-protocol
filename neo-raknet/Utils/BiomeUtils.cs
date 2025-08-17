namespace neo_raknet.Utils;

public class Biome
{
    public float AshDensity;
    public float BlueSporeDensity;
    public string DefinitionName;
    public float Depth;
    public float Downfall;
    public int Foliage; // r,g,b, NOT multiplied by alpha
    public int Grass; // r,g,b, NOT multiplied by alpha
    public int Id;
    public string Name;
    public float RedSporeDensity;
    public float Scale;
    public float Temperature;
    public int WaterColor;
    public float WhiteAshDensity;
}

public class BiomeUtils
{
    private const int FOREST_BIOME = 4;
    private const int SWAMPLAND_BIOME = 6;
    private const int FOREST_HILLS_BIOME = 18;
    private const int BIRCH_FOREST_BIOME = 27;
    private const int BIRCH_FOREST_HILLS_BIOME = 28;
    private const int ROOFED_FOREST_BIOME = 29;

    private const int MESA_BIOME = 37;
    private const int MESA_PLATEAU_F_BIOME = 38;
    private const int MESA_PLATEAU_BIOME = 39;

    public static Biome[] Biomes =
    {
        new()
        {
            Id = 0,
            Name = "Ocean",
            DefinitionName = "ocean",
            Temperature = 0.5f,
            Downfall = 0.5f
        },
        new()
        {
            Id = 1,
            Name = "Plains",
            DefinitionName = "plains",
            Temperature = 0.8f,
            Downfall = 0.4f
        },
        new()
        {
            Id = 2,
            Name = "Desert",
            DefinitionName = "desert",
            Temperature = 2.0f,
            Downfall = 0.0f
        } // TODO crashing, need to regenerate from BDS
    };

    //$c = self::interpolateColor(256, $x, $z, [0x47, 0xd0, 0x33], [0x6c, 0xb4, 0x93], [0xbf, 0xb6, 0x55], [0x80, 0xb4, 0x97]);

    //private static BiomeCorner[] PEgrassCorners = new BiomeCorner[3]
    //{
    //	new BiomeCorner {red = 0xbf, green = 0xb6, blue = 0x55}, // lower left, temperature starts at 1.0 on left
    //	new BiomeCorner {red = 0x80, green = 0xb4, blue = 0x97}, // lower right
    //	new BiomeCorner {red = 0x47, green = 0xd0, blue = 0x33} // upper left
    //};

    private static readonly BiomeCorner[] grassCorners = new BiomeCorner[3]
    {
        new()
        {
            Red = 191,
            Green = 183,
            Blue = 85
        }, // lower left, temperature starts at 1.0 on left
        new()
        {
            Red = 128,
            Green = 180,
            Blue = 151
        }, // lower right
        new()
        {
            Red = 71,
            Green = 205,
            Blue = 51
        } // upper left
    };

    private static readonly BiomeCorner[] foliageCorners = new BiomeCorner[3]
    {
        new()
        {
            Red = 174,
            Green = 164,
            Blue = 42
        }, // lower left, temperature starts at 1.0 on left
        new()
        {
            Red = 96,
            Green = 161,
            Blue = 123
        }, // lower right
        new()
        {
            Red = 26,
            Green = 191,
            Blue = 0
        } // upper left
    };

    public static float Clamp(float value, float min, float max)
    {
        return value < min ? min : value > max ? max : value;
    }

    // NOTE: elevation is number of meters above a height of 64. If elevation is < 64, pass in 0.
    private int BiomeColor(float temperature, float rainfall, int elevation, BiomeCorner[] corners)
    {
        // get UVs
        temperature = Clamp(temperature - elevation * 0.00166667f, 0.0f, 1.0f);
        // crank it up: temperature = clamp(temperature - (float)elevation*0.166667f,0.0f,1.0f);
        rainfall = Clamp(rainfall, 0.0f, 1.0f);
        rainfall *= temperature;

        // UV is essentially temperature, rainfall

        // lambda values for barycentric coordinates
        var lambda = new float[3];
        lambda[0] = temperature - rainfall;
        lambda[1] = 1.0f - temperature;
        lambda[2] = rainfall;

        float red = 0.0f, green = 0.0f, blue = 0.0f;
        for (var i = 0; i < 3; i++)
        {
            red += lambda[i] * corners[i].Red;
            green += lambda[i] * corners[i].Green;
            blue += lambda[i] * corners[i].Blue;
        }

        var r = (int)Clamp(red, 0.0f, 255.0f);
        var g = (int)Clamp(green, 0.0f, 255.0f);
        var b = (int)Clamp(blue, 0.0f, 255.0f);

        return (r << 16) | (g << 8) | b;
    }

    private int BiomeGrassColor(float temperature, float rainfall, int elevation)
    {
        return BiomeColor(temperature, rainfall, elevation, grassCorners);
    }

    private int BiomeFoliageColor(float temperature, float rainfall, int elevation)
    {
        return BiomeColor(temperature, rainfall, elevation, foliageCorners);
    }

    public void PrecomputeBiomeColors()
    {
        for (var biome = 0; biome < Biomes.Length; biome++)
        {
            Biomes[biome].Grass = ComputeBiomeColor(biome, 0, true);
            Biomes[biome].Foliage = ComputeBiomeColor(biome, 0, false);
        }

        //var mesaGrass = GetBiome(37).grass;
        //var desertGrass = GetBiome(2).grass;
        //if(mesaGrass != desertGrass) throw new Exception("Mesa: " + mesaGrass + " Desert: " + desertGrass);
    }


    // elevation == 0 means for precomputed colors and for elevation off
    // or 64 high or below. 
    public int ComputeBiomeColor(int biome, int elevation, bool isGrass)
    {
        int color;

        switch (biome)
        {
            case SWAMPLAND_BIOME:
                // the fefefe makes it so that carries are copied to the low bit,
                // then their magic "go to green" color offset is added in, then
                // divide by two gives a carry that will nicely go away.
                // old method:
                //color = BiomeGrassColor( gBiomes[biome].temperature, gBiomes[biome].rainfall );
                //gBiomes[biome].grass = ((color & 0xfefefe) + 0x4e0e4e) / 2;
                //color = BiomeFoliageColor( gBiomes[biome].temperature, gBiomes[biome].rainfall );
                //gBiomes[biome].foliage = ((color & 0xfefefe) + 0x4e0e4e) / 2;

                // new method:
                // yes, it's hard-wired in. It actually varies with temperature:
                //         return temperature < -0.1D ? 0x4c763c : 0x6a7039;
                // where temperature is varied by PerlinNoise, but I haven't recreated the
                // PerlinNoise function yet. Rich green vs. sickly swamp brown. I'm going with brown.
                return 0x6a7039;

            // These are actually perfectly normal. Only sub-type 3, roofed forest, is different.
            //case FOREST_BIOME:	// forestType 0
            //case FOREST_HILLS_BIOME:	// forestType 0
            //case BIRCH_FOREST_BIOME:	// forestType 2
            //case BIRCH_FOREST_HILLS_BIOME:	// forestType 2
            //	break;

            case ROOFED_FOREST_BIOME: // forestType 3
                if (isGrass)
                {
                    color = BiomeGrassColor(GetBiome(biome).Temperature, GetBiome(biome).Downfall, elevation);
                    // the fefefe makes it so that carries are copied to the low bit,
                    // then their magic "go to green" color offset is added in, then
                    // divide by two gives a carry that will nicely go away.
                    return ((color & 0xfefefe) + 0x28340a) / 2;
                }

                return BiomeFoliageColor(GetBiome(biome).Temperature, GetBiome(biome).Downfall, elevation);

            case MESA_BIOME:
            case MESA_PLATEAU_F_BIOME:
            case MESA_PLATEAU_BIOME:
                // yes, it's hard-wired
                return isGrass ? 0x90814d : 0x9e814d;

            default:
                return isGrass
                    ? BiomeGrassColor(GetBiome(biome).Temperature, GetBiome(biome).Downfall, elevation)
                    : BiomeFoliageColor(GetBiome(biome).Temperature, GetBiome(biome).Downfall, elevation);
        }
    }

    public static Biome GetBiome(int biomeId)
    {
        return Biomes.FirstOrDefault(biome => biome.Id == biomeId) ?? new Biome
        {
            Id = biomeId,
            Name = "" + biomeId
        };
    }

    public int BiomeSwampRiverColor(int color)
    {
        var r = (color >> 16) & 0xff;
        var g = (color >> 8) & 0xff;
        var b = color & 0xff;

        // swamp color modifier is 0xE0FFAE
        r = r * 0xE0 / 255;
        // does nothing: g=(g*0xFF)/255;
        b = b * 0xAE / 255;
        color = (r << 16) | (g << 8) | b;

        return color;
    }

    private struct BiomeCorner
    {
        public int Red;
        public int Green;
        public int Blue;
    }
}