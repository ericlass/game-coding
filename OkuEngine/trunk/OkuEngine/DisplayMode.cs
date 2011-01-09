using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Specifies a display mode with resolution, display frequency, bits per pixel and display orientation.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class DisplayMode
  {
    /// <summary>
    /// Creates a new default display mode with resolution 800x600, display frequency 60Hz and 32 bits per pixel.
    /// </summary>
    public DisplayMode()
    {
      Width = 800;
      Height = 600;
      Frequency = 60;
      BitsPerPixel = 32;
      Orientation = 0;
    }

    /// <summary>
    /// Creates a new display mode with the given settings.
    /// </summary>
    /// <param name="width">The horizontal resolution in pixels.</param>
    /// <param name="height">The vertical resolution in pixels.</param>
    /// <param name="frequency">The display frequency.</param>
    /// <param name="bitsPerPixel">The number of color bits per pixel.</param>
    /// <param name="orientation">The orientation of the display.</param>
    public DisplayMode(int width, int height, int frequency, int bitsPerPixel, int orientation)
    {
      Width = width;
      Height = height;
      Frequency = frequency;
      BitsPerPixel = bitsPerPixel;
      Orientation = orientation;
    }

    /// <summary>
    /// Gets or sets the horizontal resolution of the display in pixels.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the vertical resolution of the display in pixels.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the display refresh frequency in Hertz.
    /// </summary>
    public int Frequency { get; set; }

    /// <summary>
    /// Gets or sets the number of color bits per pixel. Allowed values are 8, 16,24 and 32.
    /// </summary>
    public int BitsPerPixel { get; set; }

    /// <summary>
    /// Gets or sets the display orientation in degrees. Allowed values are 0 and 90.
    /// </summary>
    public int Orientation { get; set; }

    /// <summary>
    /// Creates a string representation of the display mode.
    /// </summary>
    /// <returns>A string representation of the display mode.</returns>
    public override string ToString()
    {
      return Width + "x" + Height + ", " + BitsPerPixel + " bit, " + Frequency + " Hz, Orientation: " + Orientation + "°";
    }

  }
}
