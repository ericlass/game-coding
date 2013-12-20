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
      foreach (GameObjectBase go in _gameObjects)
        go.Init();
    }

    public void Update(float dt)
    {
      foreach (GameObjectBase go in _gameObjects)
        go.Update(dt);
    }

    public void Render()
    {
      _gameObjects.Sort();
      foreach (GameObjectBase go in _gameObjects)
        go.Render();
    }

    public void Finish()
    {
      foreach (GameObjectBase go in _gameObjects)
        go.Finish();
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
