using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Driver.Renderer
{
  public class RenderSettings
  {
    private string _type = "opengl";
    private bool _fullscreen = false;
    private int _width = 1024;
    private int _height = 768;
    private bool _depthTest = false;
    private Color _clearColor = Color.Magenta;

    public string Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public bool Fullscreen
    {
      get { return _fullscreen; }
      set { _fullscreen = value; }
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

    public bool DepthTest
    {
      get { return _depthTest; }
      set { _depthTest = value; }
    }

    public Color ClearColor
    {
      get { return _clearColor; }
      set { _clearColor = value; }
    }

  }
}
