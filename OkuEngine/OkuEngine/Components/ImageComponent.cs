using System;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a simple image for rendering.
  /// </summary>
  public class ImageComponent : IRenderComponent
  {
    private AssetHandle _imageHandle = null;
    private Color _tint = Color.White;

    /// <summary>
    /// Creates a new image component with the given image asset.
    /// </summary>
    /// <param name="imageHandle">The asset handle for the image for this component.</param>
    public ImageComponent(AssetHandle imageHandle)
    {
      if (!imageHandle.IsValid)
        throw new ArgumentException("Given image asset handle is not valid anymore!");

      if (imageHandle.AssetType != AssetType.Image)
        throw new ArgumentException("Trying to create an image component with an asset of type: " + imageHandle.AssetType + "! Only image asset are allowed.");

      _imageHandle = imageHandle;
    }

    /// <summary>
    /// Creates a new image component with the given image asset.
    /// </summary>
    /// <param name="imageHandle">The asset handle for the image for this component.</param>
    /// <param name="tint">The color the image is tinted with.</param>
    public ImageComponent(AssetHandle imageHandle, Color tint) : this(imageHandle)
    {
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
    public AssetHandle ImageHandle
    {
      get { return _imageHandle; }
      set
      {
        if (_imageHandle != value)
        {
          _imageHandle = value;
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
      }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IComponent Copy()
    {
      return new ImageComponent(_imageHandle, _tint);
    }

    public Mesh GetMesh()
    {
      //TODO: Implement
      return null;
    }

  }
}
