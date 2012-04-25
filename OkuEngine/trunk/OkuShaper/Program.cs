using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuEngine;

namespace OkuShaper
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      OkuGame game = new Shaper();
      game.Run();
    }
  }
}
