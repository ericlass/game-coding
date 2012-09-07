using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines one image of an animation with it's image and duration.
  /// </summary>
  public class AnimationFrame : IStoreable
  {
    private ImageContent _image = null;
    private float _duration = 0.0f;

    /// <summary>
    /// Creates a new animation frame with no image and a duration of 0.
    /// </summary>
    public AnimationFrame()
    {
    }

    /// <summary>
    /// Creates a new animation frame with the given image and duration.
    /// </summary>
    /// <param name="image">The animation image.</param>
    /// <param name="duration">The duration in milliseconds.</param>
    public AnimationFrame(ImageContent image, float duration)
    {
      _image = image;
      _duration = duration;
    }

    /// <summary>
    /// Gets or sets the image of the animation frame.
    /// </summary>
    public ImageContent Image
    {
      get { return _image; }
      set { _image = value; }
    }

    /// <summary>
    /// Gets or sets the duration this frame is displayed in milliseconds.
    /// </summary>
    public float Duration
    {
      get { return _duration; }
      set { _duration = value; }
    }

    public bool Load(XmlNode node)
    {
      string value = node.GetTagValue("image");
      if (value != null)
      {
        int imageId = 0;
        if (int.TryParse(value, out imageId))
        {
          _image = OkuData.Images[imageId];
        }
      }

      if (_image == null)
      {
        OkuManagers.Logger.LogError("Could not find image for animation frame!" + node.OuterXml);
        return false;
      }

      value = node.GetTagValue("duration");
      if (value != null)
      {
        int dur = 0;
        if (int.TryParse(value, out dur))
          _duration = dur;
      }

      if (_duration == 0.0f)
      {
        OkuManagers.Logger.LogError("No duration specified for animation frame!" + node.OuterXml);
        return false;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("frame");

      writer.WriteValueTag("image", _image.Id.ToString());
      int dur = (int)_duration;
      writer.WriteValueTag("duration", dur.ToString());

      writer.WriteEndElement();

      return true;
    }

  }
}
