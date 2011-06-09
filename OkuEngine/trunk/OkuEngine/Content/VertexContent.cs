using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class VertexContent : VisualContent
  {
    private VertexList _vertices = null;

    public VertexContent()
    {
      _vertices = new VertexList();
    }

    public VertexContent(VertexList vertices)
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
