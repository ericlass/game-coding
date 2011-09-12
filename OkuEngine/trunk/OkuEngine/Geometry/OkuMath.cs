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
    public static Vector LinearInterpolate(Vector start, Vector end, float t)
    {
      return new Vector(start.X + ((end.X - start.X) * t), start.Y + ((end.Y - start.Y) * t));
    }

  }
}
