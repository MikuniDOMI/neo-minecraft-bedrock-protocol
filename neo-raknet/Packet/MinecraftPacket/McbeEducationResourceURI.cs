// McpeEducationResourceURI.cs

// 假设基础 Packet 类在此命名空间或需相应调整

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     EducationSharedResourceURI 代表一个教育版共享资源的 URI。
/// </summary>
public class EducationSharedResourceURI
{
    /// <summary>
    ///     初始化 EducationSharedResourceURI 类的新实例。
    /// </summary>
    public EducationSharedResourceURI()
    {
    }

    /// <summary>
    ///     初始化 EducationSharedResourceURI 类的新实例。
    /// </summary>
    /// <param name="buttonName">按钮名称。</param>
    /// <param name="linkUri">链接 URI。</param>
    public EducationSharedResourceURI(string buttonName, string linkUri)
    {
        ButtonName = buttonName ?? string.Empty;
        LinkURI = linkUri ?? string.Empty;
    }

    /// <summary>
    ///     ButtonName 是资源 URI 的按钮名称。
    /// </summary>
    public string ButtonName { get; set; } = string.Empty;

    /// <summary>
    ///     LinkURI 是资源 URI 的链接地址。
    /// </summary>
    public string LinkURI { get; set; } = string.Empty;
}

/// <summary>
///     EducationResourceURI 数据包：将教育版资源设置传输给所有客户端。
/// </summary>
public class McpeEducationResourceURI : Packet
{
    /// <summary>
    ///     初始化 McpeEducationResourceURI 类的新实例。
    /// </summary>
    public McpeEducationResourceURI()
    {
        Id = 170; // IDEducationResourceURI
        IsMcpe = true;
    }

    /// <summary>
    ///     Resource 是正在被引用的资源。
    /// </summary>
    public EducationSharedResourceURI Resource { get; set; } = new();

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // 假设 Packet 基类或协议辅助方法提供 Write(EducationSharedResourceURI resource) 方法
        // 如果没有直接的方法，需要手动序列化其字段
        // 根据 methods.txt，没有直接写入 EducationSharedResourceURI 的方法，
        // 因此需要手动写入其内部的 string 字段。

        // 写入 Resource.ButtonName (string)
        Write(Resource?.ButtonName ?? string.Empty);

        // 写入 Resource.LinkURI (string)
        Write(Resource?.LinkURI ?? string.Empty);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // 假设 Packet 基类或协议辅助方法提供 ReadEducationSharedResourceURI() 方法
        // 如果没有直接的方法，需要手动反序列化其字段
        // 根据 methods.txt，没有直接读取 EducationSharedResourceURI 的方法，
        // 因此需要手动读取其内部的 string 字段。

        // 读取 Resource.ButtonName (string)
        var buttonName = ReadString();

        // 读取 Resource.LinkURI (string)
        var linkUri = ReadString();

        // 创建或更新 Resource 对象
        Resource = new EducationSharedResourceURI(buttonName, linkUri);
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        Resource = new EducationSharedResourceURI();
    }
}