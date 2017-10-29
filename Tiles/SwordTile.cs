using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayerInfo;
using Constants;

namespace Tiles
{
    public class SwordTitle : TileContext
    {
        public SwordTitle()
        {
            Found = false;
        }

        public string Description 
        { 
            get
            {
                if( Found )
                {
                    return ConstantStrings.GetMissingSword();    
                }
                else
                {
                    return ConstantStrings.GetSword();
                }
            }
        }

        public void Action(string action, Player player)
        {
            if( !Found )
            {
                //pick up sword
                Found = true;
                player.Inventory.Add( "Sword" );
            }
        }        

        private bool Found
        {
            get; set;
        }
    }
}