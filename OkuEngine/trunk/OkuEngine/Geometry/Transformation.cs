using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Determines a full transformation with translation, rotation and scale.
  /// </summary>
  public class Transformation : IStoreable
  {
    public static Transformation Identity
    {
      get { return new Transformation(); }
    }

    private Vector2f _translation = Vector2f.Zero;
    private Vector2f _scale = Vector2f.One;
    private float _rotation = 0.0f;

    private bool _matrixValid = false;
    private Matrix3 _matrix = Matrix3.Identity;

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
    public Transformation(Vector2f translation, Vector2f scale, float rotation)
    {
      _translation = translation;
      _scale = scale;
      _rotation = rotation;
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
        _matrixValid = false;
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
    /// Gets or sets the rotation angle in degrees.
    /// </summary>
    public float Rotation 
    {
      get { return _rotation; }
      set 
      {
        _rotation = value;
        _matrixValid = false;
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
        _matrixValid = false;
      }
    }

    /// <summary>
    /// Gets the transformation as a matrix that can be used to combine transformations.
    /// </summary>
    /// <returns>The current transformation as a transformation matrix.</returns>
    public Matrix3 AsMatrix()
    {
      if (!_matrixValid)
      {
        _matrix = Matrix3.Identity;
        _matrix.ApplyTransform(this);
      }
      return _matrix;
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

    /// <summary>
    /// Applies the transformation data of the given transformation to the transformation.
    /// </summary>
    /// <param name="transform">The transform to be applied.</param>
    public void Apply(Transformation transform)
    {
      _translation = transform.Translation;
      _scale = transform.Scale;
      _rotation = transform.Rotation;
      _matrixValid = false;
    }

    /// <summary>
    /// Check if the transformation is an identity transform which means
    /// that it does not do any transformation at all.
    /// </summary>
    /// <returns>True if the transformation is and identity, else false.</returns>
    public bool IsIdentity()
    {
      return (_translation == Vector2f.Zero) && (_scale == Vector2f.One) && _rotation == 0.0f;
    }

    /// <summary>
    /// Loads the transformation from the given xml node.
    /// Before the data is loaded, all transformations are reset.
    /// </summary>
    /// <param name="node">The xml node to read from.</param>
    public bool Load(XmlNode node)
    {
      _translation = Vector2f.Zero;
      _rotation = 0;
      _scale = Vector2f.One;

      string value = node.GetTagValue("position");
      if (value != null)
      {
        Vector2f pos = Vector2f.Zero;
        if (Vector2f.TryParse(value, ref pos))
          _translation = pos;
      }

      value = node.GetTagValue("rotation");
      if (value != null)
      {
        float angle = 0;
        if (float.TryParse(value, out angle))
          _rotation = angle;
      }

      value = node.GetTagValue("scale");
      if (value != null)
      {
        Vector2f scale = Vector2f.Zero;
        if (Vector2f.TryParse(value, ref scale))
          _scale = scale;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("transform");

      writer.WriteValueTag("position", _translation.ToString());
      writer.WriteValueTag("rotation", Converter.FloatToString(_rotation));
      writer.WriteValueTag("scale", _scale.ToString());

      writer.WriteEndElement();

      return true;
    }

  }
}
