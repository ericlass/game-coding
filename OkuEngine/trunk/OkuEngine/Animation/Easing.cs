using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Can be used to ease in or ease out. The strength property
  /// defines how much the curve is eased.
  /// </summary>
  public class Easing
  {
    private int _strength = 0;

    /// <summary>
    /// Creates a new linear easing.
    /// </summary>
    public Easing()
    {
    }

    /// <summary>
    /// Creates a new easing with the given strength.
    /// </summary>
    /// <param name="strength">The easing strength.</param>
    public Easing(int strength)
    {
      _strength = strength;
    }

    /// <summary>
    /// Defines how much the easing curve is curved.
    /// Positive value create easing in, negative values easing out.
    /// </summary>
    public int Strength
    {
      get { return _strength; }
      set { _strength = value; }
    }

    /// <summary>
    /// Gets the value at the given time.
    /// </summary>
    /// <param name="t">The "time" parameter. Ranges from 0.0 to 1.0.</param>
    /// <returns>The eased value at the given time. Ranges from 0.0 to 1.0.</returns>
    public float GetValueAt(float t)
    {
      if (_strength == 0)
        return t;

      float result = t;
      
      unchecked
      {
        if (_strength < 0)
          result = 1 - result;

        int max = _strength < 0 ? _strength * -1 : _strength;
        for (int i = 0; i < max; i++)
        {
          result *= result;
        }
        if (_strength < 0)
          result = 1 - result;

      }
      return result;
    }
  }
}
