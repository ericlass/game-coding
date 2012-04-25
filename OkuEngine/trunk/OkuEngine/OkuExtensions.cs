using System;
using System.Collections.Generic;
using System.Text;

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

  }
}
