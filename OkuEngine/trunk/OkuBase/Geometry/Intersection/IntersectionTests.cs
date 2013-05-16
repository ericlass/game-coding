using System;
using OkuBase.Geometry;
using OkuBase.Geometry.Shapes;
using OkuBase.Graphics;
using OkuBase.Collections;
using OkuBase.Utils;

namespace OkuBase.Geometry.Intersection
{
  /// <summary>
  /// Provides a series of intersection tests for various primitives.
  /// </summary>
  public static class IntersectionTests
  {
    private static DynamicArray<Vector2f> _vectorBuffer = new DynamicArray<Vector2f>(100);

    /// <summary>
    /// Checks for intersection of two line segments specified by the given
    /// coordinates. The line segments are formed like ((x1,y1),(x2,y2)) and 
    /// ((x3,y3),(x4,y4)).
    /// </summary>
    /// <param name="x1">The x component of the first line segments first point.</param>
    /// <param name="y1">The y component of the first line segments first point.</param>
    /// <param name="x2">The x component of the first line segments second point.</param>
    /// <param name="y2">The y component of the first line segments second point.</param>
    /// <param name="x3">The x component of the second line segments first point.</param>
    /// <param name="y3">The y component of the second line segments first point.</param>
    /// <param name="x4">The x component of the second line segments second point.</param>
    /// <param name="y4">The y component of the second line segments second point.</param>
    /// <param name="factor">Contains the line formula control value, if there is an intersection.</param>
    /// <param name="minT">The minimum line formula control value that has to be reached.</param>
    /// <returns>True if the line segments intersect, otherwise false.</returns>
    public static bool LineSegments(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, out float factor, float minT)
    {
      factor = 0.0f;

      float denominator = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
      if (denominator == 0.0f)
        return false;

      float ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / denominator;
      float ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / denominator;

      if (ua > minT)
        return false;

      if ((ua >= 0.0f && ua <= 1.0f) && (ub >= 0.0f && ub <= 1.0))
      {
        factor = ua;
        return true;
      }
      else
        return false;
    }

    /// <summary>
    /// Checks if the line segments defined by [p1,p2] and [p3,p4] intersect.
    /// </summary>
    /// <param name="p1">The start of the first line.</param>
    /// <param name="p2">The end of the first line.</param>
    /// <param name="p3">The start of the second line.</param>
    /// <param name="p4">The end of the second line.</param>
    /// <param name="factor">Contains the line formula control value, if there is an intersection.</param>
    /// <param name="minT">The minimum line formula control value that has to be reached.</param>
    /// <returns>True if the line segments intersect, otherwise false.</returns>
    public static bool LineSegments(Vector2f p1, Vector2f p2, Vector2f p3, Vector2f p4, out float factor, float minT)
    {
      return LineSegments(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y, out factor, minT);
    }

    /// <summary>
    /// Checks for intersection of a line segment and an axis aligned bounding box. The line segment
    /// is given by ((x1,y1),(x2,y2)). The bounding box is given by left, right, top and bottom.
    /// </summary>
    /// <param name="x1">The x component of the line segments first point.</param>
    /// <param name="y1">The x component of the line segments first point.</param>
    /// <param name="x2">The x component of the line segments second point.</param>
    /// <param name="y2">The x component of the line segments second point.</param>
    /// <param name="left">The left boundary of the bounding box.</param>
    /// <param name="right">The right boundary of the bounding box.</param>
    /// <param name="top">The top boundary of the bounding box.</param>
    /// <param name="bottom">The bottom boundary of the bounding box.</param>
    /// <param name="factor">Contains the line formula control value, if there is an intersection.</param>
    /// <param name="minT">The minimum line formula control value that has to be reached.</param>
    /// <returns>True if the line segment intersects the bounding box, otherwise false.</returns>
    public static bool LineSegmentAABB(float x1, float y1, float x2, float y2, float left, float right, float top, float bottom, out float factor, float minT)
    {
      factor = 0.0f;
      float lineDeltaX = x2 - x1;
      float lineDeltaY = y2 - y1;

      bool inside = true;

      float xt = 0.0f;
      if (x1 < left)
      {
        xt = left - x1;
        if (xt > lineDeltaX)
          return false;
        xt /= lineDeltaX;
        inside = false;
      }
      else if (x1 > right)
      {
        xt = right - x1;
        if (xt < lineDeltaX)
          return false;
        xt /= lineDeltaX;
        inside = false;
      }
      else
      {
        xt = -1.0f;
      }

      float yt = 0.0f;
      if (y1 < top)
      {
        yt = top - y1;
        if (yt > lineDeltaY)
          return false;
        yt /= lineDeltaY;
        inside = false;
      }
      else if (y1 > bottom)
      {
        yt = bottom - y1;
        if (yt < lineDeltaY)
          return false;
        yt /= lineDeltaY;
        inside = false;
      }
      else
      {
        yt = -1.0f;
      }

      if (inside)
        return false;

      int which = 0;
      float t = xt;
      if (yt > t)
      {
        which = 1;
        t = yt;
      }

      if (t > minT)
        return false;

      switch (which)
      {
        case 0:
          t -= (0.000001f * lineDeltaX);
          float y = y1 + lineDeltaY * t;
          if (y > bottom || y < top)
            return false;
          break;

        case 1:
          t -= (0.000001f * lineDeltaY);
          float x = x1 + lineDeltaX * t;
          if (x < left || x > right)
            return false;
          break;

        default:
          throw new Exception("Whooops!");
      }

      factor = t;
      return true;
    }

    /// <summary>
    /// Tests intersection of two convex polygons using the separating axis theorem.
    /// The returned vector is the minimum transaltion distance that can be used to move the 
    /// two polygons apart.
    /// </summary>
    /// <param name="poly1">The first polygon.</param>
    /// <param name="poly2">The second polygon.</param>
    /// <param name="mtd">The minimum transaltion distance is returned in this parameter if true is returned.</param>
    /// <returns>If an intersection is present, true is returned. Else false.</returns>
    public static bool Intersect(Vector2f[] poly1, Vector2f[] poly2, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;

      int count = poly1.Length + poly2.Length;
      _vectorBuffer.AsureCapacity(count);
      Vector2f[] normalAxes = _vectorBuffer.InternalArray;

      OkuMath.GetNormals(poly1, normalAxes, 0);
      OkuMath.GetNormals(poly2, normalAxes, poly1.Length);

      Vector2f separation = new Vector2f();
      float minOverlap = float.MaxValue;

      float min1 = float.MaxValue;
      float max1 = float.MinValue;
      float min2 = float.MaxValue;
      float max2 = float.MinValue;

      for (int i = 0; i < count; i++)
      {
        Vector2f axis = normalAxes[i];

        GetProjectedBounds(axis, poly1, out min1, out max1);
        GetProjectedBounds(axis, poly2, out min2, out max2);

        if (min1 > max2 || max1 < min2)
          return false;
        else
        {
          float center1 = (min1 + max1);
          float center2 = (min2 + max2);

          float mtdValue = 0;
          if (center2 > center1)
            mtdValue = max1 - min2;
          else
            mtdValue = min1 - max2;

          if (Math.Abs(mtdValue) < Math.Abs(minOverlap))
          {
            minOverlap = mtdValue;
            //Early exit. If minimum overlap is 0.0 then there really is no intersection.
            if (minOverlap == 0.0f)
              return false;
            separation = axis;
          }
        }
      }

      mtd = separation * minOverlap;
      return true;
    }

    /// <summary>
    /// Projects the location vectors of the given poly to the given axis and returns the
    /// minimum and maximum of all projections in the out parameters min and max.
    /// </summary>
    /// <param name="axis">The axis to project the poly onto.</param>
    /// <param name="poly">The polygon to be projected. Must have at least one point.</param>
    /// <param name="min">The minimum projection value is returned in this parameter.</param>
    /// <param name="max">The maximum projection value is returned in this parameter.</param>
    private static void GetProjectedBounds(Vector2f axis, Vector2f[] poly, out float min, out float max)
    {
      min = float.MaxValue;
      max = float.MinValue;
      for (int i = 0; i < poly.Length; i++)
      //foreach (Vector vec in poly)
      {
        float projected = axis.ProjectScalar(poly[i]);
        min = Math.Min(min, projected);
        max = Math.Max(max, projected);
      }
    }

    /// <summary>
    /// Checks if the bounding boxes defined by the given vectors are overlapping.
    /// </summary>
    /// <param name="min1">The minimum vector of the first bounding box.</param>
    /// <param name="max1">The maximum vector of the first bounding box.</param>
    /// <param name="min2">The minimum vector of the second bounding box.</param>
    /// <param name="max2">The maximum vector of the second bounding box.</param>
    /// <returns>True if the bounding boxes intersect, else false.</returns>
    public static bool Rectangles(Vector2f min1, Vector2f max1, Vector2f min2, Vector2f max2)
    {
      if (min1.X > max2.X)
        return false;
      if (max1.X < min2.X)
        return false;
      if (min1.Y > max2.Y)
        return false;
      if (max1.Y < min2.Y)
        return false;
      return true;
    }

    /// <summary>
    /// Calculates the closest intersection of the ray defined by start and end with the given 
    /// polygon.
    /// </summary>
    /// <param name="start">The start point of the ray.</param>
    /// <param name="end">The end point of the ray.</param>
    /// <param name="polygon">The polygon.</param>
    /// <param name="mtd">If an intersection is present, the ray control value of the intersection point is returned here.</param>
    /// <returns>True if the ray intersects the polygon, else false.</returns>
    public static bool RayPolygon(Vector2f start, Vector2f end, Vector2f[] polygon, out float mtd)
    {
      mtd = float.MaxValue;
      bool result = false;
      float lmtd = float.MaxValue;
      for (int i = 0; i < polygon.Length - 1; i++)
      {
        if (LineSegments(start, end, polygon[i], polygon[i + 1], out lmtd, mtd))
        {
          mtd = Math.Min(mtd, lmtd);
          result = true;
        }
      }
      return result;
    }

    /// <summary>
    /// Checks if the given point p is inside the axis aligned bounding box
    /// defined by the two point min and max.
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <param name="min">The min vector of the AABB.</param>
    /// <param name="max">The max vector of the AABB.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public static Boolean PointInRectangle(Vector2f p, Vector2f min, Vector2f max)
    {
      if (p.X < min.X)
        return false;
      if (p.Y < min.Y)
        return false;
      if (p.X > max.X)
        return false;
      if (p.Y > max.Y)
        return false;
      return true;
    }

    /// <summary>
    /// Checks if the given point is inside of the axis aligned box 
    /// defined by the points [minX, minY] and [maxX, maxY].
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <param name="minX">The x value of the min vector.</param>
    /// <param name="minY">The y value of the min vector.</param>
    /// <param name="maxX">The x value of the max vector.</param>
    /// <param name="maxY">The y value of the max vector.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public static Boolean PointInRectangle(Vector2f p, float minX, float minY, float maxX, float maxY)
    {
      if (p.X < minX)
        return false;
      if (p.Y < minY)
        return false;
      if (p.X > maxX)
        return false;
      if (p.Y > maxY)
        return false;
      return true;
    }

    /// <summary>
    /// Checks if the given point is inside of the axis aligned box 
    /// defined by the points [minX, minY] and [maxX, maxY].
    /// </summary>
    /// <param name="x">The x coordinate of the point.</param>
    /// <param name="y">The y coordinate of the point.</param>
    /// <param name="minX">The x value of the min vector.</param>
    /// <param name="minY">The y value of the min vector.</param>
    /// <param name="maxX">The x value of the max vector.</param>
    /// <param name="maxY">The y value of the max vector.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public static Boolean PointInRectangle(float x, float y, float minX, float minY, float maxX, float maxY)
    {
      if (x < minX)
        return false;
      if (y < minY)
        return false;
      if (x > maxX)
        return false;
      if (y > maxY)
        return false;
      return true;
    }

    /// <summary>
    /// Calculates if the two circle given by the parameters (c1,r1) and (c2,r2) do intersect.
    /// </summary>
    /// <param name="c1">The center of the first circle.</param>
    /// <param name="r1">The radius of the first circle.</param>
    /// <param name="c2">The center of the first circle.</param>
    /// <param name="r2">The radius of the first circle.</param>
    /// <returns>True if the circles intersect, else false.</returns>
    public static bool Circles(Vector2f c1, float r1, Vector2f c2, float r2)
    {
      float a = r1 + r2;
      float dx = c1.X - c2.X;
      float dy = c1.Y - c2.Y;
      return a * a > (dx * dx + dy * dy);
    }

    /// <summary>
    /// Calculates if the two circle given by the parameters (c1,r1) and (c2,r2) do intersect.
    /// </summary>
    /// <param name="c1">The center of the first circle.</param>
    /// <param name="r1">The radius of the first circle.</param>
    /// <param name="c2">The center of the first circle.</param>
    /// <param name="r2">The radius of the first circle.</param>
    /// <param name="mtd">The minimum translation distance is returned here.</param>
    /// <returns>True if the circles intersect, else false.</returns>
    public static bool Circles(Vector2f c1, float r1, Vector2f c2, float r2, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;

      float a = r1 + r2;
      float dx = c1.X - c2.X;
      float dy = c1.Y - c2.Y;
      bool result = a * a > (dx * dx + dy * dy);
      if (result)
      {
        Vector2f vec = c2 - c1;
        vec.Normalize();
        mtd = vec * ((dx * dx + dy * dy) - a * a);
      }
      return result;
    }

    public static bool CircleAABB(Vector2f center, float radius, Vector2f min, Vector2f max)
    {
      Vector2f cc = center;
      if (cc.X > max.X)
        cc.X = max.X;
      if (cc.X < min.X)
        cc.X = min.X;
      if (cc.Y > max.Y)
        cc.Y = max.Y;
      if (cc.Y < min.Y)
        cc.Y = min.Y;

      float dx = cc.X - center.X;
      float dy = cc.Y - center.Y;
      return radius * radius > (dx * dx + dy * dy);
    }

    public static bool CircleAABB(Vector2f center, float radius, Vector2f min, Vector2f max, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;

      Vector2f cc = center;
      if (cc.X > max.X)
        cc.X = max.X;
      if (cc.X < min.X)
        cc.X = min.X;
      if (cc.Y > max.Y)
        cc.Y = max.Y;
      if (cc.Y < min.Y)
        cc.Y = min.Y;

      float dx = cc.X - center.X;
      float dy = cc.Y - center.Y;
      bool result = radius * radius > (dx * dx + dy * dy);
      if (result)
      {
        Vector2f vec = OkuMath.ClosestPointOnRect(min, max, center);
        if (PointInRectangle(center, min, max))
        {
          mtd = vec - center;
          if (mtd.X < mtd.Y)
            mtd.Y += Math.Sign(mtd.Y) * radius;
          else
            mtd.X += Math.Sign(mtd.X) * radius;
        }
        else
          mtd = center - vec;
      }
      return result;
    }

    /// <summary>
    /// Checks if the AABB completely contains the given circle.
    /// </summary>
    /// <param name="circle">The circle to check.</param>
    /// <returns>True if the AABB completely contains the given circle, else false.</returns>
    public static bool RectContainsCircle(Vector2f min, Vector2f max, Vector2f center, float radius)
    {
      return
        min.X <= (center.X - radius) &&
        min.Y <= (center.Y - radius) &&
        max.X >= (center.X + radius) &&
        max.Y >= (center.Y + radius);
    }

    /// <summary>
    /// Checks if the given rectangle defined by [min1,max1] completly contains the rectangle defined by [min2,max2].
    /// Also returns true if the AABBs are equal.
    /// </summary>
    /// <param name="min1">The minimum point of the first rectangle.</param>
    /// <param name="max1">The maximum point of the first rectangle.</param>
    /// <param name="min2">The minimum point of the second rectangle.</param>
    /// <param name="max2">The maximum point of the second rectangle.</param>
    /// <returns>True if the given AABB is completly inside of the AABB, else false.</returns>
    public static bool Contains(Vector2f min1, Vector2f max1, Vector2f min2, Vector2f max2)
    {
      return min1.X <= min2.X && min1.Y <= min2.Y && max1.X >= max2.X && max1.Y >= max2.Y;
    }

  }
}
