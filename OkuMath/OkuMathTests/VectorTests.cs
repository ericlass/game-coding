using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OkuMath;

namespace OkuMathTest
{
  [TestClass]
  public class VectorTests
  {
    [TestMethod]
    public void Test_SquaredMagnitude()
    {
      Vector2f vec = new Vector2f(0.0f, 7.0f);

      Assert.AreEqual(49.0f, vec.SquaredMagnitude);
    }

    [TestMethod]
    public void Test_Magnitude()
    {
      Vector2f vec = new Vector2f(0.0f, 7.0f);

      Assert.AreEqual(7.0f, vec.Magnitude);
    }

    [TestMethod]
    public void Test_EqualsOperator()
    {
      Vector2f vec1 = new Vector2f(5.3f, 1.8f);
      Vector2f vec2 = new Vector2f(5.3f, 1.8f);

      Assert.IsTrue(vec1 == vec2);
    }

    [TestMethod]
    public void Test_PlusOperator()
    {
      Vector2f vec1 = new Vector2f(5.1f, 3.2f);
      Vector2f vec2 = new Vector2f(2.2f, 7.1f);
      Vector2f result = vec1 + vec2;

      Assert.AreEqual(7.3f, result.X);
      Assert.AreEqual(10.3f, result.Y);
    }

    [TestMethod]
    public void Test_MinusOperator()
    {
      Vector2f vec1 = new Vector2f(5.0f, 7.0f);
      Vector2f vec2 = new Vector2f(3.0f, 2.0f);
      Vector2f result = vec1 - vec2;

      Assert.AreEqual(2.0f, result.X);
      Assert.AreEqual(5.0f, result.Y);
    }

  }
}
