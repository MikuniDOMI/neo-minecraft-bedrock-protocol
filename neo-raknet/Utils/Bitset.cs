using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Utils
{
    using System.Numerics;

    public class Bitset
    {
        public int Size { get; private set; }
        public BigInteger IntValue { get; private set; }

        public Bitset(int size, BigInteger intValue)
        {
            Size = size;
            IntValue = intValue;
        }
    }
}
