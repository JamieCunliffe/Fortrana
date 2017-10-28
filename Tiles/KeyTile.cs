using System;
using Constants;
using PlayerInfo;

namespace Tiles
{
    public class KeyTile  : TileContext
    {
        private string _keyColour;

        public KeyTile( string keyColour )
        {
            _keyColour = keyColour;
        }

        public string Description 
        {
            get
            {
                return ConstantStrings.GetKey( _keyColour );
            }
        }

        public void Action(string action, Player player)
        {
            //do we need to check if user picked up key
            player.Inventory.Add( $"{_keyColour}-Key");
        }
        
    }
}