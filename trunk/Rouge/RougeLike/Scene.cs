using System;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;
using RougeLike.Objects;
using RougeLike.Systems;

namespace RougeLike
{
  public class Scene
  {
    private string _name = "";
    private GameObjectList _gameObjects = new GameObjectList();
    private GameSystemList _gameSystems = new GameSystemList();
    private ContentCache _content = new ContentCache();

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

    public GameSystemList GameSystems
    {
      get { return _gameSystems; }
      set { _gameSystems = value; }
    }

    public ContentCache Content
    {
      get { return _content; }
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

      foreach (IGameSystem system in _gameSystems)
        system.Init();
    }

    public void Update(float dt)
    {
      foreach (GameObjectBase go in _gameObjects)
        go.Update(dt);

      for (int i = _gameSystems.Count - 1; i >= 0; i--)
        _gameSystems[i].Update(dt);
    }

    public void Render()
    {
      _gameObjects.SortStable();
      foreach (GameObjectBase go in _gameObjects)
      {
        OkuManager.Instance.Graphics.ApplyAndPushTransform(go.Position, go.Scale, 0);
        try
        {
          RenderDescription rd = go.RenderDescription;

          if (rd.VertexBuffer != null)
            OkuManager.Instance.Graphics.DrawVertexBuffer(rd.VertexBuffer, rd.PrimitiveType, rd.Image);
          else if (rd.Image != null)
            OkuManager.Instance.Graphics.DrawImage(rd.Image, 0, 0, rd.Tint);

          if (GameData.Instance.DebugMode)
            OkuBase.OkuManager.Instance.Graphics.DrawPoint(0, 0, 2.0f, Color.Red);
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

      foreach (IGameSystem system in _gameSystems)
        system.Finish();

      _content.Clear();
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
