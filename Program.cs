using System;
using System.Runtime.InteropServices;


namespace hwapp
{    
    class Program
    {
        [DllImport("libtest.so")]
        public static extern void testfunc_();

        static void Main(string[] args)
        { 
            testfunc_();
        }
    }
}
