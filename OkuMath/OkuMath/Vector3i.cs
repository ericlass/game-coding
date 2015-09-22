using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Vector3i defines a three dimensional Vector with all standard vector math routines.
  /// Most operators have been overloaded.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Vector3i
  {
    /// <summary>
    /// The X component of the vector.
    /// </summary>
    public int X;

    /// <summary>
    /// The Y component of the vector.
    /// </summary>
    public int Y;

    /// <summary>
    /// The Z component of the vector.
    /// </summary>
    public int Z;

    /// <summary>
    /// A vector with all components set to 0.
    /// </summary>
    public static Vector3i Zero = new Vector3i(0, 0, 0);

    /// <summary>
    /// A vector with all components set to 1.
    /// </summary>
    public static Vector3i One = new Vector3i(1, 1, 1);

    /// <summary>
    /// Creates a new vector and initialzes its components with the given values.
    /// </summary>
    /// <param name="x">The X component.</param>
    /// <param name="y">The Y component.</param>
    /// <param name="z">The Z component.</param>
    public Vector3i(int x, int y, int z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    /// <summary>
    /// Creates a new vector. The X and Y components are set to the values of the given vector.
    /// The Z component is se to the given value. This is like calling new Vector3i(v.X, v.Y, z).
    /// </summary>
    /// <param name="v">The vector with the X and Y values.</param>
    /// <param name="z">The Z value.</param>
    public Vector3i(Vector2i v, int z)
    {
      X = v.X;
      Y = v.Y;
      Z = z;
    }

    /// <summary>
    /// Creates a new vector. The X component is se to the given value.
    /// The Y and Z components are set to the values of the given vector.
    /// This is like calling new Vector3i(x, v.X, v.Y).
    /// </summary>
    /// <param name="x">The X value.</param>
    /// <param name="v">The vector with the Y and Z values.</param>
    public Vector3i(int x, Vector2i v)
    {
      X = x;
      Y = v.X;
      Z = v.Y;
    }

    #region Swizzles

    /// <summary>
    /// Gets or set the XY part of the vector.
    /// </summary>
    public Vector2i XY
    {
      get { return new Vector2i(X, Y); }
      set
      {
        X = value.X;
        Y = value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the YZ part of the vector.
    /// </summary>
    public Vector2i YZ
    {
      get { return new Vector2i(Y, Z); }
      set
      {
        Y = value.X;
        Z = value.Y;
      }
    }

    /// <summary>
    /// Synonym for the X component.
    /// </summary>
    public int R
    {
      get { return X; }
      set { X = value; }
    }

    /// <summary>
    /// Synonym for the Y component.
    /// </summary>
    public int G
    {
      get { return Y; }
      set { Y = value; }
    }

    /// <summary>
    /// Synonym for the Z component.
    /// </summary>
    public int B
    {
      get { return Z; }
      set { Z = value; }
    }

    /// <summary>
    /// Gets or set the RG part of the vector.
    /// </summary>
    public Vector2i RG
    {
      get { return XY; }
      set { XY = value; }
    }

    /// <summary>
    /// Gets or sets the GB part of the vector.
    /// </summary>
    public Vector2i GB
    {
      get { return YZ; }
      set { YZ = value; }
    }

    /// <summary>
    /// Synonym for the X component.
    /// </summary>
    public int S
    {
      get { return X; }
      set { X = value; }
    }

    /// <summary>
    /// Synonym for the Y component.
    /// </summary>
    public int T
    {
      get { return Y; }
      set { Y = value; }
    }

    /// <summary>
    /// Synonym for the Z component.
    /// </summary>
    public int P
    {
      get { return Z; }
      set { Z = value; }
    }

    /// <summary>
    /// Gets or set the RG part of the vector.
    /// </summary>
    public Vector2i ST
    {
      get { return XY; }
      set { XY = value; }
    }

    /// <summary>
    /// Gets or sets the GB part of the vector.
    /// </summary>
    public Vector2i TP
    {
      get { return YZ; }
      set { YZ = value; }
    }

    #endregion

    // <summary>
    /// Defines the number of components the vector has.
    /// </summary>
    public const int ComponentCount = 3;

    /// <summary>
    /// Indexer to be able to access the components by index.
    /// 0 = X, 1 = Y, 2 = Z.
    /// </summary>
    /// <param name="index">The index. Either 0, 1 or 2.</param>
    /// <returns>The values at the given index.</returns>
    public int this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return X;
          case 1:
            return Y;
          case 2:
            return Z;

          default:
            throw new ArgumentException(nameof(Vector3i) + " can only have indexes 0, 1 and 2!");
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
          case 2:
            Z = value;
            break;

          default:
            throw new ArgumentException(nameof(Vector3i) + " can only have indexes 0, 1 and 2!");
        }
      }
    }

    /// <summary>
    /// Gets the magnitude (length) of the vector by using the pythogarean theorem.
    /// </summary>
    public int Magnitude
    {
      get { return (int)Math.Sqrt(X * X + Y * Y + Z * Z); }
    }

    /// <summary>
    /// Gets the squared length of the vector. This is not the real length but can be used for comparison
    /// as it is faster to calculate.
    /// </summary>
    public int SquaredMagnitude
    {
      get { return X * X + Y * Y + Z * Z; }
    }

    #region Operators

    /// <summary>
    /// Inverts the components of the given vector.
    /// </summary>
    /// <param name="vec">The vector to be inverted.</param>
    /// <returns>The inverted vector.</returns>
    public static Vector3i operator -(Vector3i vec)
    {
      return new Vector3i(-vec.X, -vec.Y, -vec.Z);
    }

    /// <summary>
    /// Increments all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to increment.</param>
    /// <returns>The incremented vector.</returns>
    public static Vector3i operator ++(Vector3i vec)
    {
      return new Vector3i(vec.X + 1, vec.Y + 1, vec.Z + 1);
    }

    /// <summary>
    /// Decrements all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to decrement.</param>
    /// <returns>The decremented vector.</returns>
    public static Vector3i operator --(Vector3i vec)
    {
      return new Vector3i(vec.X - 1, vec.Y - 1, vec.Z - 1);
    }

    /// <summary>
    /// Adds the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the addition.</returns>
    public static Vector3i operator +(Vector3i vec1, Vector3i vec2)
    {
      return new Vector3i(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
    }

    /// <summary>
    /// Subtracts the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the subtraction.</returns>
    public static Vector3i operator -(Vector3i vec1, Vector3i vec2)
    {
      return new Vector3i(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <param name="mul">The multiplier.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector3i operator *(Vector3i vec, int mul)
    {
      return new Vector3i(vec.X * mul, vec.Y * mul, vec.Z * mul);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="mul">The multiplier.</param>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector3i operator *(int mul, Vector3i vec)
    {
      return new Vector3i(vec.X * mul, vec.Y * mul, vec.Z * mul);
    }

    /// <summary>
    /// Multiplies the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the multiplication as a new vector.</returns>
    public static Vector3i operator *(Vector3i vec1, Vector3i vec2)
    {
      return new Vector3i(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
    }

    /// <summary>
    /// Divides the components of the given vector by the given value.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="value">The dividend.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector3i operator /(Vector3i vec, int value)
    {
      return new Vector3i(vec.X / value, vec.Y / value, vec.Z / value);
    }

    /// <summary>
    /// Returns a new vector with the components set to (value / component).
    /// </summary>
    /// <param name="value">The dividend.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector3i operator /(int value, Vector3i vec)
    {
      return new Vector3i(value / vec.X, value / vec.Y, value / vec.Z);
    }

    /// <summary>
    /// Divides the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector3i operator /(Vector3i vec1, Vector3i vec2)
    {
      return new Vector3i(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z);
    }

    /// <summary>
    /// Calculates the modulo of the components of the two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A vector containing the modulo of the components.</returns>
    public static Vector3i operator %(Vector3i vec1, Vector3i vec2)
    {
      return new Vector3i(vec1.X % vec2.X, vec1.Y % vec2.Y, vec1.Z % vec2.Z);
    }

    /// <summary>
    /// Checks if the two vectors are equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are equal, else false.</returns>
    public static bool operator ==(Vector3i vec1, Vector3i vec2)
    {
      return (vec1.X == vec2.X) && (vec1.Y == vec2.Y) && (vec1.Z == vec2.Z);
    }

    /// <summary>
    /// Checks if the two vectors are not equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are not equal, else false.</returns>
    public static bool operator !=(Vector3i vec1, Vector3i vec2)
    {
      return (vec1.X != vec2.X) || (vec1.Y != vec2.Y) || (vec1.Z != vec2.Z);
    }

    #endregion

    /// <summary>
    /// Creates a string representation of the vector in the format "X;Y;Z".
    /// </summary>
    /// <returns>A string representation of the vector.</returns>
    public override string ToString()
    {
      return X + ";" + Y + ";" + Z;
    }

    /// <summary>
    /// Compares the vector to another vector by comparing the single components.
    /// </summary>
    /// <param name="other">The vector to compare to.</param>
    /// <returns>True if the vectors are equal, else False.</returns>
    public bool Equals(Vector3i other)
    {
      return X == other.X && Y == other.Y && Z == other.Z;
    }

    /// <summary>
    /// Checks if the vector has a length of zero (= all components are zero).
    /// </summary>
    /// <returns>True if the vector is zero length, else false.</returns>
    public bool IsZero()
    {
      return (X == 0.0f) && (Y == 0.0f) && (Z == 0.0f);
    }

    /// <summary>
    /// Parses the given string into a vector.
    /// The string is expected to be in the format "X;Y;Z"
    /// like it is created by the ToString method. 
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed vector.</returns>
    public static Vector3i Parse(string str)
    {
      Vector3i result = Vector3i.Zero;
      if (!TryParse(str, ref result))
        throw new FormatException("String '" + str + "' is not a valid vector string in the format '#;#;#'!");

      return result;
    }

    /// <summary>
    /// Tries to parse the given string into a vector.
    /// The string is expected to be in the format "X;Y;Z"
    /// like it is created by the ToString method.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="vec">The parsed vector is returned here.</param>
    /// <returns>True if the str was parsed successfully, False if the 
    /// given string is null or has a wrong format.</returns>
    public static bool TryParse(string str, ref Vector3i vec)
    {
      if (str != null)
      {
        string[] parts = str.Split(';');
        if (parts.Length == 3)
        {
          vec.X = int.Parse(parts[0].Trim());
          vec.Y = int.Parse(parts[1].Trim());
          vec.Y = int.Parse(parts[2].Trim());
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
      if (obj is Vector3i)
      {
        return Equals((Vector3i)obj);
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
