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

        public string Action(string action, Player player)
        {
            if( action.ToLower().Contains( "pickup") == true )
            {
                //do we need to check if user picked up key
                player.Inventory.Add( $"{_keyColour}-Key");

                return "You picked up the key";
            }
            else
            {
                return "I dont know what you mean";
            }
        }
        
    }
}