using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines a single image.
  /// </summary>
  public class Image
  {
    private int _id = KeySequence.NextValue(KeySequence.ImageSequence);
    private ImageData _imageData = null;

    /// <summary>
    /// Creates a new empty image with no pixel data.
    /// </summary>
    public Image()
    {
    }

    /// <summary>
    /// Creates a new image with the given pixel data.
    /// </summary>
    /// <param name="data">The pixel data of the new image.</param>
    public Image(ImageData data)
    {
      _imageData = data;
    }

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

    /// <summary>
    /// Gets the raw image pixel data of the image.
    /// </summary>
    public ImageData ImageData
    {
      get { return _imageData; }
    }

  }
}
