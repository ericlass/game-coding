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

    private GameSystem _renderSystem = new RenderSystem();
    private GameSystem _inputSystem = new InputSystem();

    public OkuEngineStart(Level startLevel)
    {
      _startLevel = startLevel;
    }

    private void SetCurrentLevel(Level level)
    {
      //Finalizes current level
      if (_currentLevel != null)
        _currentLevel.DoFinish();

      _currentLevel = level;

      //Intialize new level
      if (_currentLevel != null)
        _currentLevel.DoInit();

      //Queue level change event
      _currentLevel.API.QueueEvent(EventNames.LevelChanged);
    }

    public override void Initialize()
    {
      SetCurrentLevel(_startLevel);

      _renderSystem.Init(_currentLevel);
      _inputSystem.Init(_currentLevel);
    }

    public override void Update(float dt)
    {
      _currentLevel.Variables[VariableNames.DeltaTime] = dt;
      _currentLevel.API.QueueEvent(EventNames.EngineTick, dt);

      //Update systems
      _inputSystem.Execute(_currentLevel);

      _currentLevel.EventQueue.Update(float.MaxValue);
    }

    public override void Render()
    {
      //Call render system
      _renderSystem.Execute(_currentLevel);
    }

  }
}
