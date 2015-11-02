using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuMath;

namespace OkuBase.Geometry
{
  /// <summary>
  /// Defines a set of function to create poylgons.
  /// </summary>
  public static class PolygonFactory
  {
    /// <summary>
    /// Creates an axis aligned box with the given boundaries.
    /// </summary>
    /// <param name="left">The left boundary of the box.</param>
    /// <param name="right">The right boundary of the box.</param>
    /// <param name="top">The top boundary of the box.</param>
    /// <param name="bottom">The bottom boundary of the box.</param>
    /// <returns>The vertices for the box.</returns>
    public static Vector2f[] Box(float left, float right, float top, float bottom)
    {
      return new Vector2f[] {
        new Vector2f(left, top),
        new Vector2f(right, top),
        new Vector2f(right, bottom),
        new Vector2f(left, bottom)
      };
    }

    /// <summary>
    /// Creates a circle from the given parameters.
    /// </summary>
    /// <param name="x">The x coordinate of the center of the circle.</param>
    /// <param name="y">The y coordinate of the center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="points">The number of vertices of the circle.</param>
    /// <returns>The vertices for the circle.</returns>
    public static Vector2f[] Circle(float x, float y, float radius, int points)
    {
      float step = (float)((2 * Math.PI) / points);
      float angle = 0;
      Vector2f[] result = new Vector2f[points];
      for (int i = 0; i < points; i++)
      {
        result[i] = new Vector2f((float)Math.Sin(angle) * radius + x, (float)Math.Cos(angle) * radius + y);
        angle += step;
      }
      return result;
    }

  }
}
