using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  /// <summary>
  /// Defines a renderable that renders a static image.
  /// </summary>
  public class RenderableImage : IRenderable
  {
    private ImageContent _image = null;
    private int _imageId = 0;

    private AABB _boundingBox = new AABB();
    private bool _aabbValid = false;

    public void Update(float dt)
    {
      //Nothing to do for an image
    }

    /// <summary>
    /// Gets or sets the id of image to be rendered.
    /// </summary>
    [JsonPropertyAttribute]
    public int ImageId
    {
      get { return _imageId; }
      set { _imageId = value; }
    }

    public void Render(Scene scene)
    {
      if (_image != null)
        OkuDrivers.Instance.Renderer.DrawImage(_image, Vector2f.Zero);
    }

    public AABB GetBoundingBox()
    {
      if (!_aabbValid)
      {
        _boundingBox = new AABB(_image.Width * -0.5f, _image.Height  * -0.5f, _image.Width, _image.Height);
        _aabbValid = true;
      }
      return _boundingBox;
    }

    public IRenderable Copy()
    {
      RenderableImage result = new RenderableImage();
      result._image = _image;
      result._imageId = _imageId;
      return result;
    }

    public bool AfterLoad()
    {
      _aabbValid = false;
      _image = OkuData.Instance.Images[_imageId];
      if (_image == null)
      {
        OkuManagers.Instance.Logger.LogError("There is no image with the id " + _imageId + "!");
        return false;
      }
      return true;
    }

  }
}
