using System;
using System.Collections.Generic;

namespace OkuEngine
{
  /// <summary>
  /// Performs ear clipping on non-complex polygons without holes.
  /// </summary>
  public class EarClipper
  {
    /// <summary>
    /// Calculates the barycentric coordinates of point p in the triangle formed by v1, v2 and v3.
    /// </summary>
    /// <param name="v1">The first point of the triangle.</param>
    /// <param name="v2">The second point of the triangle.</param>
    /// <param name="v3">The third point of the triangle.</param>
    /// <param name="p">The point to find the coordinates for.</param>
    /// <param name="u">The first barycentric value is returned here.</param>
    /// <param name="v">The second barycentric value is returned here.</param>
    /// <param name="w">The third barycentric value is returned here.</param>
    private static void Barycentric(Vector v1, Vector v2, Vector v3, Vector p, ref float u, ref float v, ref float w)
    {
      float det = ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
      u = ((v2.Y - v3.Y) * (p.X - v3.X) + (v3.X - v2.X) * (p.Y - v3.Y)) / det;
      v = ((v3.X - v1.X) * (p.X - v3.X) + (v1.X - v3.X) * (p.Y - v3.Y)) / det;
      w = 1 - u - v;
    }

    /// <summary>
    /// Checks if the given point p is inside the triangle formed by v1, v2 and v3.
    /// "Inside" also include the point lying on one of the edges fo the triangle.
    /// </summary>
    /// <param name="v1">The first point of the triangle.</param>
    /// <param name="v2">The second point of the triangle.</param>
    /// <param name="v3">The third point of the triangle.</param>
    /// <param name="p">The point to check.</param>
    /// <returns>True if the point is inside of the triangle, else false.</returns>
    private static bool PointInTriangle(Vector v1, Vector v2, Vector v3, Vector p) 
    {
      float u = 0;
      float v = 0;
      float w = 0;
      Barycentric(v1, v2, v3, p, ref u, ref v, ref w);
      return u >= 0 && v >= 0 && w >= 0;
    }
    
    /// <summary>
    /// Check if the given v2 is a reflex vertex to v1 and v3.
    /// </summary>
    /// <param name="v1">The first point.</param>
    /// <param name="v2">The second point.</param>
    /// <param name="v3">The third point.</param>
    /// <returns></returns>
    private static bool IsReflex(Vector v1, Vector v2, Vector v3)
    {
      float pos = Math.Sign((v3.X - v1.X) * (v2.Y - v1.Y) - (v3.Y - v1.Y) * (v2.X - v1.X));
      return pos >= 0;
    }
    
    /// <summary>
    /// Triangulates the given polygon.
    /// </summary>
    /// <param name="poly">The polygon to convert.</param>
    /// <returns>The triangles in an array where every group of 
    /// three vectors form a triangle.</returns>
    public static Vector[] Triangulate(Vector[] poly)
    {
      List<Vector> points = new List<Vector>(poly);
      List<Vector> tris = new List<Vector>();
      
      bool earFound = true;
      while (points.Count > 2 && earFound)
      {
        earFound = false;
        for (int i = 0; i < points.Count; i++)
        {
          int prev = i - 1;
          if (prev < 0)
            prev = points.Count + prev;
          
          int next = (i + 1) % points.Count;
          
          Vector v1 = points[prev];
          Vector v2 = points[i];
          Vector v3 = points[next];
          
          if (!IsReflex(v1, v2, v3))
          {
            bool isEar = true;
            for (int k = 0; k < points.Count; k++)
            {
              if (k != prev && k != i && k != next)
              {
                if (PointInTriangle(v1, v2, v3, points[k]))
                {
                  isEar = false;
                  break;
                }
              }
            }
            
            if (isEar)
            {
              tris.Add(v1);
              tris.Add(v2);
              tris.Add(v3);
              
              points.RemoveAt(i);
              
              earFound = true;
            }
            
          }
        }
      }
      
      return tris.ToArray();
    }
  }
}
