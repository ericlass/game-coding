using System;
using System.Collections.Generic;

namespace RougeLike
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

  }
}
