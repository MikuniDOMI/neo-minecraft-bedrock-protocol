using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct
{
    public class PropertySyncData
    {
        public Dictionary<uint, int>   intProperties   = new Dictionary<uint, int>();
        public Dictionary<uint, float> floatProperties = new Dictionary<uint, float>();

    }
}
