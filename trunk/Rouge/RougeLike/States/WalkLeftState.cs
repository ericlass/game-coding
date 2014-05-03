﻿using System;
using System.Collections.Generic;
using RougeLike.Attributes;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.States
{
  public class WalkLeftState : StateBase
  {
    private Animation _anim = null;
    private NumberValue _direction = new NumberValue(-1);
    private float _speed = 0;

    public override string Id
    {
      get { return "walkleft"; }
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
      _speed = 0;
      gameObject.SetAttributeValue("direction", _direction);
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      _speed = Math.Min(_speed + (800 * dt), 200);
      gameObject.Position = gameObject.Position + new Vector2f(-_speed * dt, 0);
      _anim.Update(dt);      
    }

    public override void Render(GameObjectBase gameObject)
    {
      Oku.Graphics.DrawImage(_anim.CurrentFrame, 0, 0, 0, -1, 1, Color.White);
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
