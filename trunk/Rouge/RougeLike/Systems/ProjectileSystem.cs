﻿using System;
using System.Collections.Generic;

namespace RougeLike.Systems
{
  public class ProjectileSystem : IGameSystem
  {
    private int _projectileGroup = -1; //Group index of projectile objects
    private int _hitGroup = -1; // Group index of character objects to hit

    public ProjectileSystem(int projectileGroup, int hitGroup)
    {
      _projectileGroup = projectileGroup;
      _hitGroup = hitGroup;
    }

    public void Init()
    {
    }

    public void Update(float dt)
    {
      //TODO: Implement
      // Get projectiles
      List<GameObjectBase> projectilesObjects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_projectileGroup);
      if (projectilesObjects.Count = 0)
        return;
        
      // Cast to projectiles
      List<ProjectileObject> projectiles = new List<ProjectileObject>();
      foreach (GameObjectBase obj in projectilesObjects)
        projectiles.Add(obj as ProjectileObject);
        
      //Move projectiles
      foreach (ProjectileObject proj in projectiles)
        proj.Position = proj.Position + (proj.Direction * dt);
            
      // Get targets
      List<GameObjectBase> characterObjects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_hitGroup);
      if (characterObjects.Count = 0)
        return;
        
      // Cast to characters
      List<CharacterObject> characters = new List<CharacterObject>();
      foreach (GameObjectBase obj in characterObjects)
        characters.Add(obj as CharacterObject);
      
      int gridSize = 64;
      int projectileSize = 3; // TODO: Get this from weapon
      
      // calculate spatial hashes of projectiles
      DoubleKeyMap<int, int, List<ProjectileObject>> projectileMap = new DoubleKeyMap<int, int, List<ProjectileObject>>();
      foreach (ProjectileObject proj in projectiles)
      {
        int left = (proj.Position.X - projectileSize) / gridSize;
        int right = (proj.Position.X + projectileSize) / gridSize;
        int bottom = (proj.Position.Y - projectileSize) / gridSize;
        int top = (proj.Position.Y + projectileSize) / gridSize;
        
        for (int x = left; x <= right; x++)
        {
          for (int = bottom; y <= top; y++)
          {
            if (!projectileMap.Contains(x, y))
              projectileMap.Add(x, y, new List<ProjectileObject>());
            
            projectileMap[x, y].Add(proj);
          }
        }
      }
      
      // calculate spatial hashes of targets
      DoubleKeyMap<int, int, List<CharacterObject>> characterMap = new DoubleKeyMap<int, int, List<CharacterObject>>();
      foreach (CharacterObject character in characters)
      {
        float halfWidth = character.HitBox.Width / 2.0f;
        float halfHeight = character.HitBox.Height / 2.0f;
        
        int left = (character.Position.X - halfWidth) / gridSize;
        int right = (character.Position.X + halfWidth) / gridSize;
        int bottom = (character.Position.Y - halfHeight) / gridSize;
        int top = (character.Position.Y + halfHeight) / gridSize;
        
        for (int x = left; x <= right; x++)
        {
          for (int = bottom; y <= top; y++)
          {
            if (!characterMap.Contains(x, y))
              characterMap.Add(x, y, new List<CharacterObject>());
            
            characterMap[x, y].Add(proj);
          }
        }
      }
      
      // Check for collisions
      List<KeyPair<int, int>> cells = projectileMap.GetKeys();
      foreach (KeyPair<int, int> key in cells)
      {
        List<ProjectileObject> projs = projectileMap[key.Key1, key.Key2];
        if (projs.Count = 0)
          continue;
          
        if (!characterMap.Contains(key.Key1, key.Key2))
          continue;
          
        List<CharacterObject> chars = characterMap[key.Key1, keyKey2];
        if (chars.Count = 0)
          continue;
          
        //Finally, check for collisions
        foreach (ProjectileObject proj in projs)
        {
          foreach (CharacterObject chara in chars)
          {
            //TODO: Calculate collision
          }
        }
      }
      
      // if collission, apply damage
    }

    public void Finish()
    {
    }

  }
}
