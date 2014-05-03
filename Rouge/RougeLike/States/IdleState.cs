using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using RougeLike.Attributes;

namespace RougeLike.States
{
  public class IdleState : StateBase
  {
    private ImageBase _image = null;

    public override string Id
    {
      get { return "idle"; }
    }

    public override void Init()
    {
      _image = GameUtil.LoadImage("mario_idle.png");
    }

    public override void Enter(GameObjectBase gameObject)
    {
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
    }

    public override void Render(GameObjectBase gameObject)
    {
      NumberValue value = gameObject.GetAttributeValue<NumberValue>("direction");
      float sx = 1;
      if (value != null)
        sx = (float)value.Value;

      Oku.Graphics.DrawImage(_image, 0, 0, 0, sx, 1, Color.White);
    }

    public override void Leave(GameObjectBase gameObject)
    {
    }

    public override void Finish()
    {
      Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
