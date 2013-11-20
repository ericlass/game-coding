using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public class RenderManager
  {
    private RenderTarget _target = null;

    public void Initialize()
    {
      _target = OkuManager.Instance.Graphics.NewRenderTarget(640, 360);
    }

    public void Render()
    {
      if (GameManager.Instance.ActiveScene == null)
        throw new InvalidOperationException("Trying to render when there is no active scene!");

      if (_target == null)
        throw new InvalidOperationException("RenderManager was not initialized!");

      OkuManager.Instance.Graphics.Viewport.SetValues(_target.Width * -0.5f, _target.Width * 0.5f, _target.Height * -0.5f, _target.Height * 0.5f);
      OkuManager.Instance.Graphics.SetRenderTarget(_target);
      OkuManager.Instance.Graphics.BackgroundColor = Color.White;
      OkuManager.Instance.Graphics.Clear();
      

      foreach (Entity entity in GameManager.Instance.ActiveScene.Entities.Items.Values)
      {
        RenderComponent comp = entity.GetComponent<RenderComponent>(RenderComponent.ComponentId);
        if (comp == null)
          continue;

        TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
        if (trans != null)
          OkuManager.Instance.Graphics.ApplyAndPushTransform(trans.Translation, Vector2f.One, 0.0f);

        OkuManager.Instance.Graphics.DrawImage(comp.Animation.CurrentFrame, 0, 0);

        if (trans != null)
          OkuManager.Instance.Graphics.PopTransform();
      }

      OkuManager.Instance.Graphics.Viewport.SetValues(-_target.Width, _target.Width, -_target.Height, _target.Height);
      OkuManager.Instance.Graphics.SetRenderTarget(null);
      OkuManager.Instance.Graphics.BackgroundColor = Color.Magenta;
      OkuManager.Instance.Graphics.Clear();

      OkuManager.Instance.Graphics.DrawScreenAlignedQuad(_target);
    }

  }
}
