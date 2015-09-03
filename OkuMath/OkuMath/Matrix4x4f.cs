using System;
using System.Runtime.InteropServices;

namespace OkuMath
{
  /// <summary>
  /// Defines a 4x4 matrix. The matrix is defined by an array of vectors where the vectors form the columns.
  /// That means that the indexes are defined as [column,row].
  /// Most operators are overloaded. The * operator is overloaded and follows the matrix multiplication rules.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct Matrix4x4f
  {
    /// <summary>
    /// Gets an identity matrix.
    /// </summary>
    public static Matrix4x4f Identity = new Matrix4x4f(
      1, 0, 0, 0,
      0, 1, 0, 0,
      0, 0, 1, 0,
      0, 0, 0, 1);

    /// <summary>
    /// Gets the number of columns in this matrix.
    /// </summary>
    public const int ColumnCount = 4;

    /// <summary>
    /// Gets the number of rows in this matrix.
    /// </summary>
    public const int RowCount = 4;

    /// <summary>
    /// Internal field for the values.
    /// </summary>
    private Vector4f[] _values;

    /// <summary>
    /// Creates a new matrix settings the diagonals to the given value and all other to 0.
    /// </summary>
    /// <param name="s">The value for the diagonals.</param>
    public Matrix4x4f(float s)
    {
      _values = new Vector4f[] { new Vector4f(s, 0, 0, 0), new Vector4f(0, s, 0, 0), new Vector4f(0, 0, s, 0), new Vector4f(0, 0, 0, s) };
    }

    /// <summary>
    /// Creates a new matrix with the given values.
    /// </summary>
    /// <param name="v00">The value for [0,0].</param>
    /// <param name="v01">The value for [0,1].</param>
    /// <param name="v02">The value for [0,2].</param>
    /// <param name="v03">The value for [0,3].</param>
    /// <param name="v10">The value for [1,0].</param>
    /// <param name="v11">The value for [1,1].</param>
    /// <param name="v12">The value for [1,2].</param>
    /// <param name="v13">The value for [1,3].</param>
    /// <param name="v20">The value for [2,0].</param>
    /// <param name="v21">The value for [2,1].</param>
    /// <param name="v22">The value for [2,2].</param>
    /// <param name="v23">The value for [2,3].</param>
    /// <param name="v30">The value for [3,0].</param>
    /// <param name="v31">The value for [3,1].</param>
    /// <param name="v32">The value for [3,2].</param>
    /// <param name="v33">The value for [3,3].</param>
    public Matrix4x4f(
      float v00, float v01, float v02, float v03,
      float v10, float v11, float v12, float v13,
      float v20, float v21, float v22, float v23,
      float v30, float v31, float v32, float v33)
    {
      _values = new Vector4f[] {
        new Vector4f(v00, v01, v02, v03),
        new Vector4f(v10, v11, v12, v13),
        new Vector4f(v20, v21, v22, v23),
        new Vector4f(v30, v31, v32, v33)
      };
    }

    /// <summary>
    /// Creates a new matrix setting the columns to the given values.
    /// </summary>
    /// <param name="vec1">The value for the first column.</param>
    /// <param name="vec2">The value for the second column.</param>
    /// <param name="vec3">The value for the third column.</param>
    /// <param name="vec4">The value for the fourth column.</param>
    public Matrix4x4f(Vector4f vec1, Vector4f vec2, Vector4f vec3, Vector4f vec4)
    {
      _values = new Vector4f[] { vec1, vec2, vec3, vec4 };
    }

    /// <summary>
    /// Gets the values of the columns.
    /// </summary>
    public Vector4f[] Values
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
    public Vector4f this[int index]
    {
      get { return Values[index]; }
      set { Values[index] = value; }
    }

    /// <summary>
    /// Sets the values of the matrix so it is an identity matrix.
    /// </summary>
    public void LoadIdentity()
    {
      _values = new Vector4f[] {
        new Vector4f(1, 0, 0, 0),
        new Vector4f(0, 1, 0, 0),
        new Vector4f(0, 0, 1, 0),
        new Vector4f(0, 0, 0, 1)
      };
    }

    #region Operators

    /// <summary>
    /// Inverts all values of the matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>A new matrix with all values inverted.</returns>
    public static Matrix4x4f operator -(Matrix4x4f mat)
    {
      return new Matrix4x4f(-mat[0], -mat[1], -mat[2], -mat[3]);
    }

    /// <summary>
    /// Adds the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>A new matrix with results of the addition.</returns>
    public static Matrix4x4f operator +(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return new Matrix4x4f(mat1[0] + mat2[0], mat1[1] + mat2[1], mat1[2] + mat2[2], mat1[3] + mat2[3]);
    }

    /// <summary>
    /// Substracts the two matrices component-wise.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the substraction.</returns>
    public static Matrix4x4f operator -(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return new Matrix4x4f(mat1[0] - mat2[0], mat1[1] - mat2[1], mat1[2] - mat2[2], mat1[3] - mat2[3]);
    }

    /// <summary>
    /// Multiples all values of the given matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The multiplier.</param>
    /// <returns>A new matrix with the components multiplied by value.</returns>
    public static Matrix4x4f operator *(Matrix4x4f mat, float value)
    {
      return new Matrix4x4f(mat[0] * value, mat[1] * value, mat[2] * value, mat[3] * value);
    }

    /// <summary>
    /// Multiplies the given matrix by the given vector.
    /// The vector is treated as a column vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector4f operator *(Matrix4x4f mat, Vector4f vec)
    {
      // This uses standard matrix multiplication rules.
      //      mat          vec    result
      // | #, #, #, # |   | # |   | # |
      // | #, #, #, # | * | # | = | # |
      // | #, #, #, # |   | # |   | # |
      // | #, #, #, # |   | # |   | # |
      return new Vector4f(
          mat[0].X * vec.X + mat[1].X * vec.Y + mat[2].X * vec.Z + mat[3].X * vec.W,
          mat[0].Y * vec.X + mat[1].Y * vec.Y + mat[2].Y * vec.Z + mat[3].Y * vec.W,
          mat[0].Z * vec.X + mat[1].Z * vec.Y + mat[2].Z * vec.Z + mat[3].Z * vec.W,
          mat[0].W * vec.X + mat[1].W * vec.Y + mat[2].W * vec.Z + mat[3].W * vec.W
        );
    }

    /// <summary>
    /// Multiplies the given vector by the given matrix.
    /// The vector is treated as a row vector.
    /// </summary>
    /// <param name="vec">The vector.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Vector4f operator *(Vector4f vec, Matrix4x4f mat)
    {
      // This uses standard matrix multiplication rules.
      //      vec              mat             result
      //                  | #, #, #, # |
      // | #, #, #, # | * | #, #, #, # | = | #, #, #, # |
      //                  | #, #, #, # |
      //                  | #, #, #, # |
      return new Vector4f(
          vec.X * mat[0].X + vec.Y * mat[0].Y + vec.Z * mat[0].Z + vec.W * mat[0].W,
          vec.X * mat[1].X + vec.Y * mat[1].Y + vec.Z * mat[1].Z + vec.W * mat[1].W,
          vec.X * mat[2].X + vec.Y * mat[2].Y + vec.Z * mat[2].Z + vec.W * mat[2].W,
          vec.X * mat[3].X + vec.Y * mat[3].Y + vec.Z * mat[3].Z + vec.W * mat[3].W
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
    public static Matrix4x4f operator *(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      // This uses standard matrix multiplication rules.
      // | #, #, #, # |   | #, #, #, # |   | #, #, #, # |
      // | #, #, #, # | * | #, #, #, # | = | #, #, #, # |
      // | #, #, #, # |   | #, #, #, # |   | #, #, #, # |
      // | #, #, #, # |   | #, #, #, # |   | #, #, #, # |
      return new Matrix4x4f(
          mat1[0].X * mat2[0].X + mat1[1].X * mat2[0].Y + mat1[2].X * mat2[0].Z + mat1[3].X * mat2[0].W,
          mat1[0].X * mat2[1].X + mat1[1].X * mat2[1].Y + mat1[2].X * mat2[1].Z + mat1[3].X * mat2[1].W,
          mat1[0].X * mat2[2].X + mat1[1].X * mat2[2].Y + mat1[2].X * mat2[2].Z + mat1[3].X * mat2[2].W,
          mat1[0].X * mat2[3].X + mat1[1].X * mat2[3].Y + mat1[2].X * mat2[3].Z + mat1[3].X * mat2[3].W,

          mat1[0].Y * mat2[0].X + mat1[1].Y * mat2[0].Y + mat1[2].Y * mat2[0].Z + mat1[3].Y * mat2[0].W,
          mat1[0].Y * mat2[1].X + mat1[1].Y * mat2[1].Y + mat1[2].Y * mat2[1].Z + mat1[3].Y * mat2[1].W,
          mat1[0].Y * mat2[2].X + mat1[1].Y * mat2[2].Y + mat1[2].Y * mat2[2].Z + mat1[3].Y * mat2[2].W,
          mat1[0].Y * mat2[3].X + mat1[1].Y * mat2[3].Y + mat1[2].Y * mat2[3].Z + mat1[3].Y * mat2[3].W,

          mat1[0].Z * mat2[0].X + mat1[1].Z * mat2[0].Y + mat1[2].Z * mat2[0].Z + mat1[3].Z * mat2[0].W,
          mat1[0].Z * mat2[1].X + mat1[1].Z * mat2[1].Y + mat1[2].Z * mat2[1].Z + mat1[3].Z * mat2[1].W,
          mat1[0].Z * mat2[2].X + mat1[1].Z * mat2[2].Y + mat1[2].Z * mat2[2].Z + mat1[3].Z * mat2[2].W,
          mat1[0].Z * mat2[3].X + mat1[1].Z * mat2[3].Y + mat1[2].Z * mat2[3].Z + mat1[3].Z * mat2[3].W,

          mat1[0].W * mat2[0].X + mat1[1].W * mat2[0].Y + mat1[2].W * mat2[0].Z + mat1[3].W * mat2[0].W,
          mat1[0].W * mat2[1].X + mat1[1].W * mat2[1].Y + mat1[2].W * mat2[1].Z + mat1[3].W * mat2[1].W,
          mat1[0].W * mat2[2].X + mat1[1].W * mat2[2].Y + mat1[2].W * mat2[2].Z + mat1[3].W * mat2[2].W,
          mat1[0].W * mat2[3].X + mat1[1].W * mat2[3].Y + mat1[2].W * mat2[3].Z + mat1[3].W * mat2[3].W
        );
    }

    /// <summary>
    /// Divides all components of the matrix by the given value.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="value">The value.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix4x4f operator /(Matrix4x4f mat, float value)
    {
      return new Matrix4x4f(
          mat[0] / value,
          mat[1] / value,
          mat[2] / value,
          mat[3] / value
        );
    }

    /// <summary>
    /// Calculates a matrix where each component is the result of dividing the given
    /// value by each component of the given matrix.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="mat">The matrix.</param>
    /// <returns>The result of the division.</returns>
    public static Matrix4x4f operator /(float value, Matrix4x4f mat)
    {
      return new Matrix4x4f(
          value / mat[0],
          value / mat[1],
          value / mat[2],
          value / mat[3]
        );
    }

    /// <summary>
    /// Divides the matrix by the vector by computing the inverse of the matrix
    /// and multiplying this with the vector.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <param name="vec">The vector.</param>
    /// <returns>The result of the division.</returns>
    public static Vector4f operator /(Matrix4x4f mat, Vector4f vec)
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
    public static Vector4f operator /(Vector4f vec, Matrix4x4f mat)
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
    public static Matrix4x4f operator /(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return mat1 * MatrixMath.Invert(mat2);
    }

    /// <summary>
    /// Checks if the matrices are equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if all components are equal, else false.</returns>
    public static bool operator ==(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return mat1[0] == mat2[0] && mat1[1] == mat2[1] && mat1[2] == mat2[2] && mat1[3] == mat2[3];
    }

    /// <summary>
    /// Checks if the matrices are not equal by comparing all components.
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>True if any of the components are not equal, else false.</returns>
    public static bool operator !=(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return mat1[0] != mat2[0] || mat1[1] != mat2[1] || mat1[2] != mat2[2] || mat1[3] != mat2[3];
    }

    #endregion

    #region Transform Constructors

    /// <summary>
    /// Creates a 3D translation matrix.
    /// </summary>
    /// <param name="x">The translation on the X axis.</param>
    /// <param name="y">The translation on the Y axis.</param>
    /// <param name="z">The translation on the Z axis.</param>
    /// <returns>A matrix that translates by the given values.</returns>
    public static Matrix4x4f Translate(float x, float y, float z)
    {
      return new Matrix4x4f(
          new Vector4f(1, 0, 0, x),
          new Vector4f(0, 1, 0, y),
          new Vector4f(0, 0, 1, z),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 3D rotation matrix for the given angle around the X axis.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    /// <returns>A matrix that rotates by the given angle.</returns>
    public static Matrix4x4f RotationX(float angle)
    {
      float rad = BasicMath.DegreesToRadians(angle);
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      return new Matrix4x4f(
          new Vector4f(1, 0, 0, 0),
          new Vector4f(0, cos, -sin, 0),
          new Vector4f(0, sin, cos, 0),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 3D rotation matrix for the given angle around the Y axis.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    /// <returns>A matrix that rotates by the given angle.</returns>
    public static Matrix4x4f RotationY(float angle)
    {
      float rad = BasicMath.DegreesToRadians(angle);
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      return new Matrix4x4f(
          new Vector4f(cos, 0, sin, 0),
          new Vector4f(0, 1, 0, 0),
          new Vector4f(-sin, 0, cos, 0),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 3D rotation matrix for the given angle around the Y axis.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    /// <returns>A matrix that rotates by the given angle.</returns>
    public static Matrix4x4f RotationZ(float angle)
    {
      float rad = BasicMath.DegreesToRadians(angle);
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      return new Matrix4x4f(
          new Vector4f(cos, -sin, 0, 0),
          new Vector4f(sin, cos, 0, 0),
          new Vector4f(0, 0, 1, 0),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a 3D scaling matrix.
    /// </summary>
    /// <param name="sx">The scale factor on the X axis.</param>
    /// <param name="sy">The scale factor on the Y axis.</param>
    /// <param name="sz">The scale factor on the Z axis.</param>
    /// <returns>A matrix that scales by the given values</returns>
    public static Matrix4x4f Scale(float sx, float sy, float sz)
    {
      return new Matrix4x4f(
          new Vector4f(sx, 0, 0, 0),
          new Vector4f(0, sy, 0, 0),
          new Vector4f(0, 0, sz, 0),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a left handed, look-at view matrix.
    /// </summary>
    /// <param name="eye">The position of the eye (or camera).</param>
    /// <param name="at">The point the eye looks at.</param>
    /// <param name="up">The up vector.</param>
    /// <returns>A view matrix for the given parameters.</returns>
    public static Matrix4x4f LookAtLH(Vector3f eye, Vector3f at, Vector3f up)
    {
      Vector3f zaxis = VectorMath.Normalize(at - eye);
      Vector3f xaxis = VectorMath.Normalize(VectorMath.CrossProduct(up, zaxis));
      Vector3f yaxis = VectorMath.CrossProduct(zaxis, xaxis);

      return new Matrix4x4f(
          new Vector4f(xaxis, -VectorMath.DotProduct(xaxis, eye)),
          new Vector4f(yaxis, -VectorMath.DotProduct(yaxis, eye)),
          new Vector4f(zaxis, -VectorMath.DotProduct(zaxis, eye)),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a right handed, look-at view matrix.
    /// </summary>
    /// <param name="eye">The position of the eye (or camera).</param>
    /// <param name="at">The point the eye looks at.</param>
    /// <param name="up">The up vector.</param>
    /// <returns>A view matrix for the given parameters.</returns>
    public static Matrix4x4f LookAtRH(Vector3f eye, Vector3f at, Vector3f up)
    {
      Vector3f zaxis = VectorMath.Normalize(at - eye);
      Vector3f xaxis = VectorMath.Normalize(VectorMath.CrossProduct(up, zaxis));
      Vector3f yaxis = VectorMath.CrossProduct(zaxis, xaxis);

      return new Matrix4x4f(
          new Vector4f(xaxis, VectorMath.DotProduct(xaxis, eye)),
          new Vector4f(yaxis, VectorMath.DotProduct(yaxis, eye)),
          new Vector4f(zaxis, VectorMath.DotProduct(zaxis, eye)),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a left-handed, orthgraphic projection matrix.
    /// </summary>
    /// <param name="width">The width of the view volume.</param>
    /// <param name="height">The height of the view volume.</param>
    /// <param name="zNear">The minimum z-value of the view volume./param>
    /// <param name="zFar">The maximum z-value of the view volume.</param>
    /// <returns>An orthographic projection matrix.</returns>
    public static Matrix4x4f ProjectionOrthographicLH(float width, float height, float zNear, float zFar)
    {
      return new Matrix4x4f(
          new Vector4f(2 / width, 0, 0, 0),
          new Vector4f(0, 2 / height, 0, 0),
          new Vector4f(0, 0, 1 / (zFar - zNear), -zNear / (zFar - zNear)),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a right-handed, orthgraphic projection matrix.
    /// </summary>
    /// <param name="width">The width of the view volume.</param>
    /// <param name="height">The height of the view volume.</param>
    /// <param name="zNear">The minimum z-value of the view volume./param>
    /// <param name="zFar">The maximum z-value of the view volume.</param>
    /// <returns>An orthographic projection matrix.</returns>
    public static Matrix4x4f ProjectionOrthographicRH(float width, float height, float zNear, float zFar)
    {
      return new Matrix4x4f(
          new Vector4f(2 / width, 0, 0, 0),
          new Vector4f(0, 2 / height, 0, 0),
          new Vector4f(0, 0, 1 / (zNear - zFar), zNear / (zNear - zFar)),
          new Vector4f(0, 0, 0, 1)
        );
    }

    /// <summary>
    /// Creates a left-handed perspective projection matrix.
    /// </summary>
    /// <param name="width">The width of the view volume at the near view-plane.</param>
    /// <param name="height">The height of the view volume at the near view-plane.</param>
    /// <param name="zNear">The Z-value of the near view-plane.</param>
    /// <param name="zFar">The Z-value of the far view-plane.</param>
    /// <returns>A perspective projection matrix.</returns>
    public static Matrix4x4f ProjectionPerspectiveLH(float width, float height, float zNear, float zFar)
    {
      return new Matrix4x4f(
          new Vector4f(2 * zNear / width, 0, 0, 0),
          new Vector4f(0, 2 * zNear / height, 0, 0),
          new Vector4f(0, 0, zFar / (zFar - zNear), zNear * zFar / (zNear - zFar)),
          new Vector4f(0, 0, 1, 0)
        );
    }

    /// <summary>
    /// Creates a right-handed perspective projection matrix.
    /// </summary>
    /// <param name="width">The width of the view volume at the near view-plane.</param>
    /// <param name="height">The height of the view volume at the near view-plane.</param>
    /// <param name="zNear">The Z-value of the near view-plane.</param>
    /// <param name="zFar">The Z-value of the far view-plane.</param>
    /// <returns>A perspective projection matrix.</returns>
    public static Matrix4x4f ProjectionPerspectiveRH(float width, float height, float zNear, float zFar)
    {
      return new Matrix4x4f(
          new Vector4f(2 * zNear / width, 0, 0, 0),
          new Vector4f(0, 2 * zNear / height, 0, 0),
          new Vector4f(0, 0, zFar / (zNear - zFar), zNear * zFar / (zNear - zFar)),
          new Vector4f(0, 0, -1, 0)
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
        Values[2].ToString() + Environment.NewLine +
        Values[3].ToString();
    }

    /// <summary>
    /// Checks if the matrix is equal to the given one.
    /// </summary>
    /// <param name="obj">The other matrix.</param>
    /// <returns>True if the matrices are equal, else false.</returns>
    public override bool Equals(object obj)
    {
      if (obj is Matrix4x4f)
        return this == (Matrix4x4f)obj;
      return base.Equals(obj);
    }

    // Shuts up code analyzer
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}
