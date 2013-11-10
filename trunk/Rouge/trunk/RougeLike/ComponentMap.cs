using System;
using System.Collections.Generic;

namespace RougeLike
{
  public class ComponentMap : IdObjectMap<IComponent>, IUpdatable
  {
    public void Update(float dt)
    {
      foreach (IComponent component in _objects.Values)
        component.Update(dt);
    }
  }
}
