using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a frame based animation with dynamic frame times and frame rate independent perfect timing.
  /// </summary>
  public class Animation
  {
    private List<AnimationFrame> _frames = null;
    private bool _loop = false;
    private int _currentFrame = 0;
    private float _timer = 0.0f;

    /// <summary>
    /// Creates a new animation with no frames.
    /// </summary>
    public Animation()
    {
      _frames = new List<AnimationFrame>();
    }

    /// <summary>
    /// Creates a new animation with the given frames.
    /// </summary>
    /// <param name="frames">The frames of the animation.</param>
    public Animation(List<AnimationFrame> frames)
    {
      _frames = frames;
    }

    /// <summary>
    /// Gets or sets the frames of this animation.
    /// Setting the frames resets the animation to start from the beginning.
    /// </summary>
    public List<AnimationFrame> Frames
    {
      get { return _frames; }
      set
      {
        _frames = value;
        _currentFrame = 0;
        _timer = 0;
      }
    }

    /// <summary>
    /// Gets or sets if the animation is looped.
    /// </summary>
    public bool Loop
    {
      get { return _loop; }
      set { _loop = value; }
    }

    /// <summary>
    /// Advances the animation by the given time. Should be called every frame 
    /// passing the dt parameter of the OkuGame.Update function.
    /// </summary>
    /// <param name="dt">The time that advanced in seconds.</param>
    public void Update(float dt)
    {
      if (_frames.Count > 0)
      {
        _timer -= dt;
        while (_timer < 0.0f)
        {
          int nextFrame = _currentFrame + 1;

          if (nextFrame >= _frames.Count)
            _currentFrame = _loop ? 0 : _currentFrame;
          else
            _currentFrame = nextFrame;
          
          _timer = (_frames[_currentFrame].Duration / 1000.0f) + _timer;
        }
      }
    }

    /// <summary>
    /// Gets the current image that should be displayed
    /// </summary>
    public ImageContent CurrentImage
    {
      get { return _frames[_currentFrame].Image; }
    }

    /// <summary>
    /// Gets the index of the current frame that should be displayed.
    /// </summary>
    public int CurrentImageIndex
    {
      get { return _currentFrame; }
    }

    /// <summary>
    /// Determines if the animations last frame has been reached.
    /// For looped animations this is always false.
    /// </summary>
    public bool IsFinished
    {
      get
      {
        if (!_loop)
          return _currentFrame >= _frames.Count - 1;
        return false;
      }
    }

  }
}
