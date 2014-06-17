using System;
using System.Collections.Generic;
using System.IO;
using OkuBase.Graphics;
using OkuBase.Geometry;
using JSONator;
using RougeLike.Attributes;
using RougeLike.States;
using RougeLike.Tiles;
using RougeLike.Objects;
using RougeLike.Controller;
using RougeLike.Behaviors;
using RougeLike.Renderers;

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

      EntityObject mario = CreatePlayerEntity();
      
      Scene scene = new Scene();
      scene.GameObjects.Add(tileMap);
      scene.GameObjects.Add(mario);

      for (int i = 0; i < 10; i++)
      {
        scene.GameObjects.Add(CreateEnemyEntity());
      }

      SceneList result = new SceneList();
      result.Add(scene);

      return result;
    }

    private static EntityObject CreatePlayerEntity()
    {
      EntityObject mario = new EntityObject();
      mario.Id = "mario";
      mario.ZIndex = 1;
      mario.Position = new Vector2f(0, 500);
      mario.Controller = new PlayerController();

      mario.SetAttributeValue("direction", new NumberValue(1));
      mario.SetAttributeValue("speedx", new NumberValue(0));
      mario.SetAttributeValue("speedy", new NumberValue(0));
      mario.SetAttributeValue("walkspeed", new NumberValue(300));

      State walk = new State(StateIds.Walk);
      walk.Behavior = new WalkBehavior();
      walk.Renderer = new PlayerWalkRenderer("player_walk");
      mario.StateMachine.States.Add(walk.Id, walk);

      State jump = new State(StateIds.Jump);
      jump.Behavior = new JumpBehavior();
      jump.Renderer = new DirectedImageRenderer("mario_jump");
      mario.StateMachine.States.Add(jump.Id, jump);

      State fall = new State(StateIds.Fall);
      fall.Behavior = new FallBehavior();
      fall.Renderer = new DirectedImageRenderer("mario_fall");
      mario.StateMachine.States.Add(fall.Id, fall);

      mario.StateMachine.InitialState = walk.Id;

      return mario;
    }

    private static int _enemyCounter = 0;
    private static Random _rand = new Random();

    private static EntityObject CreateEnemyEntity()
    {
      EntityObject enemy = new EntityObject();
      enemy.Id = "enemy_" + _enemyCounter;
      enemy.ZIndex = 1;
      enemy.Position = new Vector2f(_rand.Next(-500, 500), 800);
      enemy.HitBox = new Rectangle2f(-4, -8, 8, 13);
      enemy.Controller = new SimpleEnemyController();

      enemy.SetAttributeValue("direction", new NumberValue(1));
      enemy.SetAttributeValue("speedx", new NumberValue(0));
      enemy.SetAttributeValue("speedy", new NumberValue(0));
      enemy.SetAttributeValue("walkspeed", new NumberValue(150));

      State walk = new State(StateIds.Walk);
      walk.Behavior = new WalkBehavior();
      walk.Renderer = new PlayerWalkRenderer("gumba_walk");
      enemy.StateMachine.States.Add(walk.Id, walk);

      State jump = new State(StateIds.Jump);
      jump.Behavior = new JumpBehavior();
      jump.Renderer = new ImageRenderer("gumba_right");
      enemy.StateMachine.States.Add(jump.Id, jump);

      State fall = new State(StateIds.Fall);
      fall.Behavior = new FallBehavior();
      fall.Renderer = new ImageRenderer("gumba_right");
      enemy.StateMachine.States.Add(fall.Id, fall);

      enemy.StateMachine.InitialState = walk.Id;

      return enemy;
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
