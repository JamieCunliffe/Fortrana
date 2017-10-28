using System;

namespace Constants
{
    public static class ConstantStrings
    {
        public static string GetPitOfDoomString()
        {
            return "You've falled into the pit of doom forever a slave of Hades, please try again an be more careful this time";
        }

        public static string GetPitOfDoomWarningString()
        {
            return "You balance close to the pit of doom, one wrong foot and you'll find out where it gets it's name from";
        }

        public static string GetKey( string colour )
        {
            return $"On the ground you see a key, it glows {colour}, this could be important to your quest";
        }
    }
}