using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using RougeLike.Objects;

namespace RougeLike.Renderers
{
  public class AnimationRenderer : IEntityRenderer
  {
    private string _animationName = null;
    private Animation _anim = null;

    public AnimationRenderer(string animationName)
    {
      _animationName = animationName;
    }

    public string AnimationName
    {
      get { return _animationName; }
      set { _animationName = value; }
    }

    public void Update(float dt, EntityObject entity)
    {
      _anim.Update(dt);
    }

    public void Render(EntityObject entity)
    {
      OkuBase.OkuManager.Instance.Graphics.DrawImage(_anim.CurrentFrame, 0, 0);
    }

    public void Init()
    {
      _anim = GameUtil.LoadAnimation(_animationName);
    }

    public void Begin(EntityObject entity)
    {
      _anim.Restart();
    }

    public void End(EntityObject entity)
    {
    }

    public void Finish()
    {
      foreach (ImageBase image in _anim.Frames)
      {
        if (image is Image)
          OkuBase.OkuManager.Instance.Graphics.ReleaseImage(image as Image);
      }
    }

  }
}
