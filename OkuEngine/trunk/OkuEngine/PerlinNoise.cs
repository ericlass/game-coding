using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PerlinNoise
  {
    private int _seed = 0;

    public PerlinNoise()
    {
    }

    public PerlinNoise(int seed)
    {
      _seed = seed;
    }

    private float FindNoise(float x, float y)
    {
      int n = (int)x + (int)y * 57 + _seed;
      n = (n << 13) ^ n;
      int nn = (n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff;
      return 1.0f - (nn / 1073741824.0f);
    }

    private float InterpolateCosine(float a, float b, float m)
    {
      float ft = m * 3.1415927f;
      float f = (1.0f - (float)Math.Cos(ft)) * 0.5f;
      return a * (1.0f - f) + b * f;
    }

    public float Noise(float x, float y)
    {
      float floorX = (float)Math.Floor(x);
      float floorY = (float)Math.Floor(y);
      float s = FindNoise(floorX, floorY);
      float t = FindNoise(floorX + 1, floorY);
      float u = FindNoise(floorX, floorY + 1);
      float v = FindNoise(floorX + 1, floorY + 1);
      float int1 = InterpolateCosine(s, t, x - floorX);
      float int2 = InterpolateCosine(u, v, x - floorX);
      return InterpolateCosine(int1, int2, y - floorY);
    }

    public float Noise(float x, float y, int octaves)
    {
      float result = 0;
      float factor = (float)Math.Pow(2, octaves);
      float zoom = 0.5f;
      for (int i = 0; i < octaves; i++)
      {
        zoom *= 2;
        factor /= 2;
        float value = Noise(x / zoom, y / zoom) / factor;
        result += value;
      }
      return result;
    }

  }
}
