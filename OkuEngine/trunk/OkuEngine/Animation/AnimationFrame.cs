using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines one image of an animation with it's image and duration.
  /// </summary>
  public class AnimationFrame
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

  }
}
