using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public abstract class ControllerProcess : ProcessBase
  {
    protected List<Entity> _entities = new List<Entity>();

    public List<Entity> Entities
    {
      get { return _entities; }
    }

    public abstract override void Initialize();
    public abstract override bool Update(float dt);
    public abstract override void Destroy();
    
  }
}
