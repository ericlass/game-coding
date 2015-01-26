using System;
using System.Collections.Generic;
using System.IO;
using SimGame.Content;

namespace SimGame.States
{
  public class PlayingState : IGameState
  {
    ContentCache _content = null;

    public void Enter(IGameDataProvider data)
    {
      _content = new ContentCache(data.GetContentPath());
    }

    public void Update(IGameDataProvider data, float dt)
    {
      throw new NotImplementedException();
    }

    public void Render(IGameDataProvider data)
    {
      throw new NotImplementedException();
    }

    public void Leave(IGameDataProvider data)
    {
      throw new NotImplementedException();
    }
  }
}
