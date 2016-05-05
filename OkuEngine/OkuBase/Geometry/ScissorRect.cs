using System;

namespace OkuBase.Geometry
{
  public class ScissorRect
  {
    public int Left { get; set; }
    public int Right { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public ScissorRect()
    {
    }

    public ScissorRect(int left, int right, int width, int height)
    {
      Left = left;
      Right = right;
      Width = width;
      Height = height;
    }
  }
}
