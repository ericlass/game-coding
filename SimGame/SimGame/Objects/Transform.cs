using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace SimGame.Objects
{
  /// <summary>
  /// Defines a general transformation with translation, rotation and scale.
  /// </summary>
  public class Transform
  {
    private Vector2f _scale = Vector2f.One;

    /// <summary>
    /// Gets or sets the translation.
    /// </summary>
    public Vector2f Translation { get; set; }

    /// <summary>
    /// Gets or sets the rotation.
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// Gets or sets the scale.
    /// </summary>
    public Vector2f Scale 
    {
      get { return _scale; }
      set { _scale = value; }
    }
  }
}
