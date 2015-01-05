using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace SimGame
{
  public class DummyState : IGameState
  {
    public string Id
    {
      get { return "dummy"; }
    }

    public void Enter(IGameDataProvider data)
    {
      OkuManager.Instance.Graphics.BackgroundColor = Color.Yellow;
    }

    public void Update(IGameDataProvider data, float dt)
    {
    }

    public void Render(IGameDataProvider data)
    {
    }

    public void Leave(IGameDataProvider data)
    {
    }
  }
}
