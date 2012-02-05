using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace OkuEngine
{
  public class ImageContent : VisualContent
  {
    private int _width = 0;
    private int _height = 0;

    public ImageContent()
    {
    }

    public ImageContent(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.Open);
      OkuDrivers.Renderer.InitContentFile(this, stream);
      stream.Close();
    }

    public ImageContent(Stream fileStream)
    {
      OkuDrivers.Renderer.InitContentFile(this, fileStream);
    }

    public ImageContent(byte[] rawData, int width, int height)
    {
      OkuDrivers.Renderer.InitContentRaw(this, rawData, width, height);
    }

    public ImageContent(Bitmap image)
    {
      OkuDrivers.Renderer.InitContentBitmap(this, image);
    }

    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    public void Update(int x, int y, int width, int height, byte[] rawData)
    {
      OkuDrivers.Renderer.UpdateContent(this, x, y, width, height, rawData);
    }

    public void Update(int x, int y, int width, int height, Bitmap image)
    {
      OkuDrivers.Renderer.UpdateContent(this, x, y, width, height, image);
    }

    public static List<ImageContent> LoadSheet(string filename, int tileSize)
    {
      Bitmap sheet = new Bitmap(filename);
      int width = (int)(sheet.Width / tileSize);
      int height = (int)(sheet.Height / tileSize);

      List<ImageContent> result = new List<ImageContent>();
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          int left = x * tileSize;
          int top = y * tileSize;

          Rectangle rect = new Rectangle(left, top, tileSize, tileSize);
          Bitmap tile = sheet.Clone(rect, PixelFormat.Format32bppArgb);
          ImageContent tileContent = new ImageContent(tile);
          tile.Dispose();
          result.Add(tileContent);
        }
      }

      sheet.Dispose();

      return result;
    }

  }
}
