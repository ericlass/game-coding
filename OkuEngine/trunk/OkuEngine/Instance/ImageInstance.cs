using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ImageInstance : ContentInstance
  {
    private ImageContent _content = null;
    private Color _tintColor = Color.White;
    private float _transparency = 0.0f;
    private string _shader = null;

    private ImageInstance(ImageContent content)
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

    public float Transparency
    {
      get { return _transparency; }
      set { _transparency = value; }
    }

    public string Shader
    {
      get { return _shader; }
      set { _shader = value; }
    }

  }
}
