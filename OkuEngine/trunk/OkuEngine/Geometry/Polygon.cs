using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Collision;

namespace OkuEngine.Geometry
{
  /// <summary>
  /// Defines a static 2D polygon as a series of vertices.
  /// </summary>
  public class Polygon : IStoreable
  {
    private Vector2f[] _vertices = null;
    private bool _aabbValid = false;
    private AABB _aabb = new AABB();

    /// <summary>
    /// Create a new polygon.
    /// </summary>
    public Polygon()
    {
    }

    /// <summary>
    /// Gets the vertices of the polygon.
    /// If you change any of the vertices you must call 
    /// the Invalidate() method to make sure cached data is refreshed.
    /// </summary>
    public Vector2f[] Vertices
    {
      get { return _vertices; }
    }

    /// <summary>
    /// Invalidates internaly cached data. This must be called 
    /// if the vertices are changed in any way.
    /// </summary>
    public void Invalidate()
    {
      _aabbValid = false;
    }

    /// <summary>
    /// Calculates the bounding box of the polygon.
    /// </summary>
    /// <returns>The bounding box of the polygon.</returns>
    public AABB GetBoundingBox()
    {
      if (!_aabbValid)
      {
        _aabb = _vertices.GetBoundingBox();
        _aabbValid = true;
      }
      return _aabb;
    }

    /// <summary>
    /// Searches for the vertex that is closest to the given point.
    /// </summary>
    /// <param name="point">The point to find the nearest vertex for.</param>
    /// <param name="distance">The distance to the nearest vertex is returned here.</param>
    /// <returns>The index of the nearest vertex.</returns>
    public int GetNearestVertex(Vector2f point, out float distance)
    {
      return _vertices.ClosestPoint(point, out distance);
    }

    /// <summary>
    /// Checks if the polygon is clockwise or counter-clockwise.
    /// </summary>
    /// <returns>True if the polygon is clockwise, else false.</returns>
    public bool IsClockwise()
    {
      float total = 0.0f;
      for (int i = 0; i < _vertices.Length; i++)
      {
        int j = (i + 1) % _vertices.Length;
        total += (_vertices[j].X - _vertices[i].X) * (_vertices[j].Y + _vertices[i].Y);
      }
      return total >= 0.0f;
    }

    /// <summary>
    /// Creates a deep copy of the polygon.
    /// </summary>
    /// <returns>A copy of the Polygon.</returns>
    public Polygon Copy()
    {
      Polygon result = new Polygon();

      Vector2f[] verts = new Vector2f[_vertices.Length];
      Array.Copy(_vertices, verts, verts.Length);
      result._vertices = verts;

      return result;
    }

    public bool Load(XmlNode node)
    {
      try
      {
        if (node.FirstChild != null)
        {
          _vertices = Converter.ParseVectors(node.FirstChild.Value);
          _aabbValid = false;
        }
        return true;
      }
      catch (Exception e)
      {
        OkuManagers.Logger.LogError("Error while loading polygon! " + e.Message);
        return false;
      }
    }

    public bool Save(XmlWriter writer)
    {
      if (_vertices != null)
        writer.WriteValueTag("polygon", _vertices.ToOkuString());

      return true;
    }

    public override string ToString()
    {
      return _vertices == null ? "" : _vertices.ToOkuString();
    }

  }
}
