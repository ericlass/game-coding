using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Vector defines a two dimensional Vector with all standard vector math routines.
  /// The + and - operators have been overloaded to add / subtract two vectors. The
  /// * operator is overloaded to scale a vector by a float value.
  /// </summary>
  public class Vector
  {
    /// <summary>
    /// The X component of the vector.
    /// </summary>
    private float _x = 0;
    /// <summary>
    /// The Y component of the vector.
    /// </summary>
    private float _y = 0;

    /// <summary>
    /// A vector with X and Y set to 0.
    /// </summary>
    public static Vector Zero
    {
      get { return new Vector(); }
    }    

    /// <summary>
    /// A vector with X and Y set to 1.
    /// </summary>
    public static Vector One
    {
      get { return new Vector(1.0f, 1.0f); }
    }

    public Vector()
    {
    }

    /// <summary>
    /// Creates a new Vector and initializes X and Y with the given values.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    public Vector(float x, float y)
    {
      _x = x;
      _y = y;
    }

    public float X
    {
      get { return _x; }
      set { _x = value; }
    }

    public float Y
    {
      get { return _y; }
      set { _y = value; }
    }

    /// <summary>
    /// Gets the magnitude (length) of the vector by using the pythogarean theorem.
    /// </summary>
    public float Magnitude
    {
      get { return (float)Math.Sqrt(_x * _x + _y * _y); }
    }

    /// <summary>
    /// Adds the values of the given vector to this vector.
    /// </summary>
    /// <param name="other">The vector to be added.</param>
    public void Add(Vector other)
    {
      _x += other.X;
      _y += other.Y;
    }

    /// <summary>
    /// Subtracts the values of the given vector from this vector.
    /// </summary>
    /// <param name="other">The vector to be subtracted.</param>
    public void Subtract(Vector other)
    {
      _x -= other.X;
      _y -= other.X;
    }

    /// <summary>
    /// Normalizes this Vector. That is, X and Y are scaled so the magnitude of the vector is 1.0.
    /// </summary>
    public void Normalize()
    {
      float magnitude = Magnitude;
      _x /= magnitude;
      _y /= magnitude;
    }

    /// <summary>
    /// Scales the components of this vector by the given factor.
    /// </summary>
    /// <param name="factor">The scaling factor.</param>
    public void Scale(float factor)
    {
      _x *= factor;
      _y *= factor;
    }

    /// <summary>
    /// Calculates the dot/scalar product of this and the given vector.
    /// NOTE: The vectors have to normalized!
    /// </summary>
    /// <param name="other">The other vector.</param>
    /// <returns>The dot/scalar product of the two vectors.</returns>
    public float DotProduct(Vector other)
    {
      return _x * other.X + _y * other.Y;
    }

    /// <summary>
    /// Adds the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the addition.</returns>
    public static Vector operator +(Vector vec1, Vector vec2)
    {
      return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y);
    }

    /// <summary>
    /// Subtracts the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the subtraction.</returns>
    public static Vector operator -(Vector vec1, Vector vec2)
    {
      return new Vector(vec1.X - vec2.X, vec1.Y - vec2.Y);
    }

    /// <summary>
    /// Inverts the components of the given vector.
    /// </summary>
    /// <param name="vec">The vector to be inverted.</param>
    /// <returns>The inverted vector.</returns>
    public static Vector operator -(Vector vec)
    {
      return new Vector(-vec.X, -vec.Y);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <param name="mul">The multiplier.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector operator *(Vector vec, float mul)
    {
      return new Vector(vec.X * mul, vec.Y * mul);
    }

    /// <summary>
    /// Multiplies the two given vectors component-wise (X1 * X2 and Y1 * Y2).
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the multiplication as a new vector.</returns>
    public static Vector operator *(Vector vec1, Vector vec2)
    {
      return new Vector(vec1.X * vec2.X, vec1.Y * vec2.Y);
    }

    /// <summary>
    /// Divides the two given vectors component-wise (X1 / X2 and Y1 / Y2).
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector operator /(Vector vec1, Vector vec2)
    {
      return new Vector(vec1.X / vec2.X, vec1.Y / vec2.Y);
    }

    /// <summary>
    /// Normalizes the given vector and returns the result as a new vector.
    /// </summary>
    /// <param name="vec">The vector to be normalized.</param>
    /// <returns>The normalized vector.</returns>
    public static Vector Normalize(Vector vec)
    {
      float magnitude = vec.Magnitude;
      return new Vector(vec.X / magnitude, vec.Y / magnitude);
    }

    /// <summary>
    /// Calculates the dot/scalar product of the two given vectors.
    /// NOTE: The vectors have to be normalized!
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The dot/scalar product of the two given vectors.</returns>
    public static float DotProduct(Vector vec1, Vector vec2)
    {
      return vec1.X * vec2.X + vec1.Y * vec2.Y;
    }

    /// <summary>
    /// Calculates the distance between two points given by the two vectors.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The distance between the two points.</returns>
    public static float Distance(Vector vec1, Vector vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      return (float)Math.Sqrt(a * a + b * b);
    }

    /// <summary>
    /// Assigns the X and Y values of the given vector to this vector.
    /// </summary>
    /// <param name="vec">The vector to assign to this vector.</param>
    public void Assign(Vector vec)
    {
      _x = vec._x;
      _y = vec._y;
    }

    /// <summary>
    /// Creates a string representation of the vector in the format "[X,Y]".
    /// </summary>
    /// <returns>A string representation of the vector.</returns>
    public override string ToString()
    {
      StringBuilder result = new StringBuilder();
      result.Append("[");
      result.Append(_x);
      result.Append(',');
      result.Append(_y);
      result.Append("]");
      return result.ToString();
    }

    /// <summary>
    /// Compares the vector to another vector by comparing the X and Y values.
    /// </summary>
    /// <param name="other">The vector to compare to.</param>
    /// <returns>True if the vectors are equal, else False.</returns>
    public bool Equals(Vector other)
    {
      return _x == other._x && _y == other._y;
    }

    /// <summary>
    /// Rotates the vector around the origin by the given angle. Positive angles
    /// mean clockwise rotation, negative values mean counter-clockwise rotation.
    /// </summary>
    /// <param name="angle">The angle to rotate in degrees.</param>
    public void Rotate(float angle)
    {
      float rad = (angle * 180.0f) / (float)Math.PI;

      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      float nx = _x * cos - _y * sin;
      float ny = _x * sin + _y * cos;

      _x = nx;
      _y = ny;
    }

    /// <summary>
    /// Rotates the given vector by the given angle. The result
    /// is returned as a new vector. The given vector is not changed.
    /// Positive angles mean clockwise rotation, negative values mean
    /// counter-clockwise rotation.
    /// </summary>
    /// <param name="vec">The vector to be rotated.</param>
    /// <param name="angle">The angle to rotate in degrees.</param>
    /// <returns>The result of the rotation in a new vector.</returns>
    public static Vector Rotate(Vector vec, float angle)
    {
      Vector result = new Vector();
      result.Assign(vec);
      result.Rotate(angle);
      return result;
    }

    /// <summary>
    /// Project the given vector to this vector.
    /// </summary>
    /// <param name="other">The vector to be projected.</param>
    /// <returns>The projected vector.</returns>
    public Vector Project(Vector other)
    {
      float dp = DotProduct(other) / (_x * _x + _y * _y);
      return new Vector(dp * _x, dp * _y);
    }

    /// <summary>
    /// Projects the given vector to this vector.
    /// </summary>
    /// <param name="other">The vector to be projected.</param>
    /// <returns>The 1d scalar projecetd value.</returns>
    public float ProjectScalar(Vector other)
    {
      return DotProduct(other) / (_x * _x + _y * _y);
    }

  }
}
