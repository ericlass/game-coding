using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Can be used to creating easing in and out effects.
  /// </summary>
  public class EasingController
  {
    private Easing _in = new Easing();
    private Easing _out = new Easing();
    private float _min = 0;
    private float _max = 1;
    private float _left = 0;
    private float _right = 1;

    /// <summary>
    /// Creates a new EasingController.
    /// </summary>
    public EasingController()
    {
    }

    /// <summary>
    /// Creates a new EasingController with the given easing strength.
    /// </summary>
    /// <param name="strength">The easing strength.</param>
    public EasingController(int strength)
    {
      _in.Strength = strength;
      _out.Strength = -strength;
    }

    /// <summary>
    /// Gets or sets the easing strength for both in and out.
    /// </summary>
    public int Strength
    {
      get { return _in.Strength; }
      set
      {
        _in.Strength = value;
        _out.Strength = -value;
      }
    }

    /// <summary>
    /// Gets or sets the minimum value that will be returned
    /// by GetValueAt when given Left.
    /// </summary>
    public float Min
    {
      get { return _min; }
      set { _min = value; }
    }

    /// <summary>
    /// Gets or sets the maximum value that will be returned
    /// by GetValueAt when given Right.
    /// </summary>
    public float Max
    {
      get { return _max; }
      set { _max = value; }
    }

    /// <summary>
    /// Gets or sets the minimum value for the control value.
    /// </summary>
    public float Left
    {
      get { return _left; }
      set { _left = value; }
    }

    /// <summary>
    /// Gets or sets the maximum value for the control value.
    /// </summary>
    public float Right
    {
      get { return _right; }
      set { _right = value; }
    }

    /// <summary>
    /// Gets the value at the given control value.
    /// The given paramter must be in the range Left...Right.
    /// The value returned is always in the range Min...Max.
    /// </summary>
    /// <param name="t">The control parameter.</param>
    /// <returns>The interpolated value.</returns>
    public float GetValueAt(float t)
    {
      float d = (t - _left) / (_right - _left);
      Easing ease = null;
      float halfHeight = (_max - _min) * 0.5f;
      float offset = 0;
      if (d < 0.5f)
      {
        d = d * 2.0f;
        ease = _in;
      }
      else
      {
        d = (d * 2.0f) - 1;
        ease = _out;
        offset = halfHeight;
      }

      float v = ease.GetValueAt(d);
      return _min + offset + (v * halfHeight);
    }

  }
}
