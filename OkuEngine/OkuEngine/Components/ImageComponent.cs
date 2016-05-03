using System;
using System.Collections.Generic;
using OkuMath;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuEngine.Systems;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple image for rendering.
  /// </summary>
  public class ImageComponent : IRenderComponent
  {
    private ImageBase _image = null;
    private Color _tint = Color.White;
    private Mesh _mesh = null;

    /// <summary>
    /// Creates a new image component.
    /// </summary>
    public ImageComponent()
    {
    }

    /// <summary>
    /// Creates a new image component with the given image.
    /// </summary>
    /// <param name="image">The image for this component.</param>
    public ImageComponent(ImageBase image)
    {
      _image = image;
    }

    /// <summary>
    /// Creates a new image component with the given image.
    /// </summary>
    /// <param name="image">The image for this component.</param>
    /// <param name="tint">The color the image is tinted with.</param>
    public ImageComponent(ImageBase image, Color tint)
    {
      _image = image;
      _tint = tint;
    }

    /// <summary>
    /// Gets if the component can be assigned multiple times to the same entity.
    /// </summary>
    public bool IsMultiAssignable
    {
      get { return true; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string Name
    {
      get { return "image"; }
    }

    /// <summary>
    /// Gets or set the image.
    /// </summary>
    public ImageBase Image
    {
      get { return _image; }
      set
      {
        if (_image != value)
        {
          _image = value;
          _mesh = null;
        }
      }
    }

    /// <summary>
    /// Gets or sets the color the image is tinted with.
    /// </summary>
    public Color Tint
    {
      get { return _tint; }
      set
      {
        _tint = value;
        _mesh = null;
      }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IComponent Copy()
    {
      return new ImageComponent(_image, _tint);
    }

    public Mesh GetMesh()
    {
      if (_mesh == null && _image != null)
        _mesh = Mesh.ForImage(_image, _tint);

      return _mesh;
    }
  }
}
