using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

namespace SimGame
{
  public class DummyState : IGameState
  {
    private Color _color = Color.Black;

    public DummyState(object[] parameters)
    {
      _color = (Color)parameters[0];
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
