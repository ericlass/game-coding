using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace OkuBase.Settings
{
  /// <summary>
  /// Defines settings for the graphics driver.
  /// </summary>
  public class GraphicsSettings
  {
    private string _driverName = "opengl";
    private Color _bgColor = Color.Magenta;
    private bool _fullscreen = false;
    private TextureFilter _texFilter = TextureFilter.Linear;
    private int _width = 800;
    private int _height = 600;
    private bool _depthTest = false;
    private bool _dpiAware = false;

    /// <summary>
    /// Gets or sets the name of the driver to be used. "null" is always available if you do not want graphics.
    /// </summary>
    public string DriverName
    {
      get { return _driverName; }
      set { _driverName = value; }
    }    

    /// <summary>
    /// Gets or sets the color that is used to clear the screen and therefore is the background color.
    /// </summary>
    public Color BackgroundColor
    {
      get { return _bgColor; }
      set { _bgColor = value; }
    }

    /// <summary>
    /// Gets or sets if the window should be fullscreen or not.
    /// </summary>
    public bool Fullscreen
    {
      get { return _fullscreen; }
      set { _fullscreen = value; }
    }

    /// <summary>
    /// Gets or sets the filter that is used for scaling textures.
    /// </summary>
    public TextureFilter TextureFilter
    {
      get { return _texFilter; }
      set { _texFilter = value; }
    }

    /// <summary>
    /// Gets or sets the width of the game window in pixels, excluding the window borders.
    /// </summary>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Gets or sets the height of the game window in pixels, excluding the window borders.
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Gets or sets if the depth test should be enabled or not.
    /// </summary>
    public bool EnableDepthTest
    {
      get { return _depthTest; }
      set { _depthTest = value; }
    }

    /// <summary>
    /// Gets or sets if the window is automatically scalled on high DPI displays (false, the default)
    /// or the game itself is aware of that and scales accordingly (true).
    /// </summary>
    public bool DpiAware
    {
      get { return _dpiAware; }
      set { _dpiAware = value; }
    }

  }
}
