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
            if( found == false )
            {
                if( action.ToLower().Contains( "pickup") == true )
                {
                    //do we need to check if user picked up key
                    player.Inventory.Add( $"{_keyColour}-Key");
                    Console.WriteLine("Added key to inventory");
                    found = true;
                    return "You picked up the key";
                }
                else
                {
                    return "I dont know what you mean";
                }
            }
            else
            {
                return "You found a key here once";
            }
        }

        private bool found = false;
        
    }
}