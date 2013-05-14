using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace OkuBase.Settings
{
  public class GraphicsSettings
  {
    private string _driverName = "opengl";
    private Color _bgColor = Color.Magenta;
    private bool _fullscreen = false;
    private TextureFilter _texFilter = TextureFilter.Linear;
    private int _renderPasses = 0;

    public string DriverName
    {
      get { return _driverName; }
      set { _driverName = value; }
    }    

    public Color BackgroundColor
    {
      get { return _bgColor; }
      set { _bgColor = value; }
    }

    public bool Fullscreen
    {
      get { return _fullscreen; }
      set { _fullscreen = value; }
    }

    public TextureFilter TextureFilter
    {
      get { return _texFilter; }
      set { _texFilter = value; }
    }

    private int RenderPasses
    {
      get { return _renderPasses; }
      set { _renderPasses = value; }
    }

  }
}
