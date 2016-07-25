﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a rotation angle around the center of the entity.
  /// </summary>
  public class AngleComponent : Component
  {
    private float _angle = 0.0f;
    private bool _dirty = true;

    /// <summary>
    /// Creates a new angle component with 0 angle.
    /// </summary>
    public AngleComponent()
    {
    }

    /// <summary>
    /// Creates a new angle component with the given angle.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    public AngleComponent(float angle)
    {
      _angle = angle;
    }

    /// <summary>
    /// Gets or set the rotation angle.
    /// </summary>
    public float Angle
    {
      get { return _angle; }
      set
      {
        _angle = value;
        _dirty = true;
      }
    }

    internal bool Dirty
    {
      get { return _dirty; }
      set { _dirty = value; }
    }

    /// <summary>
    /// Gets if the component can be assigned multiple times to the same entity.
    /// </summary>
    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get{ return "angle"; }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override Component Copy()
    {
      return new AngleComponent(_angle);
    }

  }
}
