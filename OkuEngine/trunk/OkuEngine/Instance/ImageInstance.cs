using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ImageInstance : VisualInstance
  {
    private ImageContent _content = null;
    private Color _tintColor = Color.White;

    public ImageInstance(ImageContent content)
    {
      _content = content;
    }

    public ImageContent Content
    {
      get { return _content; }
      set { _content = value; }
    }

    public Color TintColor
    {
      get { return _tintColor; }
      set { _tintColor = value; }
    }

    public void Draw(float x, float y)
    {
      OkuDrivers.Renderer.DrawImage(_content, new Vector(x, y));
    }

    public void Draw(Vector position)
    {
      OkuDrivers.Renderer.DrawImage(_content, position, _tintColor);
    }

    public void Draw(Vector position, float rotation)
    {
      OkuDrivers.Renderer.DrawImage(_content, position, rotation, _tintColor);
    }

    public void Draw(Vector position, Vector scale)
    {
      OkuDrivers.Renderer.DrawImage(_content, position, scale, _tintColor);
    }

    public void Draw(Vector position, float rotation, Vector scale)
    {
      OkuDrivers.Renderer.DrawImage(_content, position, rotation, scale, _tintColor);
    }

  }
}
