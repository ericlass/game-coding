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

    private Vector[] _vertices = null;

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
      set
      {
        _left = value;
        _vertices = null;
      }
    }

    public float Right
    {
      get { return _right; }
      set
      {
        _right = value;
        _vertices = null;
      }
    }

    public float Top
    {
      get { return _top; }
      set 
      { 
        _top = value;
        _vertices = null;
      }
    }

    public float Bottom
    {
      get { return _bottom; }
      set 
      { 
        _bottom = value;
        _vertices = null;
      }
    }

    public Vector[] GetNormals()
    {
      //TODO: Make this lazy just like the vertices
      return new Vector[4] {
        Vector.FromPoints(_left, _top, _right, _top).GetNormal(),
        Vector.FromPoints(_right, _top, _right, _bottom).GetNormal(),
        Vector.FromPoints(_right, _bottom, _left, _bottom).GetNormal(),
        Vector.FromPoints(_left, _bottom, _left, _top).GetNormal()
      };
    }

    public bool PointInside(Vector p)
    {
      return (p.X >= _left) && (p.X <= _right) &&
             (p.Y >= _top) && (p.Y <= _bottom);
    }

    public Vector[] GetVertices()
    {
      if (_vertices == null)
      {
        _vertices = new Vector[] {
          new Vector(_left, _top),
          new Vector(_right, _top),
          new Vector(_right, _bottom),
          new Vector(_left, _bottom)
        };
      }
      return _vertices;
    }

    //TODO: OKU-3 - Add geometric functions like "intersect" and so on

  }
}
