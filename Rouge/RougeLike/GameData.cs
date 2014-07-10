using System;
using System.Collections.Generic;
using RougeLike.States;
using RougeLike.Attributes;

namespace RougeLike
{
  public class GameData : IAttributeContainer
  {
    private static GameData _instance = null;

    public static GameData Instance
    {
      get
      {
        if (_instance == null)
          _instance = new GameData();
        return _instance;
      }
    }

    private GameData()
    {
    }

    private bool _debugDraw = false;
    private SceneList _scenes = new SceneList();
    private Scene _activeScene = null;
    private AttributeMap _attributes = new AttributeMap();

    public bool DebugDraw
    {
      get { return _debugDraw; }
      set { _debugDraw = value; }
    }

    public SceneList Scenes
    {
      get { return _scenes; }
      set { _scenes = value; }
    }

    public Scene ActiveScene
    {
      get { return _activeScene; }
      set 
      {
        if (_activeScene != null)
          _activeScene.Finish();

        _activeScene = value;
        _activeScene.Init();
      }
    }

    public List<string> GetAttributeNames()
    {
      return new List<string>(_attributes.Keys);
    }

    public bool ContainsAttribute(string attribute)
    {
      return _attributes.ContainsKey(attribute);
    }

    public IAttributeValue GetAttributeValue(string attribute)
    {
      if (_attributes.ContainsKey(attribute))
        return _attributes[attribute];

      return null;
    }

    public T GetAttributeValue<T>(string attribute) where T : class, IAttributeValue
    {
      if (_attributes.ContainsKey(attribute))
        return _attributes[attribute] as T;

      return null;
    }

    public bool SetAttributeValue(string attribute, IAttributeValue value)
    {
      if (!_attributes.ContainsKey(attribute))
        return false;

      _attributes[attribute] = value;
      return true;
    }

  }
}
