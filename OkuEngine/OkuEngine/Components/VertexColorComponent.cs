using System;
using OkuBase.Graphics;

namespace OkuEngine.Components
{
  public class VertexColorComponent : IComponent
  {
    public const string ComponentName = "vertexcolor";

    private Color _color = Color.White;

    public VertexColorComponent()
    {
    }

    public VertexColorComponent(Color color)
    {
      _color = color;
    }

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public bool IsMultiAssignable
    {
      get{ return true; }
    }

    public string Name
    {
      get{ return ComponentName; }
    }

    public IComponent Copy()
    {
      return new VertexColorComponent(_color);
    }

  }
}
