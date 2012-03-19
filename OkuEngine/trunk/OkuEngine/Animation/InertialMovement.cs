using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Simulates the movement of a body of virtual mass in a 1D space.
  /// This can be used to simulate easing effects in animation.
  /// </summary>
  public class InertialMovement
  {
    private float _inertia = 1;
    private int _direction = 0;
    private float _currentSpeed = 0;

    /// <summary>
    /// Creates a new inertial movement with a default inertia of 1.
    /// </summary>
    public InertialMovement()
    {
    }

    /// <summary>
    /// Create a new inertial movement with the given intertia.
    /// </summary>
    /// <param name="inertia">The inertia.</param>
    public InertialMovement(float inertia)
    {
      _inertia = inertia;
    }

    /// <summary>
    /// Updates the internal values. Has to be called before
    /// the current speed is queried.
    /// </summary>
    /// <param name="dt">The time passed since the last frame in fractional seconds.</param>
    public void Update(float dt)
    {
      float a;
      if (_direction != 0)
        a = (_direction) / _inertia;
      else
        a = Math.Sign(-_currentSpeed) / _inertia;

      _currentSpeed = Math.Max(-1.0f, Math.Min(1.0f, _currentSpeed + (a * dt)));
    }

    /// <summary>
    /// Gets or sets the direction in with the virtual mass should move.
    /// Has to be either -1, 0 or 1.
    /// </summary>
    public int Direction
    {
      get { return _direction; }
      set { _direction = value; }
    }

    /// <summary>
    /// The inertia of the virtual mass. Must be > 0.0.
    /// The bigger the value the longer the body needs to accelerate.
    /// </summary>
    public float Inertia
    {
      get { return _inertia; }
      set 
      { 
        _inertia = value;
        if (_inertia == 0.0f)
          _inertia = 0.000001f;
      }
    }

    /// <summary>
    /// Gets the current speed of the virtual mass. Use this value to
    /// accelerate the paramter you want to ease. For example the X and Y
    /// components of a vector or the rotation of a handle.
    /// </summary>
    public float CurrentSpeed
    {
      get { return _currentSpeed; }
    }

  }
}
