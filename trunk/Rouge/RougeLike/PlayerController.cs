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

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Up) || OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.W))
        movement.Y += speed;

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Down) || OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.S))
        movement.Y -= speed;

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Left) || OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.A))
        movement.X -= speed;

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Right) || OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.D))
        movement.X += speed;

      bool moves = Math.Abs(movement.X) > 0 || Math.Abs(movement.Y) > 0;
      if (moves)
      {
        movement.Normalize();
        movement.Scale(speed);
      }

      return moves;
    }

    public override bool IsAttacking(Entity entity)
    {
      return false;
    }
  }
}
