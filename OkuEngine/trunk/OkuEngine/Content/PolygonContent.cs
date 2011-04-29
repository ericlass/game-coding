using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PolygonContent : VisualContent
  {
    private VectorList _vertices = new VectorList();

    public PolygonContent(VectorList vertices)
    {
      _vertices = vertices;
    }

    public VectorList Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

  }
}
