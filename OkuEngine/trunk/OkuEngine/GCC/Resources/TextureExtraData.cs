using System;
using System.Collections.Generic;
using System.Drawing;

namespace OkuEngine.GCC.Resources
{
  public class TextureExtraData : IResourceExtraData
  {
    private Bitmap _image = null;

    public TextureExtraData(Bitmap image)
    {
      _image = image;
    }

    public Bitmap Image
    {
      get { return _image; }
      set { _image = value; }
    }

  }
}
