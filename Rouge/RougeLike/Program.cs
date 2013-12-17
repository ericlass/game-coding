using System;
using System.Windows.Forms;
using OkuBase;

namespace RougeLike
{
  /// <summary>
  /// Class with program entry point.
  /// </summary>
  internal sealed class Program
  {
    /// <summary>
    /// Program entry point.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
      OkuGame game = new RougeGame();
      game.Run();
    }
    
  }
}
