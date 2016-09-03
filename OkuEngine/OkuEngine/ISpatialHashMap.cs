using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine
{
  public interface ISpatialHashMap
  {
    void AddOrUpdate(int group, int id, Vector2f[] poly);
    void Remove(int group, int id);
    SortedSet<int> GetItemsNear(int group, int id);
    SortedSet<int> GetItemsForAABB(int group, Vector2f min, Vector2f max);
  }
}
