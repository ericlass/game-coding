using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class OkuExtensions
  {
    public static float RandomFloat(this Random rand)
    {
      return (float)rand.NextDouble() * 2.0f - 1.0f;
    }
  }
}
