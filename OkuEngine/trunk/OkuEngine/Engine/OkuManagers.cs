using System;
using OkuEngine.Driver.Audio;
using OkuEngine.GCC.Resources;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  public static class OkuManagers
  {
    private static Input _input = null;
    private static ISoundEngine _sound = null;
    private static IRenderer _renderer = null;
    private static ResourceCache _resourceCache = null;

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

    public static ResourceCache ResourceCache
    {
      get { return _resourceCache; }
      set { _resourceCache = value; }
    }

  }
}
