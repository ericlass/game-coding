using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using SimGame.Content;

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    ContentCache _content = null;

    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    public void Enter(IGameDataProvider data)
    {
      _content = new ContentCache(data.GetContentPath());

      Oku.Graphics.Viewport.SetValues(0, 960, 0, 540);
    }

    public void Update(IGameDataProvider data, float dt)
    {
      throw new NotImplementedException();
    }

    public void Render(IGameDataProvider data)
    {
      
    }

    public void Leave(IGameDataProvider data)
    {
      throw new NotImplementedException();
    }
  }
}
