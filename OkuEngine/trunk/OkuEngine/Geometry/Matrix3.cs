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
    public double V00; //Scale X
    public double V01; //Shear X
    public double V02; //Translate X
    public double V10; //Shear Y
    public double V11; //Scale Y
    public double V12; //Translate Y

    private static Matrix3 _identity = GetIdentity();
    
    /// <summary>
    /// Helper method to get an identity matrix.
    /// </summary>
    /// <returns>An identity matrix.</returns>
    private static Matrix3 GetIdentity()
    {
      Matrix3 mat = new Matrix3();
      mat.LoadIdentity();
      return mat;
    }

    /// <summary>
    /// Gets an identity matrix.
    /// </summary>
    public static Matrix3 Identity
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
    public void Translate(double x, double y)
    {
      Multiply(CreateTranslation(x, y));
    }

    /// <summary>
    /// Translates the matrix by the given vector.
    /// </summary>
    /// <param name="vec">The translation vector.</param>
    public void Translate(Vector2f vec)
    {
      Multiply(CreateTranslation(vec.X, vec.Y));
    }

    /// <summary>
    /// Scale the matrix by the given factors.
    /// </summary>
    /// <param name="factorX">The factor in X direction.</param>
    /// <param name="factorY">The factor in Y direction.</param>
    public void Scale(double factorX, double factorY)
    {
      Multiply(CreateScale(factorX, factorY));
    }

    /// <summary>
    /// Scales the matrix by the given vector.
    /// </summary>
    /// <param name="vec">The scale vector.</param>
    public void Scale(Vector2f vec)
    {
      Multiply(CreateScale(vec.X, vec.Y));
    }

    /// <summary>
    /// Rotates the matrix by the given degrees.
    /// </summary>
    /// <param name="angle">The angle to rotate in degrees.</param>
    public void Rotate(double angle)
    {
      Multiply(CreateRotation(angle));
    }

    /// <summary>
    /// Transforms the given vector. The result is returned in the vector itself.
    /// </summary>
    /// <param name="vec">The vector to be transformed.</param>
    public void Transform(ref Vector2f vec)
    {
      double res00 = V00 * vec.X + V01 * vec.Y + V02;
      double res10 = V10 * vec.X + V11 * vec.Y + V12;

      vec.X = (float)res00;
      vec.Y = (float)res10;
    }

    /// <summary>
    /// Transforms the given values. The result is returned in the values themselves.
    /// </summary>
    /// <param name="x">The x component to transform.</param>
    /// <param name="y">The y component to transform.</param>
    public void Transform(ref float x, ref float y)
    {
      double res00 = V00 * x + V01 * y + V02;
      double res10 = V10 * x + V11 * y + V12;

      x = (float)res00;
      y = (float)res10;
    }

    /// <summary>
    /// Transforms the given vector.
    /// </summary>
    /// <param name="vec">The vector to be transformed.</param>
    /// <returns>The transformed vector.</returns>
    public Vector2f Transform(Vector2f vec)
    {
      return new Vector2f((float)(V00 * vec.X + V01 * vec.Y + V02), (float)(V10 * vec.X + V11 * vec.Y + V12));
    }

    /// <summary>
    /// Transforms the given polygon.
    /// </summary>
    /// <param name="poly">The polygon to be transformed.</param>
    public void Transform(Vector2f[] poly)
    {
      for (int i = 0; i < poly.Length; i++)
        poly[i] = Transform(poly[i]);
    }

    /// <summary>
    /// Transforms the given <code>poly</code>. The result of the transform will be returned in <code>target</code>.
    /// </summary>
    /// <param name="poly">The polygon that is transformed.</param>
    /// <param name="target">The resulting transformed polygon.</param>    
    public void Transform(Vector2f[] poly, Vector2f[] target)
    {
      for (int i = 0; i < poly.Length; i++)
        target[i] = Transform(poly[i]);
    }

    /// <summary>
    /// Multiplies the matrix by the given matirx. That is "this * other". 
    /// Remember that matrix multiplication is not commutative, so the order
    /// of multiplication matters.
    /// </summary>
    /// <param name="other">The matrix to multiply by.</param>
    public void Multiply(Matrix3 other)
    {
      double res00 = V00 * other.V00 + V01 * other.V10;
      double res01 = V00 * other.V01 + V01 * other.V11;
      double res02 = V00 * other.V02 + V01 * other.V12 + V02;

      double res10 = V10 * other.V00 + V11 * other.V10;
      double res11 = V10 * other.V01 + V11 * other.V11;
      double res12 = V10 * other.V02 + V11 * other.V12 + V12;

      V00 = res00;
      V01 = res01;
      V02 = res02;
      V10 = res10;
      V11 = res11;
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
    public static Matrix3 CreateTranslation(double x, double y)
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
    public static Matrix3 CreateRotation(double angle)
    {
      double rad = (angle / 180.0) * Math.PI;
      double sin = Math.Sin(rad);
      double cos = Math.Cos(rad);

      Matrix3 result = _identity;
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
    public static Matrix3 CreateScale(double x, double y)
    {
      Matrix3 result = _identity;
      result.V00 = x;
      result.V11 = y;
      return result;
    }

    /// <summary>
    /// Creates a new matrix that translates and scales according to the given values.
    /// </summary>
    /// <param name="tx">The translation on the x axis.</param>
    /// <param name="ty">The translation on the y axis.</param>
    /// <param name="sx">The scale on the x axis.</param>
    /// <param name="sy">The scale on the y axis.</param>
    /// <returns>A new matrix that transforms according to the parameters.</returns>
    public static Matrix3 CreateTranslateScale(double tx, double ty, double sx, double sy)
    {
      Matrix3 result = _identity;
      result.Translate(tx, ty);
      
      return result;
    }

    /// <summary>
    /// Creates a new matrix that translates and rotates according to the given values.
    /// </summary>
    /// <param name="tx">The translation on the x axis.</param>
    /// <param name="ty">The translation on the y axis.</param>
    /// <param name="angle">The angle to rotate in degrees.</param>
    /// <returns>A new matrix that transforms according to the parameters.</returns>
    public static Matrix3 CreateTranslateRotate(double tx, double ty, double angle)
    {
      Matrix3 result = _identity;
      result.Translate(tx, ty);
      result.Rotate(angle);
      return result;
    }

    /// <summary>
    /// Creates a new matrix that translates, scales and rotates according to the given values.
    /// </summary>
    /// <param name="tx">The translation on the x axis.</param>
    /// <param name="ty">The translation on the y axis.</param>
    /// <param name="sx">The scale on the x axis.</param>
    /// <param name="sy">The scale on the y axis.</param>
    /// <param name="angle">The angle to rotate in degrees.</param>
    /// <returns>A new matrix that transforms according to the parameters.</returns>
    public static Matrix3 CreateTranslateScaleRotate(double tx, double ty, double sx, double sy, double angle)
    {
      Matrix3 result = _identity;
      result.Translate(tx, ty);
      result.Scale(sx, sy);
      result.Rotate(angle);
      return result;
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
      result.V01 = m1.V00 * m2.V01 + m1.V01 * m2.V11;
      result.V02 = m1.V00 * m2.V02 + m1.V01 * m2.V12 + m1.V02;

      result.V10 = m1.V10 * m2.V00 + m1.V11 * m2.V10;
      result.V11 = m1.V10 * m2.V01 + m1.V11 * m2.V11;
      result.V12 = m1.V10 * m2.V02 + m1.V11 * m2.V12 + m1.V12;

      return result;
    }

    public Matrix3 Invert()
    {
      double det = 1.0 / (V00 * (V11) - V01 * (V10));

      Matrix3 result = Matrix3.Identity;

      result.V00 = (V11) * det;
      result.V01 = -(V01) * det;
      result.V02 = (V01 * V12 - V11 * V02) * det;

      result.V10 = -(V10) * det;
      result.V11 = (V00) * det;
      result.V12 = -(V00 * V12 - V10 * V02) * det;

      return result;

      //Full invers, just for reference
      /*double det = V00 * (V11 * V22 - V12 * V21) -
            V01 * (V10 * V22 - V12 * V20) +
            V02 * (V10 * V21 - V20 * V11);

      double invDet = 1.0 / det;

      Matrix3 result = Matrix3.Indentity;

      result.V00 = (V11 * V22 - V21 * V12) * invDet;
      result.V01 = -(V01 * V22 - V21 * V02) * invDet;
      result.V02 = (V01 * V12 - V11 * V02) * invDet;

      result.V10 = -(V10 * V22 - V20 * V12) * invDet;
      result.V11 = (V00 * V22 - V20 * V02) * invDet;
      result.V12 = -(V00 * V12 - V10 * V02) * invDet;

      result.V20 = (V10 * V21 - V20 * V11) * invDet;
      result.V21 = -(V00 * V21 - V20 * V01) * invDet;
      result.V22 = (V00 * V11 - V10 * V01) * invDet;

      return result;*/
    }

    /// <summary>
    /// Multiplies the two matrices.
    /// </summary>
    /// <param name="m1">The first matrix.</param>
    /// <param name="m2">The second matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
    {
      return Multiply(m1, m2);
    }

    /// <summary>
    /// Checks if the given matrices are equal.
    /// Matrices are equal if all of their components are equal.
    /// </summary>
    /// <param name="m1">The first matrix.</param>
    /// <param name="m2">The second matrix.</param>
    /// <returns>True if the matrices are equal, else false.</returns>
    public static bool operator ==(Matrix3 m1, Matrix3 m2)
    {
      return m1.Equals(m2);
    }

    /// <summary>
    /// Checks if the two matrices are not equal.
    /// Matrices are not equal if at least one component is different.
    /// </summary>
    /// <param name="m1">The first matrix.</param>
    /// <param name="m2">The secnond matrix.</param>
    /// <returns>True if the matrices are not equal, else false.</returns>
    public static bool operator !=(Matrix3 m1, Matrix3 m2)
    {
      return !m1.Equals(m2);
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

    public override bool Equals(object obj)
    {
      if (obj is Matrix3)
      {
        return Equals((Matrix3)obj);
      }
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

  }
}
