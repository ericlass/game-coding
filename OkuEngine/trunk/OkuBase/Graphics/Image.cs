using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines a single image.
  /// </summary>
  public class Image : ImageBase
  {
    private bool _compressed = false;

    /// <summary>
    /// Creates a new empty image with no pixel data.
    /// Do not use directly. Use Graphics.NewImage().
    /// </summary>
    internal Image()
    {
    }

    /// <summary>
    /// Creates a new image with the given pixel data.
    /// Do not use directly. Use Graphics.NewImage().
    /// </summary>
    /// <param name="data">The pixel data of the new image.</param>
    internal Image(ImageData data)
    {
      _imageData = data;
    }

    /// <summary>
    /// Creates a new image with the given pixel data.
    /// Do not use directly. Use Graphics.NewImage().
    /// </summary>
    /// <param name="data">The pixel data of the new image.</param>
    /// <param name="isCompressed">Determines if the image is compressed or not.</param>
    internal Image(ImageData data, bool isCompressed)
    {
      _imageData = data;
      _compressed = isCompressed;
    }

    /// <summary>
    /// Gets if the image is compressed or not.
    /// </summary>
    public bool IsCompressed
    {
      get { return _compressed; }
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
