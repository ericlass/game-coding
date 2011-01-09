using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class Transformation
  {
    private Vector _translation = new Vector();
    private Vector _scale = new Vector(1, 1);
    private float _rotation = 0.0f;

    public Vector Translation 
    {
      get { return _translation; }
      set { _translation = value; }
    }

    public float Rotation 
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    public Vector Scale 
    {
      get { return _scale; }
      set { _scale = value; }
    }

  }
}
