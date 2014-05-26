using System;
using System.Collections.Generic;
using RougeLike.Attributes;

namespace RougeLike
{
  public class AIController : IEntityController
  {
    private bool _movingLeft = false;
    private bool _movingRight = false;

    public bool DoMoveLeft(EntityObject entity)
    {
      if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Left))
      {
        _movingRight = false;
        _movingLeft = true;
      }

      if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Down))
        _movingLeft = false;

      return _movingLeft;
    }

    public bool DoMoveRight(EntityObject entity)
    {
      if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Right))
      {
        _movingRight = true;
        _movingLeft = false;
      }

      if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Down))
        _movingRight = false;

      return _movingRight;
    }

    public bool DoJump(EntityObject entity)
    {
      if (_movingLeft || _movingRight)
      {
        if (Math.Abs(entity.GetAttributeValue<NumberValue>("speedx").Value) < 0.1)
          return true;
      }

      return false;
    }

  }
}
