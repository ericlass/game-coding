using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Graphics
{
  public class Image
  {
    private int _id = KeySequence.NextValue(KeySequence.ImageSequence);
    private int _width = 0;
    private int _height = 0;

    public Image()
    {
    }

    public int Id
    {
      get { return _id; }
    }

    public int Width
    {
      get { return _width; }
    }

    internal void SetWidth(int width)
    {
      _width = width;
    }

    public int Height
    {
      get { return _height; }
    }

    internal void SetHeight(int height)
    {
      _height = height;
    }

  }
}
