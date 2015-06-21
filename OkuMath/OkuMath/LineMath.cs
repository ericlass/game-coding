using System;

namespace OkuMath
{
  /// <summary>
  /// Defines math functions for lines, rays and line segments.
  /// </summary>
  public static class LineMath
  {
    /// <summary>
    /// Calculates a point on the line defined by [a,b] controlled by t.
    /// </summary>
    /// <param name="a">The start point of the line.</param>
    /// <param name="b">The end point of the line.</param>
    /// <param name="t">The control value.</param>
    /// <returns>The point on the line at the given control value.</returns>
    public static Vector2f PointOnLine(Vector2f a, Vector2f b, float t)
    {
      return a + (b - a) * t;
    }

    /// <summary>
    /// Project the point p to the vector that the line given by [a,b] forms.
    /// </summary>
    /// <param name="a">The start point of the line.</param>
    /// <param name="b">The end point of the line.</param>
    /// <param name="p">The point to project.</param>
    /// <returns>The control value where the point is projected on the line.</returns>
    public static float ProjectPointOnLine(Vector2f a, Vector2f b, Vector2f p)
    {
      Vector2f ab = b - a;
      return VectorMath.DotProduct(p - a, ab) / ab.SquaredMagnitude;
    }

    /// <summary>
    /// Calculates the squared distance of point p to the line segment defined by [a,b].
    /// </summary>
    /// <param name="a">The first point of the line segment.</param>
    /// <param name="b">The second point of the line segment.</param>
    /// <param name="p">The point.</param>
    /// <returns>The squared distance of the point to the line segment.</returns>
    public static float SquaredDistanceToPoint(Vector2f a, Vector2f b, Vector2f p)
    {
      Vector2f ab = b - a;
      Vector2f ap = p - a;
      Vector2f bp = p - b;

      float e = VectorMath.DotProduct(ap, ab);

      if (e <= 0.0f)
        return ap.SquaredMagnitude;

      float f = ab.SquaredMagnitude;

      if (e >= f)
        return bp.SquaredMagnitude;

      return ap.SquaredMagnitude - e * e / f;
    }

  }
}
