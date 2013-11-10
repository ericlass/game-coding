using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Graphics
{
  public abstract class ImageBase
  {
    private int _id = KeySequence.NextValue(KeySequence.ImageSequence);
    protected ImageData _imageData = null;

    /// <summary>
    /// Gets the unique id of this image.
    /// </summary>
    public int Id
    {
      get { return _id; }
    }

    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    public int Width
    {
      get { return _imageData != null ? _imageData.Width : 0; }
    }

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    public int Height
    {
      get { return _imageData != null ? _imageData.Height : 0; }
    }

  }
}
