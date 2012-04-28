using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.Shaper
{
  /// <summary>
  /// Defines a shape like it is created by OkuShaper.
  /// Provides methods to load and save shapes.
  /// </summary>
  public class Shape
  {
    private PolygonInstance _polygon = null;
    private string _image = null;

    /// <summary>
    /// Creates a new shape.
    /// </summary>
    public Shape()
    {
      _polygon = new PolygonInstance(new VertexContent());
    }

    /// <summary>
    /// Gets or sets the polygon associated with the shape.
    /// </summary>
    public PolygonInstance Polygon
    {
      get { return _polygon; }
      set { _polygon = value; }
    }

    /// <summary>
    /// Gets or sets the image associated with the shape.
    /// </summary>
    public string Image
    {
      get { return _image; }
      set { _image = value; }
    }

    /// <summary>
    /// Saves the shapes data to the given file.
    /// </summary>
    /// <param name="filename">The file name and path.</param>
    public void Save(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
      try
      {
        Save(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    /// Saves the shape to the given stream.
    /// </summary>
    /// <param name="stream">The stream to save to.</param>
    public void Save(Stream stream)
    {
      _polygon.Content.Save(stream);
      StreamWriter writer = new StreamWriter(stream);
      writer.WriteLine("width=" + Converter.FloatToString(_polygon.LineWidth));
      writer.WriteLine("color=" + _polygon.LineColor.ToString());
      writer.WriteLine("image=" + _image);
      writer.Flush();
    }

    /// <summary>
    /// Loads a shape from the given file.
    /// </summary>
    /// <param name="filename">The file name and path.</param>
    /// <returns>The loaded shape.</returns>
    public static Shape Load(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.Open);
      try
      {
        return Load(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    /// Loads a shape from the given stream.
    /// </summary>
    /// <param name="stream">The stream to load from.</param>
    /// <returns>The loaded shape.</returns>
    public static Shape Load(Stream stream)
    {
      VertexContent vertices = new VertexContent();
      vertices.Load(stream);

      Shape result = new Shape();
      result.Polygon = new PolygonInstance(vertices);

      StreamReader reader = new StreamReader(stream);
      string line = reader.ReadLine();
      while (line != null)
      {
        line = line.Trim().ToLower();
        string[] keyValue = line.Split('=');
        if (keyValue.Length == 2)
        {
          if (keyValue[0].Trim().Equals("image", StringComparison.OrdinalIgnoreCase))
            result.Image = keyValue[1].Trim();
          else if (keyValue[0].Trim().Equals("width", StringComparison.OrdinalIgnoreCase))
            result.Polygon.LineWidth = Converter.StrToFloat(keyValue[1]);
          else if (keyValue[0].Trim().Equals("color", StringComparison.OrdinalIgnoreCase))
          {
            Color col = new Color();
            if (Color.TryParse(keyValue[1], ref col))
              result.Polygon.LineColor = col;
          }
        }

        line = reader.ReadLine();
      }

      return result;
    }

  }
}
