using System;
using System.Collections.Generic;
using RougeLike.Objects;

namespace RougeLike.States
{
  public interface IStateComponent
  {
    void Init();
    void Begin(EntityObject entity);
    void End(EntityObject entity);
    void Finish();
  }
}
