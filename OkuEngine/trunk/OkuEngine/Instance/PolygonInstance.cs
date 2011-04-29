using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  class PolygonInstance : VisualInstance
  {
    private PolygonContent _content = null;
    private float _lineWidth = 1.0f;
    private Color _lineColor = Color.White;
    private VertexInterpretation _interpretation = VertexInterpretation.Polygon;

    public PolygonInstance(PolygonContent content)
    {
      _content = content;
    }

    public override void Draw(Matrix3 transform)
    {
      OkuDrivers.Renderer.DrawLines(_content.Vertices, _lineWidth, _lineColor, _interpretation);
    }

    public PolygonContent Content
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

  }
}
