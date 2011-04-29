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

    private ImageInstance(ImageContent content)
    {
      _content = content;
    }

    public override void Draw(Matrix3 transform)
    {
      OkuDrivers.Renderer.DrawImage(_content, transform, _tintColor);
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

  }
}
