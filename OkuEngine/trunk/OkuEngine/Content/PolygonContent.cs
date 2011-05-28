using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PolygonContent : VisualContent
  {
    private VertexList _vertices = null;

    public PolygonContent()
    {
      _vertices = new VertexList();
    }

    public PolygonContent(VertexList vertices)
    {
      _vertices = vertices;
    }

    public VertexList Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

  }
}
