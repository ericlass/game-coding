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

  }
}
