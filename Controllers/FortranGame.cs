using System.Runtime.InteropServices;

namespace Controllers
{
  public class FortranAPI
  {
    [DllImport("libmain.so")]
    private static extern int move_(ref int x);
    [DllImport( "libmain.so")]
    private static extern int init_();

    public static int Init()
    {
      return init_();
    }
    
    public static int Move( int dir )
    {
      return move_( ref dir );
    }
  }
}
