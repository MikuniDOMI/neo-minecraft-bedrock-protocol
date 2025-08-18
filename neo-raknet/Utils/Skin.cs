using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace neo_raknet.Utils;

public class PersonaPiece
{
    public string PieceId { get; set; }
    public string PieceType { get; set; }
    public string PackId { get; set; }
    public bool IsDefaultPiece { get; set; }
    public string ProductId { get; set; }
}

public class SkinPiece
{
    public string PieceType { get; set; }
    public List<string> Colors { get; set; } = new();
}

public class SkinResourcePatch : ICloneable
{
    public GeometryIdentifier Geometry { get; set; }

    [JsonPropertyName( "persona_reset_resource_definitions")]
    public bool PersonaResetResourceDefinitions { get; set; }

    public object Clone()
    {
        var cloned = (SkinResourcePatch)MemberwiseClone();
        cloned.Geometry = (GeometryIdentifier)Geometry?.Clone();

        return cloned;
    }
}

public class GeometryIdentifier : ICloneable
{
    public string Default { get; set; }

    [JsonPropertyName( "animated_face")]
    public string AnimatedFace { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class Skin : ICloneable
{
    public bool Slim { get; set; }
    public bool IsPersonaSkin { get; set; }
    public bool IsPremiumSkin { get; set; }

    public Cape Cape { get; set; } = new();
    public string SkinId { get; set; }

    public string PlayFabId { get; set; }

    public string ResourcePatch { get; set; } // contains GeometryName

    public SkinResourcePatch SkinResourcePatch
    {
        get => ToJSkinResourcePatch(ResourcePatch);
        set => ResourcePatch = ToJson(value);
    } // contains GeometryName

    public int Height { get; set; }
    public int Width { get; set; }
    public byte[] Data { get; set; }
    public string GeometryName { get; set; }
    public string GeometryData { get; set; }
    public string GeometryDataVersion { get; set; } = "0.0.0";

    public string ArmSize { get; set; }

    public string SkinColor { get; set; }

    public string AnimationData { get; set; }
    public List<Animation> Animations { get; set; } = new();

    public List<PersonaPiece> PersonaPieces { get; set; } = new();
    public List<SkinPiece> SkinPieces { get; set; } = new();
    public bool IsVerified { get; set; }
    public bool IsPrimaryUser { get; set; }
    public bool isOverride { get; set; } = true;

    public object Clone()
    {
        var clonedSkin = (Skin)MemberwiseClone();
        clonedSkin.Data = Data?.Clone() as byte[];
        clonedSkin.Cape = Cape?.Clone() as Cape;
        clonedSkin.SkinResourcePatch = SkinResourcePatch?.Clone() as SkinResourcePatch;

        foreach (var animation in Animations) clonedSkin.Animations.Add((Animation)animation.Clone());

        return clonedSkin;
    }

    public static byte[] GetTextureFromFile(string filename)
    {
        var bitmap = Image.Load<Rgba32>(filename); // new Image<Rgba32>(filename);

        var size = bitmap.Height * bitmap.Width * 4;

        if (size != 0x2000 && size != 0x4000 && size != 0x10000)
            return null;

        var bytes = new byte[size];

        var i = 0;
        for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
        {
            var color = bitmap[x, y];
            bytes[i++] = color.R;
            bytes[i++] = color.G;
            bytes[i++] = color.B;
            bytes[i++] = color.A;
        }

        return bytes;
    }

    public static void SaveTextureToFile(string filename, byte[] bytes)
    {
        var size = bytes.Length;

        var width = size == 0x10000 ? 128 : 64;
        var height = size == 0x2000 ? 32 : size == 0x4000 ? 64 : 128;

        var bitmap = new Image<Rgba32>(width, height);

        var i = 0;
        for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
        {
            var r = bytes[i++];
            var g = bytes[i++];
            var b = bytes[i++];
            var a = bytes[i++];

            bitmap[x, y] = new Rgba32(r, g, b, a);
        }

        bitmap.Save(filename);
    }




    public static string ToJson(SkinResourcePatch model)
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyProperties = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false, // Set to true if you want indented formatting
        };

        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        var json = JsonSerializer.Serialize(model, options);

        return json;
    }

    public static SkinResourcePatch ToJSkinResourcePatch(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Similar to camelCase handling
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        var obj = JsonSerializer.Deserialize<SkinResourcePatch>(json, options);

        return obj;
    }
}