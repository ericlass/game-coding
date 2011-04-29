using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// A simple 2d transformation matrix. Only the six values that matter 
  /// for transformation are contained.
  /// </summary>
  public struct Matrix3
  {
    public float V00; //Scale X
    public float V01; //Shear X
    public float V02; //Translate X
    public float V10; //Shear Y
    public float V11; //Scale Y
    public float V12; //Translate Y

    private static Matrix3 _identity = GetIndentity();
    
    /// <summary>
    /// Helper method to get an identity matrix.
    /// </summary>
    /// <returns>An identity matrix.</returns>
    private static Matrix3 GetIndentity()
    {
      Matrix3 mat = new Matrix3();
      mat.LoadIdentity();
      return mat;
    }

    /// <summary>
    /// Gets an identity matrix.
    /// </summary>
    public static Matrix3 Indentity
    {
      get { return _identity; }
    }

    /// <summary>
    /// Resets the matrix to be an identity matrix. This overwrites all values of the matrix.
    /// </summary>
    public void LoadIdentity()
    {
      V00 = 1;
      V01 = 0;
      V02 = 0;
      V10 = 0;
      V11 = 1;
      V12 = 0;
    }

    /// <summary>
    /// Translates the matrix by the given amounts.
    /// </summary>
    /// <param name="x">The x translation.</param>
    /// <param name="y">The y translation.</param>
    public void Translate(float x, float y)
    {
      Multiply(CreateTranslation(x, y));
    }

    /// <summary>
    /// Translates the matrix by the given vector.
    /// </summary>
    /// <param name="vec">The translation vector.</param>
    public void Translate(Vector vec)
    {
      Multiply(CreateTranslation(vec.X, vec.Y));
    }

    /// <summary>
    /// Scale the matrix by the given factors.
    /// </summary>
    /// <param name="factorX">The factor in X direction.</param>
    /// <param name="factorY">The factor in Y direction.</param>
    public void Scale(float factorX, float factorY)
    {
      Multiply(CreateScale(factorX, factorY));
    }

    /// <summary>
    /// Scales the matrix by the given vector.
    /// </summary>
    /// <param name="vec">The scale vector.</param>
    public void Scale(Vector vec)
    {
      Multiply(CreateScale(vec.X, vec.Y));
    }

    /// <summary>
    /// Rotates the matrix by the given degrees.
    /// </summary>
    /// <param name="angle">The angle to rotate in degrees.</param>
    public void Rotate(float angle)
    {
      Multiply(CreateRotation(angle));
    }

    /// <summary>
    /// Transforms the given vector. The result is returned in the vector itself.
    /// </summary>
    /// <param name="vec">The vector to be transformed.</param>
    public void Transform(ref Vector vec)
    {
      float res00 = V00 * vec.X + V01 * vec.Y + V02;
      float res10 = V10 * vec.X + V11 * vec.Y + V12;
      vec.X = res00;
      vec.Y = res10;
    }

    /// <summary>
    /// Transforms the given values. The result is returned in the values themselves.
    /// </summary>
    /// <param name="x">The x component to transform.</param>
    /// <param name="y">The y component to transform.</param>
    public void Transform(ref float x, ref float y)
    {
      float res00 = V00 * x + V01 * y + V02;
      float res10 = V10 * x + V11 * y + V12;
      x = res00;
      y = res10;
    }

    /// <summary>
    /// Transforms the given vector.
    /// </summary>
    /// <param name="vec">The vector to be transformed.</param>
    /// <returns>The transformed vector.</returns>
    public Vector Transform(Vector vec)
    {
      return new Vector(V00 * vec.X + V01 * vec.Y + V02, V10 * vec.X + V11 * vec.Y + V12);
    }

    /// <summary>
    /// Transforms the given <code>poly</code>. The result of the transform will be returned in <code>target</code>.
    /// </summary>
    /// <param name="poly">The polygon that is transformed.</param>
    /// <param name="target">The resulting transformed polygon.</param>    
    public void Transform(VectorList poly, VectorList target)
    {
      target.Clear();
      for (int i = 0; i < poly.Count; i++)
        target.Add(Transform(poly[i]));
    }

    /// <summary>
    /// Multiplies the matrix by the given matirx. That is "this * other". 
    /// Remember that matrix multiplication is not commutative, so the order
    /// of multiplication matters.
    /// </summary>
    /// <param name="other">The matrix to multiply by.</param>
    public void Multiply(Matrix3 other)
    {
      float res00 = V00 * other.V00 + V01 * other.V10;
      float res10 = V10 * other.V00 + V11 * other.V10;
      float res01 = V00 * other.V01 + V01 * other.V11;
      float res11 = V10 * other.V01 + V11 * other.V11;
      float res02 = V00 * other.V02 + V01 * other.V12 + V02;
      float res12 = V10 * other.V02 + V11 * other.V12 + V12;

      V00 = res00;
      V10 = res10;
      V01 = res01;
      V11 = res11;
      V02 = res02;
      V12 = res12;
    }

    /// <summary>
    /// Applies the given transformation the the matrix in the order
    /// Translate, Scale, Rotate.
    /// </summary>
    /// <param name="transform">The transformation to apply to the matrix.</param>
    public void ApplyTransform(Transformation transform)
    {
      Translate(transform.Translation);
      Scale(transform.Scale);
      Rotate(transform.Rotation);
    }

    /// <summary>
    /// Creates a translation matrix for the given offsets.
    /// </summary>
    /// <param name="x">The offest on the x axis.</param>
    /// <param name="y">The offset on the y axis.</param>
    /// <returns>A matrix that translates by the given offset.</returns>
    public static Matrix3 CreateTranslation(float x, float y)
    {
      Matrix3 result = _identity;
      result.LoadIdentity();
      result.V02 = x;
      result.V12 = y;
      return result;
    }

    /// <summary>
    /// Creates a rotation matrix for the given angle.
    /// </summary>
    /// <param name="angle">The angle in degrees for the rotation matrix.</param>
    /// <returns>A matrix that rotates by the given angle.</returns>
    public static Matrix3 CreateRotation(float angle)
    {
      float rad = (angle / 180.0f) * (float)Math.PI;
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      Matrix3 result = _identity;
      result.LoadIdentity();
      result.V00 = cos;
      result.V01 = sin;
      result.V10 = -sin;
      result.V11 = cos;

      return result;
    }

    /// <summary>
    /// Creates a scale matrix for the given scale factors.
    /// </summary>
    /// <param name="x">The scale factor on the x axis.</param>
    /// <param name="y">The scale factor on the y axis.</param>
    /// <returns>A matrix that scales by the given factors.</returns>
    public static Matrix3 CreateScale(float x, float y)
    {
      Matrix3 result = _identity;
      result.LoadIdentity();
      result.V00 = x;
      result.V11 = y;
      return _identity;
    }

    /// <summary>
    /// Multiplies the two given matrices. That is "m1 * m2". 
    /// Remember that matrix multiplication is not commutative, so the order
    /// of multiplication matters.
    /// </summary>
    /// <param name="m1">The first matrix.</param>
    /// <param name="m2">The second matrix.</param>
    /// <returns>The matrix result of the multiplication.</returns>
    public static Matrix3 Multiply(Matrix3 m1, Matrix3 m2)
    {
      Matrix3 result = new Matrix3();

      result.V00 = m1.V00 * m2.V00 + m1.V01 * m2.V10;
      result.V10 = m1.V10 * m2.V00 + m1.V11 * m2.V10;
      result.V01 = m1.V00 * m2.V01 + m1.V01 * m2.V11;
      result.V11 = m1.V10 * m2.V01 + m1.V11 * m2.V11;
      result.V02 = m1.V00 * m2.V02 + m1.V01 * m2.V12 + m1.V02;
      result.V12 = m1.V10 * m2.V02 + m1.V11 * m2.V12 + m1.V12;

      return result;
    }

    /// <summary>
    /// Compares the matrix with the given one.
    /// </summary>
    /// <param name="other">The matrix to compare to.</param>
    /// <returns>True if the matrices are equal, else False.</returns>
    public bool Equals(Matrix3 other)
    {
      return V00 == other.V00 &&
             V01 == other.V01 &&
             V02 == other.V02 &&
             V10 == other.V10 &&
             V11 == other.V11 &&
             V12 == other.V12;
    }

  }
}
