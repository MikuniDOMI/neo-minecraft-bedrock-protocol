using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct.World
{
    public enum GameMode
    {
        /// <summary>
        ///     Players fight against the enviornment, mobs, and players
        ///     with limited resources.
        /// </summary>
        Survival = 0,
        S = 0,

        /// <summary>
        ///     Players are given unlimited resources, flying, and
        ///     invulnerability.
        /// </summary>
        Creative = 1,
        C = 1,

        /// <summary>
        ///     Similar to survival, with the exception that players may
        ///     not place or remove blocks.
        /// </summary>
        Adventure = 2,

        /// <summary>
        ///     Similar to creative, with the exception that players may
        ///     not place or remove blocks.
        /// </summary>
        Spectator = 3
    }
}
