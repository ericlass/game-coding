﻿using System;
using System.Collections.Generic;
using OkuBase;
using OkuEngine.Levels;
using OkuEngine.Events;
using OkuEngine.Systems;
using OkuBase.Settings;

namespace OkuEngine
{
  public class OkuEngineStart : OkuGame
  {
    private Level _startLevel = null;
    private Level _currentLevel = null;

    private List<GameSystem> _systems = new List<GameSystem>();

    private GameSystem _renderSystem = new RenderSystem();
    private GameSystem _entityRenderSystem = new EntityRenderSystem();

    public OkuEngineStart(Level startLevel)
    {
      _startLevel = startLevel;
    }

    public override OkuSettings Configure()
    {
      var settings = base.Configure();
      settings.Graphics.TextureFilter = OkuBase.Graphics.TextureFilter.NearestNeighbor;
      return settings;
    }

    private void SetCurrentLevel(Level level)
    {
      Level previous = _currentLevel;

      //Finalizes current level
      if (_currentLevel != null)
        _currentLevel.DoFinish();

      _currentLevel = level;

      //Intialize new level
      if (_currentLevel != null)
        _currentLevel.DoInit();

      //Inform systems about the level change
      foreach (var system in _systems)
        system.LevelChanged(previous, level);

      //Aloso inform "special" systems
      _entityRenderSystem.LevelChanged(previous, level);
      _renderSystem.LevelChanged(previous, level);
    }

    public override void Initialize()
    {
      SetCurrentLevel(_startLevel);

      _systems = new List<GameSystem>()
      {
        new InputSystem(),
        new TimerSystem(),
        new SpatialSystem(),
        new PhysicsSystem()        
      };


      foreach (var system in _systems)
        system.Init();

      _entityRenderSystem.Init();
      _renderSystem.Init();
    }

    public override void Update(float dt)
    {
      _currentLevel.Engine.PreviousDeltaTime = _currentLevel.Engine.DeltaTime;
      _currentLevel.Engine.DeltaTime = dt;

      _currentLevel.Engine.QueueEvent(EventNames.EveryFrame, dt);

      //Update entities
      foreach (var entity in _currentLevel.Entities)
        entity.Update(dt);

      //Update systems
      foreach (var system in _systems)
        system.Execute(_currentLevel);

      _currentLevel.EventQueue.Update(float.MaxValue);

      //Execute after event handling so everything is updated correctly before rendering
      _entityRenderSystem.Execute(_currentLevel);
    }

    public override void Render()
    {
      //Call render system
      _renderSystem.Execute(_currentLevel);
    }

  }
}
