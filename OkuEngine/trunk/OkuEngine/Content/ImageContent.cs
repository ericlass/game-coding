using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml;

namespace OkuEngine
{
  public class ImageContent : Content
  {
    private int _width = 0;
    private int _height = 0;
    private string _resource = null;

    public ImageContent()
    {
    }

    public ImageContent(string filename)
    {
      Bitmap bm = new Bitmap(filename);
      _width = bm.Width;
      _height = bm.Height;
      OkuManagers.Renderer.InitImageContent(this, bm);
    }

    public ImageContent(Stream fileStream)
    {
      Bitmap bm = new Bitmap(fileStream);
      _width = bm.Width;
      _height = bm.Height;
      OkuManagers.Renderer.InitImageContent(this, bm);
    }

    public ImageContent(byte[] rawData, int width, int height)
    {
      _width = width;
      _height = height;

      Bitmap bm = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      
      BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      Marshal.Copy(rawData, 0, data.Scan0, rawData.Length);
      bm.UnlockBits(data);

      OkuManagers.Renderer.InitImageContent(this, bm);
    }

    public ImageContent(Bitmap image)
    {
      OkuManagers.Renderer.InitImageContent(this, image);

      _width = image.Width;
      _height = image.Height;
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

    public string Resource
    {
      get { return _resource; }
      set { _resource = value; }
    }

    public void Update(int x, int y, int width, int height, Bitmap image)
    {
      OkuManagers.Renderer.UpdateContent(this, x, y, width, height, image);
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

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      _resource = node.GetTagValue("resource");

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("image");

      if (!base.Save(writer))
        return false;

      writer.WriteValueTag("resource", _resource);

      writer.WriteEndElement();

      return true;
    }

  }
}
