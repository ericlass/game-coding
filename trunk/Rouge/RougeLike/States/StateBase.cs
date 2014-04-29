using System;
using System.Collections.Generic;
using OkuBase;

namespace RougeLike.States
{
  public abstract class StateBase
  {
    public abstract string Id { get; }

    public abstract void Init();
    public abstract void Enter();
    public abstract void Update(float dt);
    public abstract void Render();
    public abstract void Leave();
    public abstract void Finish();

    protected OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

  }
}
