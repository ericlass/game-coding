using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class OkuMath
  {
    /// <summary>
    /// Calculates the left hand normal of a line segment defined by start and end.
    /// </summary>
    /// <param name="start">The start position.</param>
    /// <param name="end">The end position.</param>
    /// <returns>The normalized left hand normal.</returns>
    public static Vector GetNormal(Vector start, Vector end)
    {
      Vector result = new Vector(end.Y - start.Y, -(end.X - start.X));
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
    public static Vector GetNormal(float x1, float y1, float x2, float y2)
    {
      Vector result = new Vector(y2 - y1, -(x2 - x1));
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
    public static void GetNormals(Vector[] polygon, Vector[] normals, int start)
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
    /// <returns></returns>
    public static Vector InterpolateLinear(Vector start, Vector end, float t)
    {
      return new Vector(start.X + ((end.X - start.X) * t), start.Y + ((end.Y - start.Y) * t));
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
    public static void BoundingBox(Vector[] polygon, out Vector min, out Vector max)
    {
      min.X = float.MaxValue;
      min.Y = float.MaxValue;
      max.X = float.MinValue;
      max.Y = float.MinValue;

      for (int i = 0; i < polygon.Length; i++)
      {
        Vector vert = polygon[i];
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
    public static void GetSweptAABB(ref Vector min, ref Vector max, Vector translation)
    {
      Vector minT = min + translation;
      Vector maxT = max + translation;

      min.X = Math.Min(min.X, minT.X);
      min.Y = Math.Min(min.Y, minT.Y);
      max.X = Math.Max(max.X, maxT.X);
      max.Y = Math.Max(max.Y, maxT.Y);
    }

  }
}
