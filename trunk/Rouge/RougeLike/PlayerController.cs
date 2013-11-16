using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;

namespace RougeLike
{
  public class PlayerController : ControllerProcess
  {
    public override bool IsMoving(Entity entity, ref Vector2f movement)
    {
      const float speed = 100;

      movement.X = 0;
      movement.Y = 0;

      bool result = false;

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Up))
      {
        movement.Y += speed;
        result = true;
      }
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Down))
      {
        movement.Y -= speed;
        result = true;
      }
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Left))
      {
        movement.X -= speed;
        result = true;
      }
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Right))
      {
        movement.X += speed;
        result = true;
      }

      return result;
    }

    public override bool IsAttacking(Entity entity)
    {
      return false;
    }
  }
}
