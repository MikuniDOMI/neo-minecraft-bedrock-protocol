using Microsoft.IO;

namespace neo_protocol.Utils;

public static class MemoryStreamManger
{
    public static RecyclableMemoryStreamManager stream { get; set; } = new();
}