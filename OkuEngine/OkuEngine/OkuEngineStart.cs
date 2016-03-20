using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public OkuEngineStart(Level startLevel)
    {
      _engine = new Engine();
      _startLevel = startLevel;
    }

    private void SetCurrentLevel(Level level)
    {
      if (_currentLevel != null)
        _currentLevel.Finish();

      _currentLevel = level;

      if (_currentLevel != null)
      {
        //TODO: Set fields
        _currentLevel.Engine = _engine;
        
        //Init level
        _currentLevel.Init();
      }
    }

    public override void Initialize()
    {
      SetCurrentLevel(_startLevel);
    }

    public override void Update(float dt)
    {
      //TODO: Update systems
    }

    public override void Render()
    {
      //TODO: Call render system
    }

  }
}
