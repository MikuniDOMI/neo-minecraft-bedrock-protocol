using Microsoft.IO;

namespace neo_raknet.Utils;

public static class MemoryStreamManger
{
    public static RecyclableMemoryStreamManager stream { get; set; } = new();
}