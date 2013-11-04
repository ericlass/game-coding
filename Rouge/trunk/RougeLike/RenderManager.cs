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
      foreach (Entity entity in GameManager.Instance.Entities.Items.Values)
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
