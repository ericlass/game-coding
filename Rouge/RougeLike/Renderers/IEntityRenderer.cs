using System;
using System.Collections.Generic;
using RougeLike.Objects;
using RougeLike.States;

namespace RougeLike.Renderers
{
  public interface IEntityRenderer : IStateComponent
  {
    void Update(float dt, EntityObject entity);
    void Render(EntityObject entity);
  }
}
