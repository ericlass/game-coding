using System;
using System.Collections.Generic;
using System.IO;
using OkuBase.Graphics;
using OkuBase.Geometry;
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

    public SceneList GenerateScene()
    {
      int width = 500;
      int height = 100;

      TileGeneratorParameters parameters = new TileGeneratorParameters();
      parameters.DetailLevel = 6;
      parameters.Amplitude = 30;
      parameters.Seed = 912745896;

      Tile[,] tiles = TileMapGenerator.Instance.GenerateTile(parameters, width, height);
      List<ImageBase> tileImages = GameUtil.LoadSpriteSheet("simple_tiles.png", 16, 16);

      TileMapObject tileMap = new TileMapObject(new TileData(tiles, tileImages, 16, 16));

      Scene scene = new Scene();
      scene.GameObjects.Add(tileMap);

      for (int x = 0; x < width; x++)
      {
        int y = 0;
        while (tiles[x, y].TileType != TileType.Empty)
          y++;

        Rectangle2f tileRect = tileMap.GetTileRect(x, y);
        GrassObject grass = new GrassObject();
        grass.Position = new Vector2f(tileRect.GetCenter().X, tileRect.Min.Y);
        grass.ZIndex = -1;
        scene.GameObjects.Add(grass);
      }

      SceneList result = new SceneList();
      result.Add(scene);

      return result;
    }

    public SceneList LoadScene(string fileName)
    {
      string fullPath = Path.Combine(".\\Content\\Scenes", fileName);

      if (!File.Exists(fullPath))
        throw new OkuBase.OkuException("Could not load scene! File " + fullPath + " does not exist!");

      JSONObjectValue root = GameUtil.ParseJsonFile(fullPath);

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
