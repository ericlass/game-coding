using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class RenderSystem : EngineSystem
  {
    public override void Init(Level currentLevel)
    {
      //TODO: Init required?
    }

    public override void Execute(Level currentLevel)
    {
      GraphicsManager graphics = OkuManager.Instance.Graphics;

      foreach (var entity in currentLevel.Entities)
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

    public override void Finish(Level currentLevel)
    {
      //TODO: Finish required?
    }

  }
}
