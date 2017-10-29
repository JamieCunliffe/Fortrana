using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;

namespace Tiles
{
    public class EmptyTile : TileContext
    {
        public EmptyTile( string description )
        {
            Description = description;
        }

        public string Description { get; }

        public string Action(string action, Player player)
        {
            //do nothing it's an space
            return "You canot do that here";
        }
    }
}