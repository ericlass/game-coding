using System;

namespace RougeLike
{
  public class Scene
  {
    private string _name = "";
    private GameObjectList _gameObjects = new GameObjectList();

    public GameObjectList GameObjects
    {
      get { return _gameObjects; }
      set { _gameObjects = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public void Init()
    {
      foreach (GameObjectWrapper go in _gameObjects)
        go.GameObject.Init();
    }

    public void Update(float dt)
    {
      foreach (GameObjectWrapper go in _gameObjects)
        go.GameObject.Update(dt);
    }

    public void Render()
    {
      foreach (GameObjectWrapper go in _gameObjects)
        go.GameObject.Render();
    }

    public void Finish()
    {
      foreach (GameObjectWrapper go in _gameObjects)
        go.GameObject.Finish();
    }

    public void Load(StringPairMap data)
    {
      _name = data["name"];
    }

    public StringPairMap Save()
    {
      StringPairMap result = new StringPairMap();
      result.Add("name", _name);
      return result;
    }

  }
}
