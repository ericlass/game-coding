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
      Vector2f ab = b - a;
      Vector2f ac = c - a;

      float g = VectorMath.Project(ac, ab).SquaredMagnitude;
      float e = ac.SquaredMagnitude;
      float f = r * r - e + g;

      //Ray does not hit circle
      if (f < 0)
        return null;

      f = (float)Math.Sqrt(f);
      g = (float)Math.Sqrt(g);

      float length = 1.0f / ab.Magnitude;
      float tMin = (g - f) * length;
      float tMax = (g + f) * length;

      if (tMin == tMax)
        return new Vector2f[] { LineMath.PointOnRay(a, ab, tMax) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(a, ab, tMin),
        LineMath.PointOnRay(a, ab, tMax)
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

      float g = VectorMath.Project(oc, d).SquaredMagnitude;
      float e = oc.SquaredMagnitude;
      float f = r * r - e + g;

      //Ray does not hit circle
      if (f < 0)
        return null;

      f = (float)Math.Sqrt(f);
      g = (float)Math.Sqrt(g);

      float length = 1.0f / d.Magnitude;
      float tMin = (g - f) * length;
      float tMax = (g + f) * length;

      if (tMin < 0 || tMin == tMax)
        return new Vector2f[] { LineMath.PointOnRay(o, d, tMax) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(o, d, tMin),
        LineMath.PointOnRay(o, d, tMax)
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
      Vector2f ab = b - a;
      Vector2f ac = c - a;

      float g = VectorMath.Project(ac, ab).SquaredMagnitude;
      float e = ac.SquaredMagnitude;
      float f = r * r - e + g;

      //Ray does not hit circle
      if (f < 0)
        return null;

      f = (float)Math.Sqrt(f);
      g = (float)Math.Sqrt(g);

      float length = 1.0f / ab.Magnitude;
      float tMin = (g - f) * length;
      float tMax = (g + f) * length;

      if (tMin < 0.0f)
      {
        if (tMax > 1.0f)
          return null; //Both start and end are inside of the circle
        else
          return new Vector2f[] { LineMath.PointOnRay(a, ab, tMax) }; //Start is inside, end is outside
      }
      else
      {
        if (tMax > 1.0f)
          return new Vector2f[] { LineMath.PointOnRay(a, ab, tMin) }; //Start is outside, end is inside
        else
        {
          if (tMin == tMax)
            return new Vector2f[] { LineMath.PointOnRay(a, ab, tMin) }; // If points are the same (tangent), only return one
          else
            return new Vector2f[] //Both start and end are outside
            {
              LineMath.PointOnRay(a, ab, tMin),
              LineMath.PointOnRay(a, ab, tMax)
            };
        }
      }
    }

    /// <summary>
    /// Calculates the point(s) where the infitinite line that goes through a and b
    /// intersects the axis aligned box defined by min and max.
    /// </summary>
    /// <param name="a">The start of the line.</param>
    /// <param name="b">The end of the line.</param>
    /// <param name="min">The minimum point of the AABB.</param>
    /// <param name="max">The maximum point of the AABB.</param>
    /// <returns>
    /// Null if the line does not intersect the AABB.
    /// One point if the line perfectly hits a corner of the AABB.
    /// Two points if the line crosses the AABB.
    /// </returns>
    public static Vector2f[] LineAABB(Vector2f a, Vector2f b, Vector2f min, Vector2f max)
    {
      Vector2f ab = b - a;
      Vector2f? t = LinearAABBScalar(a, ab, min, max);

      if (t == null)
        return null;

      float tMin = t.Value.X;
      float tMax = t.Value.Y;

      if (tMin == tMax)
        return new Vector2f[] { LineMath.PointOnRay(a, ab, tMax) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(a, ab, tMin),
        LineMath.PointOnRay(a, ab, tMax)
      };
    }

    /// <summary>
    /// Calculates if the ray defined by the origin o and the direction d 
    /// hits the AABB defined by min and max.
    /// </summary>
    /// <param name="o">The origin of the ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="min">The minimum point of the AABB.</param>
    /// <param name="max">The maximum point of the AABB.</param>
    /// <returns>
    /// Null if the ray does not hit the AABB.
    /// One point if the ray origin is inside the AABB.
    /// Two point if the ray origin is outside of the AABB and crosses it.
    /// </returns>
    public static Vector2f[] RayAABB(Vector2f o, Vector2f d, Vector2f min, Vector2f max)
    {
      Vector2f? t = LinearAABBScalar(o, d, min, max);

      if (t == null)
        return null;

      float tMin = t.Value.X;
      float tMax = t.Value.Y;

      if (tMin < 0 || tMin == tMax)
        return new Vector2f[] { LineMath.PointOnRay(o, d, tMax) };

      return new Vector2f[]
      {
        LineMath.PointOnRay(o, d, tMin),
        LineMath.PointOnRay(o, d, tMax)
      };
    }

    /// <summary>
    /// Calculates the point(s) where the infitinite line that goes through a and b
    /// intersects the axis aligned box defined by min and max.
    /// </summary>
    /// <param name="a">The start of the line.</param>
    /// <param name="b">The end of the line.</param>
    /// <param name="min">The minimum point of the AABB.</param>
    /// <param name="max">The maximum point of the AABB.</param>
    /// <returns>
    /// Null if the line does not intersect the AABB.
    /// One point if the line perfectly hits a corner of the AABB.
    /// Two points if the line crosses the AABB.
    /// </returns>
    public static Vector2f[] LineSegmentAABB(Vector2f a, Vector2f b, Vector2f min, Vector2f max)
    {
      Vector2f ab = b - a;
      Vector2f? t = LinearAABBScalar(a, ab, min, max);

      if (t == null)
        return null;

      float tMin = t.Value.X;
      float tMax = t.Value.Y;

      if (tMin < 0.0f)
      {
        if (tMax > 1.0f)
          return null; //Both start and end are inside of the circle
        else
          return new Vector2f[] { LineMath.PointOnRay(a, ab, tMax) }; //Start is inside, end is outside
      }
      else
      {
        if (tMax > 1.0f)
          return new Vector2f[] { LineMath.PointOnRay(a, ab, tMin) }; //Start is outside, end is inside
        else
        {
          if (tMin == tMax)
            return new Vector2f[] { LineMath.PointOnRay(a, ab, tMin) }; // If points are the same (tangent), only return one
          else
            return new Vector2f[] //Both start and end are outside
            {
              LineMath.PointOnRay(a, ab, tMin),
              LineMath.PointOnRay(a, ab, tMax)
            };
        }
      }
    }

    /// <summary>
    /// Calculates if the linear (ray,line,segment) defined
    /// by the origin o and the direction d hits the AABB defined by min and max.
    /// </summary>
    /// <param name="o">The origin of the linear.</param>
    /// <param name="d">The direction of the linear.</param>
    /// <param name="min">The minimum point of the AABB.</param>
    /// <param name="max">The maximum point of the AABB.</param>
    /// <returns>
    /// Null if the linear does not hit the AABB.
    /// One point if the linear origin is inside the AABB.
    /// Two point if the linear origin is outside of the AABB and crosses it.
    /// </returns>
    private static Vector2f? LinearAABBScalar(Vector2f o, Vector2f d, Vector2f min, Vector2f max)
    {
      float tMin = float.MinValue;
      float tMax = float.MaxValue;

      for (int i = 0; i < Vector2f.ComponentCount; i++)
      {
        if (Math.Abs(d[i]) < 0.000001f)
        {
          // Linear is parallel to slab and does not hit AABB if origin is not with slab
          if (o[i] < min[i] || o[i] > max[i])
            return null;
        }
        else
        {
          float ood = 1.0f / d[i];
          float t1 = (min[i] - o[i]) * ood;
          float t2 = (max[i] - o[i]) * ood;

          //Depending on direction of Linear, values may need to be swapped
          if (t1 > t2)
          {
            float tmp = t1;
            t1 = t2;
            t2 = tmp;
          }

          tMin = Math.Max(tMin, t1);
          tMax = Math.Min(tMax, t2);

          //No intersection possible
          if (tMin > tMax)
            return null;
        }
      }

      return new Vector2f(tMin, tMax);
    }

  }
}
