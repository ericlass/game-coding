using System;
using System.Collections.Generic;
using SimGame.Objects;

namespace SimGame.Gui
{
  public class Dialog : GameObjectBase
  {
    public int Left { get; set; }
    public int Bottom { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public bool DrawBorder { get; set; }

    public Container Content { get; set; }

    public override void Render(GameObject obj)
    {
      if (DrawBorder)
      {
        //TODO: Draw dialog border around content
      }

      //TODO: Set transform and scissor rectangle
      Content.Render();
    }

  }
}
