using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;

namespace Tiles
{
    public class InputTile : TileContext
    {
        public InputTile( string inputName, string desciption, string keyColour )
        {
            Description = desciption;
            _keyColour = keyColour;
        }

        public string Description 
        { 
            get; 
        }

        public string Action(string action, Player player)
        {
            if( !player.Inventory.Contains($"{_keyColour}-Key") )
            {
                //don't have the key, how should we act?
                return $"You dont have the {_keyColour} key so this stone is not active";
            }
            else
            {
                string value = action.Substring( 0,1 );
                _input = $"{_input}{value}";
                return _input;
            }
        }

        private string _input;
        private string _keyColour;

    }
}