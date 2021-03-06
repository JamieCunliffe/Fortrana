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

        public string Action(string action, Player player)
        {
            if( !Found )
            {
                if( action.ToLower().Contains( "pickup") == true )
                {
                    //pick up sword
                    Found = true;
                    player.Inventory.Add( "Sword" );
                    Console.WriteLine("Picked up the sword");
                    return "You picked up the sword";
                }
            }
            return ConstantStrings.GetMissingSword();  
        }        

        private bool Found
        {
            get; set;
        }
    }
}