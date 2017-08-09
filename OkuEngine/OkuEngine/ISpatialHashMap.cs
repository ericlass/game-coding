using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine
{
  public interface ISpatialHashMap
  {
    void AddOrUpdate(Entity entity);
    void Remove(Entity entity);
    void Clear();
    SortedSet<Entity> GetItemsNear(Entity entity);
    SortedSet<Entity> GetItemsForAABB(Vector2f min, Vector2f max);
  }
}
