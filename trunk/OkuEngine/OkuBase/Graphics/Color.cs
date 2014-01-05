using System;
using System.Runtime.InteropServices;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Stores a color value in RGBA format.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Color
  {
    public byte B;
    public byte G;
    public byte R;
    public byte A;

    public static Color White = new Color(255, 255, 255);
    public static Color Black = new Color(0, 0, 0);
    public static Color Red = new Color(255, 0, 0);
    public static Color Green = new Color(0, 255, 0);
    public static Color Blue = new Color(0, 0, 255);
    public static Color Silver = new Color(192, 192, 192);
    public static Color Magenta = new Color(255, 0, 255);
    public static Color Cyan = new Color(0, 255, 255);
    public static Color Yellow = new Color(255, 255, 0);
    public static Color Transparent = new Color(0, 0, 0, 0);

    /// <summary>
    /// Creates a new opaque color with the given color values.
    /// </summary>
    /// <param name="red">The red amount of the color.</param>
    /// <param name="green">The green amount of the color.</param>
    /// <param name="blue">The blue amount of the color.</param>
    public Color(byte red, byte green, byte blue)
    {
      R = red;
      G = green;
      B = blue;
      A = 255;
    }

    /// <summary>
    /// Creates a new color with the given color values and alpha value.
    /// </summary>
    /// <param name="red">The red amount of the color.</param>
    /// <param name="green">The green amount of the color.</param>
    /// <param name="blue">The blue amount of the color.</param>
    /// <param name="alpha">The alpha transparency where 0 means completely transparent and 1 means opaque.</param>
    public Color(byte red, byte green, byte blue, byte alpha)
    {
      R = red;
      G = green;
      B = blue;
      A = alpha;
    }

    public static Color RandomColor(Random rand)
    {
      return new Color(
        (byte)(Math.Round(rand.NextDouble()) * 255),
        (byte)(Math.Round(rand.NextDouble()) * 255),
        (byte)(Math.Round(rand.NextDouble()) * 255)
        );
    }

    public static Color operator *(Color color, float mul)
    {
      return new Color((byte)(color.R * mul), (byte)(color.G * mul), (byte)(color.B * mul), color.A);
    }

    public static Color operator +(Color col1, Color col2)
    {
      return new Color((byte)(col1.R + col2.R), (byte)(col1.R + col2.R), (byte)(col1.R + col2.R));
    }

    /// <summary>
    /// Compares this color with the given color.
    /// </summary>
    /// <param name="other">The color to compare with.</param>
    /// <returns>True if the two colors R, G, B and A values are equal, else false.</returns>
    public bool Equals(Color other)
    {
      return (R == other.R) && (G == other.G) && (B == other.B) && (A == other.A);
    }

    /// <summary>
    /// Compares this color with the given one without checking the Alpha component.
    /// </summary>
    /// <param name="other">The color to compare with.</param>
    /// <returns>True if the two colors R, G and B values are equal, else false.</returns>
    public bool EqualsColor(Color other)
    {
      return (R == other.R) && (G == other.G) && (B == other.B);
    }

    /// <summary>
    /// Calculates the objective brightness of the color.
    /// </summary>
    /// <returns>The brightness in the range [0.0 - 255,0]</returns>
    public float GetBrightness()
    {
      return R * 0.2126f + G * 0.7152f + B * 0.0722f;
    }

    /// <summary>
    /// Calculates the brightness of the color like
    /// perceived by the human eye. Note that this is
    /// sdarker than <code>GetBrightness</code>.
    /// </summary>
    /// <returns></returns>
    public float GetPerceivedBrightness()
    {
      return (float)Math.Sqrt(R * R * 0.241f + G * G * 0.691f + B * B * 0.068f);
    }

    /// <summary>
    /// Converts the color into a string in the HTML color format "#RRGGBBAA".
    /// </summary>
    /// <returns>The color as a string.</returns>
    public override string ToString()
    {
      return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2") + A.ToString("X2");
    }

    /// <summary>
    /// Blends the to given colors by the given ratio.
    /// </summary>
    /// <param name="col1">The first color.</param>
    /// <param name="col2">The second color.</param>
    /// <param name="ratio">The mixing ration. Must be in the range [0.0 - 1.0]. 0.0 means col1, 1.0 col2.</param>
    /// <returns></returns>
    public static Color Blend(Color col1, Color col2, float ratio)
    {
      if (ratio > 1.0f)
        ratio = 1.0f;
      else if (ratio <= 0.0f)
        ratio = 0.0f;

      float invRatio = 1.0f - ratio;
      return new Color(
        (byte)(col1.R * invRatio + col2.R * ratio),
        (byte)(col1.G * invRatio + col2.G * ratio),
        (byte)(col1.B * invRatio + col2.B * ratio),
        (byte)(col1.A * invRatio + col2.A * ratio));
    }

    /// <summary>
    /// Gets the color that has more contrast on backgroundColor.
    /// </summary>
    /// <param name="backgroundColor">The color of the background.</param>
    /// <param name="bright">A bright color for dark backgrounds.</param>
    /// <param name="dark">A dark color for bright backgrounds.</param>
    /// <returns>Either the bright color or the dak color, depending on the brightness of the background color.</returns>
    public static Color GetContrastColor(Color backgroundColor, Color bright, Color dark)
    {
      if (backgroundColor.GetPerceivedBrightness() < 130)
        return bright;
      else
        return dark;
    }

    /// <summary>
    /// Tries to parse the given string into a color.
    /// The string is expected to be in the typical
    /// hexadecimal HTML color format (#RGB, #RGBA, #RRGGBB or #RRGGBBAA).
    /// </summary>
    /// <param name="str">The string representation of the color.</param>
    /// <param name="color">The parsed color is returend here if the method returns true.</param>
    /// <returns>True if the given string could be parsed to a color, else false.</returns>
    public static bool TryParse(string str, out Color color)
    {
      color = Black;

      if (str != null)
      {
        str = str.Substring(1); //Cut off hash
        if (str.Length == 3 || str.Length == 4)
        {
          //Expand shortcut format (i.e. #ABCD -> #AABBCCDD)
          string expanded = "";
          foreach (char c in str)
          {
            expanded += c;
            expanded += c;
          }
          str = expanded;
        }
        
        if (str.Length == 6 || str.Length == 8)
        {
          color.R = Convert.ToByte(str.Substring(0, 2), 16);
          color.G = Convert.ToByte(str.Substring(2, 2), 16);
          color.B = Convert.ToByte(str.Substring(4, 2), 16);
          if (str.Length == 8)
            color.A = Convert.ToByte(str.Substring(6, 2), 16);
        }
      }
      return false;
    }

  }
}