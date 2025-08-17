// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     PhotoInfoRequest 数据包：由客户端发送，用于向服务器请求照片信息。
///     已过时：此数据包在 1.19.80 版本中已被弃用。
/// </summary>
public class McpePhotoInfoRequest : Packet
{
    /// <summary>
    ///     初始化 McpePhotoInfoRequest 类的新实例。
    /// </summary>
    public McpePhotoInfoRequest()
    {
        Id = 173; // IDPhotoInfoRequest
        IsMcpe = true;
    }

    /// <summary>
    ///     PhotoID 是照片的 ID。
    /// </summary>
    public long PhotoID { get; set; } // int64 -> long

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void WriteSignedVarLong(long value) - 对应 Go 的 io.Varint64(&pk.PhotoID)
        WriteSignedVarLong(PhotoID);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // long ReadSignedVarLong() - 对应 Go 的 io.Varint64(&pk.PhotoID)
        PhotoID = ReadSignedVarLong();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        PhotoID = 0;
    }
}