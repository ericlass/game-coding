using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class SceneMap : IdObjectMap<Scene>, IUpdatable
  {
    public void Update(float dt)
    {
      foreach (Scene scene in _objects.Values)
      {
        scene.Update(dt);
      }
    }
  }
}
