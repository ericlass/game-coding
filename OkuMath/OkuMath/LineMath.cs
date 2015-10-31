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
      if (t == 0.0f)
        return a;
      else if (t == 1.0f)
        return b;
      else
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
      return VectorMath.ProjectScalar(p - a, b - a); // VectorMath.DotProduct(p - a, ab) / ab.SquaredMagnitude;
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

    /// <summary>
    /// Calculates a point on the ray defined by the origin o and the direction d, controlled by t.
    /// </summary>
    /// <param name="o">The origin of the ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="t">The control parameter.</param>
    /// <returns>The point on the ray at the given control value.</returns>
    public static Vector2f PointOnRay(Vector2f o, Vector2f d, float t)
    {
      if (t == 0.0f)
        return o;
      else
        return o + d * t;
    }

    /// <summary>
    /// Calculates the left hand normal of the line segment defined by [a,b].
    /// </summary>
    /// <param name="a">The first point of the line segment.</param>
    /// <param name="b">The second point of the line segment.</param>
    /// <returns>The normalized left hand normal.</returns>
    public static Vector2f GetNormal(Vector2f a, Vector2f b)
    {
      return VectorMath.Normalize(new Vector2f(b.Y - a.Y, -(b.X - a.X)));      
    }

  }
}
