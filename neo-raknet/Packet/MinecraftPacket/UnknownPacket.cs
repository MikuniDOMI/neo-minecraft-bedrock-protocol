using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    public class UnknownPacket : Packet
    {
        public ReadOnlyMemory<byte> Message { get; private set; }

        public UnknownPacket() : this(0, null)
        {
        }

        public UnknownPacket(byte id, ReadOnlyMemory<byte> message)
        {
            Message = message;
            Id = id;
        }
    }
}
