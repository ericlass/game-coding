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

    public void Enter()
    {
      OkuManager.Instance.Graphics.BackgroundColor = _color;
    }

    public void Update(float dt)
    {
    }

    public void Render()
    {
    }

    public void Leave()
    {
    }
  }
}
