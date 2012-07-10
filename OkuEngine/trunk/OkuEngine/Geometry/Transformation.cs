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
    private Vector _translation = Vector.Zero;
    private Vector _scale = Vector.One;
    private float _rotation = 0.0f;

    private bool _fromValid = false;
    private bool _toValid = false;
    private Matrix3 _from = Matrix3.Indentity;
    private Matrix3 _to = Matrix3.Indentity;

    /// <summary>
    /// Creates a new transformation with translation (0,0), scale (1,1) and rotation (0).
    /// </summary>
    public Transformation()
    {
    }

    /// <summary>
    /// Creates a new transformation with the given values for translation, scale and rotation.
    /// </summary>
    /// <param name="translation">The translation vector.</param>
    /// <param name="scale">The scale vector.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    public Transformation(Vector translation, Vector scale, float rotation)
    {
      _translation = translation;
      _scale = scale;
      _rotation = rotation;
    }

    /// <summary>
    /// Gets or sets the translation vector.
    /// </summary>
    public Vector Translation 
    {
      get { return _translation; }
      set 
      {
        if (!_translation.Equals(value))
        {
          _translation = value;
          _fromValid = false;
          _toValid = false;
        }
      }
    }

    /// <summary>
    /// Gets or sets the rotation angle in degrees.
    /// </summary>
    public float Rotation 
    {
      get { return _rotation; }
      set
      {
        if (_rotation != value)
        {
          _rotation = value;
          _fromValid = false;
          _toValid = false;
        }
      }
    }

    /// <summary>
    /// Gets or sets the scale factor.
    /// </summary>
    public Vector Scale
    {
      get { return _scale; }
      set
      {
        if (!_scale.Equals(value))
        {
          _scale = value;
          _fromValid = false;
          _toValid = false;
        }
      }
    }

    /// <summary>
    /// Gets the matrix that applies the inverse of the transform.
    /// </summary>
    public Matrix3 FromMatrix
    {
      get
      {
        if (!_fromValid)
        {
          _from.LoadIdentity();
          _from.ApplyTransform(this);
          _fromValid = true;
        }
        return _from;
      }
    }

    /// <summary>
    /// Gets the matrix that applies the transform.
    /// </summary>
    public Matrix3 ToMatrix
    {
      get
      {
        if (!_toValid)
        {
          _to.LoadIdentity();
          _to.ApplyTransform(this);
          _toValid = true;
        }
        return _to;
      }
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
