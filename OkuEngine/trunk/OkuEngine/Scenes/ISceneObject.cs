using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Collision;

namespace OkuEngine.Scenes
{
  public interface ISceneObject : ICollidable
  {
    SceneNode SceneNode { get; set; }
    void Render(Scene scene);
  }
}
