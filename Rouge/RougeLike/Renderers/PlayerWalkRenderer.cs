using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using RougeLike.Objects;
using RougeLike.Attributes;

namespace RougeLike.Renderers
{
  public class PlayerWalkRenderer : IEntityRenderer
  {
    private string _animationName = null;
    private Animation _anim = null;

    public PlayerWalkRenderer(string animationName)
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
      float speedx = entity.GetAttributeValue<NumberValue>("speedx").Value;
      float direction = entity.GetAttributeValue<NumberValue>("direction").Value;

      if (speedx == 0.0f)
        OkuBase.OkuManager.Instance.Graphics.DrawImage(_anim.Frames[0], 0, 0, 0, direction, 1, Color.White);
      else
        OkuBase.OkuManager.Instance.Graphics.DrawImage(_anim.CurrentFrame, 0, 0, 0, direction, 1, Color.White);
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
