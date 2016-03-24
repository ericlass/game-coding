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
    private Level _currentLevel = null;

    private Engine _engine = null;

    private EngineSystem renderSystem = new RenderSystem();

    public OkuEngineStart(Level startLevel)
    {
      _engine = new Engine();
      _startLevel = startLevel;
      renderSystem.Engine = _engine;
    }

    private void SetCurrentLevel(Level level)
    {
      //Finalizes current level
      if (_currentLevel != null)
        _currentLevel.Finish();

      _currentLevel = level;

      //Intialize new level
      if (_currentLevel != null)
      {
        _currentLevel.Engine = _engine;
        _currentLevel.DoInit();
      }

      renderSystem.CurrentLevel = _currentLevel;

      //TODO: Queue level change event
    }

    public override void Initialize()
    {
      SetCurrentLevel(_startLevel);
    }

    public override void Update(float dt)
    {
      _engine.DeltaTime = dt;
      //TODO: Update systems
    }

    public override void Render()
    {
      //Call render system
      renderSystem.Execute();
    }

  }
}
