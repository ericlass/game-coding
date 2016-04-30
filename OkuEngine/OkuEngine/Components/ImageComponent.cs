using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuEngine.Systems;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple image for rendering.
  /// </summary>
  public class ImageComponent : IComponent
  {
    private ImageBase _image = null;

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
      set { _image = value; }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IComponent Copy()
    {
      return new ImageComponent(_image);
    }

  }
}
