using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  public interface ISceneNode
  {
    SceneNodeProperties Properties { get; }

    void SetTransform(out Matrix3 toWorld);

    bool Update(Scene scene, float dt);
    bool Restore(Scene scene);

    bool PreRender(Scene scene);
    bool IsVisible(Scene scene);
    bool Render(Scene scene);
    bool RenderChildren(Scene scene);
    bool PostRender(Scene scene);

    bool AddChild(ISceneNode node);
    bool RemoveChild(ISceneNode node);
    bool RemoveChild(int actorId);

    bool OnLostDevice(Scene scene);
  }
}

