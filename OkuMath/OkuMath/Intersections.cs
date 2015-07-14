using System;

namespace OkuMath
{
  /// <summary>
  /// Defines functions to calculate the intersections of two primitives.
  /// </summary>
  public static class Intersections
  {
    /// <summary>
    /// Calculates the intersection point of two line segments defined by [a,b] and [c,d].
    /// Taken from "Realtime Collision Detection" page 152.
    /// </summary>
    /// <param name="a">The start point of the first line segment.</param>
    /// <param name="b">The end point of the first line segment.</param>
    /// <param name="c">The start point of the second line segment.</param>
    /// <param name="d">The end point of the second line segment.</param>
    /// <returns>The intersection point of the two line segments or NULL if the line segments do not intersect.</returns>
    public static Vector2f? LineSegmentLineSegment(Vector2f a, Vector2f b, Vector2f c, Vector2f d)
    {
      float a1 = TriangleMath.SignedTriangleArea(a, b, d);
      float a2 = TriangleMath.SignedTriangleArea(a, b, c);
      if (a1 != 0 && a2 != 0.0f && a1 * a2 < 0.0f)
      {
        float a3 = TriangleMath.SignedTriangleArea(c, d, a);
        float a4 = a3 + a2 - a1;
        if (a3 * a4 < 0.0f)
        {
          float t = a3 / (a3 - a4);
          return LineMath.PointOnLine(a, b, t);
        }
      }
      return null;
    }

    /// <summary>
    /// Calculates the intersection point of two line segments defined by [a,b] and [c,d].
    /// Uses the default approach which calucalates the intersection of the infinite lines
    /// and then checks if the intersection point lies within the segments.
    /// </summary>
    /// <param name="a">The start point of the first line segment.</param>
    /// <param name="b">The end point of the first line segment.</param>
    /// <param name="c">The start point of the second line segment.</param>
    /// <param name="d">The end point of the second line segment.</param>
    /// <returns>The intersection point of the two line segments or NULL if the line segments do not intersect.</returns>
    public static Vector2f? LineSegmentLineSegment2(Vector2f a, Vector2f b, Vector2f c, Vector2f d)
    {
      float num1 = d.X - c.X;
      float num2 = d.Y - c.Y;
      float num3 = b.X - a.X;
      float num4 = b.Y - a.Y;
      float num5 = a.Y - c.Y;
      float num6 = a.X - c.X;

      float denom = (num2 * num3) - (num1 * num4);
      if (denom == 0.0f)
        return null;

      float ua = ((num1 * num5) - (num2 * num6)) / denom;
      float ub = ((num3 * num5) - (num4 * num6)) / denom;

      if (ua < 0.0f || ua > 1.0f || ub < 0.0f || ub > 1.0f)
        return null;

      return a + (b - a) * ua;
    }

    /// <summary>
    /// Calculates the intersection point of two infinite lines going through the points defined by [a,b] and [c,d].
    /// Uses the approach which solves the linear equations of the to lines.
    /// </summary>
    /// <param name="a">The start point of the first line.</param>
    /// <param name="b">The end point of the first line.</param>
    /// <param name="c">The start point of the second line.</param>
    /// <param name="d">The end point of the second line.</param>
    /// <returns>The intersection point of the two lines or NULL if the lines do not intersect.</returns>
    public static Vector2f? LineLine(Vector2f a, Vector2f b, Vector2f c, Vector2f d)
    {
      float num1 = d.X - c.X;
      float num2 = d.Y - c.Y;

      float denom = (num2 * (b.X - a.X)) - (num1 * (b.Y - a.Y));
      if (denom == 0.0f)
        return null;

      float ua = ((num1 * (a.Y - c.Y)) - (num2 * (a.X - c.X))) / denom;
      return a + (b - a) * ua;
    }

  }
}
