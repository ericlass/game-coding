using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// Defines one image of an animation with it's image and duration.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class AnimationFrame : IStoreable
  {
    private int _imageId = 0;
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
    /// <param name="imageId">The frames image id.</param>
    /// <param name="duration">The duration in milliseconds.</param>
    public AnimationFrame(int imageId, float duration)
    {
      _imageId = imageId;
      _duration = duration;
    }

    /// <summary>
    /// Gets or sets the id of the image of this frame.
    /// </summary>
    [JsonPropertyAttribute]
    public int ImageId
    {
      get { return _imageId; }
      set { _imageId = value; }
    }

    /// <summary>
    /// Gets or sets the duration this frame is displayed in milliseconds.
    /// </summary>
    [JsonPropertyAttribute]
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
        _imageId = 0;
        if (!int.TryParse(value, out _imageId))
        {
          OkuManagers.Logger.LogError("Could not find image for animation frame!" + node.OuterXml);
          return false;
        }
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

      writer.WriteValueTag("image", _imageId.ToString());
      int dur = (int)_duration;
      writer.WriteValueTag("duration", dur.ToString());

      writer.WriteEndElement();

      return true;
    }

  }
}
