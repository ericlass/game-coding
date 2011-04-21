using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  class CameraContent : Content
  {
    private float _width = 0;
    private float _height = 0;

    public override ContentType Type
    {
      get { return ContentType.System; }
    }

    public override int ContentKey
    {
      get { return -3; }
    }

    public float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    public float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    public float GetRatio()
    {
      return _width / _height;
    }

  }
}
