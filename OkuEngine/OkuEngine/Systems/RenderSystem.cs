using System;
using System.Collections.Generic;
using OkuEngine.Components;
using OkuBase.Graphics;

namespace OkuEngine.Systems
{
  public class RenderSystem : EngineSystem
  {
    public override string Name
    {
      get { return "render"; }
    }

    public override void Execute()
    {
      GraphicsManager graphics = Engine.Instance.Oku.Graphics;

      foreach (var entity in Engine.Instance.CurrentLevel.Entities)
      {
        bool hasTransform = entity.ContainsComponent(TransformComponent.ComponentName);
        if (hasTransform)
        {
          var transform = (TransformComponent)entity.GetComponent(TransformComponent.ComponentName);
          graphics.ApplyAndPushTransform(transform.Translation, transform.Scale, transform.Rotation);
        }

        if (entity.ContainsComponent(ImageComponent.ComponentName))
        {
          var image = (ImageComponent)entity.GetComponent(ImageComponent.ComponentName);
          graphics.DrawImage(image.Image, 0, 0);
        }

        if (hasTransform)
        {
          graphics.PopTransform();
        }
      }
    }

    public override void Finish()
    {
      //TODO: Finish required?
    }

    public override void Init()
    {
      //TODO: Init required?
    }
  }
}
