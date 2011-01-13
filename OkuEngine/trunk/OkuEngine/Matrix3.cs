using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public struct Matrix3
  {
    public float V00; //Scale X
    public float V01; //Shear X
    public float V02; //Translate X
    public float V10; //Shear Y
    public float V11; //Scale Y
    public float V12; //Translate Y

    private static Matrix3 _tempMat = new Matrix3();

    public void LoadIdentity()
    {
      V00 = 1;
      V01 = 0;
      V02 = 0;
      V10 = 0;
      V11 = 1;
      V12 = 0;
    }

    public void Translate(float x, float y)
    {
      Multiply(CreateTranslation(x, y));
    }

    public void Translate(Vector vec)
    {
      Multiply(CreateTranslation(vec.X, vec.Y));
    }

    public void Scale(float factorX, float factorY)
    {
      Multiply(CreateScale(factorX, factorY));
    }

    public void Scale(Vector vec)
    {
      Multiply(CreateScale(vec.X, vec.Y));
    }

    public void Rotate(float angle)
    {
      Multiply(CreateRotation(angle));
    }

    public void Transform(ref Vector vec)
    {
      float res00 = V00 * vec.X + V01 * vec.Y + V02;
      float res10 = V10 * vec.X + V11 * vec.Y + V12;
      vec.X = res00;
      vec.Y = res10;
    }

    public Vector Transform(Vector vec)
    {
      return new Vector(V00 * vec.X + V01 * vec.Y + V02, V10 * vec.X + V11 * vec.Y + V12);
    }

    public void Multiply(Matrix3 other)
    {
      /*float res00 = other.V00 * V00 + other.V01 * V10;
      float res10 = other.V10 * V00 + other.V11 * V10;
      float res01 = other.V00 * V01 + other.V01 * V11;
      float res11 = other.V10 * V01 + other.V11 * V11;
      float res02 = other.V00 * V02 + other.V01 * V12 + other.V02;
      float res12 = other.V10 * V02 + other.V11 * V12 + other.V12;*/

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

    public static Matrix3 CreateTranslation(float x, float y)
    {
      Matrix3 result = _tempMat;
      result.LoadIdentity();
      result.V02 = x;
      result.V12 = y;
      return result;
    }

    public static Matrix3 CreateRotation(float angle)
    {
      float rad = (angle / 180.0f) * (float)Math.PI;
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      Matrix3 result = _tempMat;
      result.LoadIdentity();
      result.V00 = cos;
      result.V01 = sin;
      result.V10 = -sin;
      result.V11 = cos;

      return result;
    }

    public static Matrix3 CreateScale(float x, float y)
    {
      //Matrix3 result = new Matrix3();
      _tempMat.LoadIdentity();
      _tempMat.V00 = x;
      _tempMat.V11 = y;
      return _tempMat;
    }

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

  }
}
