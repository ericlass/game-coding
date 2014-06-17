using System;
using System.Collections.Generic;
using RougeLike.Objects;
using RougeLike.Controller;

namespace RougeLike.Behaviors
{
  public class Behavior
  {
    private Dictionary<string, IBehaviorPattern> _patterns = new Dictionary<string, IBehaviorPattern>();
    private IEntityController _controller = null;
    private string _previousState = null;

    public Behavior()
    {
    }

    public IEntityController Controller
    {
      get { return _controller; }
      set { _controller = value; }
    }

    public bool Add(string stateName, IBehaviorPattern pattern)
    {
      if (_patterns.ContainsKey(stateName))
        return false;

      _patterns.Add(stateName, pattern);
      return true;
    }

    public bool Remove(string stateName)
    {
      return _patterns.Remove(stateName);
    }

    public bool Contains(string stateName)
    {
      return _patterns.ContainsKey(stateName);
    }

    public int Count
    {
      get { return _patterns.Count; }
    }

    public void Update(float dt, EntityObject entity)
    {
      string state = entity.StateMachine.CurrentState;

      if (!_patterns.ContainsKey(state))
        throw new OkuBase.OkuException("No behavior pattern found for state '" + state + "' in entity '" + entity.Id + "'!");

      IBehaviorPattern pattern = _patterns[state];
      if (state != _previousState)
      {
        if (_previousState != null)
          _patterns[_previousState].End(entity);

        pattern.Begin(entity);
      }

      pattern.Update(dt, entity, _controller);
      _previousState = state;
    }

  }
}
