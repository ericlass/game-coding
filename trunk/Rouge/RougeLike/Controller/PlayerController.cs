using System;
using System.Collections.Generic;
using OkuBase;
using RougeLike.Objects;

namespace RougeLike.Controller
{
  public class PlayerController : IEntityController
  {
    public bool DoMoveLeft(EntityObject entity)
    {
      return OkuManager.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A);
    }

    public bool DoMoveRight(EntityObject entity)
    {
      return OkuManager.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D);
    }

    public bool DoJump(EntityObject entity)
    {
      return OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.W);
    }
  }
}
