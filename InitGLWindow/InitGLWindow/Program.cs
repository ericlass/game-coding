﻿using System;

namespace InitGLWindow
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    //[STAThread]
    static void Main()
    {
      GLApplication app = new GLApplication();
      app.Run();
    }
  }
}
