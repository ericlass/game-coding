using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;

namespace OkuBaseTest
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      OkuGame game = new OkuGame();
      game.Run();
    }
  }
}
