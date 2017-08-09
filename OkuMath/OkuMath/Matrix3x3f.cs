using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Defines a 3x3 matrix. The matrix is defined by an array of vectors where the vectors form the columns.
  /// That means that the indexes are defined as [column,row].
  /// Most operators are overloaded. The * operator is overloaded and follows the matrix multiplication rules.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Matrix3x3f
  {
    /// <summary>
    /// Gets an identity matrix.
    /// </summary>
    public static Matrix3x3f Identity = new Matrix3x3f(
      1, 0, 0,
      0, 1, 0,
      0, 0, 1);

    /// <summary>
    /// Gets the number of columns in this matrix.
    /// </summary>
    public const int ColumnCount = 3;

    /// <summary>
    /// Gets the number of rows in this matrix.
    /// </summary>
    public const int RowCount = 3;

    /// <summary>
    /// Internal field for the values.
    /// </summary>
    private Vector3f[] _values;

    /// <summary>
    /// Creates a new matrix settings the diagonals to the given value and all other to 0.
    /// </summary>
    /// <param name="s">The value for the diagonals.</param>
    public Matrix3x3f(float s)
    {
      _values = new Vector3f[] { new Vector3f(s, 0, 0), new Vector3f(0, s, 0), new Vector3f(0, 0, s) };
    }

    /// <summary>
    /// Creates a new matrix with the given values.
    /// </summary>
    /// <param name="v00">The value for [0,0].</param>
    /// <param name="v01">The value for [0,1].</param>
    /// <param name="v02">The value for [0,2]</param>
    /// <param name="v10">The value for [1,0].</param>
    /// <param name="v11">The value for [1,1].</param>
    /// <param name="v12">The value for [1,2].</param>
    /// <param name="v20">The value for [2,0].</param>
    /// <param name="v21">The value for [2,1].</param>
    /// <param name="v22">The value for [2,2].</param>
    public Matrix3x3f(float v00, float v01, float v02, float v10, float v11, float v12, float v20, float v21, float v22)
    {
      _values = new Vector3f[] {
        new Vector3f(v00, v01, v02),
        new Vector3f(v10, v11, v12),
        new Vector3f(v20, v21, v22)
      };
    }

    /// <summary>
    /// Creates a new matrix setting the columns to the given values.
    /// </summary>
    /// <param name="vec1">The value for the first column.</param>
    /// <param name="vec2">The value for the second column.</param>
    /// <param name="vec3">The value for the third column.</param>
    public Matrix3x3f(Vector3f vec1, Vector3f vec2, Vector3f vec3)
    {
      _values = new Vector3f[] { vec1, vec2, vec3 };
    }

    /// <summary>
    /// Gets the values of the columns.
    /// </summary>
    public Vector3f[] Values
    {
      get
      {
        // Need to lazily initialize the array as C# won't let me override the parameterless constructor.
        if (_values == null)
          LoadIdentity();
        return _values;
      }
    }

    /// <summary>
    /// Gets the column at the given index.
    /// </summary>
    /// <param name="index">The index of the column.</param>
    /// <returns>The value at the given column.</returns>
    public Vector3f this[int index]
    {
      get { return Values[index]; }
      set { Values[index] = value; }
    }

    /// <summary>
    /// Sets the values of the matrix so it is an identity matrix.
    /// </summary>
    public void LoadIdentity()
    {
      _values = new Vector3f[] {
        new Vector3f(1, 0, 0),
        new Vector3f(0, 1, 0),
        new Vector3f(0, 0, 1)
      };
    }

    #region Operators

    /// <summary>
    /// Inverts all values of the matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>A new matrix with all values inverted.</returns>
    public static Matrix3x3f operator -(Matrix3x3f mat)
    {
      return new Matrix3x3f(-mat[0], -mat[1], -mat[2]);
    }

    /// <summary>
    /// Adds the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>A new matrix with results of the addition.</returns>
    public static Matrix3x3f operator +(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return new Matrix3x3f(mat1[0] + mat2[0], mat1[1] + mat2[1], mat1[2] + mat2[2]);
    }

    /// <summary>
    /// Substracts the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the substraction.</returns>
    public static Matrix3x3f operator -(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return new Matrix3x3f(mat1[0] - mat2[0], mat1[1] - mat2[1], mat1[2] - mat2[2]);
    }

    /// <summary>
    /// Multiples all values of the given matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The multiplier.</param>
    /// <returns>A new matrix with the components multiplied by value.</returns>
    public static Matrix3x3f operator *(Matrix3x3f mat, float value)
    {
      return new Matrix3x3f(mat[0] * value, mat[1] * value, mat[2] * value);
    }

    /// <summary>
    /// Multiplies the given matrix by the given vector.
    /// The vector is treated as a column vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector3f operator *(Matrix3x3f mat, Vector3f vec)
    {
      // This uses standard matrix multiplication rules.
      //     mat        vec    result
      // | #, #, # |   | # |   | # |
      // | #, #, # | * | # | = | # |
      // | #, #, # |   | # |   | # |
      return new Vector3f(
          mat[0].X * vec.X + mat[1].X * vec.Y + mat[2].X * vec.Z,
          mat[0].Y * vec.X + mat[1].Y * vec.Y + mat[2].Y * vec.Z,
          mat[0].Z * vec.X + mat[1].Z * vec.Y + mat[2].Z * vec.Z
        );
    }

    /// <summary>
    /// Multiplies the given matrix by the given vector.
    /// The vector is treated as a column vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector2f operator *(Matrix3x3f mat, Vector2f vec)
    {
      // This uses standard matrix multiplication rules.
      //     mat        vec    result
      // | #, #, # |   | # |   | # |
      // | #, #, # | * | # | = | # |
      // | 0, 0, 1 |   | 1 |   | X |
      return new Vector2f(
        VectorMath.DotProduct(mat[0], new Vector3f(vec, 1)),
        VectorMath.DotProduct(mat[1], new Vector3f(vec, 1))
//          mat[0].X * vec.X + mat[1].X * vec.Y + mat[2].X,
//          mat[0].Y * vec.X + mat[1].Y * vec.Y + mat[2].Y
        );
    }

    /// <summary>
    /// Multiplies the given vector by the given matrix.
    /// The vector is treated as a row vector.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector3f operator *(Vector3f vec, Matrix3x3f mat)
    {
      // This uses standard matrix multiplication rules.
      //     vec           mat         result
      //               | #, #, # |
      // | #, #, # | * | #, #, # | = | #, #, # |
      //               | #, #, # |
      return new Vector3f(
          vec.X * mat[0].X + vec.Y * mat[0].Y + vec.Z * mat[0].Z,
          vec.X * mat[1].X + vec.Y * mat[1].Y + vec.Z * mat[1].Z,
          vec.X * mat[2].X + vec.Y * mat[2].Y + vec.Z * mat[2].Z
        );
    }

    /// <summary>
    /// Multiplies the two given matrices.
    /// Note that the matrix multiplication is not commutative, so the order is important.
    /// A * B != B * A.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The matrix result of the multiplication.</returns>
    public static Matrix3x3f operator *(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      // | #, #, # |   | #, #, # |   | #, #, # |
      // | #, #, # | * | #, #, # | = | #, #, # |
      // | #, #, # |   | #, #, # |   | #, #, # |
      return new Matrix3x3f(
          mat1[0].X * mat2[0].X + mat1[1].X * mat2[0].Y + mat1[2].X * mat2[0].Z,
          mat1[0].X * mat2[1].X + mat1[1].X * mat2[1].Y + mat1[2].X * mat2[1].Z,
          mat1[0].X * mat2[2].X + mat1[1].X * mat2[2].Y + mat1[2].X * mat2[2].Z,

          mat1[0].Y * mat2[0].X + mat1[1].Y * mat2[0].Y + mat1[2].Y * mat2[0].Z,
          mat1[0].Y * mat2[1].X + mat1[1].Y * mat2[1].Y + mat1[2].Y * mat2[1].Z,
          mat1[0].Y * mat2[2].X + mat1[1].Y * mat2[2].Y + mat1[2].Y * mat2[2].Z,

          mat1[0].Z * mat2[0].X + mat1[1].Z * mat2[0].Y + mat1[2].Z * mat2[0].Z,
          mat1[0].Z * mat2[1].X + mat1[1].Z * mat2[1].Y + mat1[2].Z * mat2[1].Z,
          mat1[0].Z * mat2[2].X + mat1[1].Z * mat2[2].Y + mat1[2].Z * mat2[2].Z
        );
    }

    /// <summary>
    /// Divides all components of the matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The value.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix3x3f operator /(Matrix3x3f mat, float value)
    {
      return new Matrix3x3f(
          mat[0] / value,
          mat[1] / value,
          mat[2] / value
        );
    }

    /// <summary>
    /// Calculates a matrix where each component is the result of dividing the given
    /// value by each component of the given matrix.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix3x3f operator /(float value, Matrix3x3f mat)
    {
      return new Matrix3x3f(
          value / mat[0],
          value / mat[1],
          value / mat[2]
        );
    }

    /// <summary>
    /// Divides the matrix by the vector by computing the inverse of the matrix
    /// and multiplying this with the vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division.</returns>
    public static Vector3f operator /(Matrix3x3f mat, Vector3f vec)
    {
      return MatrixMath.Invert(mat) * vec;
    }

    /// <summary>
    /// Divides the vector by the matrix by computing the inverse of the matrix
    /// and multiplying the vector with it.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the division.</returns>
    public static Vector3f operator /(Vector3f vec, Matrix3x3f mat)
    {
      return vec * MatrixMath.Invert(mat);
    }

    /// <summary>
    /// Divides the first matrix by the second by multiplying the first matrix
    /// with the inverse of the second.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix3x3f operator /(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return mat1 * MatrixMath.Invert(mat2);
    }

    /// <summary>
    /// Checks if the matrices are equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if all components are equal, else false.</returns>
    public static bool operator ==(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return mat1[0] == mat2[0] && mat1[1] == mat2[1] && mat1[2] == mat2[2];
    }

    /// <summary>
    /// Checks if the matrices are not equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if any of the components are not equal, else false.</returns>
    public static bool operator !=(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return mat1[0] != mat2[0] || mat1[1] != mat2[1] || mat1[2] != mat2[2];
    }

    /// <summary>
    /// Extractes the upper left 3x3 parts of the given 4x4 matrix.
    /// </summary>
    /// <param name="mat"></param>
    public static explicit operator Matrix3x3f(Matrix4x4f mat)
    {
      return new Matrix3x3f(
          mat[0].XYZ,
          mat[1].XYZ,
          mat[2].XYZ
        );
    }

    #endregion

    #region Transform Constructors

    /// <summary>
    /// Creates a 2D translation matrix.
    /// </summary>
    /// <param name="x">The translation on the X axis.</param>
    /// <param name="y">The translation on the Y axis.</param>
    /// <returns>A matrix that translates by the given values.</returns>
    public static Matrix3x3f Translate(float x, float y)
    {
      return new Matrix3x3f(
          new Vector3f(1, 0, x),
          new Vector3f(0, 1, y),
          new Vector3f(0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 2D rotation matrix for the given angle.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    /// <returns>A matrix that rotates by the given angle.</returns>
    public static Matrix3x3f Rotation(float angle)
    {
      float rad = BasicMath.DegreesToRadians(angle);
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      return new Matrix3x3f(
          new Vector3f(cos, sin, 0),
          new Vector3f(-sin, cos, 0),
          new Vector3f(0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 2D scaling matrix.
    /// </summary>
    /// <param name="sx">The scale factor on the X axis.</param>
    /// <param name="sy">The scale factor on the Y axis.</param>
    /// <returns>A matrix that scales by the given values</returns>
    public static Matrix3x3f Scale(float sx, float sy)
    {
      return new Matrix3x3f(
          new Vector3f(sx, 0, 0),
          new Vector3f(0, sy, 0),
          new Vector3f(0, 0, 1)
        );
    }

    #endregion

    /// <summary>
    /// Creates a string representation of the matrix.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return 
        Values[0].ToString() + Environment.NewLine +
        Values[1].ToString() + Environment.NewLine +
        Values[2].ToString();
    }

    /// <summary>
    /// Checks if the matrix is equal to the given one.
    /// </summary>
    /// <param name="obj">The other matrix.</param>
    /// <returns>True if the matrices are equal, else false.</returns>
    public override bool Equals(object obj)
    {
      if (obj is Matrix3x3f)
        return this == (Matrix3x3f)obj;
      return base.Equals(obj);
    }

    // Shuts up code analyzer
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}
