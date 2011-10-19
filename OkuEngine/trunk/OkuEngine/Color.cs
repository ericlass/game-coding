using System;
using System.Runtime.InteropServices;

namespace OkuEngine
{
  /// <summary>
  /// Stores a color value in RGBA format.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Color
  {
    public byte R;
    public byte G;
    public byte B;
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

    public bool Equals(Color other)
    {
      return (R == other.R) && (G == other.G) && (B == other.B) && (A == other.A);
    }

    public bool EqualsColor(Color other)
    {
      return (R == other.R) && (G == other.G) && (B == other.B);
    }

  }
}