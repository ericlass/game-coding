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

  }
}
