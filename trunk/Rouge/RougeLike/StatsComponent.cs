using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class StatsComponent : IComponent
  {
    public const string ComponentId = "stats";

    private Entity _owner = null;
    private float _health = 0.0f;
    private float _magic = 0.0f;
    private float _stamina = 0.0f;

    public string Id
    {
      get { return ComponentId; }
    }

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public float Health
    {
      get { return _health; }
      set { _health = value; }
    }

    public float Magic
    {
      get { return _magic; }
      set { _magic = value; }
    }

    public float Stamina
    {
      get { return _stamina; }
      set { _stamina = value; }
    }
    
    public void EnterState()
    {
    }
    
    public void Update(float dt)
    {
    }
    
    public void LeaveState()
    {
    }

  }
}
