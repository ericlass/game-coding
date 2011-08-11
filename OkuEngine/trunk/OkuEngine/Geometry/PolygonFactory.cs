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
  }
}
