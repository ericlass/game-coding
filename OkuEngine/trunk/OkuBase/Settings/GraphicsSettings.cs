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
    private int _width = 800;
    private int _height = 600;
    private bool _depthTest = false;

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

    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    public bool EnableDepthTest
    {
      get { return _depthTest; }
      set { _depthTest = value; }
    }

  }
}
