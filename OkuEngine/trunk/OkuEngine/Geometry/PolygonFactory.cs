using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class PolygonFactory
  {
    public static Vector[] Box(float left, float right, float top, float bottom)
    {
      return new Vector[] {
        new Vector(left, top),
        new Vector(right, top),
        new Vector(right, bottom),
        new Vector(left, bottom)
      };
    }

    public static Vector[] Circle(float x, float y, float radius, int points)
    {
      float step = (float)((2 * Math.PI) / points);
      float angle = 0;
      Vector[] result = new Vector[points];
      for (int i = 0; i < points; i++)
      {
        result[i] = new Vector((float)Math.Sin(angle) * radius + x, (float)Math.Cos(angle) * radius + y);
        angle += step;
      }
      return result;
    }

  }
}
