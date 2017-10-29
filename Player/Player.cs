using System;
using System.Collections.Generic;

namespace PlayerInfo
{

    public class Player
    {
        public Player()
        {
            Health = 50;
            Inventory = new List<string>();
        }

        public int Health
        {
            get; set;
        }

        public List<string> Inventory
        {
            get; private set;
        }

        public bool IsDead
        {
            get {  return Health == 0; }
        }
    }
}