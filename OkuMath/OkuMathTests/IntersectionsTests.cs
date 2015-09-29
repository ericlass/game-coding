using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OkuMath;

namespace UnitTestProject1
{
  [TestClass]
  public class IntersectionsTests
  {
    /// <summary>
    /// Tests the case when two line segments intersect.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentLineSegment_Positive()
    {
      Vector2f a = new Vector2f(1.0f, 1.0f);
      Vector2f b = new Vector2f(3.0f, 3.0f);
      Vector2f c = new Vector2f(3.0f, 1.0f);
      Vector2f d = new Vector2f(1.0f, 3.0f);

      var r = Intersections.LineSegmentLineSegment(a, b, c, d);

      Assert.IsTrue(r.HasValue);
      Assert.AreEqual(2.0f, r.Value.X);
      Assert.AreEqual(2.0f, r.Value.Y);
    }

    /// <summary>
    /// Tests the case when the two line segments do not intersect.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentLineSegment_Negative()
    {
      Vector2f a = new Vector2f(1.0f, 1.0f);
      Vector2f b = new Vector2f(3.0f, 3.0f);
      Vector2f c = new Vector2f(4.0f, 1.0f);
      Vector2f d = new Vector2f(4.0f, 3.0f);

      var r = Intersections.LineSegmentLineSegment(a, b, c, d);

      Assert.IsFalse(r.HasValue);
    }

    /// <summary>
    /// Tests the case when the two lines intersect.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineLine_Positive()
    {
      Vector2f a = new Vector2f(1.0f, 1.0f);
      Vector2f b = new Vector2f(3.0f, 3.0f);
      Vector2f c = new Vector2f(4.0f, 1.0f);
      Vector2f d = new Vector2f(4.0f, 3.0f);

      var r = Intersections.LineLine(a, b, c, d);

      Assert.IsTrue(r.HasValue);
      Assert.AreEqual(4.0f, r.Value.X);
      Assert.AreEqual(4.0f, r.Value.Y);
    }

    /// <summary>
    /// Tests the case when the two line segments do not intersect.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineLine_Negative()
    {
      Vector2f a = new Vector2f(1.0f, 1.0f);
      Vector2f b = new Vector2f(3.0f, 3.0f);
      Vector2f c = new Vector2f(2.0f, 2.0f);
      Vector2f d = new Vector2f(4.0f, 4.0f);

      var r = Intersections.LineSegmentLineSegment(a, b, c, d);

      Assert.IsFalse(r.HasValue);
    }

    /// <summary>
    /// Test the case when the line does not hit the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineCircle_Passante()
    {
      Vector2f a = new Vector2f(1.0f, 5.0f);
      Vector2f b = new Vector2f(3.0f, 5.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineCircle(a, b, c, radius);

      Assert.IsNull(r);
    }

    /// <summary>
    /// Test the case when the line is a tangent of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineCircle_Tangent()
    {
      Vector2f a = new Vector2f(1.0f, 4.0f);
      Vector2f b = new Vector2f(3.0f, 4.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.IsTrue(r.Length == 1);
      Assert.AreEqual(2.0f, r[0].X);
      Assert.AreEqual(4.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the line crosses the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineCircle_Secant()
    {
      Vector2f a = new Vector2f(1.0f, 2.0f);
      Vector2f b = new Vector2f(3.0f, 2.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(2, r.Length);
      Assert.AreEqual(0.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
      Assert.AreEqual(4.0f, r[1].X);
      Assert.AreEqual(2.0f, r[1].Y);
    }

    /// <summary>
    /// Test the case when the ray does not hit the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_RayCircle_Passante()
    {
      Vector2f o = new Vector2f(1.0f, 5.0f);
      Vector2f d = new Vector2f(1.0f, 0.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.RayCircle(o, d, c, radius);

      Assert.IsNull(r);
    }

    /// <summary>
    /// Test the case when the ray is a tangent of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_RayCircle_Tangent()
    {
      Vector2f o = new Vector2f(1.0f, 4.0f);
      Vector2f d = new Vector2f(1.0f, 0.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.RayCircle(o, d, c, radius);

      Assert.IsNotNull(r);
      Assert.IsTrue(r.Length == 1);
      Assert.AreEqual(2.0f, r[0].X);
      Assert.AreEqual(4.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the ray crosses the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_RayCircle_Secant()
    {
      Vector2f o = new Vector2f(0.0f, 2.0f);
      Vector2f d = new Vector2f(1.0f, 0.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.RayCircle(o, d, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(2, r.Length);
      Assert.AreEqual(0.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
      Assert.AreEqual(4.0f, r[1].X);
      Assert.AreEqual(2.0f, r[1].Y);
    }

    /// <summary>
    /// Test the case when the ray crosses the circle but the origin of the ray is inside of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_RayCircle_Secant_OriginInside()
    {
      Vector2f o = new Vector2f(1.0f, 2.0f);
      Vector2f d = new Vector2f(1.0f, 0.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.RayCircle(o, d, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(1, r.Length);
      Assert.AreEqual(4.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the line segment does not hit the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Passante()
    {
      Vector2f a = new Vector2f(-1.0f, 5.0f);
      Vector2f b = new Vector2f(5.0f, 5.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNull(r);
    }

    /// <summary>
    /// Test the case when the line segment is a tangent of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Tangent()
    {
      Vector2f a = new Vector2f(-1.0f, 4.0f);
      Vector2f b = new Vector2f(5.0f, 4.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.IsTrue(r.Length == 1);
      Assert.AreEqual(2.0f, r[0].X);
      Assert.AreEqual(4.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the line segment crosses the circle and both points are outside of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Secant_BothOutside()
    {
      Vector2f a = new Vector2f(0.0f, 2.0f);
      Vector2f b = new Vector2f(4.0f, 2.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(2, r.Length);
      Assert.AreEqual(0.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
      Assert.AreEqual(4.0f, r[1].X);
      Assert.AreEqual(2.0f, r[1].Y);
    }

    /// <summary>
    /// Test the case when the line segment crosses the circle and both points are outside of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Secant_StartInside()
    {
      Vector2f a = new Vector2f(1.0f, 2.0f);
      Vector2f b = new Vector2f(4.0f, 2.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(1, r.Length);
      Assert.AreEqual(4.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the line segment crosses the circle and both points are outside of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Secant_EndInside()
    {
      Vector2f a = new Vector2f(0.0f, 2.0f);
      Vector2f b = new Vector2f(3.0f, 2.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNotNull(r);
      Assert.AreEqual(1, r.Length);
      Assert.AreEqual(0.0f, r[0].X);
      Assert.AreEqual(2.0f, r[0].Y);
    }

    /// <summary>
    /// Test the case when the line segment crosses the circle and both points are outside of the circle.
    /// </summary>
    [TestMethod]
    public void Test_Intersect_LineSegmentCircle_Secant_BothInside()
    {
      Vector2f a = new Vector2f(1.0f, 2.0f);
      Vector2f b = new Vector2f(3.0f, 2.0f);

      Vector2f c = new Vector2f(2.0f, 2.0f);
      float radius = 2.0f;

      var r = Intersections.LineSegmentCircle(a, b, c, radius);

      Assert.IsNull(r);
    }

  }
}
