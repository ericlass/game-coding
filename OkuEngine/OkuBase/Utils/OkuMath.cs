using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase.Geometry;

namespace OkuBase.Utils
{
  /// <summary>
  /// Defines a set of math functions that are used by the engine.
  /// </summary>
  public static class OkuMath
  {
    /// <summary>
    /// The radian value of one degree.
    /// </summary>
    public const float OneDegreeInRadians = (float)(Math.PI / 180.0);

    /// <summary>
    /// Calculates the left hand normal of a line segment defined by start and end.
    /// </summary>
    /// <param name="start">The start position.</param>
    /// <param name="end">The end position.</param>
    /// <returns>The normalized left hand normal.</returns>
    public static Vector2f GetNormal(Vector2f start, Vector2f end)
    {
      Vector2f result = new Vector2f(end.Y - start.Y, -(end.X - start.X));
      result.Normalize();
      return result;
    }

    /// <summary>
    /// Calculates the left hand normal of a line segment defined by the given coordinates.
    /// </summary>
    /// <param name="x1">The x coordinate of the start point.</param>
    /// <param name="y1">The y coordinate of the start point.</param>
    /// <param name="x2">The x coordinate of the end point.</param>
    /// <param name="y2">The y coordinate of the end point.</param>
    /// <returns>The normalized left hand normal.</returns>
    public static Vector2f GetNormal(float x1, float y1, float x2, float y2)
    {
      Vector2f result = new Vector2f(y2 - y1, -(x2 - x1));
      result.Normalize();
      return result;
    }

    /// <summary>
    /// Calculates the normals for a closed polygon shape. The normals are written to
    /// the given normals array starting at the given start index.
    /// </summary>
    /// <param name="polygon">The points of the polygon.</param>
    /// <param name="normals">The normals array the results are written to.</param>
    /// <param name="start">The start index in the normals array where the normals are written to.</param>
    public static void GetNormals(Vector2f[] polygon, Vector2f[] normals, int start)
    {
      for (int i = 0; i < polygon.Length; i++)
      {
        int j = (i + 1) % polygon.Length;
        normals[start + i] = GetNormal(polygon[i], polygon[j]);
      }
    }

    /// <summary>
    /// Interpolates linearly between the two given points.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    /// <param name="t">A value in the range 0.0 - 1.0 where 0.0 means start and 1.0 means end.</param>
    /// <returns>The interpolated vector.</returns>
    public static Vector2f InterpolateLinear(Vector2f start, Vector2f end, float t)
    {
      return new Vector2f(start.X + ((end.X - start.X) * t), start.Y + ((end.Y - start.Y) * t));
    }

    /// <summary>
    /// Interpolates linearly between the two given values.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">A value in the range 0.0 - 1.0 where 0.0 means start and 1.0 means end.</param>
    /// <returns>The interpolated value.</returns>
    public static float InterpolateLinear(float start, float end, float t)
    {
      return start + (end - start) * t;
    }
    
    /// <summary>
    /// Interpolates linearly between the two given values.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">A value in the range 0.0 - 1.0 where 0.0 means start and 1.0 means end.</param>
    /// <returns>The interpolated value.</returns>
    public static double InterpolateLinear(double start, double end, double t)
    {
      return start + (end - start) * t;
    }

    /// <summary>
    /// Interpolates between a and b using cosine interpolation. m controls the amount of interpolation.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <param name="m">The control paramters.</param>
    /// <returns>The interpolated value.</returns>
    public static float InterpolateCosine(float a, float b, float m)
    {
      float f = (1.0f - (float)Math.Cos(m * 3.1415927f)) * 0.5f;
      return a * (1.0f - f) + b * f;
    }

    /// <summary>
    /// Interpolates a value between y1 and y2 taking into account y0 and y3.
    /// </summary>
    /// <param name="y0">The first value.</param>
    /// <param name="y1">The second value.</param>
    /// <param name="y2">The third value.</param>
    /// <param name="y3">The fourth value.</param>
    /// <param name="m">The control paramter.</param>
    /// <returns>The interpolated value.</returns>
    public static float InterpolateCubic(float y0, float y1, float y2, float y3, float m)
    {
      float a0, a1, a2, a3, m2;

      m2 = m * m;
      a0 = y3 - y2 - y0 + y1;
      a1 = y0 - y1 - a0;
      a2 = y2 - y0;
      a3 = y1;

      return (a0 * m * m2 + a1 * m2 + a2 * m + a3);
    }

    /// <summary>
    /// Gets the next integer value above the given value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The next integer value above the given value.</returns>
    public static int Ceiling(float value)
    {
      return (int)(value + 1.0f);
    }

    /// <summary>
    /// Gets the next integer value &lt;= the given value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The next integer value &lt;= the given value.</returns>
    public static int Floor(float value)
    {
      return (int)value;
    }

    /// <summary>
    /// Calculates the bouding box for the given polygon. If the polygon does not change
    /// the bounding box should not be recalculated everytime it is needed. Cache it.
    /// </summary>
    /// <param name="polygon">The polygon to get the bounding box for.</param>
    /// <param name="min">Returns the minimum vector of the bounding box.</param>
    /// <param name="max">Returns the maximum vector of the bounding box.</param>
    public static void BoundingBox(Vector2f[] polygon, out Vector2f min, out Vector2f max)
    {
      min.X = float.MaxValue;
      min.Y = float.MaxValue;

      max.X = float.MinValue;
      max.Y = float.MinValue;

      for (int i = 0; i < polygon.Length; i++)
      {
        Vector2f vert = polygon[i];
        min.X = Math.Min(min.X, vert.X);
        min.Y = Math.Min(min.Y, vert.Y);
        max.X = Math.Max(max.X, vert.X);
        max.Y = Math.Max(max.Y, vert.Y);
      }
    }

    /// <summary>
    /// Gets the swept AABB of the AABB defined by min and max if it was translated
    /// by the given translation vector.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB. The result is also returned here.</param>
    /// <param name="max">The maximum vector of the AABB. The result is also returned here.</param>
    /// <param name="translation">The translation of the AABB.</param>
    public static void GetSweptAABB(ref Vector2f min, ref Vector2f max, Vector2f translation)
    {
      Vector2f minT = min + translation;
      Vector2f maxT = max + translation;

      min.X = Math.Min(min.X, minT.X);
      min.Y = Math.Min(min.Y, minT.Y);
      max.X = Math.Max(max.X, maxT.X);
      max.Y = Math.Max(max.Y, maxT.Y);
    }

    /// <summary>
    /// Clamps the given value to the given min and max values.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The allowed minimum value.</param>
    /// <param name="max">The allowed maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static float Clamp(float value, float min, float max)
    {
      if (value < min)
        return min;
      if (value > max)
        return max;
      return value;
    }

    /// <summary>
    /// Clamps the given value to the given min and max values.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The allowed minimum value.</param>
    /// <param name="max">The allowed maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static float Clamp(int value, int min, int max)
    {
      if (value < min)
        return min;
      if (value > max)
        return max;
      return value;
    }

    /// <summary>
    /// Calculates the center of the given polygon.
    /// </summary>
    /// <param name="polygon"></param>
    /// <returns></returns>
    public static Vector2f GetCenter(Vector2f[] polygon)
    {
      Vector2f min;
      Vector2f max;
      BoundingBox(polygon, out min, out max);
      return (min + max) * 0.5f;
    }

    /// <summary>
    /// Recalculates the given polygon or point cloud so that all
    /// vertices positions are realtive to the center of the polygon.
    /// </summary>
    /// <param name="polygon">The polygon to center.</param>
    public static void CenterOrigin(Vector2f[] polygon)
    {
      CenterAt(polygon, Vector2f.Zero);
    }

    /// <summary>
    /// Center the given polygon vertices at the given center.
    /// That means that all vertices are now relative to the
    /// given center.
    /// </summary>
    /// <param name="polygon">The polygon to be centered.</param>
    /// <param name="center">The new center of the polygon.</param>
    public static void CenterAt(Vector2f[] polygon, Vector2f center)
    {
      Vector2f currentCenter = GetCenter(polygon);
      Vector2f offset = center - currentCenter;
      for (int i = 0; i < polygon.Length; i++)
        polygon[i] += offset;
    }

    /// <summary>
    /// Signed ceiling function. If the value is positive, it
    /// acts just like the normal ceiling. If the value is negative,
    /// the next smaller value is returned, so -1.5 returns -2 instead
    /// of -1.
    /// </summary>
    /// <param name="value">The value to process.</param>
    /// <returns>The ceiling of the given value.</returns>
    public static int SignedCeiling(float value)
    {
      if (value >= 0)
        return (int)Math.Ceiling(value);
      else
        return (int)Math.Floor(value);
    }

    /// <summary>
    /// Signed floor function. If the value is positive, it
    /// acts just like the normal floor. If the value is negative,
    /// the next bigger value is returned, so -1.5 returns -1 instead
    /// of -2.
    /// </summary>
    /// <param name="value">The value to process.</param>
    /// <returns>The ceiling of the given value.</returns>
    public static float SignedFloor(float value)
    {
      if (value >= 0)
        return (int)Math.Floor(value);
      else
        return (int)Math.Ceiling(value);
    }

    /// <summary>
    /// Calculates the point on the perimeter of the aabb theat is closest to the given point.
    /// </summary>
    /// <param name="p">The point.</param>
    /// <returns>The point on the perimeter that is closest to p.</returns>
    public static Vector2f ClosestPointOnRect(Vector2f min, Vector2f max, Vector2f p)
    {
      Vector2f result = Vector2f.Zero;
      if (IntersectionTests.PointInRectangle(p, min, max))
      {
        Vector2f center = GetRectCenter(min, max);

        float borderX, borderY;
        if (p.X >= center.X)
          borderX = max.X;
        else
          borderX = min.X;

        if (p.Y >= center.Y)
          borderY = max.Y;
        else
          borderY = min.Y;

        float dx = Math.Abs(p.X - borderX);
        float dy = Math.Abs(p.Y - borderY);
        if (dx < dy)
          return new Vector2f(borderX, p.Y);
        else
          return new Vector2f(p.X, borderY);
      }
      else
      {
        result = p;
        if (result.X > max.X)
          result.X = max.X;
        if (result.X < min.X)
          result.X = min.X;
        if (result.Y > max.Y)
          result.Y = max.Y;
        if (result.Y < min.Y)
          result.Y = min.Y;
      }
      return result;
    }

    /// <summary>
    /// Calculates the center of the rectangle.
    /// </summary>
    /// <returns>The center point of the rectangle.</returns>
    public static Vector2f GetRectCenter(Vector2f min, Vector2f max)
    {
      return (min + max) * 0.5f;
    }



  }
}
