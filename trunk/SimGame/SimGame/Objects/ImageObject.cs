using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace SimGame.Objects
{
  /// <summary>
  /// A simple object that draws a static image.
  /// The image origin is the lower left corner.
  /// </summary>
  public class ImageObject : GameObjectBase
  {
    public ImageBase _image = null;

    /// <summary>
    /// Creates a new object with the given image.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    public ImageObject(ImageBase image)
    {
      _image = image;
    }

    /// <summary>
    /// Render the image.
    /// </summary>
    /// <param name="obj">The parent game object.</param>
    public override void Render(GameObject obj)
    {
      Oku.Graphics.DrawImage(_image, _image.Width / 2, _image.Height / 2);
    }
  }
}
