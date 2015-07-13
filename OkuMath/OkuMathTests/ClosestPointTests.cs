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

      Vector2f c = ClosestPoint.OnLineSegmentToPointV(a, b, p);
      float t = ClosestPoint.OnLineSegmentToPointF(a, b, p);

      Assert.AreEqual(0.5f, t);
      Assert.AreEqual(0.0f, c.X);
      Assert.AreEqual(2.0f, c.Y);
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

      Vector2f c = ClosestPoint.OnLineSegmentToPointV(a, b, p);
      float t = ClosestPoint.OnLineSegmentToPointF(a, b, p);

      Assert.AreEqual(0.0f, t);
      Assert.AreEqual(-1.0f, c.X);
      Assert.AreEqual(2.0f, c.Y);
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

      Vector2f c = ClosestPoint.OnLineSegmentToPointV(a, b, p);
      float t = ClosestPoint.OnLineSegmentToPointF(a, b, p);

      Assert.AreEqual(1.0f, t);
      Assert.AreEqual(1.0f, c.X);
      Assert.AreEqual(2.0f, c.Y);
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

      Vector2f c = ClosestPoint.OnRayToPointV(o, d, p);
      float t = ClosestPoint.OnRayToPointF(o, d, p);

      Assert.AreEqual(0.5f, t);
      Assert.AreEqual(0.0f, c.X);
      Assert.AreEqual(2.0f, c.Y);
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

      Vector2f c = ClosestPoint.OnRayToPointV(o, d, p);
      float t = ClosestPoint.OnRayToPointF(o, d, p);

      Assert.AreEqual(0.0f, t);
      Assert.AreEqual(o.X, c.X);
      Assert.AreEqual(o.Y, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected to a point on the ray that
    /// has a positive control value.
    /// </summary>
    [TestMethod]
    public void Test_OnCapsuleToPoint_Center()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(1, 3);
      float radius = 1.0f;
      Vector2f p = new Vector2f(3, 2);

      Vector2f c = ClosestPoint.OnCapsuleToPoint(a, b, radius, p);

      Assert.AreEqual(2.0f, c.X);
      Assert.AreEqual(2.0f, c.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected onto the hypothenuse of the triangle.
    /// </summary>
    [TestMethod]
    public void Test_OnTriangleToPoint()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(3, 3);
      Vector2f c = new Vector2f(3, 1);

      Vector2f p = new Vector2f(1.5f, 2);

      Vector2f r = ClosestPoint.OnTriangleToPoint(a, b, c, p);

      Assert.AreEqual(1.75f, r.X);
      Assert.AreEqual(1.75f, r.Y);
    }

    /// <summary>
    /// Tests the case when the point is projected onto the hypothenuse of the triangle.
    /// </summary>
    [TestMethod]
    public void Test_OnTriangleToPointV()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(3, 3);
      Vector2f c = new Vector2f(3, 1);

      Vector2f p = new Vector2f(1.5f, 2);

      Vector2f r = ClosestPoint.OnTriangleToPointV(a, b, c, p);

      Assert.AreEqual(1.75f, r.X);
      Assert.AreEqual(1.75f, r.Y);
    }

    /// <summary>
    /// Defines the number of times the methods are executed for performance tests.
    /// </summary>
    private const int NumPerfRuns = 100000;

    /// <summary>
    /// Tests the performance of the OnTriangleToPoint method by running is several times.
    /// </summary>
    [TestMethod]
    public void Test_Perf_OnTriangleToPoint()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(3, 3);
      Vector2f c = new Vector2f(3, 1);

      Vector2f p = new Vector2f(1.5f, 2);

      Vector2f r = new Vector2f();
      for (int i = 0; i < NumPerfRuns; i++)
      {
        r = ClosestPoint.OnTriangleToPoint(a, b, c, p);
      }

      Assert.AreEqual(1.75f, r.X);
      Assert.AreEqual(1.75f, r.Y);
    }

    /// <summary>
    /// Tests the performance of the OnTriangleToPointV method by running is several times.
    /// </summary>
    [TestMethod]
    public void Test_Perf_OnTriangleToPointV()
    {
      Vector2f a = new Vector2f(1, 1);
      Vector2f b = new Vector2f(3, 3);
      Vector2f c = new Vector2f(3, 1);

      Vector2f p = new Vector2f(1.5f, 2);

      Vector2f r = new Vector2f();
      for (int i = 0; i < NumPerfRuns; i++)
      {
        r = ClosestPoint.OnTriangleToPointV(a, b, c, p);
      }

      Assert.AreEqual(1.75f, r.X);
      Assert.AreEqual(1.75f, r.Y);
    }

  }
}
