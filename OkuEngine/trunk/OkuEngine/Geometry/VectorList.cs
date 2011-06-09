using System;
using System.Collections.Generic;

namespace OkuEngine
{
  /// <summary>
  /// Simple polygon class which is just a list of vectors specifying the points of the polygon.
  /// </summary>
  public class VectorList : List<Vector>
  {
    public VectorList()
    {
    }

    /// <summary>
    /// Calculates the bounding box of the vector list. The complexity is O(n).
    /// </summary>
    /// <returns>The calculated bounding box of the vector list.</returns>
    public Quad GetBoundingBox()
    {
      float left = float.MaxValue;
      float right = float.MinValue;
      float top = float.MaxValue;
      float bottom = float.MinValue;

      foreach (Vector vec in this)
      {
        left = Math.Min(left, vec.X);
        right = Math.Max(right, vec.X);
        top = Math.Min(top, vec.Y);
        bottom = Math.Max(bottom, vec.Y);
      }

      return new Quad(left, right, top, bottom);
    }

    public bool IsConvex()
    {
      int lastSign = 0;
      bool first = true;
      for (int i = 0; i < Count - 1; i++)
      {
        Vector current = this[i];
        Vector vec1 = this[(i + 1) % Count] - current;
        Vector vec2 = this[(i + 2) % Count] - current;

        if (!first)
        {
          int sign = Math.Sign(Vector.DotProduct(vec1, vec2));
          if ((sign < 0 && lastSign > 0) || (sign > 0 && lastSign < 0))
            return false;
          lastSign = sign;
        }
        else
        {
          lastSign = Math.Sign(Vector.DotProduct(vec1, vec2));
          first = false;
        }
      }
      return true;
    }

  }
}
