using System;
using Constants;
using PlayerInfo;

namespace Tiles
{
    public class PitOfDoomWarning  : TileContext
    {
        public PitOfDoomWarning()
        {
        }

        public string Description 
        {
            get
            {
                return ConstantStrings.GetPitOfDoomWarningString();
            }
        }

        public string Action(string action, Player player)
        {
            //no action required
            return ConstantStrings.GetPitOfDoomWarningString();
        }
    }
}