using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  /// <summary>
  /// Defines a single state transition including it conditions.
  /// </summary>
  public class Transition
  {
    private string _targetState = null;
    private string _eventId = null;
    private bool _forOwningObject = false; //This is a crutch. There should be a better way to define this. Maybe through attributes too?
    private List<Condition> _conditions = null;

    /// <summary>
    /// Creates a new, empty transition.
    /// </summary>
    public Transition()
    {
    }

    /// <summary>
    /// Create a new transition with the given parameters.
    /// </summary>
    /// <param name="eventId">The id of the event that triggers the state transition.</param>
    /// <param name="targetState">The state the object will be in after the transition.</param>
    /// <param name="forOwningObject">If true, the transition will only happen if the object that caused the event is the same as the object owning the transition.</param>
    /// <param name="conditions">A set of conditions that have to be fulfilled for the state change to happen.</param>
    public Transition(string eventId, string targetState, bool forOwningObject, List<Condition> conditions)
    {
      _eventId = eventId;
      _targetState = targetState;
      _forOwningObject = forOwningObject;
      _conditions = conditions;
    }

    /// <summary>
    /// Gets or sets the state the object will be in after the transition.
    /// </summary>
    public string TargetState
    {
      get { return _targetState; }
      set { _targetState = value; }
    }

    /// <summary>
    /// Gets or sets the id of the event that triggers the state transition.
    /// </summary>
    public string EventId
    {
      get { return _eventId; }
      set { _eventId = value; }
    }

    /// <summary>
    /// Gets or sets if the transition will only happen if the object that caused the event is the same as the object owning the transition.
    /// </summary>
    public bool ForOwningObject
    {
      get { return _forOwningObject; }
      set { _forOwningObject = value; }
    }

    /// <summary>
    /// Gets or sets a set of conditions that have to be fulfilled for the state change to happen.
    /// </summary>
    public List<Condition> Conditions
    {
      get { return _conditions; }
      set { _conditions = value; }
    }

  }
}
