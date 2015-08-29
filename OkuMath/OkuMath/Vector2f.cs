using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Vector2f defines a two dimensional Vector with all standard vector math routines.
  /// Most operators have been overloaded.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Vector2f
  {
    /// <summary>
    /// The X component of the vector.
    /// </summary>
    public float X;

    /// <summary>
    /// The Y component of the vector.
    /// </summary>
    public float Y;

    /// <summary>
    /// A vector with all components set to 0.
    /// </summary>
    public static Vector2f Zero = new Vector2f(0, 0);

    /// <summary>
    /// A vector with all components set to 1.
    /// </summary>
    public static Vector2f One = new Vector2f(1, 1);

    /// <summary>
    /// Creates a new vector and initializes its components with the given values.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    public Vector2f(float x, float y)
    {
      X = x;
      Y = y;
    }

    #region Swizzles

    /// <summary>
    /// Synonym for the X component.
    /// </summary>
    public float R
    {
      get { return X; }
      set { X = value; }
    }

    /// <summary>
    /// Synonym for the Y component.
    /// </summary>
    public float G
    {
      get { return Y; }
      set { Y = value; }
    }

    /// <summary>
    /// Synonym for the X component.
    /// </summary>
    public float S
    {
      get { return X; }
      set { X = value; }
    }

    /// <summary>
    /// Synonym for the Y component.
    /// </summary>
    public float T
    {
      get { return Y; }
      set { Y = value; }
    }

    #endregion

    // <summary>
    /// Defines the number of components the vector has.
    /// </summary>
    public const int ComponentCount = 2;

    /// <summary>
    /// Indexer to be able to access the components by index.
    /// 0 = X, 1 = Y.
    /// </summary>
    /// <param name="index">The index. Either 0 or 1.</param>
    /// <returns>The values at the given index.</returns>
    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return X;
          case 1:
            return Y;

          default:
            throw new ArgumentException(nameof(Vector2f) + " can only have indexes 0 and 1!");
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            X = value;
            break;
          case 1:
            Y = value;
            break;
          default:
            throw new ArgumentException(nameof(Vector2f) + " can only have indexes 0 and 1!");
        }
      }
    }

    /// <summary>
    /// Gets the magnitude (length) of the vector by using the pythogarean theorem.
    /// </summary>
    public float Magnitude
    {
      get { return (float)Math.Sqrt(X * X + Y * Y); }
    }

    /// <summary>
    /// Gets the squared length of the vector. This is not the real length but can be used for comparison
    /// as it is faster to calculate.
    /// </summary>
    public float SquaredMagnitude
    {
      get { return X * X + Y * Y; }
    }

    #region Operators

    /// <summary>
    /// Inverts the components of the given vector.
    /// </summary>
    /// <param name="vec">The vector to be inverted.</param>
    /// <returns>The inverted vector.</returns>
    public static Vector2f operator -(Vector2f vec)
    {
      return new Vector2f(-vec.X, -vec.Y);
    }

    /// <summary>
    /// Increments all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to increment.</param>
    /// <returns>The incremented vector.</returns>
    public static Vector2f operator ++(Vector2f vec)
    {
      return new Vector2f(vec.X + 1, vec.Y + 1);
    }

    /// <summary>
    /// Decrements all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to decrement.</param>
    /// <returns>The decremented vector.</returns>
    public static Vector2f operator --(Vector2f vec)
    {
      return new Vector2f(vec.X - 1, vec.Y - 1);
    }

    /// <summary>
    /// Adds the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the addition.</returns>
    public static Vector2f operator +(Vector2f vec1, Vector2f vec2)
    {
      return new Vector2f(vec1.X + vec2.X, vec1.Y + vec2.Y);
    }

    /// <summary>
    /// Subtracts the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the subtraction.</returns>
    public static Vector2f operator -(Vector2f vec1, Vector2f vec2)
    {
      return new Vector2f(vec1.X - vec2.X, vec1.Y - vec2.Y);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <param name="mul">The multiplier.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector2f operator *(Vector2f vec, float mul)
    {
      return new Vector2f(vec.X * mul, vec.Y * mul);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="mul">The multiplier.</param>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector2f operator *(float mul, Vector2f vec)
    {
      return new Vector2f(vec.X * mul, vec.Y * mul);
    }

    /// <summary>
    /// Multiplies the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the multiplication as a new vector.</returns>
    public static Vector2f operator *(Vector2f vec1, Vector2f vec2)
    {
      return new Vector2f(vec1.X * vec2.X, vec1.Y * vec2.Y);
    }

    /// <summary>
    /// Divides the components of the given vector by the given value.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="value">The dividend.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector2f operator /(Vector2f vec, float value)
    {
      return new Vector2f(vec.X / value, vec.Y / value);
    }

    /// <summary>
    /// Returns a new vector with the components set to (value / component).
    /// </summary>
    /// <param name="value">The dividend.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector2f operator /(float value, Vector2f vec)
    {
      return new Vector2f(value / vec.X, value / vec.Y);
    }

    /// <summary>
    /// Divides the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector2f operator /(Vector2f vec1, Vector2f vec2)
    {
      return new Vector2f(vec1.X / vec2.X, vec1.Y / vec2.Y);
    }

    /// <summary>
    /// Calculates the modulo of the components of the two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A vector containing the modulo of the components.</returns>
    public static Vector2f operator %(Vector2f vec1, Vector2f vec2)
    {
      return new Vector2f(vec1.X % vec2.X, vec1.Y % vec2.Y);
    }

    /// <summary>
    /// Checks if the two vectors are equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are equal, else false.</returns>
    public static bool operator ==(Vector2f vec1, Vector2f vec2)
    {
      return (vec1.X == vec2.X) && (vec1.Y == vec2.Y);
    }

    /// <summary>
    /// Checks if the two vectors are not equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are not equal, else false.</returns>
    public static bool operator !=(Vector2f vec1, Vector2f vec2)
    {
      return (vec1.X != vec2.X) || (vec1.Y != vec2.Y);
    }

    /// <summary>
    /// Extract the X and Y part of the given vector.
    /// </summary>
    /// <param name="vec">The source vector.</param>
    public static explicit operator Vector2f(Vector3f vec)
    {
      return vec.XY;
    }

    /// <summary>
    /// Extract the X and Y part of the given vector.
    /// </summary>
    /// <param name="vec">The source vector.</param>
    public static explicit operator Vector2f(Vector4f vec)
    {
      return vec.XY;
    }

    #endregion

    /// <summary>
    /// Creates a string representation of the vector in the format "X;Y".
    /// </summary>
    /// <returns>A string representation of the vector.</returns>
    public override string ToString()
    {
      return X + ";" + Y;
    }

    /// <summary>
    /// Compares the vector to another vector by comparing the single components.
    /// </summary>
    /// <param name="other">The vector to compare to.</param>
    /// <returns>True if the vectors are equal, else False.</returns>
    public bool Equals(Vector2f other)
    {
      return X == other.X && Y == other.Y;
    }

    /// <summary>
    /// Checks if the vector has a length of zero (= all components are zero).
    /// </summary>
    /// <returns>True if the vector is zero length, else false.</returns>
    public bool IsZero()
    {
      return (X == 0.0f) && (Y == 0.0f);
    }

    /// <summary>
    /// Parses the given string into a vector.
    /// The string is expected to be in the format "X;Y"
    /// like it is created by the ToString method. 
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed vector.</returns>
    public static Vector2f Parse(string str)
    {
      Vector2f result = Vector2f.Zero;
      if (!TryParse(str, ref result))
        throw new FormatException("String '" + str + "' is not a valid vector string in the format '#;#'!");

      return result;
    }

    /// <summary>
    /// Tries to parse the given string into a vector.
    /// The string is expected to be in the format "X;Y"
    /// like it is created by the ToString method.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="vec">The parsed vector is returned here.</param>
    /// <returns>True if the str was parsed successfully, False if the 
    /// given string is null or has a wrong format.</returns>
    public static bool TryParse(string str, ref Vector2f vec)
    {
      if (str != null)
      {
        string[] parts = str.Split(';');
        if (parts.Length == 2)
        {
          vec.X = float.Parse(parts[0].Trim());
          vec.Y = float.Parse(parts[1].Trim());
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Checks if the two vectors are equal.
    /// </summary>
    /// <param name="obj">The other vector.</param>
    /// <returns>True if the vectors are equal.</returns>
    public override bool Equals(object obj)
    {
      if (obj is Vector2f)
      {
        return Equals((Vector2f)obj);
      }
      return base.Equals(obj);
    }

    //Shuts up code analyzer
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}
