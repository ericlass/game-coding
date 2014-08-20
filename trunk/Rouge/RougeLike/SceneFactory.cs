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
using RougeLike.Character;
using RougeLike.Systems;

namespace RougeLike
{
  public class SceneFactory
  {
    public const int DoorGroupIndex = 21;

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
      int width = 1024;
      int height = 512;

      Scene scene = new Scene();

      Biome biome = BiomeParameters.Instance["mountain"];

      if (biome == null)
        throw new OkuBase.OkuException("There is no biome with the id \"\"!");

      TileGeneratorParameters parameters = biome.GeneratorParameters;
      parameters.Seed = GameData.Instance.WorldSeed;

      TileGeneratorResult genResult = TileMapGenerator.Instance.GenerateTiles(parameters, width, height);
      Tile[,] tiles = genResult.Tiles;

      ImageBase tileImages = scene.Content.GetImage(biome.Tileset);

      TileMapObject tileMap = new TileMapObject(new TileData(tiles, tileImages, 16, 16));
      tileMap.Id = "tilemap";
      //tileMap.Scale = new Vector2f(0.0625f, 0.0625f);

      int doorNum = 0;
      foreach (Vector2i doorPos in genResult.Doors)
      {
        DoorObject door = new DoorObject();
        door.Id = "door_" + doorNum;
        door.OpenAnimationName = "door_green_open";
        door.OpenedImageName = "door_open_04";
        door.CloseAnimationName = "door_green_close";
        door.ClosedImageName = "door_open_01";
        door.ZIndex = 2;
        door.GroupIndex = DoorGroupIndex;
        door.BaseTile = doorPos;

        Rectangle2f tileRect = tileMap.GetTileRect(doorPos.X, doorPos.Y);
        door.Position = new Vector2f(tileRect.Min.X + 8, tileRect.Min.Y + 24);

        scene.GameObjects.Add(door);

        doorNum++;
      }

      DoorSystem doorSystem = new DoorSystem(DoorGroupIndex);
      scene.GameSystems.Add(doorSystem);
      
      GameObjectBase player = CreatePlayerEntity();
      
      scene.GameObjects.Add(tileMap);
      scene.GameObjects.Add(player);

      WalkingCharacterControlSystem system = null;

      for (int i = 0; i < 10; i++)
      {
        GameObjectBase enemy = CreateEnemyEntity("enemy_" + i);
        scene.GameObjects.Add(enemy);

        system = new WalkingCharacterControlSystem(enemy.Id, new SimpleAIController());
        system.MaxWalkSpeed = 100;
        scene.GameSystems.Add(system);
      }

      system = new WalkingCharacterControlSystem(player.Id, new PlayerController());
      system.MaxWalkSpeed = 250;
      scene.GameSystems.Add(system);

      ProjectileSystem projSystem = new ProjectileSystem(10, 20);
      scene.GameSystems.Add(projSystem);

      SceneList result = new SceneList();
      result.Add(scene);

      return result;
    }

    private static GameObjectBase CreatePlayerEntity()
    {
      CharacterObject player = new CharacterObject();
      player.Id = "mario";
      player.ZIndex = 1;
      player.Position = new Vector2f(0, 500);
      player.HitBox = new Rectangle2f(-4, -9, 8, 16);
      player.EquipedWeapon = "weapon_laser";
      player.Skills.BeamWeapons = 1;
      player.Skills.ProjectileWeapons = 1;
      player.Health = 100;

      StatePropertyMap animMap = new StatePropertyMap();
      animMap.Add(CharacterState.Idle, "player_idle");
      animMap.Add(CharacterState.Walking, "player_walk");
      animMap.Add(CharacterState.Jumping, "player_jump");
      animMap.Add(CharacterState.Falling, "player_fall");
      player.StateAnimations = animMap;

      return player;
    }

    private static Random _rand = new Random();

    private static GameObjectBase CreateEnemyEntity(string id)
    {
      CharacterObject enemy = new CharacterObject();
      enemy.Id = id;
      enemy.ZIndex = 1;
      enemy.Position = new Vector2f(_rand.Next(-500, 500), 800);
      enemy.HitBox = new Rectangle2f(-4, -8, 8, 13);
      enemy.GroupIndex = 20;
      enemy.Health = 10;

      StatePropertyMap animMap = new StatePropertyMap();
      animMap.Add(CharacterState.Idle, "enemy_idle");
      animMap.Add(CharacterState.Walking, "enemy_walk");
      animMap.Add(CharacterState.Jumping, "enemy_jump");
      animMap.Add(CharacterState.Falling, "enemy_fall");
      animMap.Add(CharacterState.Dead, "enemy_dead");
      enemy.StateAnimations = animMap;

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
