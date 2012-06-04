using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OkuEngine
{
  public static class OkuExtensions
  {
    /// <summary>
    /// Calculates a random float value in the range [-1.0,+1.0].
    /// </summary>
    /// <param name="rand">The random number generator to use.</param>
    /// <returns>A random float value in the range [-1.0,+1.0].</returns>
    public static float RandomFloat(this Random rand)
    {
      return (float)rand.NextDouble() * 2.0f - 1.0f;
    }

    /// <summary>
    /// Converts the vector array to a string.
    /// </summary>
    /// <param name="vectors">The vector array to be converted.</param>
    /// <returns>The string representation of the vector array.</returns>
    public static string ToOkuString(this Vector[] vectors)
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < vectors.Length; i++)
      {
        if (i > 0)
          builder.Append(";");
        builder.Append(vectors[i].ToString());
      }
      return builder.ToString();
    }

    /// <summary>
    /// Converts the color array to a string.
    /// </summary>
    /// <param name="colors">The color array to convert.</param>
    /// <returns>A string representation of the color array.</returns>
    public static string ToOkuString(this Color[] colors)
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < colors.Length; i++)
      {
        if (i > 0)
          builder.Append(";");
        builder.Append(colors[i].ToString());
      }
      return builder.ToString();
    }

    /// <summary>
    /// Calculates the point in the array that is closest to the given point.
    /// </summary>
    /// <param name="vectors">The array of vectors.</param>
    /// <param name="point">The point to find the closest point for.</param>
    /// <param name="distance">The distance is of the closest point is returned here.</param>
    /// <returns>The index of the closest point. -1 if vectors does not contain any points.</returns>
    public static int ClosestPoint(this Vector[] vectors, Vector point, out float distance)
    {
      distance = 0.0f;

      int closest = -1;
      float nearest = float.MaxValue;
      for (int i = 0; i < vectors.Length; i++)
      {
        float dist = (vectors[i] - point).Magnitude;
        if (dist < nearest)
        {
          nearest = dist;
          closest = i;
        }
      }
      distance = nearest;
      return closest;
    }

  }
}
