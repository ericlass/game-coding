using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a hermite spline in 2D space.
  /// Usefull tool if arc length parameterization is implemented.
  /// </summary>
  public class Spline
  {
    private Vector[] _points = null;
    private double _tension = 0;
    private double _bias = 0;
    private double _continuity = 0;
    private double[] _arcLengthMap = null;

    /// <summary>
    /// Creates a new spline with the given points.
    /// </summary>
    /// <param name="points">The points that will be used for interpolation.</param>
    public Spline(Vector[] points)
    {
      _points = points;
    }

    /// <summary>
    /// Gets or sets the points that are used for interpolation.
    /// </summary>
    public Vector[] Points
    {
      get { return _points; }
      set { _points = value; }
    }

    /// <summary>
    /// Gets or sets how much of the points tension is applied to the interpolated curve. Ranges from 0.0...1.0.
    /// </summary>
    public double Tension
    {
      get { return _tension; }
      set { _tension = value; }
    }

    /// <summary>
    /// Gets or sets how much of the points bias is applied to the interpolated curve. Ranges from 0.0...1.0.
    /// </summary>
    public double Bias
    {
      get { return _bias; }
      set { _bias = value; }
    }

    /// <summary>
    /// Gets or sets how much of the points continuity is applied to the interpolated curve. Ranges from 0.0...1.0.
    /// </summary>
    public double Continuity
    {
      get { return _continuity; }
      set { _continuity = value; }
    }

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
    private Vector InterpolateHermite(Vector p0, Vector p1, Vector p2, Vector p3, double t, double tension, double bias, double continuity)
    {
      double mu2 = t * t;
      double mu3 = mu2 * t;

      double a0 = 2 * mu3 - 3 * mu2 + 1;
      double a1 = mu3 - 2 * mu2 + t;
      double a2 = mu3 - mu2;
      double a3 = -2 * mu3 + 3 * mu2;

      double m0 = (p1.X - p0.X) * (1 + bias) * (1 - tension) * (1 + continuity) / 2;
      m0 = m0 + ((p2.X - p1.X) * (1 - bias) * (1 - tension) * (1 - continuity) / 2);
      double m1 = (p2.X - p1.X) * (1 + bias) * (1 - tension) * (1 - continuity) / 2;
      m1 = m1 + ((p3.X - p2.X) * (1 - bias) * (1 - tension) * (1 + continuity) / 2);

      float resultX = (float)(a0 * p1.X + a1 * m0 + a2 * m1 + a3 * p2.X);

      m0 = (p1.Y - p0.Y) * (1 + bias) * (1 - tension) * (1 + continuity) / 2;
      m0 = m0 + ((p2.Y - p1.Y) * (1 - bias) * (1 - tension) * (1 - continuity) / 2);
      m1 = (p2.Y - p1.Y) * (1 + bias) * (1 - tension) * (1 - continuity) / 2;
      m1 = m1 + ((p3.Y - p2.Y) * (1 - bias) * (1 - tension) * (1 + continuity) / 2);

      float resultY = (float)(a0 * p1.Y + a1 * m0 + a2 * m1 + a3 * p2.Y);

      return new Vector(resultX, resultY);
    }

    /// <summary>
    /// Interpolates a point on the spline at position t using the hermite interpolation.
    /// t ranges from 0.0 to 1.0.
    /// </summary>
    /// <param name="t">The position of the point to interpolate. Ranges from 0.0 to 1.0.</param>
    /// <param name="result">The interpolated point is returned in this ref parameter.</param>
    /// <returns>true if the point was interpolated correctly or false if the t parameter is out of range.</returns>
    public bool GetInterpolatedPoint(double t, ref Vector result)
    {
      if ((t < 0) || (t > 1))
        return false;

      double realPos = t * (_points.Length - 1);
      int second = (int)Math.Floor(realPos);
      int third = (int)Math.Ceiling(realPos);

      int first = Math.Max(second - 1, 0);
      int fourth = Math.Min(third + 1, _points.Length - 1);

      result = InterpolateHermite(_points[first], _points[second], _points[third], _points[fourth], t, _tension, _bias, _continuity);

      return true;
    }
    
    /// <summary>
    /// Calculates the arc length of the complete spline. Note that this is only an aproximation and not the 100% correct length.
    /// But it should be enough for most purposes especialy games.
    /// </summary>
    /// <returns>The aproximated arc-length of the spline.</returns>
    public double GetLength()
    {
      int steps = _points.Length * 20;
      double step = 1.0 / steps;

      double result = 0;
      Vector last = Vector.Zero;
      Vector current = Vector.Zero;
      GetInterpolatedPoint(0, ref last);
      for (double t = step; t <= 1.0; t += step)
      {
        GetInterpolatedPoint(t, ref current);
        result += Vector.Distance(last, current);
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
    /// <param name="points">Specifies how many points the resulting polygon will have.</param>
    /// <returns>The tesselated polygon.</returns>
    public Vector[] Tesselate(int points)
    {
      Vector[] result = new Vector[points];

      double step = 1.0 / (points - 1);
      Vector vec = Vector.Zero;

      for (int i = 0; i < points; i++)
      {
        double t = i * step;
        GetInterpolatedPoint(t, ref vec);
        result[i] = vec;
      }

      return result;
    }
    
    /// <summary>
    /// Gets a map that translates from linear length to arc length.
    /// </summary>
    private double[] ArcLengthMap
    {
      get
      {
        if (_arcLengthMap == null)
        {
          _arcLengthMap = new double[100];
          _arcLengthMap[0] = 0.0;
          
          Vector previous = _points[0];
          Vector current = Vector.Zero;
          
          double arcLength = 0.0;
          for (int i = 1; i < _arcLengthMap.Length; i++)
          {
            double t = i / (double)_arcLengthMap.Length;
            if (GetInterpolatedPoint(t, ref current))
            {
              arcLength += Vector.Distance(previous, current);
              _arcLengthMap[i] = arcLength;
              previous = current;
            }
          }
        }
        return _arcLengthMap;
      }
    }
    
    /// <summary>
    /// Interpolates a point on the spline at the given control value t.
    /// The spline is parameterized  to linear length so a control value of 0.5
    /// is garantueed to return a point that half way down the spline.
    /// </summary>
    /// <param name="t">The linear control value. Must be in range 0.0 - 1.0.</param>
    /// <param name="result">The interpolated point is returned here.</param>
    /// <returns>True if the point was interpolated, false if the control parameter t was out of range 0.0 - 1.0.</returns>
    public bool GetParameterizedInterpolatedPoint(double t, ref Vector result)
    {
      if (t < 0 || t > 1)
        return false;
     
      double totalLength = ArcLengthMap[ArcLengthMap.Length - 1];
      
      int min = (int)(t * ArcLengthMap.Length) - 1;
      if (min >= ArcLengthMap.Length - 1)
        return _points[_points.Length - 1];      
      
      int max = min + 1;
      
      //TODO: Make this work correctly
      double tarc = OkuMath.InterpolateLinear(ArcLengthMap[min], ArcLengthMap[max], t - (Math.Floor(t)));
      
      return true;
    }

    /// <summary>
    /// Tesselates the spline to a polygon. The points are evenly spread on the spline
    /// at even distances-
    /// </summary>
    /// <param name="points">The number of points the tesselated spline should have.</param>
    /// <returns>The points of the tesselated polygon.</returns>
    public Vector[] TesselateParameterized(int points)
    {
      Vector[] result = new Vector[points];

      double step = 1.0 / (points - 1);
      Vector vec = Vector.Zero;

      for (int i = 0; i < points; i++)
      {
        double t = i * step;
        GetParameterizedInterpolatedPoint(t, ref vec);
        result[i] = vec;
      }

      return result;
    }

  }
}
