using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;

namespace SimGame.Gui
{
  public class Panel : Container
  {
    public override void Render()
    {
      OkuManager.Instance.Graphics.DrawRectangle(0, Width, 0, Height, BackgroundColor);
      foreach (var child in this)
      {
        OkuManager.Instance.Graphics.ApplyAndPushTransform(new Vector2f(child.Left, child.Bottom), Vector2f.One, 0.0f);
        //TODO: Set scissor rect. Need to calculate screen coordinates of widget for that!
        try
        {
          child.Render();
        }
        finally
        {
          OkuManager.Instance.Graphics.PopTransform();
        }
      }
    }
  }
}
