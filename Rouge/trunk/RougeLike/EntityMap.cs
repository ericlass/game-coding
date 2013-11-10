using System;

namespace RougeLike
{
  public class EntityMap : IdObjectMap<Entity>, IUpdatable
  {
    public void Update(float dt)
    {
      foreach (Entity entity in _objects.Values)
        entity.Update(dt);
    }
  }
}