using System;
using Constants;
using PlayerInfo;

namespace Tiles
{
    public class PitOfDoom  : TileContext
    {
        public PitOfDoom()
        {
        }

        public string Description 
        {
            get
            {
                return ConstantStrings.GetPitOfDoomString();
            }
        }

        public string Action(string action, Player player)
        {
            player.Health = 0;
            return ConstantStrings.GetPitOfDoomString();
        }
    }
}