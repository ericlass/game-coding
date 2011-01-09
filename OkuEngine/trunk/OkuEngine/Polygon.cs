using System;
using System.Collections.Generic;

namespace OkuEngine
{
  /// <summary>
  /// Simple polygon class which is just a list of vectors specifying the points of the polygon.
  /// +++ NOT YET APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class Polygon : List<Vector>
  {
    public Polygon()
    {
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
