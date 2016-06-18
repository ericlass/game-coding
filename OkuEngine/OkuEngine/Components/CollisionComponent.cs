using System;
using OkuEngine.Systems;

namespace OkuEngine.Components
{
  public class CollisionComponent : IComponent
  {
    private ICollisionShape _shape = null;
    private string _eventName = null;
    private bool _isSolid = true;

    public CollisionComponent()
    {
    }

    public CollisionComponent(ICollisionShape shape, string eventName, bool isSolid)
    {
      _shape = shape;
      _eventName = eventName;
      _isSolid = isSolid;
    }

    public ICollisionShape Shape
    {
      get { return _shape; }
      set { _shape = value; }
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

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return "collision"; }
    }

    public IComponent Copy()
    {
      throw new NotImplementedException();
    }

  }
}
