﻿using System;
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
      OkuEngineStart engine = new OkuEngineStart(new StartLevel());
      engine.Run();
    }
  }
}
