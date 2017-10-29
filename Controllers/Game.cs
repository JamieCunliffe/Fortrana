using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Tiles;
using Actions;

namespace Controllers
{
    // public class API
    // {
    //     private TileContext _currentTile = new EmptyTile("Starting point");
    //     private Player _player = new Player();
    //     public string MoveAction( ResultModel resultModel )
    //     {
                            
    //     int direction = Parser.GetDirection(message);

    //     int result = _fortran.Move(direction);

    //                 _currentTile = TileFactory.GetTile(result);
    //     }

    //     public string Action( string message )
    //     {
    //         //parse the message
    //         ActionType moveType = Parser.GetAction(message);

    //         switch ( moveType )
    //         {
    //             case ActionType.Move:

    //                 int direction = Parser.GetDirection(message);

    //                 int result = _fortran.Move(direction);

    //                 _currentTile = TileFactory.GetTile(result);

    //                 break;
    //             case ActionType.Input:
    //             case ActionType.Action:

    //                 _currentTile.Action(message, _player);

    //                 break;
    //             default:
    //                 return "What I don't understand";
    //         }


    //         return _currentTile.Description;
    //     }
    // }
}
