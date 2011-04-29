using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class OkuDrivers
  {
    private static Input _input = null;
    private static ISoundEngine _sound = null;
    private static IRenderer _renderer = null;

    public static Input Input
    {
      get 
      {
        if (_input == null)
          _input = new Input();
        return _input;
      }
      set { _input = value; }
    }

    public static ISoundEngine SoundEngine
    {
      get { return _sound; }
      set { _sound = value; }
    }

    public static IRenderer Renderer
    {
      get { return _renderer; }
      set { _renderer = value; }
    }

  }
}
