using System;
using System.Collections.Generic;
using System.IO;
using OkuBase.Graphics;
using OkuBase.Geometry;
using JSONator;
using RougeLike.Attributes;
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
      mario.SetAttributeValue("direction", new NumberValue(1));
      
      IdleState idle = new IdleState();
      mario.StateMachine.States.Add(idle.Id, idle);

      WalkState walk = new WalkState();
      mario.StateMachine.States.Add(walk.Id, walk);

      mario.StateMachine.InitialState = idle.Id;

      Transition leftStart = new Transition("player_left_start", walk.Id, false, null);
      leftStart.TransitAction = () => mario.SetAttributeValue("direction", new NumberValue(-1));
      mario.StateMachine.Transitions.Add(leftStart);

      Transition rightStart = new Transition("player_right_start", walk.Id, false, null);
      rightStart.TransitAction = () => mario.SetAttributeValue("direction", new NumberValue(1));
      mario.StateMachine.Transitions.Add(rightStart);

      Transition leftEnd = new Transition("player_left_end", idle.Id, false, null);
      leftEnd.Conditions.Add(new Condition("currentstate", "==", new TextValue("walk")));
      leftEnd.Conditions.Add(new Condition("direction", ">", new NumberValue(0)));
      mario.StateMachine.Transitions.Add(leftEnd);

      Transition rightEnd = new Transition("player_right_end", idle.Id, false, null);
      rightEnd.Conditions.Add(new Condition("currentstate", "==", new TextValue("walk")));
      rightEnd.Conditions.Add(new Condition("direction", "<", new NumberValue(0)));
      mario.StateMachine.Transitions.Add(rightEnd);
      
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
