using System;
using OkuBase;

namespace RougeLike
{
  public class GameManager : IUpdatable
  {
    private static GameManager _instance = null;

    public static GameManager Instance
    {
      get
      {
        if (_instance == null)
          _instance = new GameManager();

        return _instance;
      }
    }

    private EventQueue _eventQueue = null;
    private RenderManager _renderer = null;
    private SceneMap _scenes = null;
    private InventoryItemMap _inventoryItems = null;

    private Scene _activeScene = null;

    private GameManager()
    {
      _eventQueue = new EventQueue();
      _renderer = new RenderManager();
      _scenes = new SceneMap();
      _inventoryItems = new InventoryItemMap();
    }
    
    public void Initialize()
    {
      Scene scene = SceneFactory.Instance.GetHardCodedExampleScene();
      _scenes.Add(scene);
      SetActiveScene(scene.Id);
      _renderer.Initialize();
    }

    public void Update(float dt)
    {
      _activeScene.Update(dt);
      _eventQueue.ProcessEvents();
    }    

    public EventQueue EventQueue
    {
      get { return _eventQueue; }
    }
    
    public RenderManager Renderer
    {
      get { return _renderer; }
    }

    public SceneMap Scenes
    {
      get { return _scenes; }
      set { _scenes = value; }
    }

    public Scene ActiveScene
    {
      get { return _activeScene; }
    }

    internal void SetActiveScene(string sceneId)
    {
      if (!_scenes.ContainsId(sceneId))
        throw new OkuException("Trying to activate scene \"" + sceneId + "\" which does not exist!");

      if (_activeScene != null)
      {
        if (_activeScene.Id == sceneId)
          return;
        _activeScene.Deactivate();
      }

      _eventQueue.Clear();
      _activeScene = _scenes[sceneId];
      _activeScene.Activate();      
    }

    public InventoryItemMap InventoryItems
    {
      get { return _inventoryItems; }
      set { _inventoryItems = value; }
    }

  }
}
