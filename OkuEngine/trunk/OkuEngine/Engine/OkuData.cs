﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Resources;
using OkuEngine.Actors;
using OkuEngine.Input;
using OkuEngine.Events;
using OkuEngine.Scripting;
using OkuEngine.Collision;
using OkuEngine.Driver.Renderer;
using OkuEngine.Driver.Audio;

namespace OkuEngine
{
  /// <summary>
  /// Contains the data of the game.
  /// </summary>
  public class OkuData
  {
    private static OkuData _instance = null;

    public static OkuData Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuData();
        return _instance;
      }
    }

    private OkuData()
    {
    }

    private GameProperties _gameProperties = new GameProperties();
    private RenderSettings _renderSettings = new RenderSettings();
    private AudioSettings _audioSettings = new AudioSettings();
    private SceneManager _sceneManager = new SceneManager();
    private EntityManager<ActorType> _actorTypes = new EntityManager<ActorType>("actortypes", "actortype", KeySequence.ActorTypeSequence);
    private EntityManager<ImageContent> _images = new EntityManager<ImageContent>("images", "image", KeySequence.ImageSequence);
    private EntityManager<Animation> _animations = new EntityManager<Animation>("animations", "animation", KeySequence.AnimationSequence);
    private EntityManager<UserEvent> _userEvents = new EntityManager<UserEvent>("userevents", "event", KeySequence.UserEventSequence);
    private EntityManager<Behavior> _behaviors = new EntityManager<Behavior>("behaviors", "behavior", KeySequence.BehaviorSequence);
    private SceneObjectManager _sceneObjects = new SceneObjectManager();

    public GameProperties GameProperties
    {
      get { return _gameProperties; }
      set { _gameProperties = value; }
    }

    public RenderSettings RenderSettings
    {
      get { return _renderSettings; }
      set { _renderSettings = value; }
    }

    public AudioSettings AudioSettings
    {
      get { return _audioSettings; }
      set { _audioSettings = value; }
    }

    /// <summary>
    /// Gets the scene manager.
    /// </summary>
    public SceneManager SceneManager
    {
      get { return _sceneManager; }
      set { _sceneManager = value; }
    }

    /// <summary>
    /// Gets the actor type manager that contains all actor types.
    /// </summary>
    public EntityManager<ActorType> ActorTypes
    {
      get { return _actorTypes; }
      set { _actorTypes = value; }
    }

    /// <summary>
    /// Gets the image manager that contains all images.
    /// </summary>
    public EntityManager<ImageContent> Images
    {
      get { return _images; }
      set { _images = value; }
    }

    /// <summary>
    /// Gets the animation manager that contains all animations.
    /// </summary>
    public EntityManager<Animation> Animations
    {
      get { return _animations; }
      set { _animations = value; }
    }

    /// <summary>
    /// Gets the manager that stores all user defined events.
    /// </summary>
    public EntityManager<UserEvent> UserEvents
    {
      get { return _userEvents; }
      set { _userEvents = value; }
    }

    /// <summary>
    /// Gets the manager that contains all behaviors.
    /// </summary>
    public EntityManager<Behavior> Behaviors
    {
      get { return _behaviors; }
      set { _behaviors = value; }
    }

    /// <summary>
    /// Gets the manager that contains all scene objects.
    /// </summary>
    public SceneObjectManager SceneObjects
    {
      get { return _sceneObjects; }
      set { _sceneObjects = value; }
    }

  }
}
