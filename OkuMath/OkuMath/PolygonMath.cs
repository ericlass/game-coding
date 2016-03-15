using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuMath
{
  public static class PolygonMath
  {
    /// <summary>
    /// Calculates the normals for a closed polygon shape.
    /// </summary>
    /// <param name="polygon">The points of the polygon.</param>
    /// <returns>The normals of the polygons segments.</returns>
    public static Vector2f[] GetNormals(Vector2f[] polygon)
    {
      Vector2f[] normals = new Vector2f[polygon.Length];
      for (int i = 0; i < polygon.Length; i++)
      {
        int j = (i + 1) % polygon.Length;
        normals[i] = VectorMath.GetNormal(polygon[j] - polygon[i]);
      }
      return normals;
    }

    /// <summary>
    /// Calculates the center of the given polygon.
    /// </summary>
    /// <param name="polygon">The points of the polygon.</param>
    /// <returns>The center of the polygon.</returns>
    public static Vector2f Center(Vector2f[] polygon)
    {
      Tuple<Vector2f, Vector2f> aabb = AABBMath.FromPoints(polygon);
      return AABBMath.Center(aabb.Item1, aabb.Item2);
    }

    /// <summary>
    /// Recalculates the given polygon or point cloud so that all
    /// vertices positions are realtive to the center of the polygon.
    /// </summary>
    /// <param name="polygon">The polygon to center.</param>
    public static void CenterAtOrigin(Vector2f[] polygon)
    {
      CenterAt(polygon, Vector2f.Zero);
    }

    /// <summary>
    /// Center the given polygon vertices at the given center.
    /// That means that all vertices are now relative to the
    /// given center.
    /// </summary>
    /// <param name="polygon">The polygon to be centered.</param>
    /// <param name="center">The new center of the polygon.</param>
    public static void CenterAt(Vector2f[] polygon, Vector2f center)
    {
      Vector2f currentCenter = Center(polygon);
      Vector2f offset = center - currentCenter;
      for (int i = 0; i < polygon.Length; i++)
        polygon[i] += offset;
    }

  }
}
