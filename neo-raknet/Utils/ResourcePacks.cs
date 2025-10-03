namespace neo_raknet.Utils;

public class ResourcePackInfos : List<ResourcePackInfo>
{
}
public enum PackSettingType : int // 或者可以使用 enum uint
{
    Float = 0,
    Bool = 1,
    String = 2,
}

/// <summary>
/// PackSetting 代表一个资源包设置。
/// </summary>
public class PackSetting
{
    /// <summary>
    /// Name 是设置的名称。
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Value 是设置的新值。这可以是 float, bool 或 string。
    /// 在 C# 中，使用 object 类型来表示 Go 的 any。
    /// </summary>
    public object Value { get; set; } = null; // 或者可以初始化为 default(object)

    /// <summary>
    /// 初始化 PackSetting 类的新实例。
    /// </summary>
    public PackSetting() { }

    /// <summary>
    /// 初始化 PackSetting 类的新实例。
    /// </summary>
    /// <param name="name">设置的名称。</param>
    /// <param name="value">设置的值。</param>
    public PackSetting(string name, object value)
    {
        Name = name ?? string.Empty;
        Value = value; // Allow null, or validate value type if needed
    }
}
public class ResourcePackInfo
{
    /// <summary>
    ///     The unique identifier for the pack
    /// </summary>
    public UUID UUID { get; set; }

    /// <summary>
    ///     Version is the version of the pack. The client will cache packs sent by the server as
    ///     long as they carry the same version. Sending a pack with a different version than previously
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    ///     Size is the total size in bytes that the texture pack occupies. This is the size of the compressed
    ///     archive (zip) of the texture pack.
    /// </summary>
    public ulong Size { get; set; }

    /// <summary>
    ///     ContentKey is the key used to decrypt the behaviour pack if it is encrypted. This is generally the case
    ///     for marketplace texture packs.
    /// </summary>
    public string ContentKey { get; set; }

    public string SubPackName { get; set; }

    /// <summary>
    ///     Size is the total size in bytes that the texture pack occupies. This is the size of the compressed archive (zip) of
    ///     the texture pack.
    /// </summary>
    public string ContentIdentity { get; set; }

    /// <summary>
    ///     HasScripts specifies if the texture packs has any scripts in it. A client will only download the behaviour pack if
    ///     it supports scripts, which, up to 1.11, only includes Windows 10.
    /// </summary>
    public bool HasScripts { get; set; }

    public bool isAddon { get; set; }
    public string cndUrls { get; set; }
}

public class TexturePackInfos : List<TexturePackInfo>
{
}

public class TexturePackInfo : ResourcePackInfo
{
    /// <summary>
    ///     RTXEnabled specifies if the texture pack uses the raytracing technology introduced in 1.16.200.
    /// </summary>
    public bool RtxEnabled { get; set; }
}

public class ResourcePackIdVersions : List<PackIdVersion>
{
}

public class PackIdVersion
{
    public string Id { get; set; }
    public string Version { get; set; }
    public string SubPackName { get; set; }
}

public class ResourcePackIds : List<string>
{
}

public enum ResourcePackType : byte
{
    Addon = 1,
    Cached = 2,
    CopyProtected = 3,
    Behaviour = 4,
    PersonaPiece = 5,
    Resources = 6,
    Skins = 7,
    WorldTemplate = 8
}

public class Header
{
    public string Description { get; set; }
    public string Name { get; set; }
    public string Uuid { get; set; }
    public List<int> Version { get; set; }
    public List<int> MinEngineVersion { get; set; }
}

public class Module
{
    public string Type { get; set; }
    public string Uuid { get; set; }
    public List<int> Version { get; set; }
}

public class manifestStructure
{
    public int FormatVersion { get; set; }
    public Header Header { get; set; }
    public List<Module> Modules { get; set; }
}

public class PlayerPackMapData
{
    public string pack { get; set; }
    public ResourcePackType type { get; set; }
}