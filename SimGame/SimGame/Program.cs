using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;

namespace SimGame
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      OkuGame game = new SimGameMain();
      game.Run();
    }
  }
}
