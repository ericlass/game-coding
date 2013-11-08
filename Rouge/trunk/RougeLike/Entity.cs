using System;

namespace RougeLike
{
  public class Entity : IIdObject, IUpdatable
  {
    private string _id = null;
    private ComponentMap _components = new ComponentMap();
    private StateMachine _stateMachine = new StateMachine();

    public Entity(string id)
    {
      _id = id;
    }

    public string Id
    {
      get { return _id; }
    }

    public ComponentMap Components
    {
      get { return _components; }
    }

    public StateMachine StateMachine
    {
      get { return _stateMachine; }
    }

    public bool AddComponent(IComponent component)
    {
      component.Owner = this;
      return _components.Add(component);
    }

    public bool AddStateComponent(string state, IComponent component)
    {
      if (!_stateMachine.States.ContainsId(state))
        return false;

      component.Owner = this;
      return _stateMachine.States[state].Components.Add(component);
    }

    public T GetComponent<T>(string componentId) where T : IComponent
    {
      IComponent result = null;

      if (_stateMachine.CurrentState != null)
      {
        result = _stateMachine.CurrentState.Components[componentId];

        if (result != null)
          return (T)result;
      }

      result = _components[componentId];
      return (T)result;
    }

    public void Update(float dt)
    {
      _components.Update(dt);
      _stateMachine.Update(dt);
    }

  }
}
