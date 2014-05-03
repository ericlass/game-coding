using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;

namespace RougeLike.States
{
  public class WalkRightState : StateBase
  {
    private Animation _anim = null;
    private NumberValue _direction = new NumberValue(1);

    public override string Id
    {
      get { return "walkright"; }
    }

    public override void Init()
    {
      ImageBase frame0Img = GameUtil.LoadImage("mario_idle.png");
      ImageBase frame1Img = GameUtil.LoadImage("mario_right.png");

      _anim = new Animation();
      _anim.Frames.Add(frame0Img);
      _anim.Frames.Add(frame1Img);
      _anim.FrameTime = 50;
      _anim.Loop = true;
    }

    public override void Enter(GameObjectBase gameObject)
    {
      gameObject.SetAttributeValue("direction", _direction);
      _anim.Restart();
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      gameObject.Position = gameObject.Position + new Vector2f(200 * dt, 0);
      _anim.Update(dt);
    }

    public override void Render(GameObjectBase gameObject)
    {
      Oku.Graphics.DrawImage(_anim.CurrentFrame, 0, 0);
    }

    public override void Leave(GameObjectBase gameObject)
    {
    }

    public override void Finish()
    {
      foreach (ImageBase img in _anim.Frames)
        Oku.Graphics.ReleaseImage(img as Image);
    }
  }
}
