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
      return LineSegments(ls1.X1, ls1.Y1, ls1.X2, ls1.Y2, ls2.X1, ls2.Y1, ls2.X2, ls2.Y2, out factor, minT);
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
      if (y1 < bottom)
      {
        yt = bottom - y1;
        if (yt > lineDeltaY)
          return false;
        yt /= lineDeltaY;
        inside = false;
      }
      else if (y1 > top)
      {
        yt = top - y1;
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
          float y = y1 + lineDeltaY * t;
          if (y < bottom || y > top)
            return false;
          break;

        case 1:
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

  }
}
