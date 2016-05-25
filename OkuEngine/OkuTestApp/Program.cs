using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTestApp
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      //var level = new StartLevel();
      var level = new TilemapLevel();

      OkuEngineStart engine = new OkuEngineStart(level);
      engine.Run();
    }
  }
}
