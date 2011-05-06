using System;

namespace OkuEngine
{
  /// <summary>
  /// Stores a color value in RGBA format.
  /// </summary>
  public struct Color
  {
    public float R;
    public float G;
    public float B;
    public float A;

    public static Color White = new Color(1, 1, 1);
    public static Color Black = new Color(0, 0, 0);
    public static Color Red = new Color(1, 0, 0);
    public static Color Green = new Color(0, 1, 0);
    public static Color Blue = new Color(0, 0, 1);

    /// <summary>
    /// Creates a new opaque color with the given color values.
    /// </summary>
    /// <param name="red">The red amount of the color.</param>
    /// <param name="green">The green amount of the color.</param>
    /// <param name="blue">The blue amount of the color.</param>
    public Color(float red, float green, float blue)
    {
      R = red;
      G = green;
      B = blue;
      A = 1;
    }

    /// <summary>
    /// Creates a new color with the given color values and alpha value.
    /// </summary>
    /// <param name="red">The red amount of the color.</param>
    /// <param name="green">The green amount of the color.</param>
    /// <param name="blue">The blue amount of the color.</param>
    /// <param name="alpha">The alpha transparency where 0 means completely transparent and 1 means opaque.</param>
    public Color(float red, float green, float blue, float alpha)
    {
      R = red;
      G = green;
      B = blue;
      A = alpha;
    }

  }
}