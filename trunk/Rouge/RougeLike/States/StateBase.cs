using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public abstract class StateBase
  {
    public abstract string Id { get; }

    public abstract void Enter();
    public abstract void Update(float dt);
    public abstract void Render();
    public abstract void Leave();
  }
}
