﻿using System;
using OkuBase.Graphics;
using OkuMath;

namespace OkuBase.Geometry
{
  /// <summary>
  /// Defines a mesh with vertices and an optional texture.
  /// </summary>
  public class Mesh
  {
    private Vertices _vertices = null;
    private ImageBase _texture = null;
    private PrimitiveType _primitiveType = PrimitiveType.ClosedPolygon;

    /// <summary>
    /// Creates a new mesh with no data.
    /// </summary>
    public Mesh()
    {
    }

    /// <summary>
    /// Creates a new image with the given data.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="texture">The texture to use for the mesh (can be null).</param>
    /// <param name="type">The type of primitives to form from the vertices.</param>
    public Mesh(Vertices vertices, ImageBase texture, PrimitiveType type)
    {
      _vertices = vertices;
      _texture = texture;
      _primitiveType = type;
    }

    /// <summary>
    /// Gets or sets the vertices of the mesh.
    /// </summary>
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    /// <summary>
    /// Gets or sets the texture of the mesh.
    /// </summary>
    public ImageBase Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    /// <summary>
    /// Gets or sets the type of primitive that the vertices form for drawing.
    /// </summary>
    public PrimitiveType PrimitiveType
    {
      get { return _primitiveType; }
      set { _primitiveType = value; }
    }

    /// <summary>
    /// Creates a mesh that renders the given image with the given tint color in original size.
    /// </summary>
    /// <param name="image">The image to be used.</param>
    /// <param name="tint">The tint color.</param>
    /// <returns>The generated mesh.</returns>
    public static Mesh ForImage(ImageBase image, Color tint)
    {
      float halfWidth = image.Width / 2;
      float halfHeight = image.Height / 2;

      Vector2f[] pos = new Vector2f[4] {
        new Vector2f(-halfWidth, -halfHeight),
        new Vector2f(-halfWidth, halfHeight),
        new Vector2f(halfWidth, -halfHeight),
        new Vector2f(halfWidth, halfHeight)
      };

      Vector2f[] tex = new Vector2f[4] {
        new Vector2f(0, 0),
        new Vector2f(0, 1),
        new Vector2f(1, 0),
        new Vector2f(1, 1)
      };

      Color[] col = new Color[4] { tint, tint, tint, tint };

      Mesh result = new Mesh();
      result.Vertices = new Vertices(pos, tex, col);

      result.Texture = image;
      result.PrimitiveType = PrimitiveType.TriangleStrip;

      return result;
    }

  }
}
