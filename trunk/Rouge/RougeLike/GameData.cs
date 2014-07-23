using System;
using System.Collections.Generic;
using System.IO;
using JSONator;
using RougeLike.States;
using RougeLike.Attributes;
using RougeLike.Character;

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
      LoadInventoryItems();
    }

    private bool _debugDraw = false;
    private SceneList _scenes = new SceneList();
    private Scene _activeScene = null;
    private AttributeMap _attributes = new AttributeMap();
    private Dictionary<string, InventoryItemDefinition> _inventoryItems = null;

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

    public Dictionary<string, InventoryItemDefinition> InventoryItems
    {
      get
      {
        if (_inventoryItems == null)
          LoadInventoryItems();
        return _inventoryItems;
      }
      set { _inventoryItems = value; }
    }

    private void LoadInventoryItems()
    {
      _inventoryItems = new Dictionary<string, InventoryItemDefinition>();

      string inventoryPath = ".\\Content\\InventoryItems";
      string[] files = Directory.GetFiles(inventoryPath, "*.json");
      foreach (string file in files)
      {
        JSONObjectValue json = GameUtil.ParseJsonFile(file);
        InventoryItemDefinition item = InventoryItemFactory.Instance.CreateInventoryItem(json);
        _inventoryItems.Add(item.Id, item);
      }
    }

    #region Attribute Stuff

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

    #endregion

  }
}
