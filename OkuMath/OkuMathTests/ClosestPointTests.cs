using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OkuMath;

namespace OkuMathTest
{
  [TestClass]
  public class ClosestPointTests
  {
    /// <summary>
    /// Tests the case when the point is directly next to the middle point of the line segment.
    /// In this case, the result is expected to be the center of the line segment (t = 0.5).
    /// </summary>
    [TestMethod]
    public void Test_OnLineSegmentToPoint_Center()
    {
      Vector2f a = new Vector2f(-1.0f, 2.0f);
      Vector2f b = new Vector2f(1.0f, 2.0f);
      Vector2f p = new Vector2f(0.0f, 3.0f);

      Vector2f c;
      float t;
      ClosestPoint.OnLineSegmentToPoint(a, b, p, out t, out c);

      Assert.AreEqual<float>(0.5f, t);
      Assert.AreEqual<float>(0.0f, c.X);
      Assert.AreEqual<float>(2.0f, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected to a point that has a negative control value.
    /// In this case, the result is expected to be the start point of the line segment.
    /// </summary>
    [TestMethod]
    public void Test_OnLineSegmentToPoint_Min()
    {
      Vector2f a = new Vector2f(-1.0f, 2.0f);
      Vector2f b = new Vector2f(1.0f, 2.0f);
      Vector2f p = new Vector2f(-2.0f, 3.0f);

      Vector2f c;
      float t;
      ClosestPoint.OnLineSegmentToPoint(a, b, p, out t, out c);

      Assert.AreEqual<float>(0.0f, t);
      Assert.AreEqual<float>(-1.0f, c.X);
      Assert.AreEqual<float>(2.0f, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected to a point that has a control value > 1.
    /// In this case, the result is expected to be the end point of the line segment.
    /// </summary>
    [TestMethod]
    public void Test_OnLineSegmentToPoint_Max()
    {
      Vector2f a = new Vector2f(-1.0f, 2.0f);
      Vector2f b = new Vector2f(1.0f, 2.0f);
      Vector2f p = new Vector2f(2.0f, 3.0f);

      Vector2f c;
      float t;
      ClosestPoint.OnLineSegmentToPoint(a, b, p, out t, out c);

      Assert.AreEqual<float>(1.0f, t);
      Assert.AreEqual<float>(1.0f, c.X);
      Assert.AreEqual<float>(2.0f, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected to a point on the ray that
    /// has a positive control value.
    /// </summary>
    [TestMethod]
    public void Test_OnRayToPoint_Positive()
    {
      Vector2f o = new Vector2f(-1.0f, 2.0f);
      Vector2f d = new Vector2f(2.0f, 0.0f);
      Vector2f p = new Vector2f(0.0f, 3.0f);

      Vector2f c;
      float t;
      ClosestPoint.OnRayToPoint(o, d, p, out t, out c);

      Assert.AreEqual<float>(0.5f, t);
      Assert.AreEqual<float>(0.0f, c.X);
      Assert.AreEqual<float>(2.0f, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected to a point on the ray that
    /// has a negative control value. In this case, the result is expected to
    /// be the orgin of the ray.
    /// </summary>
    [TestMethod]
    public void Test_OnRayToPoint_Negative()
    {
      Vector2f o = new Vector2f(-1.0f, 2.0f);
      Vector2f d = new Vector2f(2.0f, 0.0f);
      Vector2f p = new Vector2f(-3.0f, 3.0f);

      Vector2f c;
      float t;
      ClosestPoint.OnRayToPoint(o, d, p, out t, out c);

      Assert.AreEqual<float>(0.0f, t);
      Assert.AreEqual<float>(o.X, c.X);
      Assert.AreEqual<float>(o.Y, c.Y);
    }

    [TestMethod]
    public void Test_OnCapsuleToPoint_Center()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(1, 3);
      float radius = 1.0f;
      Vector2f p = new Vector2f(3, 2);

      Vector2f c;
      ClosestPoint.OnCapsuleToPoint(a, b, radius, p, out c);

      Assert.AreEqual<float>(2.0f, c.X);
      Assert.AreEqual<float>(2.0f, c.Y);
    }

  }
}
