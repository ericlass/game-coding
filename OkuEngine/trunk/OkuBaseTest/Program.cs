using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Graphics;

namespace OkuBaseTest
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      OkuGame game = new FirstTestGame();
      game.Run();
    }
  }
}
