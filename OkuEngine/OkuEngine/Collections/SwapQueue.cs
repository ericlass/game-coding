using System;
using System.Collections.Generic;

namespace OkuEngine.Collections
{
  public class SwapQueue<T>
  {
    private List<T> _activeQueue = new List<T>();
    private List<T> _backgroundQueue = new List<T>();

    public List<T> ActiveQueue
    {
      get { return _activeQueue; }
    }

    public List<T> BackgroundQueue
    {
      get { return _backgroundQueue; }
    }

    public void Swap()
    {
      var temp = _backgroundQueue;
      _backgroundQueue = _activeQueue;
      _activeQueue = _backgroundQueue;
    }

  }
}
