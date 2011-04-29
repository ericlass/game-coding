using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  public class ImageContent : VisualContent
  {
    private int _width = 0;
    private int _height = 0;

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

  }
}
