using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public struct Quad
  {
    public float Left;
    public float Right;
    public float Top;
    public float Bottom;

    public Quad(float left, float right, float top, float bottom)
    {
      Left = left;
      Right = right;
      Top = top;
      Bottom = bottom;
    }

  }
}
