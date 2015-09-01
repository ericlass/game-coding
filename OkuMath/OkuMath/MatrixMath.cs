using System;

namespace OkuMath
{
  public static class MatrixMath
  {
    /// <summary>
    /// Computes the determinant of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The determinant of the matrix.</returns>
    public static float Determinant(Matrix2x2f mat)
    {
      return mat[0].X * mat[1].Y - mat[1].X * mat[0].Y;
    }

    /// <summary>
    /// Computes the determinant of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The determinant of the matrix.</returns>
    public static float Determinant(Matrix3x3f mat)
    {
      return
        mat[0].X * (mat[1].Y * mat[2].Z - mat[2].Y * mat[1].Z) -
        mat[1].X * (mat[0].Y * mat[2].Z - mat[2].Y * mat[0].Z) +
        mat[2].X * (mat[0].Y * mat[1].Z - mat[1].Y * mat[0].Z);
    }

    /// <summary>
    /// Computes the determinant of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The determinant of the matrix.</returns>
    public static float Determinant(Matrix4x4f mat)
    {
      float subFactor00 = mat[2].Z * mat[3].W - mat[3].Z * mat[2].W;
      float subFactor01 = mat[2].Y * mat[3].W - mat[3].Y * mat[2].W;
      float subFactor02 = mat[2].Y * mat[3].Z - mat[3].Y * mat[2].Z;
      float subFactor03 = mat[2].X * mat[3].W - mat[3].X * mat[2].W;
      float subFactor04 = mat[2].X * mat[3].Z - mat[3].X * mat[2].Z;
      float subFactor05 = mat[2].X * mat[3].Y - mat[3].X * mat[2].Y;

      Vector4f detCof = new Vector4f(
        +(mat[1].Y * subFactor00 - mat[1].Z * subFactor01 + mat[1].W * subFactor02),
        -(mat[1].X * subFactor00 - mat[1].Z * subFactor03 + mat[1].W * subFactor04),
        +(mat[1].X * subFactor01 - mat[1].Y * subFactor03 + mat[1].W * subFactor05),
        -(mat[1].X * subFactor02 - mat[1].Y * subFactor04 + mat[1].Z * subFactor05));

      return
        mat[0].X * detCof[0] + mat[0].Y * detCof[1] +
        mat[0].Z * detCof[2] + mat[0].W * detCof[3];
    }

    /// <summary>
    /// Inverst the given matrix. It should checked first if the matrix has a non-zero determinant.
    /// Otherwise, the result is undefined.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The inverse matrix.</returns>
    public static Matrix2x2f Invert(Matrix2x2f mat)
    {
      float oneOverDet = 1.0f / Determinant(mat);

      return new Matrix2x2f(
          mat[1].Y * oneOverDet,
          -mat[0].Y * oneOverDet,
          -mat[1].X * oneOverDet,
          mat[0].X * oneOverDet
        );
    }

    /// <summary>
    /// Inverst the given matrix. It should checked first if the matrix has a non-zero determinant.
    /// Otherwise, the result is undefined.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The inverse matrix.</returns>
    public static Matrix3x3f Invert(Matrix3x3f mat)
    {
      float oneOverDet = 1.0f / Determinant(mat);

      return new Matrix3x3f(
          (mat[1].Y * mat[2].Z - mat[2].Y * mat[1].Z) * oneOverDet,
          -(mat[0].Y * mat[2].Z - mat[2].Y * mat[0].Z) * oneOverDet,
          (mat[0].Y * mat[1].Z - mat[1].Y * mat[0].Z) * oneOverDet,
          -(mat[1].X * mat[2].Z - mat[2].X * mat[1].Z) * oneOverDet,
          (mat[0].X * mat[2].Z - mat[2].X * mat[0].Z) * oneOverDet,
          -(mat[0].X * mat[1].Z - mat[1].X * mat[0].Z) * oneOverDet,
          (mat[1].X * mat[2].Y - mat[2].X * mat[1].Y) * oneOverDet,
          -(mat[0].X * mat[2].Y - mat[2].X * mat[0].Y) * oneOverDet,
          (mat[0].X * mat[1].Y - mat[1].X * mat[0].Y) * oneOverDet
        );
    }

    /// <summary>
    /// Inverst the given matrix. It should checked first if the matrix has a non-zero determinant.
    /// Otherwise, the result is undefined.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The inverse matrix.</returns>
    public static Matrix4x4f Invert(Matrix4x4f mat)
    {
      float coef00 = mat[2].Z * mat[3].W - mat[3].Z * mat[2].W;
      float coef02 = mat[1].Z * mat[3].W - mat[3].Z * mat[1].W;
      float coef03 = mat[1].Z * mat[2].W - mat[2].Z * mat[1].W;

      float coef04 = mat[2].Y * mat[3].W - mat[3].Y * mat[2].W;
      float coef06 = mat[1].Y * mat[3].W - mat[3].Y * mat[1].W;
      float coef07 = mat[1].Y * mat[2].W - mat[2].Y * mat[1].W;

      float coef08 = mat[2].Y * mat[3].Z - mat[3].Y * mat[2].Z;
      float coef10 = mat[1].Y * mat[3].Z - mat[3].Y * mat[1].Z;
      float coef11 = mat[1].Y * mat[2].Z - mat[2].Y * mat[1].Z;

      float coef12 = mat[2].X * mat[3].W - mat[3].X * mat[2].W;
      float coef14 = mat[1].X * mat[3].W - mat[3].X * mat[1].W;
      float coef15 = mat[1].X * mat[2].W - mat[2].X * mat[1].W;

      float coef16 = mat[2].X * mat[3].Z - mat[3].X * mat[2].Z;
      float coef18 = mat[1].X * mat[3].Z - mat[3].X * mat[1].Z;
      float coef19 = mat[1].X * mat[2].Z - mat[2].X * mat[1].Z;

      float coef20 = mat[2].X * mat[3].Y - mat[3].X * mat[2].Y;
      float coef22 = mat[1].X * mat[3].Y - mat[3].X * mat[1].Y;
      float coef23 = mat[1].X * mat[2].Y - mat[2].X * mat[1].Y;

      Vector4f fac0 = new Vector4f(coef00, coef00, coef02, coef03);
      Vector4f fac1 = new Vector4f(coef04, coef04, coef06, coef07);
      Vector4f fac2 = new Vector4f(coef08, coef08, coef10, coef11);
      Vector4f fac3 = new Vector4f(coef12, coef12, coef14, coef15);
      Vector4f fac4 = new Vector4f(coef16, coef16, coef18, coef19);
      Vector4f fac5 = new Vector4f(coef20, coef20, coef22, coef23);

      Vector4f vec0 = new Vector4f(mat[1].X, mat[0].X, mat[0].X, mat[0].X);
      Vector4f vec1 = new Vector4f(mat[1].Y, mat[0].Y, mat[0].Y, mat[0].Y);
      Vector4f vec2 = new Vector4f(mat[1].Z, mat[0].Z, mat[0].Z, mat[0].Z);
      Vector4f vec3 = new Vector4f(mat[1].W, mat[0].W, mat[0].W, mat[0].W);

      Vector4f inv0 = vec1 * fac0 - vec2 * fac1 + vec3 * fac2;
      Vector4f inv1 = vec0 * fac0 - vec2 * fac3 + vec3 * fac4;
      Vector4f inv2 = vec0 * fac1 - vec1 * fac3 + vec3 * fac5;
      Vector4f inv3 = vec0 * fac2 - vec1 * fac4 + vec2 * fac5;

      Vector4f signA = new Vector4f(+1, -1, +1, -1);
      Vector4f signB = new Vector4f(-1, +1, -1, +1);
      Matrix4x4f inverse = new Matrix4x4f(inv0 * signA, inv1 * signB, inv2 * signA, inv3 * signB);

      Vector4f row0 = new Vector4f(inverse[0].X, inverse[1].X, inverse[2].X, inverse[3].X);

      Vector4f dot0 = mat[0] * row0;
      float dot1 = (dot0.X + dot0.Y) + (dot0.Z + dot0.W);

      float oneOverDeterminant = 1.0f / dot1;

      return inverse * oneOverDeterminant;
    }

    /// <summary>
    /// Multiply matrix mat1 by matrix mat2 component-wise, i.e., result[i][j] is the scalar product of mat1[i][j] and mat2[i][j].
    /// Note: To get linear algebraic matrix multiplication, use the multiply operator (*).
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix2x2f MultiplyComponents(Matrix2x2f mat1, Matrix2x2f mat2)
    {
      return new Matrix2x2f(
          mat1[0] * mat2[0],
          mat1[1] * mat2[1]
        );
    }

    /// <summary>
    /// Multiply matrix mat1 by matrix mat2 component-wise, i.e., result[i][j] is the scalar product of mat1[i][j] and mat2[i][j].
    /// Note: To get linear algebraic matrix multiplication, use the multiply operator (*).
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix3x3f MultiplyComponents(Matrix3x3f mat1, Matrix3x3f mat2)
    {
      return new Matrix3x3f(
          mat1[0] * mat2[0],
          mat1[1] * mat2[1],
          mat1[2] * mat2[2]
        );
    }

    /// <summary>
    /// Multiply matrix mat1 by matrix mat2 component-wise, i.e., result[i][j] is the scalar product of mat1[i][j] and mat2[i][j].
    /// Note: To get linear algebraic matrix multiplication, use the multiply operator (*).
    /// </summary>
    /// <param name="mat1">The first matrix.</param>
    /// <param name="mat2">The second matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix4x4f MultiplyComponents(Matrix4x4f mat1, Matrix4x4f mat2)
    {
      return new Matrix4x4f(
          mat1[0] * mat2[0],
          mat1[1] * mat2[1],
          mat1[2] * mat2[2],
          mat1[3] * mat2[3]
        );
    }

    /// <summary>
    /// Computes the outer product of the two given vectors, which is a matrix.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The outer product matrix.</returns>
    public static Matrix2x2f OuterProduct(Vector2f vec1, Vector2f vec2)
    {
      return new Matrix2x2f(
          vec1.X * vec2.X,
          vec1.X * vec2.Y,
          vec1.Y * vec2.X,
          vec1.Y * vec2.Y
        );
    }

    /// <summary>
    /// Computes the outer product of the two given vectors, which is a matrix.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The outer product matrix.</returns>
    public static Matrix3x3f OuterProduct(Vector3f vec1, Vector3f vec2)
    {
      return new Matrix3x3f(
          vec1.X * vec2.X,
          vec1.X * vec2.Y,
          vec1.X * vec2.Z,

          vec1.Y * vec2.X,
          vec1.Y * vec2.Y,
          vec1.Y * vec2.Z,

          vec1.Z * vec2.X,
          vec1.Z * vec2.Y,
          vec1.Z * vec2.Z
        );
    }

    /// <summary>
    /// Computes the outer product of the two given vectors, which is a matrix.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The outer product matrix.</returns>
    public static Matrix4x4f OuterProduct(Vector4f vec1, Vector4f vec2)
    {
      return new Matrix4x4f(
          vec1.X * vec2.X,
          vec1.X * vec2.Y,
          vec1.X * vec2.Z,
          vec1.X * vec2.W,

          vec1.Y * vec2.X,
          vec1.Y * vec2.Y,
          vec1.Y * vec2.Z,
          vec1.Y * vec2.W,

          vec1.Z * vec2.X,
          vec1.Z * vec2.Y,
          vec1.Z * vec2.Z,
          vec1.Z * vec2.W,

          vec1.W * vec2.X,
          vec1.W * vec2.Y,
          vec1.W * vec2.Z,
          vec1.W * vec2.W
        );
    }

    /// <summary>
    /// Comptes the transpose of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix2x2f Transpose(Matrix2x2f mat)
    {
      return new Matrix2x2f(
          mat[0].X,
          mat[1].X,
          mat[0].Y,
          mat[1].Y
        );
    }

    /// <summary>
    /// Comptes the transpose of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix3x3f Transpose(Matrix3x3f mat)
    {
      return new Matrix3x3f(
          mat[0].X,
          mat[1].X,
          mat[2].X,

          mat[0].Y,
          mat[1].Y,
          mat[2].Y,

          mat[0].Z,
          mat[1].Z,
          mat[2].Z
        );
    }

    /// <summary>
    /// Comptes the transpose of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix4x4f Transpose(Matrix4x4f mat)
    {
      return new Matrix4x4f(
          mat[0].X,
          mat[1].X,
          mat[2].X,
          mat[3].X,

          mat[0].Y,
          mat[1].Y,
          mat[2].Y,
          mat[3].Y,

          mat[0].Z,
          mat[1].Z,
          mat[2].Z,
          mat[3].Z,

          mat[0].W,
          mat[1].W,
          mat[2].W,
          mat[3].W
        );
    }

  }
}
