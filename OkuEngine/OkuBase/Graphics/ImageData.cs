using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines the pixel data for an image. The pixel data can be read and manipulated.
  /// </summary>
  public class ImageData
  {
    private int _width = 0;
    private int _height = 0;
    private int[] _pixelData = null; //Pixel data. Size is [width * height]. Each pixel is one byte. Byte order in memory is BGRA.

    /// <summary>
    /// Creates new image data with the given width and height.
    /// </summary>
    /// <param name="width">The width of the image data in pixels.</param>
    /// <param name="height">The height of the image data in pixels.</param>
    public ImageData(int width, int height)
    {
      _width = width;
      _height = height;
      _pixelData = new int[width * height];
    }

    /// <summary>
    /// Creates new image data with the given width and height and pixel data.
    /// </summary>
    /// <param name="width">The width of the image data in pixels.</param>
    /// <param name="height">The height of the image data in pixels.</param>
    /// <param name="pixelData">The pixel data of the new image data.</param>
    internal ImageData(int width, int height, int[] pixelData)
    {
      _width = width;
      _height = height;
      _pixelData = pixelData;
    }

    /// <summary>
    /// Gets the width of the image data in pixels.
    /// </summary>
    public int Width
    {
      get { return _width; }
    }

    /// <summary>
    /// Gets the height of the image data in pixels.
    /// </summary>
    public int Height
    {
      get { return _height; }
    }

    /// <summary>
    /// Gets the raw internal pixel data array.
    /// </summary>
    public int[] PixelData
    {
      get { return _pixelData; }
      //set { _pixelData = value; }
    }

    /// <summary>
    /// Calculates the index of the pixel with the given, zero based x and y coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The index of the pixel in the _pixelData array.</returns>
    private int IndexOfPixel(int x, int y)
    {
      return (y * _width) + x;
    }

    /// <summary>
    /// Gets the color of the pixel at the given, zero based coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The color of the pixel at the given coordinates.</returns>
    public Color GetPixelColor(int x, int y)
    {
      int index = IndexOfPixel(x, y);
      int pixel = _pixelData[index];

      Color result = Color.Black;
      result.B = (byte)(pixel & 0x000000FF);
      pixel = pixel >> 8;
      result.G = (byte)(pixel & 0x000000FF);
      pixel = pixel >> 8;
      result.R = (byte)(pixel & 0x000000FF);
      pixel = pixel >> 8;
      result.A = (byte)(pixel & 0x000000FF);

      return result;
    }

    /// <summary>
    /// Sets the color of the pixel at the given, zero based coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <param name="color">The color to set the pixel to.</param>
    public void SetPixelColor(int x, int y, Color color)
    {
      int pixel = (int)color.A | color.R << 8 | color.G << 16 | color.B << 24;
      _pixelData[IndexOfPixel(x, y)] = pixel;
    }

    /// <summary>
    /// Converts the image data to a Bitmap.
    /// </summary>
    /// <returns>The bitmap for the image data.</returns>
    public Bitmap ToBitmap()
    {
      Bitmap result = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);

      BitmapData bmData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      System.Runtime.InteropServices.Marshal.Copy(_pixelData, 0, bmData.Scan0, _pixelData.Length);
      result.UnlockBits(bmData);

      return result;
    }

    /// <summary>
    /// Creates new image data from the given bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap to read the pixel data from.</param>
    /// <returns>The image data version of the bitmap.</returns>
    public static ImageData FromBitmap(Bitmap bitmap)
    {
      Bitmap flipped = new Bitmap(bitmap);
      flipped.RotateFlip(RotateFlipType.RotateNoneFlipY);

      BitmapData bmData = flipped.LockBits(new Rectangle(0, 0, flipped.Width, flipped.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      int numBytes = Math.Abs(bmData.Width) * bmData.Height;
      int[] pixels = new int[numBytes];
      System.Runtime.InteropServices.Marshal.Copy(bmData.Scan0, pixels, 0, numBytes);
      flipped.UnlockBits(bmData);

      return new ImageData(flipped.Width, flipped.Height, pixels);
    }
    
    /// <summary>
    /// Creates new image data from the given image file.
    /// </summary>
    /// <param name="filename">The path of the image file.</param>
    /// <returns>The image data of the image file.</returns>
    public static ImageData FromFile(string filename)
    {
      Bitmap bitmap = new Bitmap(filename);
      return FromBitmap(bitmap);
    }

    /// <summary>
    /// Creates new image data from the given stream.
    /// The stream is expected to contain a complete image file.
    /// </summary>
    /// <param name="stream">The stream with image data.</param>
    /// <returns>The image data of the stream.</returns>
    public static ImageData FromStream(Stream stream)
    {
      Bitmap bitmap = new Bitmap(stream);
      return FromBitmap(bitmap);
    }

    /// <summary>
    /// Creates new image data with the given width, height and raw pixel data.
    /// The bytes of the ints are expected to have the order BGRA.
    /// The first pixel is expected to be the one in the bottom left corner.
    /// </summary>
    /// <param name="rawData">The raw pixel data.</param>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    /// <returns>The image data.</returns>
    public static ImageData FromRaw(int[] rawData, int width, int height)
    {
      return new ImageData(width, height, rawData);
    }

  }
}
