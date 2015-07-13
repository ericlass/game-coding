using System;

namespace OkuMath
{
  /// <summary>
  /// Defines functions to calculate the closest point for various primitives.
  /// </summary>
  public static class ClosestPoint
  {
    /// <summary>
    /// Calculates the control value of the point on the line segment defined by [a,b] which
    /// is closest to the point p. The returned control value is guaranteed to be in the range [0.0...1.0].
    /// </summary>
    /// <param name="a">The start of the line segment.</param>
    /// <param name="b">The end of the line segment.</param>
    /// <param name="p">The point.</param>
    /// <returns>The control value t for the point closest to p. (c = a + (b - a) * t)</returns>
    public static float OnLineSegmentToPointF(Vector2f a, Vector2f b, Vector2f p)
    {
      return BasicMath.Clamp(LineMath.ProjectPointOnLine(a, b, p), 0.0f, 1.0f);
    }

    /// <summary>
    /// Calculates the point on the line segment defined by [a,b] which is closest to the point p.
    /// </summary>
    /// <param name="a">The start of the line segment.</param>
    /// <param name="b">The end of the line segment.</param>
    /// <param name="p">The point.</param>
    /// <returns>The closest point.</returns>
    public static Vector2f OnLineSegmentToPointV(Vector2f a, Vector2f b, Vector2f p)
    {
      float t = OnLineSegmentToPointF(a, b, p);
      if (t <= 0.0f)
        return a;
      else if (t >= 1.0f)
        return b;
      else
        return LineMath.PointOnLine(a, b, t);
    }

    /// <summary>
    /// Calculates the control value of the point on the ray starting in o and going into direction defined by d
    /// which is closest to the point p. The returned control value is guaranteed to be >= 0.
    /// </summary>
    /// <param name="o">The origin of ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="p">The point.</param>
    /// <returns>The control value for the point closest to p. (c = o + d * t)</returns>
    public static float OnRayToPointF(Vector2f o, Vector2f d, Vector2f p)
    {
      return Math.Max(0.0f, LineMath.ProjectPointOnLine(o, o + d, p));
    }

    /// <summary>
    /// Calculates the point on the ray starting in o and going into direction defined by d
    /// which is closest to the point p.
    /// </summary>
    /// <param name="o">The origin of ray.</param>
    /// <param name="d">The direction of the ray.</param>
    /// <param name="p">The point.</param>
    /// <returns>The closest point.</returns>
    public static Vector2f OnRayToPointV(Vector2f o, Vector2f d, Vector2f p)
    {
      float t = OnRayToPointF(o, d, p);

      if (t <= 0.0f)
        return o;
      else
        return LineMath.PointOnRay(o, d, t);
    }

    /// <summary>
    /// Calculates the control value of the point on the infinite line that
    /// goes through the points a and b which is closest to the point p.
    /// </summary>
    /// <param name="a">The first point of the line.</param>
    /// <param name="b">The second point of the line.</param>
    /// <param name="p">The point.</param>
    /// <returns>The control value for the point closest to p. (c = a + (b - a) * t)</returns>
    public static float OnLineToPointF(Vector2f a, Vector2f b, Vector2f p)
    {
      return LineMath.ProjectPointOnLine(a, b, p);
    }

    /// <summary>
    /// Calculates the point on the infinite line that goes through the points a and b
    /// which is closest to the point p.
    /// </summary>
    /// <param name="a">The first point of the line.</param>
    /// <param name="b">The second point of the line.</param>
    /// <param name="p">The closest point.</param>
    /// <returns>The closest point.</returns>
    public static Vector2f OnLineToPointV(Vector2f a, Vector2f b, Vector2f p)
    {
      float t = LineMath.ProjectPointOnLine(a, b, p);
      return LineMath.PointOnLine(a, b, t);
    }

    /// <summary>
    /// Calculates the point in the AABB defined by [min,max] which is closest to the point p.
    /// If p is inside the AABB, the result is p.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <param name="p">The point.</param>
    /// <param name="c">The closest point is returned here.</param>
    public static Vector2f OnAABBToPoint(Vector2f min, Vector2f max, Vector2f p)
    {
      return new Vector2f(BasicMath.Clamp(p.X, min.X, max.X), BasicMath.Clamp(p.Y, min.Y, max.Y));
    }

    /// <summary>
    /// Calculates the point on the capsule defined by [a,b] and radius which is
    /// closest to the given point p.
    /// </summary>
    /// <param name="a">The start of the capsules line segment.</param>
    /// <param name="b">The end of the capsules line segment.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="p">The point.</param>
    /// <returns>The closest point on the capsule.</returns>
    public static Vector2f OnCapsuleToPoint(Vector2f a, Vector2f b, float radius, Vector2f p)
    {
      Vector2f cl = ClosestPoint.OnLineSegmentToPointV(a, b, p);
      Vector2f pc = cl - p;
      float rInT = radius / pc.Magnitude;
      return LineMath.PointOnLine(p, cl, 1.0f - rInT);
    }

    /// <summary>
    /// Calculates the point  on the triangle defined by [a,b,c]
    /// which is closest to the given point p.
    /// This uses a barycentric coordinate based approach as described
    /// in the book "Realtime Collision Detection" on page 141.
    /// </summary>
    /// <param name="a">The first point of the triangle.</param>
    /// <param name="b">The second point of the triangle.</param>
    /// <param name="c">The third point of the triangle.</param>
    /// <param name="p">The point.</param>
    /// <returns>The closest point on the triangle.</returns>
    public static Vector2f OnTriangleToPoint(Vector2f a, Vector2f b, Vector2f c, Vector2f p)
    {
      //Check if p is in vertex region outside a
      Vector2f ab = b - a;
      Vector2f ac = c - a;
      Vector2f ap = p - a;
      float d1 = VectorMath.DotProduct(ab, ap);
      float d2 = VectorMath.DotProduct(ac, ap);

      if (d1 <= 0.0f && d2 <= 0.0f)
        return a;

      //Check if p is in vertex region outside b
      Vector2f bp = p - b;
      float d3 = VectorMath.DotProduct(ab, bp);
      float d4 = VectorMath.DotProduct(ac, bp);

      if (d3 >= 0.0f && d4 <= d3)
        return b;

      //Check if p is on edge region of ab
      float vc = d1 * d4 - d3 * d2;
      if (vc <= 0.0f && d1 >= 0.0f && d3 <= 0.0f)
      {
        float vi = d1 / (d1 - d3);
        return a + (ab * vi);
      }

      //Check if p is in vertex region outside c
      Vector2f cp = p - c;
      float d5 = VectorMath.DotProduct(ab, cp);
      float d6 = VectorMath.DotProduct(ac, cp);

      if (d6 >= 0.0f && d5 <= d6)
        return c;

      //Check if p is on edge region of ac
      float vb = d5 * d2 - d1 * d6;
      if (vb <= 0.0f && d2 >= 0.0f && d6 < 0.0f)
      {
        float wi = d2 / (d2 - d6);
        return a + (ac * wi);
      }

      //Check if p is on edge region of bc
      float va = d3 * d6 - d5 * d4;
      float d7 = d4 - d3;
      float d8 = d5 - d6;
      if (va <= 0.0f && d7 >= 0.0f && d8 >= 0.0f)
      {
        float wi = d7 / (d7 + d8);
        return b + ((c - b) * wi);
      }

      //P inside face region
      float denom = 1.0f / (va + vb + vc);
      float v = vb * denom;
      float w = vc * denom;
      return a + (ab * v) + (ac * w);
    }

    /// <summary>
    /// Calculates the point  on the triangle defined by [a,b,c]
    /// which is closest to the given point p.
    /// This uses a self-made algorithm which checks the closest point
    /// for each side of the triangle. This approach is about 2.5 times 
    /// slower than the one in OnTriangleToPoint!
    /// </summary>
    /// <param name="a">The first point of the triangle.</param>
    /// <param name="b">The second point of the triangle.</param>
    /// <param name="c">The third point of the triangle.</param>
    /// <param name="p">The point.</param>
    /// <returns>The closest point on the triangle.</returns>
    public static Vector2f OnTriangleToPointV(Vector2f a, Vector2f b, Vector2f c, Vector2f p)
    {
      //Get closest points on line segments of triangle
      Vector2f pab = OnLineSegmentToPointV(a, b, p);
      Vector2f pbc = OnLineSegmentToPointV(b, c, p);
      Vector2f pca = OnLineSegmentToPointV(c, a, p);

      //Find point which is closest to p
      float distab = VectorMath.SquaredDistance(pab, p);
      float distbc = VectorMath.SquaredDistance(pbc, p);
      float distca = VectorMath.SquaredDistance(pca, p);

      float min = distab;
      Vector2f result = pab;

      if (distbc < min)
      {
        min = distbc;
        result = pbc;
      }

      if (distca < min)
      {
        min = distca;
        result = pca;
      }

      return result;
    }

  }
}
