using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Constants;

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
                    return new InputTile( "Title", "Title Stone", "red" );
                case 2:
                    return new InputTile( "Name", "Name Stone", "blue" );
                case 3:
                    return new InputTile( "Phone Number", "Phone number stone", "yellow" );
                case 4:
                    return new InputTile( "Address", "Address Stone", "green" );
                case 5:
                    return new InputTile( "Complaint", "Complaint Stone", "purple" );

                case 11:
                    return new MonsterTile( MonsterTypes.Fenrir );
                case 12:
                    return new MonsterTile( MonsterTypes.Snake );
                case 13:
                    return new MonsterTile( MonsterTypes.IceGiant );
                case 14:
                    return new MonsterTile( MonsterTypes.Fenrir );
                case 15:
                    return new MonsterTile( MonsterTypes.Fenrir );

                case 21:
                    return new KeyTile("red");
                case 22:
                    return new KeyTile("blue");
                case 23:
                    return new KeyTile("yellow");
                case 24:
                    return new KeyTile("green");
                case 25:
                    return new KeyTile("purple");

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