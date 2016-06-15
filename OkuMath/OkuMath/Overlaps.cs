using System;
using System.Collections.Generic;

namespace OkuMath
{
  /// <summary>
  /// Defines functions to calculate if two primitives overlap or not.
  /// </summary>
  public static class Overlaps
  {
    /// <summary>
    /// Tests intersection of two convex polygons using the separating axis theorem.
    /// The vector returned in mtd is the minimum transaltion distance that can be used to move the 
    /// two polygons apart.
    /// </summary>
    /// <param name="poly1">The first polygon.</param>
    /// <param name="poly2">The second polygon.</param>
    /// <param name="mtd">The minimum transaltion distance is returned in this parameter if the polygons intersect.</param>
    /// <returns>If an intersection is present, true is returned. Else false.</returns>
    public static bool PolygonPolygon(Vector2f[] poly1, Vector2f[] poly2, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;

      //Get normals of both polygons
      Vector2f[] normals1 = PolygonMath.GetNormals(poly1);
      Vector2f[] normals2 = PolygonMath.GetNormals(poly2);

      //Create combined list of all axes
      List<Vector2f> allAxes = new List<Vector2f>(normals1.Length + normals2.Length);
      allAxes.AddRange(normals1);
      allAxes.AddRange(normals2);

      //Make axes unique so there are no duplicate axes
      for (int i = allAxes.Count - 1; i >= 0; i--)
      {
        var normal = allAxes[i];
        for (int j = 0; j < i; j++)
        {
          var axis = allAxes[j];
          if (axis == normal || axis == -normal)
          {
            allAxes.RemoveAt(i);
            break;
          }
        }
      }

      //Intitialize values for loop
      Vector2f separation = new Vector2f();
      float minOverlap = float.MaxValue;

      float min1 = float.MaxValue;
      float max1 = float.MinValue;
      float min2 = float.MaxValue;
      float max2 = float.MinValue;

      foreach (var axis in allAxes)
      {
        GetProjectedBounds(axis, poly1, out min1, out max1);
        GetProjectedBounds(axis, poly2, out min2, out max2);

        if (min1 > max2 || max1 < min2)
          return false; //Found a separating axis. Polys do not overlap.
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

      mtd = separation * (-minOverlap);
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
      foreach (Vector2f vec in poly)
      {
        float projected = VectorMath.ProjectScalar(vec, axis);
        min = Math.Min(min, projected);
        max = Math.Max(max, projected);
      }
    }

    /// <summary>
    /// Checks if the bounding boxes defined by the given vectors [min1,max1] and [min2,max2] are overlapping.
    /// </summary>
    /// <param name="min1">The minimum vector of the first bounding box.</param>
    /// <param name="max1">The maximum vector of the first bounding box.</param>
    /// <param name="min2">The minimum vector of the second bounding box.</param>
    /// <param name="max2">The maximum vector of the second bounding box.</param>
    /// <returns>True if the bounding boxes intersect, else false.</returns>
    public static bool AABBAABB(Vector2f min1, Vector2f max1, Vector2f min2, Vector2f max2)
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
    /// Checks if the given point p is inside the axis aligned bounding box
    /// defined by the two points min and max.
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <param name="min">The min vector of the AABB.</param>
    /// <param name="max">The max vector of the AABB.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public static Boolean PointAABB(Vector2f p, Vector2f min, Vector2f max)
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
    /// Calculates if the two circle given by the parameters (c1,r1) and (c2,r2) do intersect.
    /// </summary>
    /// <param name="c1">The center of the first circle.</param>
    /// <param name="r1">The radius of the first circle.</param>
    /// <param name="c2">The center of the second circle.</param>
    /// <param name="r2">The radius of the second circle.</param>
    /// <returns>True if the circles intersect, else false.</returns>
    public static bool CircleCircle(Vector2f c1, float r1, Vector2f c2, float r2)
    {
      float a = r1 + r2;
      float dx = c1.X - c2.X;
      float dy = c1.Y - c2.Y;
      return a * a > (dx * dx + dy * dy);
    }

    /// <summary>
    /// Calculates if the two circle given by the parameters (c1,r1) and (c2,r2) do intersect.
    /// If they intersect, the distance that they overlap is also calculated and returned in the mtd paramter.
    /// </summary>
    /// <param name="c1">The center of the first circle.</param>
    /// <param name="r1">The radius of the first circle.</param>
    /// <param name="c2">The center of the second circle.</param>
    /// <param name="r2">The radius of the second circle.</param>
    /// <param name="mtd">The minimum translation distance is returned here.</param>
    /// <returns>True if the circles intersect, else false.</returns>
    public static bool CircleCircle(Vector2f c1, float r1, Vector2f c2, float r2, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;

      float a = r1 + r2;
      float dx = c1.X - c2.X;
      float dy = c1.Y - c2.Y;
      bool result = a * a > (dx * dx + dy * dy);
      if (result)
      {
        Vector2f vec = VectorMath.Normalize(c2 - c1);
        mtd = vec * ((dx * dx + dy * dy) - a * a);
      }
      return result;
    }

    /// <summary>
    /// Calculates if the circle defined by center and radius overlaps the AABB defined
    /// by min and max.
    /// </summary>
    /// <param name="center">The center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>True if the circle and the AABB overlap, else false.</returns>
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

    /// <summary>
    /// Calculates if the circle defined by center and radius overlaps the AABB defined
    /// by min and max. Also calculates the distance the two overlap.
    /// </summary>
    /// <param name="center">The center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <param name="mtd">The minimum translation vector is returned here.</param>
    /// <returns>True if the circle and the AABB overlap, else false.</returns>
    public static bool CircleAABB(Vector2f center, float radius, Vector2f min, Vector2f max, out Vector2f mtd)
    {
      mtd = Vector2f.Zero;
      bool result = CircleAABB(center, radius, min, max);
      if (result)
      {
        Vector2f vec = ClosestPoint.OnAABBToPoint(min, max, center);
        if (PointAABB(center, min, max))
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

  }
}
