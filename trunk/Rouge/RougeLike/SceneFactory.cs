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

      GameObjectBase mario = CreatePlayerEntity();
      
      Scene scene = new Scene();
      scene.GameObjects.Add(tileMap);
      scene.GameObjects.Add(mario);

      WalkingCharacterControlSystem system = null;

      for (int i = 0; i < 1; i++)
      {
        GameObjectBase enemy = CreateEnemyEntity("enemy_" + i);
        scene.GameObjects.Add(enemy);

        system = new WalkingCharacterControlSystem(enemy.Id, new SimpleAIController());
        system.MaxWalkSpeed = 100;
        scene.GameSystems.Add(system);
      }

      system = new WalkingCharacterControlSystem(mario.Id, new PlayerController());
      system.MaxWalkSpeed = 300;
      scene.GameSystems.Add(system);

      ProjectileSystem projSystem = new ProjectileSystem(10, 20);
      scene.GameSystems.Add(projSystem);

      SceneList result = new SceneList();
      result.Add(scene);

      return result;
    }

    private static GameObjectBase CreatePlayerEntity()
    {
      CharacterObject mario = new CharacterObject();
      mario.Id = "mario";
      mario.ZIndex = 1;
      mario.Position = new Vector2f(0, 500);
      mario.HitBox = new Rectangle2f(-4, -9, 8, 16);
      mario.EquipedWeapon = "weapon_laser";
      mario.Skills.BeamWeapons = 1;
      mario.Skills.ProjectileWeapons = 1;
      mario.Health = 100;

      StatePropertyMap animMap = new StatePropertyMap();
      animMap.Add(CharacterState.Idle, "player_idle");
      animMap.Add(CharacterState.Walking, "player_walk");
      animMap.Add(CharacterState.Jumping, "player_jump");
      animMap.Add(CharacterState.Falling, "player_fall");
      mario.StateAnimations = animMap;

      return mario;
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
      enemy.Health = 50;

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
