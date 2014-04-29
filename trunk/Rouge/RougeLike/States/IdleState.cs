using System;
using System.Collections.Generic;
using OkuBase.Graphics;

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

    public override void Enter()
    {
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
      Oku.Graphics.DrawImage(_image, 0, 0);
    }

    public override void Leave()
    {
    }

    public override void Finish()
    {
      Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
