using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Determines a full transformation with translation, rotation and scale.
  /// </summary>
  public class Transformation
  {
    private Vector _translation = new Vector();
    private Vector _scale = new Vector(1, 1);
    private float _rotation = 0.0f;

    /// <summary>
    /// Gets or sets the translation vector.
    /// </summary>
    public Vector Translation 
    {
      get { return _translation; }
      set { _translation = value; }
    }

    /// <summary>
    /// Gets or sets the rotation angle in degrees.
    /// </summary>
    public float Rotation 
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    /// <summary>
    /// Gets or sets the scale factor.
    /// </summary>
    public Vector Scale 
    {
      get { return _scale; }
      set { _scale = value; }
    }

    /// <summary>
    /// Compares the transformation to another.
    /// </summary>
    /// <param name="other">The transformation to compare to.</param>
    /// <returns>True id the transformations are equal, else False.</returns>
    public bool Equals(Transformation other)
    {
      return _translation.Equals(other._translation) &&
        _rotation == other._rotation &&
        _scale.Equals(other._scale);
    }

  }
}
