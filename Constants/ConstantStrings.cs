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
    
    }
}