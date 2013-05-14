using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace OkuBase.Graphics
{
  public class ImageData
  {
    private int _width = 0;
    private int _height = 0;
    private byte[] _pixelData = null; //Bytes of pixel data. Size is [width * height * 4]. Byte order in memory is BGRA.

    public ImageData(int width, int height)
    {
      _width = width;
      _height = height;
      _pixelData = new byte[width * height * 4];
    }

    internal ImageData(int width, int height, byte[] pixelData)
    {
      _width = width;
      _height = height;
      _pixelData = pixelData;
    }

    public int Width
    {
      get { return _width; }
    }

    public int Height
    {
      get { return _height; }
    }

    internal byte[] PixelData
    {
      get { return _pixelData; }
      set { _pixelData = value; }
    }

    private int IndexOfPixel(int x, int y)
    {
      return ((y * _width) + x) * 4;
    }

    public Color GetPixelColor(int x, int y)
    {
      int index = IndexOfPixel(x, y);
      Color result = Color.Black;
      result.B = _pixelData[index];
      result.G = _pixelData[index + 1];
      result.R = _pixelData[index + 2];
      result.A = _pixelData[index + 3];
      return result;
    }

    public void SetPixelColor(int x, int y, Color color)
    {
      int index = IndexOfPixel(x, y);
      _pixelData[index] = color.B;
      _pixelData[index + 1] = color.G;
      _pixelData[index + 2] = color.R;
      _pixelData[index + 3] = color.A;
    }

    public static ImageData FromBitmap(Bitmap bitmap)
    {
      BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      int numBytes = Math.Abs(bmData.Stride) * bmData.Height;
      byte[] pixels = new byte[numBytes];
      System.Runtime.InteropServices.Marshal.Copy(bmData.Scan0, pixels, 0, numBytes);

      return new ImageData(bitmap.Width, bitmap.Height, pixels);
    }
    
    public static ImageData FromFile(string filename)
    {
      Bitmap bitmap = new Bitmap(filename);
      return FromBitmap(bitmap);
    }

    public static ImageData FromStream(Stream stream)
    {
      Bitmap bitmap = new Bitmap(stream);
      return FromBitmap(bitmap);
    }

    public static ImageData FromRaw(byte[] rawData, int width, int height)
    {
      return new ImageData(width, height, rawData);
    }

  }
}
