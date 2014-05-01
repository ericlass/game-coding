using System;
using System.Collections.Generic;
using System.IO;
using OkuBase.Graphics;
using OkuBase.Geometry;
using JSONator;
using RougeLike.States;

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
      int width = 2000;
      int height = 112;

      Biome biome = BiomeParameters.Instance["mountain"];

      if (biome == null)
        throw new OkuBase.OkuException("There is no biome with the id \"\"!");

      TileGeneratorParameters parameters = biome.GeneratorParameters;

      Tile[,] tiles = TileMapGenerator.Instance.GenerateTiles(parameters, width, height);
      ImageBase tileImages = GameUtil.LoadImage(biome.Tileset);

      TileMapObject tileMap = new TileMapObject(new TileData(tiles, tileImages, 16, 16));
      tileMap.Id = "tilemap";

      EntityObject mario = new EntityObject();
      mario.Id = "mario";
      mario.ZIndex = 1;
      mario.Position = new Vector2f(0, 500);
      
      IdleState idle = new IdleState();
      mario.StateMachine.States.Add(idle.Id, idle);

      WalkLeftState left = new WalkLeftState();
      mario.StateMachine.States.Add(left.Id, left);

      WalkRightState right = new WalkRightState();
      mario.StateMachine.States.Add(right.Id, right);

      mario.StateMachine.InitialState = idle.Id;

      mario.StateMachine.Transitions.Add(new Transition("player_left_start", left.Id, false, null));
      mario.StateMachine.Transitions.Add(new Transition("player_right_start", right.Id, false, null));

      mario.StateMachine.Transitions.Add(new Transition("player_left_end", idle.Id, false, null));
      mario.StateMachine.Transitions.Add(new Transition("player_right_end", idle.Id, false, null));
      

      Scene scene = new Scene();
      scene.GameObjects.Add(tileMap);
      scene.GameObjects.Add(mario);

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
