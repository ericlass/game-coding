using System;
using System.Collections.Generic;
using System.Reflection;

namespace RougeLike
{
  public class GameObjectFactory
  {
    private static GameObjectFactory _instance = null;

    public static GameObjectFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new GameObjectFactory();
        return _instance;
      }
    }

    private Dictionary<string, Func<GameObjectBase>> _objectCreators = new Dictionary<string, Func<GameObjectBase>>();

    private GameObjectFactory()
    {
      Assembly assembly = this.GetType().Assembly;
      List<Type> objectTypes = GameUtil.GetTypesInhertingFromClass(typeof(GameObjectBase), assembly);
      foreach (Type ot in objectTypes)
      {
        GameObjectBase go = assembly.CreateInstance(ot.FullName) as GameObjectBase;
        RegisterCreator(go.ObjectType, () => assembly.CreateInstance(ot.FullName) as GameObjectBase);
      }
    }

    public void RegisterCreator(string objectType, Func<GameObjectBase> creator)
    {
      if (_objectCreators.ContainsKey(objectType))
        throw new OkuBase.OkuException("There already is a creator for object type '" + objectType + "'!");

      _objectCreators.Add(objectType, creator);
    }

    public GameObjectBase CreateObject(StringPairMap data)
    {
      if (!data.ContainsKey("type"))
        throw new OkuBase.OkuException("Game object has no 'type' property!");

      string objectType = data["type"];
      if (!_objectCreators.ContainsKey(objectType))
        throw new OkuBase.OkuException("No creator registered for object type '" + objectType + "'!");

      GameObjectBase result = _objectCreators[objectType]();
      result.Load(data);
      return result;
    }

  }
}
