using System;

namespace Constants
{
    public static class ConstantStrings
    {
        public static string GetPitOfDoomString()
        {
            return "You've fallen into the pit of doom forever a slave of Hel, please try again an be more careful this time";
        }

        public static string GetPitOfDoomWarningString()
        {
            return "You balance close to the pit of doom, one wrong foot and you'll find out where it gets it's name from";
        }

        public static string GetKey( string colour )
        {
            return $"On the ground you see a key, it glows {colour}, this could be important to your quest";
        }

        public static string GetSword()
        {
            return $"A sword lies on the ground in front of you, the hilt shines with the sunlight which is weird because its night";
        }

        public static string GetMissingSword()
        {
            return "This is where you found the sword earlier, who leave a sword lying about";
        }
    

        public static string GetMonsterDescription( MonsterTypes monsterType, bool alive )
        {
            switch( monsterType )
            {
                case MonsterTypes.Fenrir:
                    if( alive )
                    {
                        return "The snarling wolf stares at you, the legendary Fenrir, you understand why the norse gods fear him";
                    }
                    else
                    {
                        return "The wolf body lays on the floor, its coat could supply a whole village, Odin may now rest easy";
                    }
                case MonsterTypes.Snake:
                    if( alive )
                    {
                        return "The giant snake surpasses moutains in size, destined to devour to world";
                    }
                    else
                    {
                        return "The only the skin of the snake is left, will Loki seek revenge for this";
                    }
                case MonsterTypes.IceGiant:
                    if( alive )
                    {
                        return "You feel your spine shiver with the cold, this giant is 4 times larger than you, and looks angry";
                    }
                    else
                    {
                        return "The villagers will surely sing sonnets of your triumph over this abomination";
                    }
            }
            return "";
        }
    }
}