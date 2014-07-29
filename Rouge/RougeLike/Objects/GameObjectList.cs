using System;
using System.Collections;
using System.Collections.Generic;

namespace RougeLike.Objects
{
  public class GameObjectList : IEnumerable<GameObjectBase>
  {
    private class GameObjectComparer : IComparer<GameObjectBase>
    {
      public int Compare(GameObjectBase x, GameObjectBase y)
      {
        return x.ZIndex - y.ZIndex;
      }
    }

    private GameObjectComparer _comparer = new GameObjectComparer();

    private List<GameObjectBase> _allObjects = new List<GameObjectBase>();
    private Dictionary<string, GameObjectBase> _idMap = new Dictionary<string, GameObjectBase>();
    private Dictionary<int, List<GameObjectBase>> _groupMap = new Dictionary<int, List<GameObjectBase>>();

    public void Sort()
    {
      _allObjects.Sort(_comparer);
    }

    public void SortStable()
    {
      for (int i = 1; i < _allObjects.Count; i++)
      {
        GameObjectBase x = _allObjects[i];
        int j = i;
        while (j > 0 && _comparer.Compare(_allObjects[j-1], x) > 0)
        {
          _allObjects[j] = _allObjects[j-1];
          j--;
        }
        _allObjects[j] = x;
      }
    }

    public void Add(GameObjectBase gameObject)
    {
      _allObjects.Add(gameObject);
      _idMap.Add(gameObject.Id, gameObject);
      if (!_groupMap.ContainsKey(gameObject.GroupIndex))
        _groupMap.Add(gameObject.GroupIndex, new List<GameObjectBase>());
      _groupMap[gameObject.GroupIndex].Add(gameObject);
    }

    public void Remove(GameObjectBase gameObject)
    {
      _allObjects.Remove(gameObject);
      _idMap.Remove(gameObject.Id);
      _groupMap[gameObject.GroupIndex].Remove(gameObject);
      if (_groupMap[gameObject.GroupIndex].Count == 0)
        _groupMap.Remove(gameObject.GroupIndex);
    }

    public GameObjectBase GetObjectById(string id)
    {
      if (_idMap.ContainsKey(id))
        return _idMap[id];

      return null;
    }

    public List<GameObjectBase> GetObjectsOfGroup(int groupIndex)
    {
      if (_groupMap.ContainsKey(groupIndex))
        return _groupMap[groupIndex];

      return null;
    }

    public IEnumerator<GameObjectBase> GetEnumerator()
    {
      return _allObjects.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _allObjects.GetEnumerator();
    }

  }
}
