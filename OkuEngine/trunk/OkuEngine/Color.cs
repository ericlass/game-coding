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
    /// Blends the to given colors by the given ratio.
    /// </summary>
    /// <param name="col1">The first color.</param>
    /// <param name="col2">The second color.</param>
    /// <param name="ratio">The mixing ration. Must be in the range [0.0 - 1.0]. 0.0 means col1, 1.0 col2.</param>
    /// <returns></returns>
    public static Color Blend(Color col1, Color col2, float ratio)
    {
      ratio = OkuMath.Clamp(ratio, 0.0f, 1.0f);
      float invRatio = 1.0f - ratio;
      return new Color(
        (byte)(col1.R * invRatio + col2.R * ratio),
        (byte)(col1.G * invRatio + col2.G * ratio),
        (byte)(col1.B * invRatio + col2.B * ratio),
        (byte)(col1.A * invRatio + col2.A * ratio));
    }

  }
}