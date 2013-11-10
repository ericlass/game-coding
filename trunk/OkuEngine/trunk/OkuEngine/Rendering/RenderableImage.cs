using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  /// <summary>
  /// Defines a renderable that renders a static image.
  /// </summary>
  public class RenderableImage : IRenderable
  {
    private ImageBase _image = null;
    private int _imageId = 0;

    private Rectangle2f _boundingBox = new Rectangle2f();
    private bool _aabbValid = false;

    private Circle _circle = new Circle();
    private bool _circleValid = false;

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
        OkuBase.OkuManager.Instance.Graphics.DrawImage(_image, 0, 0);
    }

    public Rectangle2f GetBoundingBox()
    {
      if (!_aabbValid)
      {
        _boundingBox = new Rectangle2f(_image.Width * -0.5f, _image.Height  * -0.5f, _image.Width, _image.Height);
        _aabbValid = true;
      }
      return _boundingBox;
    }

    public Circle GetBoundingCircle()
    {
      if (!_circleValid)
      {
        _circle = new Circle(Vector2f.Zero, (float)Math.Sqrt(_image.Width * _image.Width + _image.Height * _image.Height) * 0.5f);
        _circleValid = true;
      }

      return _circle;
    }

    public bool AfterLoad()
    {
      _aabbValid = false;
      _image = OkuData.Instance.Images[_imageId];
      if (_image == null)
      {
        OkuBase.OkuManager.Instance.Logging.LogError("There is no image with the id " + _imageId + "!");
        return false;
      }
      return true;
    }

  }
}
