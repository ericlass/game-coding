using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Provides a series of intersection tests for various primitives.
  /// </summary>
  public static class Intersections
  {
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
    /// <param name="minT">The minimum line formaula control value that has to be reached.</param>
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
    /// Checks if the two given line segments intersect.
    /// </summary>
    /// <param name="ls1">The first line segment.</param>
    /// <param name="ls2">The second line segment.</param>
    /// <param name="factor">Contains the line formula control value, if there is an intersection.</param>
    /// <param name="minT">The minimum line formaula control value that has to be reached.</param>
    /// <returns>True if the line segments intersect, otherwise false.</returns>
    public static bool LineSegments(LineSegment ls1, LineSegment ls2, out float factor, float minT)
    {
      return LineSegments(ls1.Start.X, ls1.Start.Y, ls1.End.X, ls1.End.Y, ls2.Start.X, ls2.Start.Y, ls2.End.X, ls2.End.Y, out factor, minT);
    }

    /// <summary>
    /// Checks for intersection of a line segment and an axis aligned boudning box. The line segment
    /// if given by ((x1,y1),(x2,y2)). The bounding box is given by left, right, top and bottom.
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
    /// <param name="minT">The minimum line formaula control value that has to be reached.</param>
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
    public static bool Intersect(Vector[] poly1, Vector[] poly2, out Vector mtd)
    {
      mtd = Vector.Zero;

      List<Vector> normalAxes = new List<Vector>(poly1.Length + poly2.Length);

      //Get normals of first poly
      for (int i = 0; i < poly1.Length; i++)
      {
        int j = (i + 1) % poly1.Length;
        Vector vec = poly1[j] - poly1[i];
        normalAxes.Add(vec.GetNormal());
      }

      //Get normals of second poly
      for (int i = 0; i < poly2.Length; i++)
      {
        int j = (i + 1) % poly2.Length;
        Vector vec = poly2[j] - poly2[i];
        normalAxes.Add(vec.GetNormal());
      }

      Vector separation = new Vector();
      float minOverlap = float.MaxValue;

      float min1 = float.MaxValue;
      float max1 = float.MinValue;
      float min2 = float.MaxValue;
      float max2 = float.MinValue;

      foreach (Vector axis in normalAxes)
      {
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
    private static void GetProjectedBounds(Vector axis, Vector[] poly, out float min, out float max)
    {
      if (poly.Length < 1)
        throw new ArgumentException("Poly must have at least one vector!");

      min = float.MaxValue;
      max = float.MinValue;
      foreach (Vector vec in poly)
      {
        float projected = axis.ProjectScalar(vec);
        min = Math.Min(min, projected);
        max = Math.Max(max, projected);
      }
    }

  }
}
