using System;
using OkuMath;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple transformation with translation, rotation and scale.
  /// </summary>
  public class TransformComponent : IComponent
  {
    public const string ComponentName = "transform";

    private Vector2f _translation = Vector2f.Zero;
    private float _rotation = 0.0f;
    private Vector2f _scale = Vector2f.One;
    private bool _screenSpace = false;

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return ComponentName; }
    }

    /// <summary>
    /// Gets or sets the translation of the transform.
    /// </summary>
    public Vector2f Translation
    {
      get { return _translation; }
      set { _translation = value; }
    }

    /// <summary>
    /// Gets or sets the scale of the transform.
    /// </summary>
    public Vector2f Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    /// <summary>
    /// Gets or sets the rotation of the transform in degrees.
    /// </summary>
    public float Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    /// <summary>
    /// Gets or sets if the transformation is given in world or screen space coordinates.
    /// </summary>
    public bool ScreenSpace
    {
      get { return _screenSpace; }
      set { _screenSpace = value; }
    }

    /// <summary>
    /// Gets the transformation as a 3x3 matrix. The transformation are applied in the order T * R * S.
    /// </summary>
    public Matrix3x3f AsMatrix
    {
      get
      {
        return Matrix3x3f.Translate(_translation.X, _translation.Y) * Matrix3x3f.Rotation(_rotation) * Matrix3x3f.Scale(_scale.X, _scale.Y);
      }
    }

  }
}
