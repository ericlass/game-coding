using System;

namespace OkuEngine
{
  /// <summary>
  /// Defines an integer vector with two components.
  /// </summary>
  public struct Vector2i
  {
    public int X;
    public int Y;

    /// <summary>
    /// A vector with X and Y set to 0.
    /// </summary>
    public static Vector2i Zero = new Vector2i(0, 0);

    /// <summary>
    /// A vector with X and Y set to 1.
    /// </summary>
    public static Vector2i One = new Vector2i(1, 1);

    /// <summary>
    /// Creates a new vector with the given values.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    public Vector2i(int x, int y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    /// Creates a new integer vector from the given float vector.
    /// The components of the float vector are floored.
    /// </summary>
    /// <param name="fvec">The float vector to copy.</param>
    public Vector2i(Vector2f fvec)
    {
      X = (int)fvec.X;
      Y = (int)fvec.Y;
    }

    public static Vector2i operator +(Vector2i vec1, Vector2i vec2)
    {
      return new Vector2i(vec1.X + vec2.X, vec1.Y + vec2.Y);
    }

    public static Vector2i operator -(Vector2i vec1, Vector2i vec2)
    {
      return new Vector2i(vec1.X - vec2.X, vec1.Y - vec2.Y);
    }

    public static Vector2i operator -(Vector2i vec)
    {
      return new Vector2i(-vec.X, -vec.Y);
    }

    public static Vector2i operator *(Vector2i vec1, Vector2i vec2)
    {
      return new Vector2i(vec1.X * vec2.X, vec1.Y * vec2.Y);
    }

    public static Vector2i operator *(Vector2i vec, int mul)
    {
      return new Vector2i(vec.X * mul, vec.Y * mul);
    }

    public static Vector2i operator /(Vector2i vec1, Vector2i vec2)
    {
      return new Vector2i(vec1.X / vec2.X, vec1.Y / vec2.Y);
    }

    public static Vector2i operator /(Vector2i vec, int div)
    {
      return new Vector2i(vec.X / div, vec.Y / div);
    }

    public static bool operator ==(Vector2i vec1, Vector2i vec2)
    {
      return (vec1.X == vec2.X) && (vec1.Y == vec2.Y);
    }

    public static bool operator !=(Vector2i vec1, Vector2i vec2)
    {
      return (vec1.X != vec2.X) || (vec1.Y != vec2.Y);
    }

    /// <summary>
    /// Creates a string representation of the vector in the format "x,y".
    /// </summary>
    /// <returns>The string representation of the vector.</returns>
    public override string ToString()
    {
      return X + ";" + Y;
    }

    /// <summary>
    /// Cecks if the vector equals the given one.
    /// </summary>
    /// <param name="other">The vector to compare too.</param>
    /// <returns>True if the vectors are equal, else false.</returns>
    public bool Equals(Vector2i other)
    {
      return this == other;
    }

    public override bool Equals(object obj)
    {
      if (obj is Vector2i)
        return this == (Vector2i)obj;

      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}