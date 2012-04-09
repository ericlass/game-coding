using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public struct Quad
  {
    public Vector Min;
    public Vector Max;

    public Quad(Vector min, Vector max)
    {
      Min = min;
      Max = max;
    }

    public Quad(float left, float right, float top, float bottom)
    {
      Min = new Vector(left, bottom);
      Max = new Vector(right, top);
    }

    public Vector GetCenter()
    {
      return (Min + Max) * 0.5f;
    }

    public Vector[] GetNormals()
    {
      //TODO: Make this lazy just like the vertices
      return new Vector[4] {
        OkuMath.GetNormal(Min.X, Min.Y, Max.X, Min.Y),
        OkuMath.GetNormal(Max.X, Min.Y, Max.X, Max.Y),
        Vector.FromPoints(Max.X, Max.Y, Min.X, Max.Y).GetNormal(),
        Vector.FromPoints(Min.X, Max.Y, Min.X, Min.Y).GetNormal()
      };
    }

    //TODO: OKU-3 - Add geometric functions like "intersect" and so on

  }
}
