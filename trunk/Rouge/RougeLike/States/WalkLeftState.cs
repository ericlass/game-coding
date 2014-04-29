using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.States
{
  public class WalkLeftState : StateBase
  {
    private ImageBase _image = null;

    public override string Id
    {
      get { return "walkleft"; }
    }

    public override void Init()
    {
      _image = GameUtil.LoadImage("mario_left.png");
    }

    public override void Enter()
    {
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      gameObject.Position = gameObject.Position + new Vector2f(-150 * dt, 0);
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
