using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;

namespace Tiles
{
    public interface TileContext
    {
        string Description { get; }
        
        string Action(string action, Player player);
    }
}