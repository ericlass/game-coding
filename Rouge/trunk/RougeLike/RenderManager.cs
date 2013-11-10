using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;

namespace RougeLike
{
  public class RenderManager
  {
    public void Render()
    {
      if (GameManager.Instance.ActiveScene == null)
        throw new InvalidOperationException("Trying to render when there is no active scene!");

      foreach (Entity entity in GameManager.Instance.ActiveScene.Entities.Items.Values)
      {
        RenderComponent comp = entity.GetComponent<RenderComponent>(RenderComponent.ComponentId);
        if (comp == null)
          continue;

        TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
        if (trans != null)
          OkuManager.Instance.Graphics.ApplyAndPushTransform(trans.Translation, Vector2f.One, 0.0f);

        OkuManager.Instance.Graphics.DrawMesh(comp.Mesh);

        if (trans != null)
          OkuManager.Instance.Graphics.PopTransform();
      }
    }

  }
}
