using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Provides methods to generate two dimensional perlin noise
  /// with multiple octaves.
  /// </summary>
  public class PerlinNoise
  {
    private int _seed = 0;

    /// <summary>
    /// Creates a new perlin noise with a seed of 0.
    /// </summary>
    public PerlinNoise()
    {
    }

    /// <summary>
    /// Creates a new perlin noise with the given seed.
    /// </summary>
    /// <param name="seed"></param>
    public PerlinNoise(int seed)
    {
      _seed = seed;
    }

    /// <summary>
    /// Finds the unsmoothed noise value for the given coordinates.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    /// <returns>The noise value for the given coordinates in the range [-1,1].</returns>
    private float FindNoise(float x, float y)
    {
      int n = (int)x + (int)y * 57 + _seed;
      n = (n << 13) ^ n;
      int nn = (n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff;
      return 1.0f - (nn / 1073741824.0f);
    }

    /// <summary>
    /// Gets a noise value for the given coordinates for a noise with just one octave.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <returns>The noise value.</returns>
    public float CosineNoise(float x, float y)
    {
      float floorX = (float)Math.Floor(x);
      float floorY = (float)Math.Floor(y);
      float s = FindNoise(floorX, floorY);
      float t = FindNoise(floorX + 1, floorY);
      float u = FindNoise(floorX, floorY + 1);
      float v = FindNoise(floorX + 1, floorY + 1);
      float int1 = OkuMath.InterpolateCosine(s, t, x - floorX);
      float int2 = OkuMath.InterpolateCosine(u, v, x - floorX);
      return OkuMath.InterpolateCosine(int1, int2, y - floorY);
    }

    /// <summary>
    /// Gets a cubic interpolated noise value for the given coordinates with just one octave.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    /// <returns>The noise value in the range [-1,1].</returns>
    public float CubicNoise(float x, float y)
    {
      float floorX = (float)Math.Floor(x);
      float floorY = (float)Math.Floor(y);

      float xm = x - floorX;
      float ym = y - floorY;

      float a, b, c, d;
      float[] values = new float[4];
      for (int i = 0; i < 4; i++)
      {
        float num = i - 1;
        a = FindNoise(floorX - 1, floorY + num);
        b = FindNoise(floorX, floorY + num);
        c = FindNoise(floorX + 1, floorY + num);
        d = FindNoise(floorX + 2, floorY + num);

        values[i] = OkuMath.InterpolateCubic(a, b, c, d, xm);
      }

      return OkuMath.InterpolateCubic(values[0], values[1], values[2], values[3], ym);
    }

    /// <summary>
    /// Calculates the multi octave noise value for the given coordinate.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="octaves">The number of octaves to calulate.</param>
    /// <param name="size">Determines the size of the noise. 100 is a good starting value. 1 means pixel noise.</param>
    /// <returns>The noise value in the range [-1,1].</returns>
    public float Noise(float x, float y, int octaves, float size)
    {
      float result = 0;
      float factor = 1.0f / ((float)Math.Pow(2, octaves));
      float zoom = (float)Math.Pow(2, octaves);
      for (int i = 0; i < octaves; i++)
      {
        float value = CubicNoise(x * zoom, y * zoom) * factor;
        result += value;
        zoom /= 2.02f;
        factor *= 2;
      }
      return result;
    }

  }
}
