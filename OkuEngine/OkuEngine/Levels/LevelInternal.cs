﻿using System;
using System.Collections.Generic;
using OkuEngine.Collections;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Systems;

namespace OkuEngine.Levels
{
  /// <summary>
  /// Defines the internal stuff for a level.
  /// </summary>
  public abstract partial class Level
  {
    private List<Entity> _entities = new List<Entity>(100);
    private List<EventListener> _listeners = new List<EventListener>(50);
    private EventQueue _eventQueue = new EventQueue("level");
    private List<InputContext> _inputContexts = new List<InputContext>(10);
    private List<RenderTask> _renderQueue = new List<RenderTask>();
    private List<Timer> _timer = new List<Timer>();
    private ISpatialHashMap _spatialMeshMap = null;
    private ISpatialHashMap _spatialShapeMap = null;
    private bool _initialized = false;

    /// <summary>
    /// Gets the list of entities of this level.
    /// </summary>
    internal List<Entity> Entities
    {
      get { return _entities; }
    }

    /// <summary>
    /// Gets the list of event listeners of this level.
    /// </summary>
    internal List<EventListener> EventListeners
    {
      get { return _listeners; }
    }

    /// <summary>
    /// Gets the event queue of this level.
    /// </summary>
    internal EventQueue EventQueue
    {
      get { return _eventQueue; }
    }

    /// <summary>
    /// Gets if the level was already initialized or not.
    /// </summary>
    internal bool Initialized
    {
      get { return _initialized; }
    }

    /// <summary>
    /// Gets the list of input contexts.
    /// </summary>
    internal List<InputContext> InputContexts
    {
      get { return _inputContexts; }
    }

    /// <summary>
    /// Gets the render queue for this level.
    /// </summary>
    internal List<RenderTask> RenderQueue
    {
      get { return _renderQueue; }
    }

    /// <summary>
    /// Gets the list of timers in the level.
    /// </summary>
    internal List<Timer> Timers
    {
      get { return _timer; }
    }

    /// <summary>
    /// Gets the spatial hash map for this level containing the meshes and shapes.
    /// </summary>
    internal ISpatialHashMap SpatialMeshMap
    {
      get { return _spatialMeshMap; }
    }

    /// <summary>
    /// Gets the spatial hash map for this level containing the meshes and shapes.
    /// </summary>
    internal ISpatialHashMap SpatialShapeMap
    {
      get { return _spatialShapeMap; }
    }

    /// <summary>
    /// Initializes the level, but only if it was not initialized already.
    /// </summary>
    internal void DoInit()
    {
      if (!_initialized)
      {
        _engine = new EngineAPI(this);
        Init();
        _initialized = true;
      }
    }

    /// <summary>
    /// Finishes the level, but only if it was initializes before.
    /// </summary>
    internal void DoFinish()
    {
      if (_initialized)
      {
        Finish();
        _initialized = false;
      }
    }

  }
}