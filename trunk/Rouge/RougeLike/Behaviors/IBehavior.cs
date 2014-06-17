using System;
using System.Collections.Generic;
using RougeLike.Objects;
using RougeLike.States;

namespace RougeLike.Behaviors
{
  public interface IBehavior : IStateComponent
  {
    string Update(float dt, EntityObject entity);
  }
}
