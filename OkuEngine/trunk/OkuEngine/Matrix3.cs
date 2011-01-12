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
    public float V20;
    public float V21;
    public float V22;

    public void LoadIdentity()
    {
      V00 = 1;
      V01 = 0;
      V02 = 0;
      V10 = 0;
      V11 = 1;
      V12 = 0;
      V20 = 0;
      V21 = 0;
      V22 = 1;
    }

    public void Translate(float x, float y)
    {
      Multiply(CreateTranslation(x, y));
      /*V02 += x;
      V12 += y;*/
    }

    public void Translate(Vector vec)
    {
      Multiply(CreateTranslation(vec.X, vec.Y));
      /*V02 += vec.X;
      V12 += vec.Y;*/
    }

    public void Scale(float factorX, float factorY)
    {
      Multiply(CreateScale(factorX, factorY));
      /*V00 *= factorX;
      V11 *= factorY;*/
    }

    public void Scale(Vector vec)
    {
      Multiply(CreateScale(vec.X, vec.Y));
      /*V00 *= vec.X;
      V11 *= vec.Y;*/
    }

    //[1,0,2] [ 3,2,0] [ 3,2,2] [5,,]
    //[0,1,3] [-2,3,0] [-2,3,3] [-12,,]
    //[0,0,1] [ 0,0,1] [ 0,0,1] [0,,]

    public void Rotate(float angle)
    {
      Multiply(CreateRotation(angle));
    }

    //[ 0,1,2] [4] []
    //[-1,0,3] [5] []
    //[ 0,0,1] [1] []

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
      float res20 = 0;
      float res01 = other.V00 * V01 + other.V01 * V11;
      float res11 = other.V10 * V01 + other.V11 * V11;
      float res21 = 0;
      float res02 = other.V00 * V02 + other.V01 * V12 + other.V02;
      float res12 = other.V10 * V02 + other.V11 * V12 + other.V12;
      float res22 = 1;*/

      float res00 = V00 * other.V00 + V01 * other.V10;
      float res10 = V10 * other.V00 + V11 * other.V10;
      float res20 = 0;
      float res01 = V00 * other.V01 + V01 * other.V11;
      float res11 = V10 * other.V01 + V11 * other.V11;
      float res21 = 0;
      float res02 = V00 * other.V02 + V01 * other.V12 + V02;
      float res12 = V10 * other.V02 + V11 * other.V12 + V12;
      float res22 = 1;

      V00 = res00;
      V10 = res10;
      V20 = res20;
      V01 = res01;
      V11 = res11;
      V21 = res21;
      V02 = res02;
      V12 = res12;
      V22 = res22;
    }

    private static Matrix3 _tempMat = new Matrix3();

    public static Matrix3 CreateTranslation(float x, float y)
    {
      //Matrix3 result = new Matrix3();
      _tempMat.LoadIdentity();
      _tempMat.V02 = x;
      _tempMat.V12 = y;
      return _tempMat;
    }

    public static Matrix3 CreateRotation(float angle)
    {
      float rad = (angle / 180.0f) * (float)Math.PI;
      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      //Matrix3 rotation = new Matrix3();
      _tempMat.LoadIdentity();
      _tempMat.V00 = cos;
      _tempMat.V01 = sin;
      _tempMat.V10 = -sin;
      _tempMat.V11 = cos;

      return _tempMat;
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
      result.V20 = 0;
      result.V01 = m1.V00 * m2.V01 + m1.V01 * m2.V11;
      result.V11 = m1.V10 * m2.V01 + m1.V11 * m2.V11;
      result.V21 = 0;
      result.V02 = m1.V00 * m2.V02 + m1.V01 * m2.V12 + m1.V02;
      result.V12 = m1.V10 * m2.V02 + m1.V11 * m2.V12 + m1.V12;
      result.V22 = 1;

      return result;
    }

  }
}
