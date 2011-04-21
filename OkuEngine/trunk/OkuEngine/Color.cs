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

    public const Color White = new Color(1, 1, 1);
    public const Color Black = new Color(0, 0, 0);

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