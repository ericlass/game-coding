using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PolygonInstance : VisualInstance
  {
    private VertexContent _content = null;
    private float _lineWidth = 1.0f;
    private Color _lineColor = Color.White;
    private VertexInterpretation _interpretation = VertexInterpretation.Polygon;

    public PolygonInstance(VertexContent content)
    {
      _content = content;
    }

    public VertexContent Content
    {
      get { return _content; }
      set { _content = value; }
    }

    public float LineWidth
    {
      get { return _lineWidth; }
      set { _lineWidth = value; }
    }

    public Color LineColor
    {
      get { return _lineColor; }
      set { _lineColor = value; }
    }

    public VertexInterpretation Interpretation
    {
      get { return _interpretation; }
      set { _interpretation = value; }
    }

    public void Draw()
    {
      if (_content.Colors != null)
        OkuDrivers.Renderer.DrawLines(_content.Positions, _content.Colors, _content.Positions.Length, _lineWidth, _interpretation);
      else
        OkuDrivers.Renderer.DrawLines(_content.Positions, _lineColor, _content.Positions.Length, _lineWidth, _interpretation);
    }

  }
}
