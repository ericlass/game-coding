using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple image for rendering.
  /// </summary>
  public class ImageComponent : IComponent
  {
    /// <summary>
    /// The unique name of this component.
    /// </summary>
    public const string ComponentName = "image";

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

    public bool IsMultiAssignable
    {
      get { return true; }
    }

    public string Name
    {
      get { return ComponentName; }
    }

    /// <summary>
    /// Gets or set the image.
    /// </summary>
    public ImageBase Image
    {
      get { return _image; }
      set { _image = value; }
    }

    public IComponent Copy()
    {
      return new ImageComponent(_image);
    }

  }
}
