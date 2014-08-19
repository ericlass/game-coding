using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public struct Vector2i
  {
    public int X;
    public int Y;

    public Vector2i(int x, int y)
    {
      X = x;
      Y = y;
    }

    public static Vector2i operator +(Vector2i v1, Vector2i v2)
    {
      return new Vector2i(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2i operator -(Vector2i v1, Vector2i v2)
    {
      return new Vector2i(v1.X - v2.X, v1.Y - v2.Y);
    }

  }
}
