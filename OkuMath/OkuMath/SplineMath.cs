using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuMath
{
  public static class SplineMath
  {
    /// <summary>
    /// Interpolates a point on the curve through the given points taking into account the given parameters.
    /// t gives the position of the point to interpolate. 0 means the start of the curve, 1 means the end of the
    /// curve. The interpolation is only calulated betwenn the points p1 and p2. p0 and p3 are only use to
    /// calculate the curvature. So a value of 0 for t actually returns p1 and a value of 1 returns p2. Values between
    /// 0 and 1 return a point on the curve between p1 and p2. 
    /// </summary>
    /// <param name="p0">The first point.</param>
    /// <param name="p1">The second point. This is the point where the curve starts.</param>
    /// <param name="p2">The third points. This is the point where the curve ends.</param>
    /// <param name="p3">The fourth point.</param>
    /// <param name="t">The position parameter. Allowed value range from 0.0 to 1.0.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The interpolated point at position t between p1 and p2.</returns>
    public static Vector2f InterpolateHermite(Vector2f p0, Vector2f p1, Vector2f p2, Vector2f p3, float t, float tension, float bias, float continuity)
    {
      float mu2 = t * t;
      float mu3 = mu2 * t;

      float a0 = 2 * mu3 - 3 * mu2 + 1;
      float a1 = mu3 - 2 * mu2 + t;
      float a2 = mu3 - mu2;
      float a3 = -2 * mu3 + 3 * mu2;

      float m0 = (p1.X - p0.X) * (1 + bias) * (1 - tension) * (1 + continuity) / 2;
      m0 = m0 + ((p2.X - p1.X) * (1 - bias) * (1 - tension) * (1 - continuity) / 2);
      float m1 = (p2.X - p1.X) * (1 + bias) * (1 - tension) * (1 - continuity) / 2;
      m1 = m1 + ((p3.X - p2.X) * (1 - bias) * (1 - tension) * (1 + continuity) / 2);

      float resultX = (a0 * p1.X + a1 * m0 + a2 * m1 + a3 * p2.X);

      m0 = (p1.Y - p0.Y) * (1 + bias) * (1 - tension) * (1 + continuity) / 2;
      m0 = m0 + ((p2.Y - p1.Y) * (1 - bias) * (1 - tension) * (1 - continuity) / 2);
      m1 = (p2.Y - p1.Y) * (1 + bias) * (1 - tension) * (1 - continuity) / 2;
      m1 = m1 + ((p3.Y - p2.Y) * (1 - bias) * (1 - tension) * (1 + continuity) / 2);

      float resultY = (a0 * p1.Y + a1 * m0 + a2 * m1 + a3 * p2.Y);

      return new Vector2f(resultX, resultY);
    }

    /// <summary>
    /// Interpolates a point on the spline at position t using the hermite interpolation.
    /// t ranges from 0.0 to 1.0.
    /// </summary>
    /// <param name="t">The position of the point to interpolate. Ranges from 0.0 to 1.0.</param>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The interpolated point of the spline.</returns>
    public static Vector2f PointOnHermiteSpline(Vector2f[] points, float t, float tension, float bias, float continuity)
    {
      t = BasicMath.Clamp(t, 0.0f, 1.0f);

      float realPos = t * (points.Length - 1);
      int second = (int)Math.Floor(realPos);
      int third = (int)Math.Ceiling(realPos);

      int first = Math.Max(second - 1, 0);
      int fourth = Math.Min(third + 1, points.Length - 1);

      return InterpolateHermite(points[first], points[second], points[third], points[fourth], t, tension, bias, continuity);
    }

    /// <summary>
    /// Calculates the arc length of the complete spline. Note that this is only an aproximation and not the 100% correct length.
    /// But it should be enough for most purposes especialy games.
    /// </summary>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The aproximated arc-length of the spline.</returns>
    public static float HermiteSplineLength(Vector2f[] points, float tension, float bias, float continuity)
    {
      int steps = points.Length * 20;
      float step = 1.0f / steps;

      float result = 0;
      Vector2f last = Vector2f.Zero;
      Vector2f current = Vector2f.Zero;
      last  = PointOnHermiteSpline(points, 0.0f, tension, bias, continuity);
      for (float t = step; t <= 1.0; t += step)
      {
        current = PointOnHermiteSpline(points, t, tension, bias, continuity);
        result += VectorMath.Distance(last, current);
        last = current;
      }

      return result;
    }

    /// <summary>
    /// Tesselates the spline into a polygon. Note that the points of the polygon are not evenly spread over the spline
    /// due to the non-linear nature of the hermite spline. If you need the points to be evenly spread 
    /// (for example for moving something along the spline at a constant speed) use the TesselateParameterized()
    /// method which is in return slower due to more complex math involved.
    /// </summary>
    /// <param name="numPoints">Specifies how many points the resulting polygon will have.</param>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The tesselated polygon.</returns>
    public static Vector2f[] TesselateHermiteSpline(int numPoints, Vector2f[] points, float tension, float bias, float continuity)
    {
      Vector2f[] result = new Vector2f[numPoints];

      float step = 1.0f / (numPoints - 1);
      Vector2f vec = Vector2f.Zero;

      for (int i = 0; i < numPoints; i++)
      {
        float t = i * step;
        result[i] = PointOnHermiteSpline(points, t, tension, bias, continuity); ;
      }

      return result;
    }

    /// <summary>
    /// Calculates a map that translates from linear length to arc length.
    /// </summary>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>An arc length map that can be used to translate from linear length to arc length.</returns>
    private static float[] CalculateArcLengthMap(Vector2f[] points, float tension, float bias, float continuity)
    {
      float[] arcLengthMap = new float[100];
      arcLengthMap[0] = 0.0f;

      Vector2f previous = points[0];
      Vector2f current = Vector2f.Zero;

      float arcLength = 0.0f;
      for (int i = 1; i < arcLengthMap.Length; i++)
      {
        float t = i / (float)arcLengthMap.Length;
        current = PointOnHermiteSpline(points, t, tension, bias, continuity);
        arcLength += VectorMath.Distance(previous, current);
        arcLengthMap[i] = arcLength;
        previous = current;
      }
      return arcLengthMap;
    }

    /// <summary>
    /// Interpolates a point on the spline at the given control value t.
    /// The spline is parameterized  to linear length so a control value of 0.5
    /// is garantueed to return a point that is half way down the spline.
    /// </summary>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="t">The linear control value. Must be in range 0.0 - 1.0.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The interpolated point.</returns>
    public static Vector2f PointOnParameterizedHermiteSpline(Vector2f[] points, float t, float tension, float bias, float continuity)
    {
      t = BasicMath.Clamp(t, 0.0f, 1.0f);

      float[] arcLengthMap = CalculateArcLengthMap(points, tension, bias, continuity);

      float totalLength = arcLengthMap[arcLengthMap.Length - 1];

      int min = (int)(t * arcLengthMap.Length) - 1;
      if (min >= arcLengthMap.Length - 1)
      {
        return points[points.Length - 1];
      }

      int max = min + 1;

      //TODO: Make this work correctly
      double tarc = BasicMath.Lerp(arcLengthMap[min], arcLengthMap[max], t - (Math.Floor(t)));

      return Vector2f.Zero;
    }

    /// <summary>
    /// Tesselates the spline to a polygon. The points are evenly spread on the spline
    /// at even distances. This is very useful for animations.
    /// </summary>
    /// <param name="numPoints">The number of points the tesselated spline should have.</param>
    /// <param name="points">The control points of the spline.</param>
    /// <param name="tension">The tension parameter.</param>
    /// <param name="bias">The bias parameter.</param>
    /// <param name="continuity">The continuity parameter.</param>
    /// <returns>The points of the tesselated polygon.</returns>
    public static Vector2f[] TesselateParameterizedHermiteSpline(int numPoints, Vector2f[] points, float tension, float bias, float continuity)
    {
      Vector2f[] result = new Vector2f[numPoints];
      float step = 1.0f / (numPoints - 1);

      for (int i = 0; i < numPoints; i++)
      {
        float t = i * step;
        result[i] = PointOnParameterizedHermiteSpline(points, t, tension, bias, continuity);
      }

      return result;
    }

  }
}
