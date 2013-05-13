using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Graphics;

namespace OkuBase
{
  public class Oku
  {
    private static Oku _instance = null;

    private static Oku Instance
    {
      get
      {
        if (_instance == null)
          _instance = new Oku();
        return _instance;
      }
    }

    private Oku()
    {
    }

    private GraphicsManager _graphics = null;

    public GraphicsManager Graphics
    {
      get
      {
        if (_graphics == null)
          _graphics = new GraphicsManager();
        return _graphics;
      }
    }

  }
}
