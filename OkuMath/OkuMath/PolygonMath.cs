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
  }
}
