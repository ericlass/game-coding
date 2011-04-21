using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  public class ImageContent : Content
  {
    private Polygon _vertices = new Polygon();
    private int _width = 0;
    private int _height = 0;

    private Matrix3 _lastTransform = Matrix3.Indentity;
    private Polygon _transformed = new Polygon();

    public ImageContent(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.Open);
      OkuInterfaces.Renderer.InitContentFile(this, stream);
      stream.Close();
    }

    public ImageContent(Stream fileStream)
    {
      OkuInterfaces.Renderer.InitContentFile(this, fileStream);
    }

    public ImageContent(byte[] rawData, int width, int height)
    {
      OkuInterfaces.Renderer.InitContentRaw(this, rawData, width, height);
    }

    public Polygon Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
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

    public Polygon GetTransformedVertices(Matrix3 transform)
    {
      if (!transform.Equals(_lastTransform))
      {
        transform.Transform(_vertices, _transformed);
        _lastTransform = transform;
      }
      return _transformed;
    }

  }
}
