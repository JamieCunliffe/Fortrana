using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;

namespace Tiles
{
    public static class TileFactory
    {
        public static TileContext GetTile( int tileId )
        {

            switch( tileId )
            {
                case 0:
                    return new EmptyTile( "This is an empty space");
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return new InputTile( "Input name", "Input field", "red" );

                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return new MonsterTile();

                case 69:
                    return new SwordTitle();

                case 665:
                    return new PitOfDoomWarning();
                case 666:
                    return new PitOfDoom();
            }

            return new EmptyTile( "Didn't recognise the tile id" );
        }
    }
}