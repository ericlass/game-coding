using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase.Graphics;

namespace OkuEngine
{
  /// <summary>
  /// Defines one image of an animation with it's image and duration.
  /// </summary>
  public class AnimationFrame
  {
    private ImageBase _image = null;
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
    public AnimationFrame(ImageBase image, float duration)
    {
      _image = image;
      _duration = duration;
    }

    /// <summary>
    /// Gets or sets the id of the image of this frame.
    /// </summary>
    public ImageBase Image
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

    public bool AfterLoad()
    {
      return true;
    }

  }
}
