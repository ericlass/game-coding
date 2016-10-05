using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine
{
  public interface ISpatialHashMap
  {
    //Suposed to add the given poly to the spatial map, referenced by the given group and id.
    void AddOrUpdate(int group, int id, Vector2f[] poly);
    //Supposed to remove the poly with the given group and id from the spatial map.
    void Remove(int group, int id);
    //Supposed to update all references of the poly with the given id in all groups.
    void UpdateAll(int id, Vector2f[] poly);
    //Supposed to remove all references of the poly with the given id in all groups.
    void RemoveAll(int id);
    //Supposed to get all items near the item with the given group and id.
    SortedSet<int> GetItemsNear(int group, int id);
    //Supposed to get all items that are in cells that touch the AABB given by [min,max].
    SortedSet<int> GetItemsForAABB(int group, Vector2f min, Vector2f max);
  }
}
