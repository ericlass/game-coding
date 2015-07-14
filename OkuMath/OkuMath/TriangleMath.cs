using System;

namespace OkuMath
{
  /// <summary>
  /// Defines functions to work with triangles.
  /// </summary>
  public static class TriangleMath
  {
    public static float SignedTriangleArea(Vector2f a, Vector2f b, Vector2f c)
    {
      return (a.X - c.X) * (b.Y - c.Y) - (a.Y - c.Y) * (b.X - c.X);
    }

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
      float A, B, C, D, E, F, AE, BD;

      A = a.X - c.X;
      B = b.X - c.X;
      C = c.X - p.X;

      D = a.Y - c.Y;
      E = b.Y - c.Y;
      F = c.Y - p.Y;

      AE = A * E;
      BD = B * D;

      u = (B * F - C * E) / (AE - BD);
      v = (A * F - C * D) / (BD - AE);
      w = 1.0f - u - v;
    }

  }
}
