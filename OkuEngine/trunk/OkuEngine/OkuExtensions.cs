using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public static class OkuExtensions
  {
    /// <summary>
    /// Calculates a random float value in the range [-1.0,+1.0].
    /// </summary>
    /// <param name="rand">The random number generator to use.</param>
    /// <returns>A random float value in the range [-1.0,+1.0].</returns>
    public static float RandomFloat(this Random rand)
    {
      return (float)rand.NextDouble() * 2.0f - 1.0f;
    }
  }
}
