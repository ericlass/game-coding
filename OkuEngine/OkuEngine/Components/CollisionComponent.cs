using System;
using System.Collections.Generic;
using OkuEngine.Systems;

namespace OkuEngine.Components
{
  public class CollisionComponent : Component
  {
    private string _eventName = null;
    private bool _isSolid = true;

    public CollisionComponent()
    {
    }

    public CollisionComponent(string eventName, bool isSolid)
    {
      _eventName = eventName;
      _isSolid = isSolid;
    }

    public string EventName
    {
      get { return _eventName; }
      set { _eventName = value; }
    }

    public bool IsSolid
    {
      get { return _isSolid; }
      set { _isSolid = value; }
    }

    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    public override string Name
    {
      get { return "collision"; }
    }

    public override Component Copy()
    {
      throw new NotImplementedException();
    }

  }
}
