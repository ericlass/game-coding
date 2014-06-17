using System;
using System.Collections.Generic;
using RougeLike.Objects;

namespace RougeLike.Renderers
{
  public interface IEntityRenderer
  {
    void Init();
    void Begin(EntityObject entity);
    void Update(float dt, EntityObject entity);
    void Render(EntityObject entity);
    void End(EntityObject entity);
    void Finish();
  }
}
