using System;

namespace RougeLike
{
  public class State : IIdObject, IUpdatable
  {
    private string _id = null;
    private ComponentMap _components = new ComponentMap();

    public string Id
    {
      get { return _id; }
    }

    public ComponentMap Components
    {
      get { return _components; }
    }

    public void Update(float dt)
    {
      _components.Update(dt);
    }

  }
}
