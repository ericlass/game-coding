using System;
using System.Collections.Generic;

namespace RougeLike
{
  public class StateTransitions
  {
    private Dictionary<EventId, Dictionary<string, string>> _transitions = new Dictionary<EventId, Dictionary<string, string>>();

    public bool Add(EventId eventId, string source, string target)
    {
      if (!_transitions.ContainsKey(eventId))
        _transitions.Add(eventId, new Dictionary<string, string>());

      if (_transitions[eventId].ContainsKey(source))
        return false;

      _transitions[eventId].Add(source, target);
      return true;
    }

    public bool Remove(EventId eventId)
    {
      if (!_transitions.ContainsKey(eventId))
        return false;

      _transitions.Remove(eventId);
      return true;
    }

    public bool Remove(EventId eventId, string source)
    {
      if (!_transitions.ContainsKey(eventId))
        return false;

      if (!_transitions[eventId].ContainsKey(source))
        return false;

      _transitions[eventId].Remove(source);
      return true;
    }

    public void Clear()
    {
      _transitions.Clear();
    }

    public bool Contains(EventId eventId)
    {
      return _transitions.ContainsKey(eventId);
    }

    public string GetTargetState(EventId eventId, string sourceState)
    {
      if (!_transitions.ContainsKey(eventId))
        return null;

      if (!_transitions[eventId].ContainsKey(sourceState))
        return null;

      return _transitions[eventId][sourceState];
    }

    public List<EventId> GetEvents()
    {
      return new List<EventId>(_transitions.Keys);
    }

  }
}
