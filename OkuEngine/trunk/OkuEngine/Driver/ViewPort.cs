using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Driver
{
  public class ViewPort
  {
    private Vector _center = Vector.Zero;
    private Vector _scale = Vector.Zero;
    private float _halfWidth = 0;
    private float _halfHeight = 0;

    public ViewPort()
    {
      _halfWidth = OkuData.Globals.Get<int>(OkuConstants.VarScreenWidth) / 2;
      _halfHeight = OkuData.Globals.Get<int>(OkuConstants.VarScreenHeight) / 2;
    }

    public Vector Center
    {
      get { return _center; }
      set { _center = value; }
    }

    public Vector Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public float Left
    {
      get { return _center.X - (_halfWidth * _scale.X); }
      set { _center.X = value + (_halfWidth * _scale.Y); }
    }

    public float Top
    {
      get { return _center.Y - (_halfHeight * _scale.Y); }
      set { _center.Y = value + (_halfHeight * _scale.Y); }
    }

    public float Width
    {
      get { return _halfWidth * 2; }
    }

    public float Height
    {
      get { return _halfHeight * 2; }
    }

  }
}
