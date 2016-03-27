using System;
using System.Collections.Generic;
using OkuBase;
using OkuEngine.Levels;
using OkuEngine.Events;
using OkuEngine.Systems;

namespace OkuEngine
{
  public class OkuEngineStart : OkuGame
  {
    private Level _startLevel = null;

    private EngineSystem renderSystem = new RenderSystem();

    public OkuEngineStart(Level startLevel)
    {
      _startLevel = startLevel;
    }

    private void SetCurrentLevel(Level level)
    {
      //Finalizes current level
      if (Engine.Instance.CurrentLevel != null)
        Engine.Instance.CurrentLevel.Finish();

      Engine.Instance.CurrentLevel = level;

      //Intialize new level
      if (Engine.Instance.CurrentLevel != null)
        Engine.Instance.CurrentLevel.DoInit();

      //TODO: Queue level change event
    }

    public override void Initialize()
    {
      SetCurrentLevel(_startLevel);
    }

    public override void Update(float dt)
    {
      Engine.Instance.Variables.DeltaTime = dt;
      //TODO: Update systems
    }

    public override void Render()
    {
      //Call render system
      renderSystem.Execute();
    }

  }
}
