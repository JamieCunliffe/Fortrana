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

        public void Action(string action, Player player)
        {
            if( !player.Inventory.Contains($"{_keyColour}-Key") )
            {
                //don't have the key, how should we act?
            }
            else
            {
                if ( action.Length <= 1 )
                {
                    _input = $"{_input}action";
                }
            }
        }

        private string _input;
        private string _keyColour;

    }
}