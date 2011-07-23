using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class Quad
  {
    private float _left;
    private float _right;
    private float _top;
    private float _bottom;

    public Quad(float left, float right, float top, float bottom)
    {
      _left = left;
      _right = right;
      _top = top;
      _bottom = bottom;
    }

    public float Left
    {
      get { return _left; }
      set { _left = value; }
    }

    public float Right
    {
      get { return _right; }
      set { _right = value; }
    }

    public float Top
    {
      get { return _top; }
      set { _top = value; }
    }

    public float Bottom
    {
      get { return _bottom; }
      set { _bottom = value; }
    }

    public VectorList GetNormals()
    {
      return new VectorList() {
        Vector.FromPoints(_left, _top, _right, _top).GetNormal(),
        Vector.FromPoints(_right, _top, _right, _bottom).GetNormal(),
        Vector.FromPoints(_right, _bottom, _left, _bottom).GetNormal(),
        Vector.FromPoints(_left, _bottom, _left, _top).GetNormal()
      };
    }

    //TODO: OKU-3 - Add geometric functions like "intersect" and so on

  }
}
