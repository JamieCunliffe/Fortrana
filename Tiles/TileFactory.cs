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
                    return new EmptyTile( "The open field stretches for leagues, the smell of flowers fills the air");
                case 1:
                    if( _title == null )
                    {
                        _title =  new InputTile( "Title", "Title Stone", "red" );
                    }
                    return _title;
                case 2:
                    if( _name == null )
                    {
                        _name = new InputTile( "Name", "Name Stone", "blue" );
                    }
                    return _name;
                case 3:
                    if( _phoneNumber == null )
                    {
                        _phoneNumber = new InputTile( "Phone Number", "Phone number stone", "yellow" );
                    }
                    return _phoneNumber;
                case 4:
                    if( _address == null )
                    {
                        _address = new InputTile( "Address", "Address Stone", "green" );
                    }
                    return _address;
                case 5:
                    if( _complaint == null )
                    {
                        _complaint = new InputTile( "Complaint", "Complaint Stone", "purple" );
                    }
                    return _complaint;
                case 11:
                    if( _fenrir == null )
                    {
                        _fenrir = new MonsterTile( MonsterTypes.Fenrir );
                    }
                    return _fenrir;
                case 12:
                    if( _snake == null )
                    {
                        _snake = new MonsterTile( MonsterTypes.Snake );
                    }
                    return _snake;
                case 13:
                    if( _giant == null )
                    {
                        _giant = new MonsterTile( MonsterTypes.IceGiant );
                    }
                    return _giant;
                case 14:
                    return new MonsterTile( MonsterTypes.Fenrir );
                case 15:
                    return new MonsterTile( MonsterTypes.Fenrir );

                case 21:
                    if( _red == null )
                    {
                        _red = new KeyTile( "red" );
                    }
                    return _red;
                case 22:
                    if( _blue == null )
                    {
                        _blue = new KeyTile( "blue" );
                    }
                    return _blue;
                case 23:
                    if( _green == null )
                    {
                        _green = new KeyTile( "green" );
                    }
                    return _green;
                case 24:
                    if( _yellow == null )
                    {
                        _yellow = new KeyTile( "yellow" );
                    }
                    return _yellow;
                case 25:
                    if( _purple == null )
                    {
                        _purple = new KeyTile( "purple" );
                    }
                    return _purple;

                case 69:
                    if( _sword == null )
                    {
                        _sword = new SwordTitle();
                    }
                    return _sword;

                case 665:
                    return new PitOfDoomWarning();
                case 666:
                    return new PitOfDoom();
            }

            return new EmptyTile( "Didn't recognise the tile id" );
        }

        private static InputTile _title;
        private static InputTile _name;
        private static InputTile _address;
        private static InputTile _phoneNumber;
        private static InputTile _complaint;


        private static MonsterTile _fenrir;
        private static MonsterTile _snake;
        private static MonsterTile _giant;

        private static KeyTile _red;
        private static KeyTile _blue;
        private static KeyTile _green;
        private static KeyTile _yellow;
        private static KeyTile _purple;

        private static SwordTitle _sword;

    }
}