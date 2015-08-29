using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Vector4f defines a four dimensional Vector with all standard vector math routines.
  /// Most operators have been overloaded.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Vector4f
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
    /// The Z component of the vector.
    /// </summary>
    public float Z;

    /// <summary>
    /// The Z component of the vector.
    /// </summary>
    public float W;

    /// <summary>
    /// A vector with all components set to 0.
    /// </summary>
    public static Vector4f Zero = new Vector4f(0, 0, 0, 0);

    /// <summary>
    /// A vector with all components set to 1.
    /// </summary>
    public static Vector4f One = new Vector4f(1, 1, 1, 1);

    /// <summary>
    /// Creates a new vector and initialzes its components with the given values.
    /// </summary>
    /// <param name="x">The X component.</param>
    /// <param name="y">The Y component.</param>
    /// <param name="z">The Z component.</param>
    /// <param name="w">The W component.</param>
    public Vector4f(float x, float y, float z, float w)
    {
      X = x;
      Y = y;
      Z = z;
      W = w;
    }

    /// <summary>
    /// Creates a new vector. The X and Y components are set to the values of the given vector.
    /// The Z and W components are set to the given values. This is like calling new Vector4f(v.X, v.Y, z, w).
    /// </summary>
    /// <param name="v">The vector with the X and Y values.</param>
    /// <param name="z">The Z component.</param>
    /// <param name="w">The W component.</param>
    public Vector4f(Vector2f v, float z, float w)
    {
      X = v.X;
      Y = v.Y;
      Z = z;
      W = w;
    }

    /// <summary>
    /// Creates a new vector. The Y and Z components are set to the values of the given vector.
    /// The X and W components are set to the given values. This is like calling new Vector4f(x, v.X, v.Y, w).
    /// </summary>
    /// <param name="x">The X component.</param>
    /// <param name="v">The vector with the Y and Z values.</param>
    /// <param name="w">The w component.</param>
    public Vector4f(float x, Vector2f v, float w)
    {
      X = x;
      Y = v.X;
      Z = v.Y;
      W = w;
    }

    /// <summary>
    /// Creates a new vector. The X and Y components are set to the given values.
    /// The Z and W components are set to the values of the given vector.
    /// This is like calling new Vector4f(x, y, v.X, v.Y).
    /// </summary>
    /// <param name="x">The X value.</param>
    /// <param name="v">The vector with the Y and Z values.</param>
    public Vector4f(float x, float y, Vector2f v)
    {
      X = x;
      Y = y;
      Z = v.X;
      W = v.Y;
    }

    /// <summary>
    /// Creates a new vector. The X and Y components are set to the values of v1.
    /// The Z and W components are set to the values of v2.
    /// This is like calling new Vector4f(v1.X, v1.Y, v2.X, v2.Y).
    /// </summary>
    /// <param name="v1">The first vector.</param>
    /// <param name="v2">The second vector.</param>
    public Vector4f(Vector2f v1, Vector2f v2)
    {
      X = v1.X;
      Y = v1.Y;
      Z = v2.X;
      W = v2.Y;
    }

    /// <summary>
    /// Creates a new vector. The W component is set to the given value.
    /// The X, Y and Z components are set to the values of the given vector.
    /// This is like calling new Vector4f(v.X, v.Y, v.Z, w).
    /// </summary>
    /// <param name="v">The vector for the first components.</param>
    /// <param name="w">The W value.</param>
    public Vector4f(Vector3f v, float w)
    {
      X = v.X;
      Y = v.Y;
      Z = v.Z;
      W = w;
    }

    /// <summary>
    /// Creates a new vector. The X component is set to the given value.
    /// The Y, Z and W components are set to the values of the given vector.
    /// This is like calling new Vector4f(x, v.X, v.Y, v.Z).
    /// </summary>
    /// <param name="x">The X value.</param>
    /// <param name="v">The vector for the last components.</param>
    public Vector4f(float x, Vector3f v)
    {
      X = x;
      Y = v.X;
      Z = v.Y;
      W = v.Z;
    }

    #region Swizzles

    /// <summary>
    /// Gets or set the XY part of the vector.
    /// </summary>
    public Vector2f XY
    {
      get { return new Vector2f(X, Y); }
      set
      {
        X = value.X;
        Y = value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the YZ part of the vector.
    /// </summary>
    public Vector2f YZ
    {
      get { return new Vector2f(Y, Z); }
      set
      {
        Y = value.X;
        Z = value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the ZW part of the vector.
    /// </summary>
    public Vector2f ZW
    {
      get { return new Vector2f(Z, W); }
      set
      {
        Z = value.X;
        W = value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the XYZ part of the vector.
    /// </summary>
    public Vector3f XYZ
    {
      get { return new Vector3f(X, Y, Z); }
      set
      {
        X = value.X;
        Y = value.Y;
        Z = value.Z;
      }
    }

    /// <summary>
    /// Gets or sets the YZW part of the vector.
    /// </summary>
    public Vector3f YZW
    {
      get { return new Vector3f(Y, Z, W); }
      set
      {
        Y = value.X;
        Z = value.Y;
        W = value.Z;
      }
    }

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
    /// Synonym for the Z component.
    /// </summary>
    public float B
    {
      get { return Z; }
      set { Z = value; }
    }

    /// <summary>
    /// Synonym for the W component.
    /// </summary>
    public float A
    {
      get { return W; }
      set { W = value; }
    }

    /// <summary>
    /// Gets or sets the RG part of the vector.
    /// </summary>
    public Vector2f RG
    {
      get { return XY; }
      set { XY = value; }
    }

    /// <summary>
    /// Gets or sets the GB part of the vector.
    /// </summary>
    public Vector2f GB
    {
      get { return YZ; }
      set { YZ = value; }
    }

    /// <summary>
    /// Gets or sets the BA part of the vector.
    /// </summary>
    public Vector2f BA
    {
      get { return ZW; }
      set { ZW = value; }
    }

    /// <summary>
    /// Gets or sets the RGB part of the vector.
    /// </summary>
    public Vector3f RGB
    {
      get { return XYZ; }
      set { XYZ = value; }
    }

    /// <summary>
    /// Gets or sets the GBA part of the vector.
    /// </summary>
    public Vector3f GBA
    {
      get { return YZW; }
      set { YZW = value; }
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

    /// <summary>
    /// Synonym for the Z component.
    /// </summary>
    public float P
    {
      get { return Z; }
      set { Z = value; }
    }

    /// <summary>
    /// Synonym for the W component.
    /// </summary>
    public float Q
    {
      get { return W; }
      set { W = value; }
    }

    /// <summary>
    /// Gets or sets the ST part of the vector.
    /// </summary>
    public Vector2f ST
    {
      get { return XY; }
      set { XY = value; }
    }

    /// <summary>
    /// Gets or sets the TP part of the vector.
    /// </summary>
    public Vector2f TP
    {
      get { return YZ; }
      set { YZ = value; }
    }

    /// <summary>
    /// Gets or sets the PQ part of the vector.
    /// </summary>
    public Vector2f PQ
    {
      get { return ZW; }
      set { ZW = value; }
    }

    /// <summary>
    /// Gets or sets the STP part of the vector.
    /// </summary>
    public Vector3f STP
    {
      get { return XYZ; }
      set { XYZ = value; }
    }

    /// <summary>
    /// Gets or sets the TPQ part of the vector.
    /// </summary>
    public Vector3f TPQ
    {
      get { return YZW; }
      set { YZW = value; }
    }

    #endregion

    /// <summary>
    /// Defines the number of components the vector has.
    /// </summary>
    public const int ComponentCount = 4;

    /// <summary>
    /// Indexer to be able to access the components by index.
    /// 0 = X, 1 = Y, 2 = Z, 3 = W.
    /// </summary>
    /// <param name="index">The index. Either 0, 1, 2 or 3.</param>
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
          case 2:
            return Z;
          case 3:
            return W;

          default:
            throw new ArgumentException(nameof(Vector4f) + " can only have indexes 0, 1, 2 and 3!");
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
          case 3:
            W = value;
            break;

          default:
            throw new ArgumentException(nameof(Vector4f) + " can only have indexes 0, 1, 2 and 3!");
        }
      }
    }

    /// <summary>
    /// Gets the magnitude (length) of the vector by using the pythogarean theorem.
    /// </summary>
    public float Magnitude
    {
      get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
    }

    /// <summary>
    /// Gets the squared length of the vector. This is not the real length but can be used for comparison
    /// as it is faster to calculate.
    /// </summary>
    public float SquaredMagnitude
    {
      get { return X * X + Y * Y + Z * Z + W * W; }
    }

    #region Operators

    /// <summary>
    /// Inverts the components of the given vector.
    /// </summary>
    /// <param name="vec">The vector to be inverted.</param>
    /// <returns>The inverted vector.</returns>
    public static Vector4f operator -(Vector4f vec)
    {
      return new Vector4f(-vec.X, -vec.Y, -vec.Z, -vec.W);
    }

    /// <summary>
    /// Increments all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to increment.</param>
    /// <returns>The incremented vector.</returns>
    public static Vector4f operator ++(Vector4f vec)
    {
      return new Vector4f(vec.X + 1, vec.Y + 1, vec.Z + 1, vec.W + 1);
    }

    /// <summary>
    /// Decrements all components of the vectors by 1.
    /// </summary>
    /// <param name="vec">The vector to decrement.</param>
    /// <returns>The decremented vector.</returns>
    public static Vector4f operator --(Vector4f vec)
    {
      return new Vector4f(vec.X - 1, vec.Y - 1, vec.Z - 1, vec.W - 1);
    }

    /// <summary>
    /// Adds the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the addition.</returns>
    public static Vector4f operator +(Vector4f vec1, Vector4f vec2)
    {
      return new Vector4f(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z, vec1.W + vec2.W);
    }

    /// <summary>
    /// Subtracts the components of the two given vectors and returns the result.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A new vector with the result of the subtraction.</returns>
    public static Vector4f operator -(Vector4f vec1, Vector4f vec2)
    {
      return new Vector4f(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z, vec1.W - vec2.W);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <param name="mul">The multiplier.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector4f operator *(Vector4f vec, float mul)
    {
      return new Vector4f(vec.X * mul, vec.Y * mul, vec.Z * mul, vec.W * mul);
    }

    /// <summary>
    /// Scales the given vectors components by the given multiplier.
    /// </summary>
    /// <param name="mul">The multiplier.</param>
    /// <param name="vec">The vector to be multiplied.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector4f operator *(float mul, Vector4f vec)
    {
      return new Vector4f(vec.X * mul, vec.Y * mul, vec.Z * mul, vec.W * mul);
    }

    /// <summary>
    /// Multiplies the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the multiplication as a new vector.</returns>
    public static Vector4f operator *(Vector4f vec1, Vector4f vec2)
    {
      return new Vector4f(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z, vec1.W * vec2.W);
    }

    /// <summary>
    /// Divides the components of the given vector by the given value.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="value">The dividend.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector4f operator /(Vector4f vec, float value)
    {
      return new Vector4f(vec.X / value, vec.Y / value, vec.Z / value, vec.W / value);
    }

    /// <summary>
    /// Returns a new vector with the components set to (value / component).
    /// </summary>
    /// <param name="value">The dividend.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector4f operator /(float value, Vector4f vec)
    {
      return new Vector4f(value / vec.X, value / vec.Y, value / vec.Z, value / vec.W);
    }

    /// <summary>
    /// Divides the two given vectors component-wise.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The result of the division as a new vector.</returns>
    public static Vector4f operator /(Vector4f vec1, Vector4f vec2)
    {
      return new Vector4f(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z, vec1.W / vec2.W);
    }

    /// <summary>
    /// Calculates the modulo of the components of the two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>A vector containing the modulo of the components.</returns>
    public static Vector4f operator %(Vector4f vec1, Vector4f vec2)
    {
      return new Vector4f(vec1.X % vec2.X, vec1.Y % vec2.Y, vec1.Z % vec2.Z, vec1.W % vec2.W);
    }

    /// <summary>
    /// Checks if the two vectors are equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are equal, else false.</returns>
    public static bool operator ==(Vector4f vec1, Vector4f vec2)
    {
      return (vec1.X == vec2.X) && (vec1.Y == vec2.Y) && (vec1.Z == vec2.Z) && (vec1.W == vec2.W);
    }

    /// <summary>
    /// Checks if the two vectors are not equal.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>True if the vectors are not equal, else false.</returns>
    public static bool operator !=(Vector4f vec1, Vector4f vec2)
    {
      return (vec1.X != vec2.X) || (vec1.Y != vec2.Y) || (vec1.Z != vec2.Z) || (vec1.W != vec2.W);
    }

    #endregion

    /// <summary>
    /// Creates a string representation of the vector in the format "X;Y;Z;W".
    /// </summary>
    /// <returns>A string representation of the vector.</returns>
    public override string ToString()
    {
      return X + ";" + Y + ";" + Z + ";" + W;
    }

    /// <summary>
    /// Compares the vector to another vector by comparing the single components.
    /// </summary>
    /// <param name="other">The vector to compare to.</param>
    /// <returns>True if the vectors are equal, else False.</returns>
    public bool Equals(Vector4f other)
    {
      return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
    }

    /// <summary>
    /// Checks if the vector has a length of zero (= all components are zero).
    /// </summary>
    /// <returns>True if the vector is zero length, else false.</returns>
    public bool IsZero()
    {
      return (X == 0.0f) && (Y == 0.0f) && (Z == 0.0f) && (W == 0.0f);
    }

    /// <summary>
    /// Parses the given string into a vector.
    /// The string is expected to be in the format "X;Y;Z;W"
    /// like it is created by the ToString method. 
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed vector.</returns>
    public static Vector4f Parse(string str)
    {
      Vector4f result = Vector4f.Zero;
      if (!TryParse(str, ref result))
        throw new FormatException("String '" + str + "' is not a valid vector string in the format '#;#;#;#'!");

      return result;
    }

    /// <summary>
    /// Tries to parse the given string into a vector.
    /// The string is expected to be in the format "X;Y;Z;W"
    /// like it is created by the ToString method.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="vec">The parsed vector is returned here.</param>
    /// <returns>True if the str was parsed successfully, False if the 
    /// given string is null or has a wrong format.</returns>
    public static bool TryParse(string str, ref Vector4f vec)
    {
      if (str != null)
      {
        string[] parts = str.Split(';');
        if (parts.Length == 4)
        {
          vec.X = float.Parse(parts[0].Trim());
          vec.Y = float.Parse(parts[1].Trim());
          vec.Y = float.Parse(parts[2].Trim());
          vec.Y = float.Parse(parts[3].Trim());
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
      if (obj is Vector4f)
      {
        return Equals((Vector4f)obj);
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
