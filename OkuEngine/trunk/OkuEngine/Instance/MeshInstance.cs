using System;
using OkuEngine.Driver.Renderer;
using OkuEngine.Rendering;

namespace OkuEngine
{
  /// <summary>
  /// One instance of a 2D mesh.
  /// </summary>
  public class MeshInstance : ContentInstance
  {
    private Vertices _vertices = null;
    private MeshMode _mode = MeshMode.Quads;
    private ImageContent _texture = null;

    /// <summary>
    /// Creates a new, empty mesh.
    /// </summary>
    public MeshInstance()
    {
      _vertices = new Vertices();
    }

    /// <summary>
    /// Creates a new mesh with the given vertex data.
    /// </summary>
    /// <param name="vertices">The vertices.</param>
    public MeshInstance(Vertices vertices)
    {
      _vertices = vertices;
    }

    /// <summary>
    /// Create a new mesh with the given texture.
    /// </summary>
    /// <param name="texture">The texture.</param>
    public MeshInstance(ImageContent texture)
    {
      _vertices = new Vertices();
      _texture = texture;
    }

    /// <summary>
    /// Create a new mesh with the given vertices and texture.
    /// </summary>
    /// <param name="vertices">The vertices.</param>
    /// <param name="texture">The texture.</param>
    public MeshInstance(Vertices vertices, ImageContent texture)
    {
      _vertices = vertices;
      _texture = texture;
    }

    /// <summary>
    /// Create a new mesh with the given vertices, texture and mesh mode.
    /// </summary>
    /// <param name="vertices">The vertices.</param>
    /// <param name="texture">The texture.</param>
    /// <param name="mode">The mesh mode.</param>
    public MeshInstance(Vertices vertices, ImageContent texture, MeshMode mode)
    {
      _vertices = vertices;
      _texture = texture;
      _mode = mode;
    }

    /// <summary>
    /// Gets the vertices of the mesh.
    /// </summary>
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    /// <summary>
    /// Gets the texture of the mesh.
    /// </summary>
    public ImageContent Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    /// <summary>
    /// Gets the mode that is used to draw the mesh.
    /// </summary>
    public MeshMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    /// <summary>
    /// Draws the mesh.
    /// </summary>
    public void Draw()
    {
      OkuDrivers.Instance.Renderer.DrawMesh(_vertices.Positions, _vertices.TexCoords, _vertices.Colors, _vertices.Positions.Length, _mode, _texture);
    }
    
  }
}
