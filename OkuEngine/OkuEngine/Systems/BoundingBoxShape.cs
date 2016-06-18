using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine.Systems
{
  public class BoundingBoxShape : ICollisionShape
  {
    private Vector2f _min = Vector2f.Zero;
    private Vector2f _max = Vector2f.Zero;

    private List<Vector2f[]> _vertices = null;

    public Vector2f Min
    {
      get { return _min; }
      set
      {
        _min = value;
        _vertices = null;
      }
    }

    public Vector2f Max
    {
      get { return _max; }
      set
      {
        _max = value;
        _vertices = null;
      }
    }

    public bool NeedsUpdate
    {
      get { return _vertices == null; }
    }

    public List<Vector2f[]> GetShapes()
    {
      if (_vertices == null)
      {
        _vertices = new List<Vector2f[]>(1);
        _vertices.Add(new Vector2f[]
        {
          _min,
          new Vector2f(_min.X, _max.Y),
          _max,
          new Vector2f(_max.X, _max.Y)
        });
      }
      return _vertices;
    }

  }
}
