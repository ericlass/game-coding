using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public delegate GameObjectBase CreateObjectDelegate(StringPairMap data);

    private Dictionary<string, CreateObjectDelegate> _objectCreators = new Dictionary<string, CreateObjectDelegate>();

    private GameObjectFactory()
    {
      RegisterCreator("player", new CreateObjectDelegate(CreatePlayerObject));
      RegisterCreator("square", new CreateObjectDelegate(CreateSquareObject));
      RegisterCreator("tilemap", new CreateObjectDelegate(CreateTileMapObject));
      RegisterCreator("playercontroller", new CreateObjectDelegate(CreatePlayerControllerObject));
      RegisterCreator("proceduraltilemap", CreateProceduralTileMapObject);
    }

    public void RegisterCreator(string objectType, CreateObjectDelegate creator)
    {
      if (_objectCreators.ContainsKey(objectType))
        throw new OkuBase.OkuException("There already is a creator for object type '" + objectType + "'!");

      _objectCreators.Add(objectType, creator);
    }

    public GameObjectBase CreateObject(StringPairMap data)
    {
      string objectType = data["type"];
      if (!_objectCreators.ContainsKey(objectType))
        throw new OkuBase.OkuException("No creator registered for object type '" + objectType + "'!");

      return _objectCreators[objectType](data);
    }

    private GameObjectBase CreatePlayerObject(StringPairMap data)
    {
      PlayerObject result = new PlayerObject();
      result.Load(data);
      return result;
    }

    private GameObjectBase CreateSquareObject(StringPairMap data)
    {
      SquareObject result = new SquareObject();
      result.Load(data);
      return result;
    }

    private GameObjectBase CreateTileMapObject(StringPairMap data)
    {
      TileMapObject result = new TileMapObject();
      result.Load(data);
      return result;
    }

    private GameObjectBase CreateProceduralTileMapObject(StringPairMap data)
    {
      ProceduralTileMapObject result = new ProceduralTileMapObject();
      result.Load(data);
      return result;
    }

    private GameObjectBase CreatePlayerControllerObject(StringPairMap data)
    {
      PlayerControllerObject result = new PlayerControllerObject();
      result.Load(data);
      return result;
    }

  }
}
