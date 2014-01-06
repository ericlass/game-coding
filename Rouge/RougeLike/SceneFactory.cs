using System;
using System.Collections.Generic;
using System.IO;
using OkuBase.Graphics;
using JSONator;

namespace RougeLike
{
  public class SceneFactory
  {
    private static SceneFactory _instance = null;

    public static SceneFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new SceneFactory();
        return _instance;
      }
    }

    private SceneFactory()
    {
    }

    public SceneList GetHardCodedScene()
    {
      SceneList result = new SceneList();

      PlayerObject player = new PlayerObject();

      SquareObject square = new SquareObject();
      square.Position = new OkuBase.Geometry.Vector2f(0, 100);

      TileMapObject tilemap = new TileMapObject();
      tilemap.Position = new OkuBase.Geometry.Vector2f(0, -100);

      Scene scene = new Scene();
      scene.Name = "Test";

      scene.GameObjects.Add(player);
      scene.GameObjects.Add(square);
      scene.GameObjects.Add(tilemap);

      result.Add(scene);
      return result;
    }

    public SceneList LoadScene(string fileName)
    {
      string fullPath = Path.Combine(".\\Content\\Scenes", fileName);

      if (!File.Exists(fullPath))
        throw new OkuBase.OkuException("Could not load scene! File " + fullPath + " does not exist!");

      StreamReader reader = new StreamReader(fullPath);
      string json = reader.ReadToEnd();
      reader.Close();

      JSONParser parser = new JSONParser();
      JSONObjectValue root = parser.Parse(json);

      JSONObjectValue sceneObj = (JSONObjectValue)root["scene"];
      JSONArrayValue objectsArray = (JSONArrayValue)root["objects"];

      Scene scene = new Scene();
      scene.Name = sceneObj["name"].ToString();

      for (int i = 0; i < objectsArray.Count; i++)
      {
        JSONObjectValue obj = (JSONObjectValue)objectsArray[i];
        StringPairMap data = GameUtil.JSONObjectToMap(obj);
        GameObjectBase gameObject = GameObjectFactory.Instance.CreateObject(data);
        scene.GameObjects.Add(gameObject);
      }

      SceneList result = new SceneList();
      result.Add(scene);

      return result;
    }

  }
}
