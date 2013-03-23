using System;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OkuEngine
{
  /// <summary>
  /// Contains the data of the game.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class OkuData : IStoreable
  {
    /// <summary>
    /// Defines the engine wide serializer settings.
    /// </summary>
    private static JsonSerializerSettings _jsonSettings = null;

    public static JsonSerializerSettings JsonSettings
    {
      get
      {
        if (_jsonSettings == null)
        {
          _jsonSettings = new JsonSerializerSettings();
          _jsonSettings.TypeNameHandling = TypeNameHandling.Auto;
          _jsonSettings.Converters.Add(new StringEnumConverter());
        }
        return _jsonSettings;
      }
    }

    private static OkuData _instance = null;

    public static OkuData Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuData();
        return _instance;
      }
      set { _instance = value; }
    }

    private OkuData()
    {
    }

    private GameProperties _gameProperties = new GameProperties();
    private RenderSettings _renderSettings = new RenderSettings();
    private AudioSettings _audioSettings = new AudioSettings();

    private List<KeyBinding> _keyBindings = new List<KeyBinding>();
    private EntityManager<UserEvent> _userEvents = new EntityManager<UserEvent>("userevents", "event", KeySequence.UserEventSequence);
    private EntityManager<Behavior> _behaviors = new EntityManager<Behavior>("behaviors", "behavior", KeySequence.BehaviorSequence);
    private EntityManager<ImageContent> _images = new EntityManager<ImageContent>("images", "image", KeySequence.ImageSequence);
    private EntityManager<Animation> _animations = new EntityManager<Animation>("animations", "animation", KeySequence.AnimationSequence);
    private SceneObjectManager _sceneObjects = new SceneObjectManager();
    private SceneManager _sceneManager = new SceneManager();

    public bool AfterLoad()
    {
      return
        _userEvents.AfterLoad() &&
        _behaviors.AfterLoad() &&
        _images.AfterLoad() &&
        _animations.AfterLoad() &&
        _sceneObjects.AfterLoad() &&
        _sceneManager.AfterLoad();
    }

    [JsonPropertyAttribute]
    public GameProperties GameProperties
    {
      get { return _gameProperties; }
      set { _gameProperties = value; }
    }

    [JsonPropertyAttribute]
    public RenderSettings RenderSettings
    {
      get { return _renderSettings; }
      set { _renderSettings = value; }
    }

    [JsonPropertyAttribute]
    public AudioSettings AudioSettings
    {
      get { return _audioSettings; }
      set { _audioSettings = value; }
    }

    /// <summary>
    /// Gets the scene manager.
    /// </summary>
    [JsonPropertyAttribute]
    public SceneManager SceneManager
    {
      get { return _sceneManager; }
      set { _sceneManager = value; }
    }

    /// <summary>
    /// Gets the image manager that contains all images.
    /// </summary>
    [JsonPropertyAttribute]
    public EntityManager<ImageContent> Images
    {
      get { return _images; }
      set { _images = value; }
    }

    /// <summary>
    /// Gets the animation manager that contains all animations.
    /// </summary>
    [JsonPropertyAttribute]
    public EntityManager<Animation> Animations
    {
      get { return _animations; }
      set { _animations = value; }
    }

    /// <summary>
    /// Gets the manager that stores all user defined events.
    /// </summary>
    [JsonPropertyAttribute]
    public EntityManager<UserEvent> UserEvents
    {
      get { return _userEvents; }
      set { _userEvents = value; }
    }

    /// <summary>
    /// Gets the manager that contains all behaviors.
    /// </summary>
    [JsonPropertyAttribute]
    public EntityManager<Behavior> Behaviors
    {
      get { return _behaviors; }
      set { _behaviors = value; }
    }

    /// <summary>
    /// Gets the manager that contains all scene objects.
    /// </summary>
    [JsonPropertyAttribute]
    public SceneObjectManager SceneObjects
    {
      get { return _sceneObjects; }
      set { _sceneObjects = value; }
    }

    /// <summary>
    /// Gets the list of key bindings.
    /// </summary>
    [JsonPropertyAttribute]
    public List<KeyBinding> KeyBindings
    {
      get { return _keyBindings; }
      set { _keyBindings = value; }
    }

  }
}
