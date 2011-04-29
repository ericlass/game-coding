using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public abstract class VisualInstance : ContentInstance
  {
    public abstract void Draw(Matrix3 transform);
  }
}
