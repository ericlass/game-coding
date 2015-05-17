using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuMath
{
  public static class TriangleMath
  {
    /// <summary>
    /// Calclucates the barycentric coordinates of the point p in the triangle defined by [a, b, c].
    /// </summary>
    /// <param name="a">The first point of the triangle.</param>
    /// <param name="b">The second point of the triangle.</param>
    /// <param name="c">The third point of the triangle.</param>
    /// <param name="p">The point.</param>
    /// <param name="u">The first barycentric coordinate is returned here.</param>
    /// <param name="v">The second barycentric coordinate is returned here.</param>
    /// <param name="w">The third barycentric coordinate is returned here.</param>
    public static void BarycentricCoordinates(Vector2f a, Vector2f b, Vector2f c, Vector2f p, out float u, out float v, out float w)
    {
      Vector2f v0 = b - a;
      Vector2f v1 = c - a;
      Vector2f v2 = p - a;

      float d00 = VectorMath.DotProduct(v0, v0);
      float d01 = VectorMath.DotProduct(v0, v1);
      float d11 = VectorMath.DotProduct(v1, v1);
      float d20 = VectorMath.DotProduct(v2, v0);
      float d21 = VectorMath.DotProduct(v2, v1);

      float denom = d00 * d11 - d01 * d01;

      v = (d11 * d20 - d01 * d21) / denom;
      w = (d00 * d21 - d01 * d20) / denom;
      u = 1.0f - v - w;
    }

  }
}
