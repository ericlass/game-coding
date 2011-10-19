﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class ContinuousCollision
  {

    public static bool PolygonPolygon(Vector[] poly1, Vector[] poly2, Vector translation, out float mtd)
    {
      mtd = float.MaxValue;

      //Calculate swept bounding box of poly1
      Vector min1 = new Vector();
      Vector max1 = new Vector();
      OkuMath.BoundingBox(poly1, out min1, out max1);
      OkuMath.GetSweptAABB(ref min1, ref max1, translation);

      //Calculate swept bounding box of poly2
      Vector min2 = new Vector();
      Vector max2 = new Vector();
      OkuMath.BoundingBox(poly1, out min2, out max2);
      OkuMath.GetSweptAABB(ref min2, ref max2, translation);

      // Only continue if the swept bounding boxes intersect
      bool result = false;
      if (Intersections.AABBs(min1, max1, min2, max2))
      {
        float lmtd = float.MaxValue;

        //Porject vertices of poly1 onto poly2
        for (int i = 0; i < poly1.Length; i++)
        {
          if (Intersections.RayPolygon(poly1[i], poly1[i] + translation, poly2, out lmtd))
          {
            mtd = Math.Min(mtd, lmtd);
            result = true;
          }
        }

        //Project vertices of poy2 backwards onto poly1
        for (int i = 0; i < poly2.Length; i++)
        {
          if (Intersections.RayPolygon(poly2[i], poly2[i] - translation, poly1, out lmtd))
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
