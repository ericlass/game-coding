using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuEngine.Attributes;

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
    /// Converts the given string to a float value. The decimal separator has to be a ".".
    /// </summary>
    /// <param name="str">The string to be converted to a float.</param>
    /// <returns>The converted float value.</returns>
    public static bool TryStrToFloat(string str, out float result)
    {
      string[] parts = str.Split('.');

      result = 0.0f;
      float fraction = 0.0f;
      try
      {
        result = float.Parse(parts[0]);
        if (parts.Length > 1)
          fraction = float.Parse(parts[1]);
      }
      catch (Exception)
      {
        return false;
      }

      while (fraction >= 1.0f)
        fraction /= 10.0f;

      result += fraction;

      return true;
    }

    /// <summary>
    /// Converts the given string to a vector array.
    /// The string is expected to be in the format that
    /// is created by VectorsToStr.
    /// </summary>
    /// <param name="str">The string with the vectors.</param>
    /// <returns>A vector array with all vectors.</returns>
    public static Vector2f[] ParseVectors(string str)
    {
      List<Vector2f> result = new List<Vector2f>();
      string[] vectors = str.Split(';');
      for (int i = 0; i < vectors.Length; i++)
      {
        Vector2f vec = new Vector2f();
        if (Vector2f.TryParse(vectors[i], ref vec))
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
        if (Color.TryParse(colors[i], out col))
          result.Add(col);
      }
      return result.ToArray();
    }

    /// <summary>
    /// Parses the given string into a value of the generic
    /// type which must be an enum. Unfiortunatelly, this cannot
    /// be forced through generic contraints.
    /// </summary>
    /// <typeparam name="T">The enum type to parse to.</typeparam>
    /// <param name="str">The string to parse.</param>
    /// <returns>The parsed enum value or default(T) if no member was found.</returns>
    public static T ParseEnum<T>(string str)
    {
      if (typeof(T).IsEnum)
      {
        foreach (T value in Enum.GetValues(typeof(T)))
        {
          if (value.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
            return value;
        }
      }
      else
      {
        throw new ArgumentException("Generic parameter type must be an enum!");
      }
      return default(T);
    }

    /// <summary>
    /// Tries to parse the given string into a member of the given enum type.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="result">If true is returned, the parsed enum member is returned here.</param>
    /// <returns>True if the string was parsed successful, else false.</returns>
    public static bool TryParseEnum<T>(string str, out T result)
    {
      result = default(T);
      if (typeof(T).IsEnum)
      {
        foreach (T value in Enum.GetValues(typeof(T)))
        {
          if (value.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
          {
            result = value;
            return true;
          }
        }
      }
      else
      {
        throw new ArgumentException("Generic parameter type must be an enum!");
      }
      return false;
    }

    /// <summary>
    /// Converts the given string to a boolean value.
    /// "yes" is converted to true and "no" is converted to false.
    /// If the string is neither "yes" nor "no", defaultIfNull is returned.
    /// </summary>
    /// <param name="str">The string to be converted.</param>
    /// <param name="defaultIfNull">The default value to return when the string cannot be converted to boolean.</param>
    /// <returns>True if the given string is "yes", false if it is "no" or defaultIfNull if it could bot be converted.</returns>
    public static bool StrToBool(string str, bool defaultIfNull)
    {
      if (str != null)
      {
        if (str.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
          return true;
        else if (str.Equals("no", StringComparison.CurrentCultureIgnoreCase))
          return false;
      }
      return defaultIfNull;
    }

    /// <summary>
    /// Convert the given boolean value to a string.
    /// True is converted "yes" and false is converted to "no".
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>"yes" if true is given, else "no".</returns>
    public static string BoolToStr(bool value)
    {
      return value ? "yes" : "no";
    }

    /// <summary>
    /// Converts the given string to an attribute value of the given type.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="type">The target type.</param>
    /// <returns>The converted attribute value. Null if the given value is null.</returns>
    public static object AttributeValueFromString(string value, AttributeType type)
    {
      if (value == null)
        return null;

      switch (type)
      {
        case AttributeType.Boolean:
          return Converter.StrToBool(value, false);

        case AttributeType.Integer:
          int test = 0;
          if (int.TryParse(value, out test))
            return test;
          else
            return 0;

        case AttributeType.Number:
          double testd = 0;
          if (double.TryParse(value, out testd))
            return testd;
          else
            return 0.0;

        case AttributeType.String:
          return value;

        default:
          throw new NotImplementedException("Don't know how to parse parameter type " + type.ToString() + "!");
      }
    }

    public static string ValueToString(AttributeValue value)
    {
      if (value == null || value.RawValue == null)
        return null;

      switch (value.Type)
      {
        case AttributeType.Boolean:
          return BoolToStr((bool)value.RawValue);

        case AttributeType.Integer:
          return value.RawValue.ToString();

        case AttributeType.Number:
          return FloatToString((float)value.RawValue);

        case AttributeType.String:
          return value.RawValue as string;

        default:
          throw new NotImplementedException("Don't know how to convert parameter type " + value.Type + "!");
      }
    }

    public static bool TryParseAABB(string str, out Rectangle2f result)
    {
      result = new Rectangle2f();
      if (str != null)
      {
        Vector2f[] minMax = Converter.ParseVectors(str);
        if (minMax.Length == 2)
        {
          result.Min = minMax[0];
          result.Max = minMax[1];
          return true;
        }
        else
        {
          OkuManager.Instance.Logging.LogError("AABB '" + str + "' has wrong format!");
        }
      }
      return false;
    }

  }
}
