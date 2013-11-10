using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Graphics
{
  public class RenderTarget : ImageBase
  {
    internal RenderTarget()
    {
    }

    internal RenderTarget(int width, int height)
    {
      _imageData = new ImageData(width, height, null);
    }

  }
}
