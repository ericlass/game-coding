using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.GCC.Actors.Components
{
  public abstract class RenderComponent : ActorComponent
  {
    public const int ComponentId = 2;
    public const string ComponentName = "renderable";

    protected Vector[] _points = null;
    protected Vector[] _texCoords = null;
    protected Color[] _colors = null;
    protected DrawMode _mode = DrawMode.None;
    protected ImageContent _image = null;
    protected string _imageName = null;

    public string ImageName
    {
      get { return _imageName; }
      set { _imageName = value; }
    }

    public Vector[] Points
    {
      get { return _points; }
      set { _points = value; }
    }

    public Vector[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    public Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

    public DrawMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    public ImageContent Image
    {
      get { return _image; }
      set { _image = value; }
    }

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public abstract bool PreRender();
    public abstract bool PostRender();

    public abstract override bool Load(XmlNode node);
    public abstract override void Save(XmlWriter writer);

  }
}
