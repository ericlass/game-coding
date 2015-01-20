using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace SimGame.States
{
  public class DummyState : IGameState
  {
    private Color _color = Color.Black;

    public DummyState(Color color)
    {
      _color = color;
    }

    public string Id
    {
      get { return "dummy"; }
    }

    public void Enter(IGameDataProvider data)
    {
      OkuManager.Instance.Graphics.BackgroundColor = _color;
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
