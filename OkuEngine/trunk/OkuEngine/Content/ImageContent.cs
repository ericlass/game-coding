using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using OkuEngine.Resources;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// A single loaded, renderable image.
  /// </summary>
  public class ImageContent : StoreableEntity
  {
    private int _width = 0;
    private int _height = 0;
    private string _resource = null;
    private bool _compressed = false;

    /// <summary>
    /// Creates a new image.
    /// </summary>
    public ImageContent()
    {
    }

    /// <summary>
    /// Createa a new image and loads the image data from the given file.
    /// </summary>
    /// <param name="filename">The name and path of the file to load the image from.</param>
    public ImageContent(string filename)
    {
      Bitmap bm = new Bitmap(filename);
      _width = bm.Width;
      _height = bm.Height;
      OkuDrivers.Instance.Renderer.InitImageContent(this, bm);
    }

    /// <summary>
    /// Createa a new image and loads the image data from the given stream.
    /// </summary>
    /// <param name="filename">The stream to load the image from.</param>
    public ImageContent(Stream fileStream)
    {
      Bitmap bm = new Bitmap(fileStream);
      _width = bm.Width;
      _height = bm.Height;
      OkuDrivers.Instance.Renderer.InitImageContent(this, bm);
    }

    /// <summary>
    /// Creates a new image with the given raw image data.
    /// </summary>
    /// <param name="rawData">The raw pixel data of the image.</param>
    /// <param name="width">The width of the image in pixels.</param>
    /// <param name="height">The height of the image in pixels.</param>
    public ImageContent(byte[] rawData, int width, int height)
    {
      _width = width;
      _height = height;

      Bitmap bm = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      
      BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      Marshal.Copy(rawData, 0, data.Scan0, rawData.Length);
      bm.UnlockBits(data);

      OkuDrivers.Instance.Renderer.InitImageContent(this, bm);
    }

    /// <summary>
    /// Createa a new image and loads the image data from the given bitmap.
    /// </summary>
    /// <param name="filename">The bitmap to load the image from.</param>
    public ImageContent(Bitmap image)
    {
      _width = image.Width;
      _height = image.Height;
      OkuDrivers.Instance.Renderer.InitImageContent(this, image);
    }

    /// <summary>
    /// Gets or sets the width of the image in pixels.
    /// </summary>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Gets or sets the height of the image in pixels.
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Gets or sets the name of the image resource the image was loaded from.
    /// </summary>
    [JsonPropertyAttribute]
    public string Resource
    {
      get { return _resource; }
      set { _resource = value; }
    }

    /// <summary>
    /// Gets or sets if the image should be compressed or not.
    /// NOTE: After the image has been loaded changing this has no effect.
    /// </summary>
    [JsonPropertyAttribute]
    public bool Compressed
    {
      get { return _compressed; }
      set { _compressed = value; }
    }

    /// <summary>
    /// Updates a part of the image with the given bitmap.
    /// </summary>
    /// <param name="x">The left bound of the rectangle to be updated.</param>
    /// <param name="y">The lower bound of the rectangle to be updated.</param>
    /// <param name="width">The width of the rectangle to be updated.</param>
    /// <param name="height">The height of the rectangle to be updated.</param>
    /// <param name="image">The bitmap to put in the updated rectangle.</param>
    public void Update(int x, int y, int width, int height, Bitmap image)
    {
      OkuDrivers.Instance.Renderer.UpdateContent(this, x, y, width, height, image);
    }

    public override bool AfterLoad()
    {
      if (_resource == null)
        return false;

      ResourceHandle handle = OkuManagers.Instance.ResourceCache.GetHandle(new Resource(_resource));
      if (handle != null)
      {
        Bitmap bm = (handle.Extras as TextureExtraData).Image;
        OkuDrivers.Instance.Renderer.InitImageContent(this, bm);
        _width = bm.Width;
        _height = bm.Height;
      }
      else
      {
        OkuManagers.Instance.Logger.LogError("Image resource '" + _resource + "' was not found!");
        return false;
      }

      return true;
    }

    /// <summary>
    /// Loads a number of images from a sprite sheet.
    /// The sprites must have equal width and height.
    /// </summary>
    /// <param name="filename">The name of the file to load from.</param>
    /// <param name="tileSize">The width and height of the sprites in pixels</param>
    /// <returns>A list of the sprites loaded from the sheet.</returns>
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
