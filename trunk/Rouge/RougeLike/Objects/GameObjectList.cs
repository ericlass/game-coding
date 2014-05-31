using System;
using System.Collections.Generic;

namespace RougeLike.Objects
{
  public class GameObjectList : List<GameObjectBase>
  {
    private class GameObjectComparer : IComparer<GameObjectBase>
    {
      public int Compare(GameObjectBase x, GameObjectBase y)
      {
        if (x.ZIndex == y.ZIndex)
          return (int)(x.Position.Y - y.Position.Y) * -1;
        else
          return x.ZIndex - y.ZIndex;
      }
    }

    private GameObjectComparer _comparer = new GameObjectComparer();

    public new void Sort()
    {
      Sort(_comparer);
    }

    public void SortStable()
    {
      for (int i = 1; i < Count; i++)
      {
        GameObjectBase x = this[i];
        int j = i;
        while (j > 0 && _comparer.Compare(this[j-1], x) > 0)
        {
          this[j] = this[j-1];
          j--;
        }
        this[j] = x;
      }
    }

    public GameObjectBase GetObjectById(string id)
    {
      foreach (GameObjectBase obj in this)
      {
        if (obj.Id == id)
          return obj;
      }
      return null;
    }

    public List<T> GetObjectsOfType<T>() where T : GameObjectBase
    {
      List<T> result = new List<T>();
      foreach (GameObjectBase obj in this)
      {
        if (obj is T)
          result.Add(obj as T);
      }
      return result;
    }

  }
}
