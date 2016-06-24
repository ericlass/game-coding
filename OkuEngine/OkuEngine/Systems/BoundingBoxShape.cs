using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine.Systems
{
  public class BoundingBoxShape : CollisionShape
  {
    private Vector2f _min = Vector2f.Zero;
    private Vector2f _max = Vector2f.Zero;
    private bool _dirty = true;

    private List<Vector2f[]> _vertices = null;

    public BoundingBoxShape()
    {
    }

    public Vector2f Min
    {
      get { return _min; }
      set
      {
        _min = value;
        _dirty = true;
      }
    }

    public Vector2f Max
    {
      get { return _max; }
      set
      {
        _max = value;
        _dirty = true;
      }
    }

    internal override bool Dirty
    {
      get { return _dirty; }
    }

    public override List<Vector2f[]> GetShapes()
    {
      if (_dirty)
      {
        _vertices = new List<Vector2f[]>(1);
        _vertices.Add(new Vector2f[]
        {
          _min,
          new Vector2f(_min.X, _max.Y),
          _max,
          new Vector2f(_max.X, _max.Y)
        });

        _dirty = false;
      }
      return _vertices;
    }

  }
}
