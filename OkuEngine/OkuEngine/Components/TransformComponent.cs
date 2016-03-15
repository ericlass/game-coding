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
    /// Gets or sets the rotation of the transform.
    /// </summary>
    public float Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

  }
}
