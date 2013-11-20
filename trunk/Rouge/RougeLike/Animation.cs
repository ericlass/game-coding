using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace RougeLike
{
  public class Animation : IUpdatable
  {
    private List<ImageBase> _frames = new List<ImageBase>();
    private int _frameTime = 40;
    private bool _loop = false;

    private int _currentFrame = 0;
    private float _frameStep = 0.04f;
    private float _timeOut = 0;

    public Animation()
    {
    }

    public List<ImageBase> Frames
    {
      get { return _frames; }
      set { _frames = value; }
    }

    public int FrameTime
    {
      get { return _frameTime; }
      set 
      {
        _frameTime = value;
        _frameStep = value / 1000.0f;
      }
    }

    public bool Loop
    {
      get { return _loop; }
      set { _loop = value; }
    }

    public ImageBase CurrentFrame
    {
      get { return _frames[_currentFrame]; }
    }

    public bool Finished
    {
      get { return _currentFrame >= _frames.Count; }
    }
    
    public void Update(float dt)
    {
      if (_frames.Count == 1)
        return;

      _timeOut -= dt;

      while (_timeOut <= 0)
      {
        _timeOut += _frameStep;
        _currentFrame++;
      }

      int lastFrame = _currentFrame;

      if (_currentFrame >= _frames.Count)
      {
        if (_loop)
          _currentFrame = _currentFrame % _frames.Count;
        else
          _currentFrame = _frames.Count - 1;
      }
    }    

    public void Restart()
    {
      _timeOut = _frameStep;
      _currentFrame = 0;
    }

  }
}
