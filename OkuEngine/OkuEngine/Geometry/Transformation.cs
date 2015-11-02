using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase.Geometry;
using OkuMath;

namespace OkuEngine
{
  /// <summary>
  /// Determines a full transformation with translation, orientation and scale.
  /// </summary>
  public class Transformation
  {
    public delegate void OnChangeDelegate(Transformation transform);

    public event OnChangeDelegate OnChange;

    public static Transformation Identity
    {
      get { return new Transformation(); }
    }

    private Vector2f _translation = Vector2f.Zero;
    private Vector2f _scale = Vector2f.One;
    private float _orientation = 0.0f;

    /// <summary>
    /// Creates a new transformation with translation (0,0), scale (1,1) and orientation (0).
    /// </summary>
    public Transformation()
    {
    }

    /// <summary>
    /// Creates a new transformation with the given values for translation, scale and orientation.
    /// </summary>
    /// <param name="translation">The translation vector.</param>
    /// <param name="scale">The scale vector.</param>
    /// <param name="orientation">The orientation angle in degrees.</param>
    public Transformation(Vector2f translation, Vector2f scale, float orientation)
    {
      _translation = translation;
      _scale = scale;
      _orientation = orientation;
    }

    /// <summary>
    /// Gets or sets the translation vector.
    /// </summary>
    public Vector2f Translation
    {
      get { return _translation; }
      set
      {
        _translation = value;
      }
    }

    /// <summary>
    /// Sets the x value of the translation.
    /// </summary>
    /// <param name="x">The new x value.</param>
    internal void SetX(float x)
    {
      _translation.X = x;
    }

    /// <summary>
    /// Sets the y value of the translation.
    /// </summary>
    /// <param name="y">The new y value.</param>
    internal void SetY(float y)
    {
      _translation.Y = y;
    }

    /// <summary>
    /// Gets or sets the orientation angle in degrees.
    /// </summary>
    public float Orientation 
    {
      get { return _orientation; }
      set 
      {
        _orientation = value;
      }
    }

    /// <summary>
    /// Gets or sets the scale factor.
    /// </summary>
    public Vector2f Scale
    {
      get { return _scale; }
      set
      {
        _scale = value;
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
        _orientation == other._orientation &&
        _scale.Equals(other._scale);
    }

    /// <summary>
    /// Applies the transformation data of the given transformation to the transformation.
    /// </summary>
    /// <param name="transform">The transform to be applied.</param>
    public void Apply(Transformation transform)
    {
      _translation = transform.Translation;
      _scale = transform.Scale;
      _orientation = transform.Orientation;
    }

    /// <summary>
    /// Check if the transformation is an identity transform which means
    /// that it does not do any transformation at all.
    /// </summary>
    /// <returns>True if the transformation is and identity, else false.</returns>
    public bool IsIdentity()
    {
      return (_translation == Vector2f.Zero) && (_scale == Vector2f.One) && _orientation == 0.0f;
    }

    /// <summary>
    /// Linearly interpolates between the two given tranformations t1 and t2
    /// where t = 0 means t1 and t = 1 means t2.
    /// The result is returned in target.
    /// </summary>
    /// <param name="t1">The first transform.</param>
    /// <param name="t2">The second transform.</param>
    /// <param name="t">The control parameter.</param>
    /// <param name="target">The interpolated values are returned here.</param>
    public static void Lerp(Transformation t1, Transformation t2, float t, ref Transformation target)
    {
      float negT = 1 - t;
      target.Translation = BasicMath.Lerp(t1.Translation, t2.Translation, t);
      target.Scale = BasicMath.Lerp(t1.Scale, t2.Scale, t);
      target.Orientation = BasicMath.Lerp(t1.Orientation, t2.Orientation, t);
    }

  }
}
