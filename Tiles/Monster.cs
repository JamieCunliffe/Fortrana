using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Constants;

namespace Tiles
{
    public class MonsterTile : TileContext
    {
        private MonsterTypes _monsterType;

        public MonsterTile( MonsterTypes monsterType )
        {
            _monsterType = monsterType;
        }

        public string Description 
        { 
            get
            {
                return ConstantStrings.GetMonsterDescription( _monsterType, !_monsterDead);
            }
        }

        public string Action(string action, Player player)
        {
            if( !_monsterDead )
            {
                //any action here will result in death without the sword
                if( !player.Inventory.Contains("Sword") )
                {
                    player.Health = 0;
                    return "You died";
                }
                else
                {
                    _monsterDead = true;
                    return "Success you killed the monster";
                }
            }
            return "The monster is already dead do not disgrace its corpse";
        }    

        private bool _monsterDead = false;    
    }
}