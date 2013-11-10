using System;
using System.Collections.Generic;
using System.Text;
using OkuBase;
using OkuBase.Geometry;

namespace OkuEngine
{
  public static class OkuExtensions
  {
    /// <summary>
    /// Calculates the bounding circle of the vectors with the given center.
    /// </summary>
    /// <param name="vectors">The vectors to get the circle for.</param>
    /// <param name="center">The center of the calculated circle.</param>
    /// <returns>The bounding circle of the vectors.</returns>
    public static Circle GetBoundingCircle(this Vector2f[] vectors, Vector2f center)
    {
      if (vectors.Length > 0)
      {
        float maxDist = 0;

        foreach (Vector2f vec in vectors)
        {
          float dx = vec.X - center.X;
          float dy = vec.Y - center.Y;
          float dist = dx * dx + dy * dy;
          if (dist > maxDist)
            maxDist = dist;
        }

        return new Circle(center, (float)Math.Sqrt(maxDist));
      }
      return new Circle();
    }

    /// <summary>
    /// Calculates the bounding circle using the arithmetic center of the vectors.
    /// </summary>
    /// <param name="vectors">The vectors to the boudning circle for.</param>
    /// <returns>The bounding circle of the vectors.</returns>
    public static Circle GetBoundingCircleCentered(this Vector2f[] vectors)
    {
      return vectors.GetBoundingCircle(vectors.GetCenter());
    }

  }
}
