using System;

namespace RougeLike
{
  public class StateMap : IdObjectMap<State>, IUpdatable
  {
    public void Update(float dt)
    {
      foreach (State state in _objects.Values)
        state.Update(dt);
    }
  }
}
