using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Tiles;
using Actions;
using mvc_template.models;

namespace Controllers
{
    public class GameContext
    {
        private TileContext _currentTile = new EmptyTile( "This is where your journey begins" );
        private FortranProxy _fortranProxy = new FortranProxy();

        public GameContext()
        {
            _fortranProxy.Init();
        }

        public string Move( ResultModel model )
        {
            try
            {
                string direction = model.parameters.direction.ToString();

                int directionToSend = -1;

                switch( direction.ToLower() )
                {
                    case "left":
                    //handle left
                    directionToSend = 2;
                    break;

                    case "right":
                    //handle right 
                    directionToSend = 3;
                    break;

                    case "up":
                    //handle up
                    directionToSend = 0;
                    break;

                    case "down":
                    //handle down
                    directionToSend = 1;
                    break;

                    default:
                        return "I didn't understand that";
                }
                
                int fortranResult = _fortranProxy.SendToFortran( directionToSend );

                var t = TileFactory.GetTile( fortranResult );
                _currentTile = t;

                return t.Description;
            }
            catch( Exception e )
            {
                return $"Error occured, {e.ToString()}";
            }
        }
    }

    public class FortranProxy
    {
        public int SendToFortran( int direction )
        {
            return Move(direction);
        }

        [DllImport("libmain.so")]
        private static extern int move_(ref int x);
        [DllImport( "libmain.so")]
        private static extern int init_();

        public static int Init()
        {
        return init_();
        }
        
        public static int Move( int dir )
        {
        return move_( ref dir );
        }
    }
}