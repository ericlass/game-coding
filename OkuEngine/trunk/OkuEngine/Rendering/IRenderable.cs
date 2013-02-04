using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;

namespace OkuEngine
{
  public interface IRenderable : IStoreable
  {
    void Update(float dt);
    void Render(Scene scene);
    AABB GetBoundingBox();

    IRenderable Copy();
  }
}
