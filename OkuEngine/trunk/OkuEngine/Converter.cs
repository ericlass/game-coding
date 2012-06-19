using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OkuEngine
{
  public static class Converter
  {
    /// <summary>
    /// Converts the given float value to a string. The decimal separator will always be ".".
    /// </summary>
    /// <param name="value">The float to be converted.</param>
    /// <returns>The string represenation of the given float value.</returns>
    public static string FloatToString(float value)
    {
      int num = (int)value;
      int frac = (int)Math.Abs((value - num) * 1000000000.0f);
      return num + "." + frac;

      /*string result = value.ToString("0");
      result += "." + value.ToString(".0##################################").Substring(1);
      return result;*/
    }

    /// <summary>
    /// Converts the given string to a float value. The decimal separator has to be a ".".
    /// </summary>
    /// <param name="str">The string to be converted to a float.</param>
    /// <returns>The converted float value.</returns>
    public static float StrToFloat(string str)
    {
      string[] parts = str.Split('.');
      
      float result = float.Parse(parts[0]);

      float fraction = 0.0f;
      if (parts.Length > 1)
        fraction = float.Parse(parts[1]);

      while (fraction >= 1.0f)
        fraction /= 10.0f;

      result += fraction;
      return result;
    }

    /// <summary>
    /// Converts the given string to a vector array.
    /// The string is expected to be in the format that
    /// is created by VectorsToStr.
    /// </summary>
    /// <param name="str">The string with the vectors.</param>
    /// <returns>A vector array with all vectors.</returns>
    public static Vector[] ParseVectors(string str)
    {
      List<Vector> result = new List<Vector>();
      string[] vectors = str.Split(';');
      for (int i = 0; i < vectors.Length; i++)
      {
        Vector vec = new Vector();
        if (Vector.TryParse(vectors[i], ref vec))
          result.Add(vec);
      }
      return result.ToArray();
    }

    /// <summary>
    /// Converts the given string to a color array.
    /// The string is expected to be in the format that
    /// is created by ColorsToStr.
    /// </summary>
    /// <param name="str">The string with the colors.</param>
    /// <returns>A color array with all colors.</returns>
    public static Color[] ParseColors(string str)
    {
      List<Color> result = new List<Color>();
      string[] colors = str.Split(';');
      for (int i = 0; i < colors.Length; i++)
      {
        Color col = new Color();
        if (Color.TryParse(colors[i], ref col))
          result.Add(col);
      }
      return result.ToArray();
    }

    /// <summary>
    /// Parses the given string to a mesh mode. The string has to be the name of the corresponding enum member.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    /// <returns>The parsed meshmode. MeshMode.None if the string could not be parsed.</returns>
    public static MeshMode ParseMeshMode(string str)
    {
      foreach (MeshMode mode in Enum.GetValues(typeof(MeshMode)))
      {
        if (mode.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
          return mode;
      }
      return MeshMode.None;
    }

  }
}
