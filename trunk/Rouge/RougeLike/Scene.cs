using System;
using OkuBase;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Objects;

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

    public IAttributeValue GetObjectAttribute(string objectId, string attributeName)
    {
      GameObjectBase go = _gameObjects.GetObjectById(objectId);
      if (go == null)
        return null;

      return go.GetAttributeValue(attributeName);
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
      _gameObjects.SortStable();
      foreach (GameObjectBase go in _gameObjects)
      {
        OkuManager.Instance.Graphics.ApplyAndPushTransform(go.Position, Vector2f.One, 0);
        try
        {
          go.Render();
          //OkuBase.OkuManager.Instance.Graphics.DrawPoint(0, 0, 2.0f, OkuBase.Graphics.Color.Red);
        }
        finally
        {
          OkuManager.Instance.Graphics.PopTransform();
        }        
      }
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
