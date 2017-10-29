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
        private Player _player;

        public bool GameOver
        {
            get; private set;
        }

        public GameContext()
        {
            _fortranProxy.Start();
            _player = new Player();
        }
        

        public string GetDebugString()
        {
            int x = _fortranProxy.GetX();
            int y = _fortranProxy.GetY();

            return $"current position ({x},{y})";
        }

        public string Action( ResultModel model )
        {
            Console.WriteLine("Performing action");
            var result = _currentTile.Action( model.action, _player );

            if( _player.IsDead )
            {
                GameOver = true;
                return "You died game over";
            }
            return result;
        }

        public string Action( string model )
        {
            Console.WriteLine("Performing action");
            var result = _currentTile.Action( model, _player );

            if( _player.IsDead )
            {
                GameOver = true;
                return "You died game over";
            }
            return result;
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
                directionToSend++;
                
                int fortranResult = _fortranProxy.SendToFortran( directionToSend );

                if( fortranResult == 6 )
                {
                    return @"There is a large pillar blocking your way, you'll have to go around";
                }

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

        public void Start()
        {
            Init();
        }

        public int GetX()
        {
            return GetXPos();
        }

        public int GetY()
        {
            return GetYPos();
        }

        [DllImport("libmain.so")]
        private static extern int move_(ref int x);
        [DllImport( "libmain.so")]
        private static extern int init_();
        [DllImport("libmain.so")]
        private static extern int getxpos_();
        [DllImport( "libmain.so")]
        private static extern int getypos_();

        private static int Init()
        {
        return init_();
        }
        
        public static int Move( int dir )
        {
        return move_( ref dir );
        }

        public static int GetXPos() {
          return getxpos_();
        }
        public static int GetYPos() {
          return getypos_();
        }
    }
}
