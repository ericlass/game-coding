using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      OkuGame game = new TileTestGame();
      game.Run();
    }

  }
}
