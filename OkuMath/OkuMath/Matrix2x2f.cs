using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Defines a 2x2 matrix. The matrix is defined by an array of vectors where the vectors form the columns.
  /// That means that the indexes are defined as [column,row].
  /// Most operators are overloaded. The * operator is overloaded and follows the matrix multiplication rules.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Matrix2x2f
  {
    /// <summary>
    /// Gets an identity matrix.
    /// </summary>
    public static Matrix2x2f Identity = new Matrix2x2f(1, 0, 0, 1);

    /// <summary>
    /// Gets the number of columns in this matrix.
    /// </summary>
    public const int ColumnCount = 2;

    /// <summary>
    /// Gets the number of rows in this matrix.
    /// </summary>
    public const int RowCount = 2;

    /// <summary>
    /// Internal field for the values.
    /// </summary>
    private Vector2f[] _values;    

    /// <summary>
    /// Creates a new matrix settings the diagonals to the given value and all other to 0.
    /// </summary>
    /// <param name="s">The value for the diagonals.</param>
    public Matrix2x2f(float s)
    {
      _values = new Vector2f[] { new Vector2f(s, 0), new Vector2f(0, s) };
    }

    /// <summary>
    /// Creates a new matrix with the given values.
    /// </summary>
    /// <param name="v00">The value for [0,0].</param>
    /// <param name="v01">The value for [0,1].</param>
    /// <param name="v10">The value for [1,0].</param>
    /// <param name="v11">The value for [1,1].</param>
    public Matrix2x2f(float v00, float v01, float v10, float v11)
    {
      _values = new Vector2f[] { new Vector2f(v00, v01), new Vector2f(v10, v11) };
    }

    /// <summary>
    /// Creates a new matrix setting the columns to the given values.
    /// </summary>
    /// <param name="vec1">The value for the first column.</param>
    /// <param name="vec2">The value for the second column.</param>
    public Matrix2x2f(Vector2f vec1, Vector2f vec2)
    {
      _values = new Vector2f[] { vec1, vec2 };
    }

    /// <summary>
    /// Gets the values of the columns.
    /// </summary>
    public Vector2f[] Values
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
    public Vector2f this[int index]
    {
      get { return Values[index]; }
      set { Values[index] = value; }
    }

    /// <summary>
    /// Sets the values of the matrix so it is an identity matrix.
    /// </summary>
    public void LoadIdentity()
    {
      _values = new Vector2f[] { new Vector2f(1, 0), new Vector2f(0, 1) };
    }

    #region Operators

    /// <summary>
    /// Inverts all values of the matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>A new matrix with all values inverted.</returns>
    public static Matrix2x2f operator -(Matrix2x2f mat)
    {
      return new Matrix2x2f(-mat[0], -mat[1]);
    }

    /// <summary>
    /// Adds the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>A new matrix with results of the addition.</returns>
    public static Matrix2x2f operator +(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return new Matrix2x2f(mat1[0] + mat2[0], mat1[1] + mat2[1]);
    }

    /// <summary>
    /// Substracts the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the substraction.</returns>
    public static Matrix2x2f operator -(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return new Matrix2x2f(mat1[0] - mat2[0], mat1[1] - mat2[1]);
    }

    /// <summary>
    /// Multiples all values of the given matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The multiplier.</param>
    /// <returns>A new matrix with the components multiplied by value.</returns>
    public static Matrix2x2f operator *(Matrix2x2f mat, float value)
    {
      return new Matrix2x2f(mat[0] * value, mat[1] * value);
    }

    /// <summary>
    /// Multiplies the given matrix by the given vector.
    /// The vector is treated as a column vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector2f operator *(Matrix2x2f mat, Vector2f vec)
    {
      // This uses standard matrix multiplication rules.
      //   mat       vec    result
      // | #, # |   | # |   | # |
      // | #, # | * | # | = | # |
      return new Vector2f(
          mat[0].X * vec.X + mat[1].X * vec.Y,
          mat[0].Y * vec.X + mat[1].Y * vec.Y
        );
    }

    /// <summary>
    /// Multiplies the given vector by the given matrix.
    /// The vector is treated as a row vector.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector2f operator *(Vector2f vec, Matrix2x2f mat)
    {
      // This uses standard matrix multiplication rules.
      //   vec        mat       result
      //            | #, # |
      // | #, # | * | #, # | = | #, # |
      return new Vector2f(
          vec.X * mat[0].X + vec.Y * mat[0].Y,
          vec.X * mat[1].X + vec.Y * mat[1].Y
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
    public static Matrix2x2f operator *(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return new Matrix2x2f(
          mat1[0].X * mat2[0].X + mat1[1].X * mat2[0].Y,
          mat1[0].X * mat2[1].X + mat1[1].X * mat2[1].Y,
          mat1[0].Y * mat2[0].X + mat1[1].Y * mat2[0].Y,
          mat1[0].Y * mat2[1].X + mat1[1].Y * mat2[1].Y
        );
    }

    /// <summary>
    /// Divides all components of the matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The value.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix2x2f operator /(Matrix2x2f mat, float value)
    {
      return new Matrix2x2f(
          mat[0] / value,
          mat[1] / value
        );
    }

    /// <summary>
    /// Calculates a matrix where each component is the result of dividing the given
    /// value by each component of the given matrix.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix2x2f operator /(float value, Matrix2x2f mat)
    {
      return new Matrix2x2f(
          value / mat[0],
          value / mat[1]
        );
    }

    /// <summary>
    /// Divides the matrix by the vector by computing the inverse of the matrix
    /// and multiplying this with the vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division.</returns>
    public static Vector2f operator /(Matrix2x2f mat, Vector2f vec)
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
    public static Vector2f operator /(Vector2f vec, Matrix2x2f mat)
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
    public static Matrix2x2f operator /(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return mat1 * MatrixMath.Invert(mat2);
    }

    /// <summary>
    /// Checks if the matrices are equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if all components are equal, else false.</returns>
    public static bool operator ==(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return mat1[0] == mat2[0] && mat1[1] == mat2[1];
    }

    /// <summary>
    /// Checks if the matrices are not equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if any of the components are not equal, else false.</returns>
    public static bool operator !=(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return mat1[0] != mat2[0] || mat1[1] != mat2[1];
    }

    #endregion

    /// <summary>
    /// Creates a string representation of the matrix.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Values[0].ToString() + Environment.NewLine + Values[1].ToString();
    }

    /// <summary>
    /// Checks if the matrix is equal to the given one.
    /// </summary>
    /// <param name="obj">The other matrix.</param>
    /// <returns>True if the matrices are equal, else false.</returns>
    public override bool Equals(object obj)
    {
      if (obj is Matrix2x2f)
        return this == (Matrix2x2f)obj;
      return base.Equals(obj);
    }

    // Shuts up code analyzer
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}
