using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public class ImageAsset : Asset
  {
    private ImageBase _image = null;

    public ImageAsset()
    {
    }

    public ImageAsset(ImageBase image)
    {
      _image = image;
    }

    public ImageBase Image
    {
      get { return _image; }
      set { _image = value; }
    }

  }
}
