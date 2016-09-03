using System;
using OkuEngine.Systems;

namespace OkuEngine.Components
{
  public class CollisionComponent : Component
  {
    private int _shape = -1;
    private string _eventName = null;
    private bool _isSolid = true;

    public CollisionComponent()
    {
    }

    public CollisionComponent(int shape, string eventName, bool isSolid)
    {
      _shape = shape;
      _eventName = eventName;
      _isSolid = isSolid;
    }

    public int Shape
    {
      get { return _shape; }
      set
      {
        _shape = value;
        QueueEvent(EventNames.EntityShapeChanged);
      }
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
