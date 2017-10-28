using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;

namespace Tiles
{

    public class InputTile : TileContext
    {
        public InputTile( string inputName, string desciption )
        {
            Description = desciption;
        }

        public string Description { get; }

        public void Action(string action, Player player)
        {
            if ( action.Length <= 1 )
            {
                _input = $"{_input}action";
            }
        }

        private string _input;
    }
}