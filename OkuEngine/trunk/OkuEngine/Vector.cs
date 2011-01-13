using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Vector defines a two dimensional Vector with all standard vector math routines.
  /// The + and - operators have been overloaded to add / subtract two vectors. The
  /// * operator is overloaded to scale a vector by a float value.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class Vector
  {
    /// <summary>
    /// The X component of the vector.
    /// </summary>
    private float _x;
    /// <summary>
    /// The Y component of the vector.
    /// </summary>
    private float _y;

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
    /// Reads a string in the format "float,float", that represents a vector, into this vector.
    /// You can get a string in that format from the <code>ToString</code> method.
    /// Throws a <code>FormatException</code> if the format of the given string is not correct.
    /// </summary>
    /// <param name="str"></param>
    public void Assign(string str)
    {
      string[] components = str.Split(',');
      if (components.Length == 2)
      {
        float value = 0;
        if (Single.TryParse(components[0], out value))
          _x = value;
        else
          throw new FormatException("Wrong number format of X component in vector string: \"" + components[0] + "\" is not a valid float number!");

        if (Single.TryParse(components[1], out value))
          _y = value;
        else
          throw new FormatException("Wrong number format of Y component in vector string: \"" + components[1] + "\" is not a valid float number!");
      }
      else
        throw new FormatException("Wrong vector string format: \"" + str + "\"");
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
    /// Creates a string representation of the vector in the format "X,Y".
    /// </summary>
    /// <returns>A string representation of the vector.</returns>
    public override string ToString()
    {
      StringBuilder result = new StringBuilder();
      result.Append(_x);
      result.Append(',');
      result.Append(_y);
      return result.ToString();
    }

  }
}
