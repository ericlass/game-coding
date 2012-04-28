using System;
using System.Windows.Forms;

namespace OkuEngine
{
  public struct RendererParams
  {
    public bool Fullscreen;
    public int Width;
    public int Height;
    public Color ClearColor;
    public int Passes;
    public int[] PassTargets;
    public Control Display;
  }
}