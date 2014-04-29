using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class Transition
  {
    private string _targetState = null;
    private string _eventId = null;
    private bool _forOwningObject = false;
    // Maybe define preconditions for the state switch too.

    public Transition()
    {
    }

    public Transition(string eventId, string targetState, bool forOwningObject)
    {
      _eventId = eventId;
      _targetState = targetState;
      _forOwningObject = forOwningObject;
    }

    public string TargetState
    {
      get { return _targetState; }
      set { _targetState = value; }
    }

    public string EventId
    {
      get { return _eventId; }
      set { _eventId = value; }
    }

    public bool ForOwningObject
    {
      get { return _forOwningObject; }
      set { _forOwningObject = value; }
    }

  }
}
