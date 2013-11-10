using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase.Geometry;

namespace OkuEngine
{
  /// <summary>
  /// Defines a set of functions that do continuous collision detection for several shapes.
  /// </summary>
  public static class ContinuousCollision
  {
    /// <summary>
    /// Calculates continuous collisions for two polygons.
    /// </summary>
    /// <param name="poly1">The first polygon.</param>
    /// <param name="poly2">The second polygon.</param>
    /// <param name="translation">The translation of the first polygon.</param>
    /// <param name="mtd">The minimum translation distance to move the two polygons apart if they collide.</param>
    /// <returns>True if the polygons collide, else false.</returns>
    public static bool PolygonPolygon(Vector2f[] poly1, Vector2f[] poly2, Vector2f translation, out float mtd)
    {
      mtd = float.MaxValue;

      //Calculate swept bounding box of poly1
      Vector2f min1 = new Vector2f();
      Vector2f max1 = new Vector2f();
      OkuMath.BoundingBox(poly1, out min1, out max1);
      OkuMath.GetSweptAABB(ref min1, ref max1, translation);

      //Calculate swept bounding box of poly2
      Vector2f min2 = new Vector2f();
      Vector2f max2 = new Vector2f();
      OkuMath.BoundingBox(poly1, out min2, out max2);
      OkuMath.GetSweptAABB(ref min2, ref max2, translation);

      // Only continue if the swept bounding boxes intersect
      bool result = false;
      if (IntersectionTests.Rectangles(min1, max1, min2, max2))
      {
        float lmtd = float.MaxValue;

        //Porject vertices of poly1 onto poly2
        for (int i = 0; i < poly1.Length; i++)
        {
          if (IntersectionTests.RayPolygon(poly1[i], poly1[i] + translation, poly2, out lmtd))
          {
            mtd = Math.Min(mtd, lmtd);
            result = true;
          }
        }

        //Project vertices of poy2 backwards onto poly1
        for (int i = 0; i < poly2.Length; i++)
        {
          if (IntersectionTests.RayPolygon(poly2[i], poly2[i] - translation, poly1, out lmtd))
          {
            mtd = Math.Min(mtd, lmtd);
            result = true;
          }
        }
      }

      return result;
    }

  }
}
