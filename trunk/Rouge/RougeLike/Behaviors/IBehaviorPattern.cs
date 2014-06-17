using System;
using System.Collections.Generic;
using RougeLike.Objects;
using RougeLike.Controller;

namespace RougeLike.Behaviors
{
  public interface IBehaviorPattern
  {
    void Begin(EntityObject entity);
    string Update(float dt, EntityObject entity, IEntityController controller);
    void End(EntityObject entity);
  }
}
