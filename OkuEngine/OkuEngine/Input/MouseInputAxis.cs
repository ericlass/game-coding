using System;
using System.Collections.Generic;
using OkuBase;

namespace OkuEngine.Input
{
  public class MouseInputAxis : IInputAxis
  {
    private float _scaleX = 0.0f;
    private float _scaleY = 0.0f;

    public MouseInputAxis(float scaleX, float scaleY)
    {
      _scaleX = scaleX;
      _scaleY = scaleY;
    }

    public float ScaleX
    {
      get { return _scaleX; }
      set { _scaleX = value; }
    }

    public float ScaleY
    {
      get { return _scaleY; }
      set { _scaleY = value; }
    }

    public float GetCurrentValue()
    {
      float x = OkuManager.Instance.Input.Mouse.RelativeX * _scaleX;
      float y = OkuManager.Instance.Input.Mouse.RelativeY * _scaleY;

      return x + y;
    }

  }
}
