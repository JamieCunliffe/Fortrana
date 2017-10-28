using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Tiles;
using Actions;

namespace Controllers
{
    public class API
    {
        private TileContext _currentTile = new EmptyTile("Starting point");
        private FortranSimulator _fortran= new FortranSimulator(true);
        private Player _player = new Player();

        public string Action( string message )
        {
            //parse the message
            ActionType moveType = Parser.GetAction(message);

            switch ( moveType )
            {
                case ActionType.Move:

                    int direction = Parser.GetDirection(message);

                    int result = _fortran.Move(direction);

                    _currentTile = TileFactory.GetTile(result);

                    break;
                case ActionType.Input:
                case ActionType.Action:

                    _currentTile.Action(message, _player);

                    break;
                default:
                    return "What I don't understand";
            }


            return _currentTile.Description;
        }

        static class Parser
        {
            public static ActionType GetAction( string message )
            {
                return ActionType.Move;
            }

            public static int GetDirection( string message )
            {
                int r;
                if ( Int32.TryParse( message, out r ) )
                {
                    return r;
                }
                return -1;
            }
        }
    }

    public class FortranSimulator
    {
        private int[,] _grid;
        private int positionX = 2;
        private int positionY = 2;
        private bool _useFortran;
        public FortranSimulator(bool useFortran)
        {
          _useFortran = useFortran;
          if( useFortran )
          {
            FortranAPI.Init();
          }
          else
          {
            _grid = new int[3,3];

            _grid[1, 2] = 2;
          }
        }

        public int Move( int direction )
        {
          if( _useFortran )
          {
            return FortranAPI.Move( direction );
          }
          else
          {
            switch ( (Direction)direction )
            {
                case Direction.Up:
                    if ( positionY != 0 )
                    {
                        positionY = positionY - 1;
                    }
                    break;
                case Direction.Down:
                    if ( positionY < 3 )
                    {
                        positionY = positionY + 1;
                    }
                    break;
                case Direction.Left:
                    if ( positionX != 0 )
                    {
                        positionX = positionX - 1;
                    }
                    break;
                case Direction.Right:
                    if ( positionX < 3 )
                    {
                        positionX++;
                    }
                    break;
            }
            return _grid[positionX, positionY];
          }
        }
    }
}
