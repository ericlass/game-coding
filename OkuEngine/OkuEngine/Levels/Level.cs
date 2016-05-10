﻿using System;
using OkuEngine.Assets;
using OkuEngine.Collections;

namespace OkuEngine.Levels
{
  /// <summary>
  /// Defines a single level for the game.
  /// </summary>
  public abstract partial class Level
  {
    private EngineAPI _api = null;
    private AssetManager _assets = new AssetManager();
    private BlackBoard _blackBoard = new BlackBoard();
    
    /// <summary>
    /// Gets the API with all functions of the engine.
    /// </summary>
    public EngineAPI API
    {
      get { return _api; }
    }

    /// <summary>
    /// Gets the asset manager that is used to register assets.
    /// </summary>
    public AssetManager Assets
    {
      get { return _assets; }
    }

    /// <summary>
    /// Gets the black board for this level.
    /// </summary>
    public BlackBoard Blackboard
    {
      get { return _blackBoard; }
    }

    /// <summary>
    /// Called once when the level is activated the first time.
    /// Supposed to set up systems and entities before the game loop starts.
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// Called once when the level should clean up all it's data.
    /// </summary>
    protected abstract void Finish();
  }
}
