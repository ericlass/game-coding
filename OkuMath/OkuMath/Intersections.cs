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

    /// <summary>
    /// Calculates the point(s) where the infinite line defined by the points a and b
    /// intersects the circle defined by the center c and radius r.
    /// </summary>
    /// <param name="a">The first point of the line.</param>
    /// <param name="b">The second point of the line.</param>
    /// <param name="c">The center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <returns>
    /// Null if the line does not intersect the circle.
    /// A single point when the line perfectly hits the perimeter of the circle, which means it is a tangent.
    /// Two points when the line crosses the circle, which means it is a secant.
    /// </returns>
    public static Vector2f[] LineCircle(Vector2f a, Vector2f b, Vector2f c, float r)
    {
      float tp = ClosestPoint.OnLineToPointF(a, b, c);
      Vector2f p = LineMath.PointOnLine(a, b, tp);
      float dist = VectorMath.Distance(c, p);

      //Line does not intersect the circle at all (Passante)
      if (dist > r)
        return null;

      //Line perfectly hits the circles perimeter (Tangente)
      if (dist == r)
        return new Vector2f[] { p };

      //Line crosses the circle (Sekante)
      float w = CircleMath.HalfWidthOfCircle(dist / r) * r;
      float wt = w / VectorMath.Distance(a, b);

      return new Vector2f[]
      {
        LineMath.PointOnLine(a, b, tp - wt),
        LineMath.PointOnLine(a, b, tp + wt),
      };
    }

    /// <summary>
    /// Calculates the point(s) where the infinite ray, defined by the origin o and the direction d,
    /// intersects the circle defined by the center c and radius r.
    /// </summary>
    /// <param name="o">The origin of the ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="c">The center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <returns>
    /// Null if the ray does not intersect the circle.
    /// A single point when the ray perfectly hits the perimeter of the circle, which means it is a tangent.
    /// One or two points when the ray crosses the circle, which means it is a secant,
    /// depnding on if the rays origin is inside the circle or not.
    /// </returns>
    private static Vector2f[] RayCircleNaive(Vector2f o, Vector2f d, Vector2f c, float r)
    {
      float tp = ClosestPoint.OnRayToPointF(o, d, c);
      Vector2f p = LineMath.PointOnRay(o, d, tp);
      float dist = VectorMath.Distance(c, p);

      //Ray does not intersect the circle at all (Passante)
      if (dist > r)
        return null;

      //Ray perfectly hits the circles perimeter (Tangente)
      if (dist == r)
        return new Vector2f[] { p };

      //Ray crosses the circle (Sekante)
      float w = CircleMath.HalfWidthOfCircle(dist / r) * r;
      float wt = w / d.Magnitude;

      float tMin = tp - wt;

      //If first point is before ray origin, do not return it.
      //The ray origin is inside the circle and there is only one intersection in this case.
      if (tMin < 0.0f)
        return new Vector2f[] { LineMath.PointOnRay(o, d, tp + wt) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(o, d, tMin),
        LineMath.PointOnRay(o, d, tp + wt),
      };
    }

    /// <summary>
    /// Calculates the point(s) where the infinite ray, defined by the origin o and the direction d,
    /// intersects the circle defined by the center c and radius r.
    /// </summary>
    /// <param name="o">The origin of the ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="c">The center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <returns>
    /// Null if the ray does not intersect the circle.
    /// A single point when the ray perfectly hits the perimeter of the circle, which means it is a tangent.
    /// One or two points when the ray crosses the circle, which means it is a secant,
    /// depnding on if the rays origin is inside the circle or not.
    /// </returns>
    public static Vector2f[] RayCircle(Vector2f o, Vector2f d, Vector2f c, float r)
    {
      Vector2f oc = c - o;

      float a = VectorMath.Project(oc, d).SquaredMagnitude;
      float e = oc.SquaredMagnitude;
      float f = r * r - e + a;

      //Ray does not hit circle
      if (f < 0)
        return null;

      f = (float)Math.Sqrt(f);
      a = (float)Math.Sqrt(a);

      float length = d.Magnitude;
      float tMin = (a - f) / length;
      float tMax = (a + f) / length;

      if (tMin < 0 || tMin == tMax)
        return new Vector2f[] { LineMath.PointOnRay(o, d, tMax) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(o, d, tMin),
        LineMath.PointOnRay(o, d, tMax),
      };
    }

    /// <summary>
    /// Calculates the point(s) where the line segment defined by the points a and b
    /// intersects the circle defined by the center c and radius r.
    /// </summary>
    /// <param name="a">The first point of the line segment.</param>
    /// <param name="b">The second point of the line segment.</param>
    /// <param name="c">The center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <returns>
    /// Null if the line segment does not intersect the circle.
    /// A single point when the line segment perfectly hits the perimeter of the circle, which means it is a tangent.
    /// Null, one or two points when the line crosses the circle, which means it is a secant,
    /// depending on if the line segment starts and/or ends inside in the circle.
    /// </returns>
    public static Vector2f[] LineSegmentCircle(Vector2f a, Vector2f b, Vector2f c, float r)
    {
      float tp = ClosestPoint.OnLineSegmentToPointF(a, b, c);
      Vector2f p = LineMath.PointOnLine(a, b, tp);
      float dist = VectorMath.Distance(c, p);

      //Line does not intersect the circle at all (Passante)
      if (dist > r)
        return null;

      //Line perfectly hits the circles perimeter (Tangente)
      if (dist == r)
        return new Vector2f[] { p };

      //Line crosses the circle (Sekante)
      float w = CircleMath.HalfWidthOfCircle(dist / r) * r;
      float wt = w / VectorMath.Distance(a, b);

      float tMin = tp - wt;
      float tMax = tp + wt;

      if (tMin < 0.0f)
      {
        if (tMax > 1.0f)
          return null; //Both start and end are inside of the circle
        else
          return new Vector2f[] { LineMath.PointOnLine(a, b, tMax) }; //Start is inside, end is outside
      }
      else
      {
        if (tMax > 1.0f)
          return new Vector2f[] { LineMath.PointOnLine(a, b, tMin) }; //Start is outside, end is inside
        else
          return new Vector2f[] //Both start and end are outside
          {
            LineMath.PointOnLine(a, b, tMin),
            LineMath.PointOnLine(a, b, tMax),
          };
      }      
    }

  }
}
