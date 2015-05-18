using System;

namespace OkuMath
{
  /// <summary>
  /// Defines functions to calculate the closest point for various primitives.
  /// </summary>
  public static class ClosestPoint
  {
    /// <summary>
    /// Calculates the point on the line segment defined by [a,b] which is closest to the point p.
    /// The returned control value is guaranteed to be in the range [0.0...1.0].
    /// </summary>
    /// <param name="a">The start of the line segment.</param>
    /// <param name="b">The end of the line segment.</param>
    /// <param name="p">The point.</param>
    /// <param name="t">The control value for the point closest to p is returned here. (c = a + (b - a) * t)</param>
    /// <param name="c">The closest point is returned here.</param>
    public static void OnLineSegmentToPoint(Vector2f a, Vector2f b, Vector2f p, out float t, out Vector2f c)
    {
      Vector2f ab = b - a;
      t = VectorMath.DotProduct(p - a, ab) / ab.SquaredMagnitude;
      
      if (t < 0.0f)
      {
        t = 0.0f;
        c = a;
      }
      else if (t > 1.0f)
      {
        t = 1.0f;
        c = b;
      }
      else
      {
        c = a + (ab * t);
      }      
    }

    /// <summary>
    /// Calculates the point on the ray starting in a and going into direction defined by b
    /// which is closest to the point p. The returned control value is guaranteed to be >= 0.
    /// </summary>
    /// <param name="a">The start of ray.</param>
    /// <param name="b">The direction of th ray.</param>
    /// <param name="p">The point.</param>
    /// <param name="t">The control value for the point closest to p is returned here. (c = a + b * t)</param>
    /// <param name="c">The closest point is returned here.</param>
    public static void OnRayToPoint(Vector2f a, Vector2f b, Vector2f p, out float t, out Vector2f c)
    {
      Vector2f ab = b - a;
      t = VectorMath.DotProduct(p - a, ab) / ab.SquaredMagnitude;

      if (t < 0.0f)
      {
        t = 0.0f;
        c = a;
      }
      else
      {
        c = a + (ab * t);
      }
    }

    /// <summary>
    /// Calculates the point on the infinite line that goes through the points a and b
    /// which is closest to the point p.
    /// </summary>
    /// <param name="a">The first point of the line.</param>
    /// <param name="b">The second point of the line.</param>
    /// <param name="p">The point.</param>
    /// <param name="t">The control value for the point closest to p is returned here. (c = a + (b - a) * t)</param>
    /// <param name="c">The closest point is returned here.</param>
    public static void OnLineToPoint(Vector2f a, Vector2f b, Vector2f p, out float t, out Vector2f c)
    {
      Vector2f ab = b - a;
      t = VectorMath.DotProduct(p - a, ab) / ab.SquaredMagnitude;
      c = a + (ab * t);
    }

    /// <summary>
    /// Calculates the point in the AABB defined by [min,max] which is closest to the point p.
    /// If p is inside the AABB, the result is p.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <param name="p">The point.</param>
    /// <param name="c">The closest point is returned here.</param>
    public static void OnAABBToPoint(Vector2f min, Vector2f max, Vector2f p, out Vector2f c)
    {
      c = new Vector2f(BasicMath.Clamp(p.X, min.X, max.X), BasicMath.Clamp(p.Y, min.Y, max.Y));
    }

  }
}
