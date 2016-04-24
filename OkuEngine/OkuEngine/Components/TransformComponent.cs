using System;
using OkuMath;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple transformation with translation, rotation and scale.
  /// </summary>
  public class TransformComponent : IComponent
  {
    //TODO: Split this into four components, so the values can be overriden individually.

    public const string ComponentName = "transform";

    private Vector2f _translation = Vector2f.Zero;
    private float _rotation = 0.0f;
    private Vector2f _scale = Vector2f.One;
    private bool _screenSpace = false;

    public TransformComponent()
    {
    }

    public TransformComponent(Vector2f translation, float rotation, Vector2f scale)
    {
      _translation = translation;
      _rotation = rotation;
      _scale = scale;
    }

    public TransformComponent(Vector2f translation, float rotation, Vector2f scale, bool screenSpace)
    {
      _translation = translation;
      _rotation = rotation;
      _scale = scale;
      _screenSpace = screenSpace;
    }

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

    public IComponent Copy()
    {
      return new TransformComponent(_translation, _rotation, _scale, _screenSpace);
    }

  }
}
