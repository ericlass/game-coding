using System;
using System.Collections.Generic;
using OkuEngine.Driver.Renderer;
using OkuEngine.Collections;

namespace OkuEngine
{
  /// <summary>
  /// Used to draw to a specific rectangle area in display space.
  /// The area to be used is given in the Area property.
  /// All drawing is clipped to the drawing area.
  /// </summary>
  public class Canvas
  {
    private AABB _area;
    private DynamicArray<Vector2f> _vertices = new DynamicArray<Vector2f>();
    private DynamicArray<Color> _colors = new DynamicArray<Color>();

    /// <summary>
    /// Creates a new Canvas with the given area.
    /// </summary>
    /// <param name="area"></param>
    public Canvas(AABB area)
    {
      _area = area;
    }
    
    /// <summary>
    /// Gets or sets the drawing area.
    /// </summary>
    public AABB Area
    {
      get { return _area; }
      set { _area = value; }
    }

    /// <summary>
    /// Fills thea area defined by the given vectors.
    /// </summary>
    /// <param name="min">The minimum vector.</param>
    /// <param name="max">The maximum vector.</param>
    /// <param name="color">The color of the rectangle.</param>
    public void FillRect(Vector2f min, Vector2f max, Color color)
    {
      //Convert to display space
      min += _area.Min;
      max += _area.Min;

      //TODO: Clipping

      _vertices.Clear();
      _vertices.Add(min);
      _vertices.Add(new Vector2f(min.X, max.Y));
      _vertices.Add(max);
      _vertices.Add(new Vector2f(max.X, min.Y));

      _colors.Clear();
      for (int i = 0; i < 4; i++)
        _colors.Add(color);

      OkuManagers.Renderer.DrawMesh(_vertices.InternalArray, null, _colors.InternalArray, 4, MeshMode.Quads, null);
    }

    /// <summary>
    /// Draws a generic mesh using the given parameters.
    /// </summary>
    /// <param name="points">The coordinates of the vertices of the mesh in world space. Must not be null.</param>
    /// <param name="texCoords">The normalized texture coordinates of the vertices. Must be same length as points. If null, no texture is applied.</param>
    /// <param name="colors">The colors of the vertices. Must be same length as points. If null, white is used as default color.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="mode">The mode used to create polygons from the given vertices.</param>
    /// <param name="texture">The texture to be applied. If not null, texCoords must also be given.</param>
    public void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, MeshMode mode, ImageContent texture)
    {
      _vertices.Clear();
      int min = Math.Min(points.Length, count);
      for (int i = 0; i < min; i++)
        _vertices.Add(points[i] + _area.Min);

      OkuManagers.Renderer.DrawMesh(_vertices.InternalArray, texCoords, colors, count, mode, texture);
    }

    /// <summary>
    /// Draws the given mesh instance.
    /// </summary>
    /// <param name="mesh">The mesh to be drawn.</param>
    public void DrawMesh(MeshInstance mesh)
    {
      DrawMesh(mesh.Vertices.Positions, mesh.Vertices.TexCoords, mesh.Vertices.Colors, mesh.Vertices.Positions.Length, mesh.Mode, mesh.Texture);
    }

    /// <summary>
    /// Draws the given image content at the given position.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    public void DrawImage(ImageContent image, Vector2f position)
    {
      position += _area.Min;
      OkuManagers.Renderer.DrawImage(image, position);
    }

    public void DrawImage(ImageContent image, Vector2f position, Vector2f scale)
    {
      position += _area.Min;
      OkuManagers.Renderer.DrawImage(image, position, scale);
    }

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    public void DrawLine(Vector2f start, Vector2f end, float width, Color color)
    {
      start += _area.Min;
      end += _area.Min;
      OkuManagers.Renderer.DrawLine(start, end, width, color);
    }

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw lines with.</param>
    /// <param name="color">The color of the lines.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixel.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    public void DrawLines(Vector2f[] vertices, Color color, int count, float width, VertexInterpretation interpretation)
    {
      _vertices.Clear();
      int min = Math.Min(vertices.Length, count);
      for (int i = 0; i < min; i++)
        _vertices.Add(vertices[i] + _area.Min);

      OkuManagers.Renderer.DrawLines(_vertices.InternalArray, color, count, width, interpretation);
    }

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="p">The center of the point in world space pixels.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    public void DrawPoint(Vector2f p, float size, Color color)
    {
      p += _area.Min;
      OkuManagers.Renderer.DrawPoint(p, size, color);
    }

    /// <summary>
    /// Draws a point at every position in the given points array.
    /// </summary>
    /// <param name="points">The points to draw.</param>
    /// <param name="color">The color of the points.</param>
    /// <param name="count">The number of points to draw.</param>
    /// <param name="size">The size in pixels of the points.</param>
    public void DrawPoints(Vector2f[] points, Color color, int count, float size)
    {
      _vertices.Clear();
      int min = Math.Min(points.Length, count);
      for (int i = 0; i < min; i++)
        _vertices.Add(points[i] + _area.Min);

      OkuManagers.Renderer.DrawPoints(_vertices.InternalArray, color, count, size);
    }

  }
}
