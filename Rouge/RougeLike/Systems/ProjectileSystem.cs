using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using RougeLike.Objects;
using RougeLike.Character;

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
      // Get projectiles
      List<GameObjectBase> projectileObjects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_projectileGroup);
      if (projectileObjects.Count == 0)
        return;
        
      // Cast to projectiles
      List<ProjectileObject> projectiles = new List<ProjectileObject>();
      foreach (GameObjectBase obj in projectileObjects)
        projectiles.Add(obj as ProjectileObject);
        
      //Move projectiles
      foreach (ProjectileObject proj in projectiles)
      {
        WeaponDefinition weapon = GameData.Instance.InventoryItems[proj.WeaponId] as WeaponDefinition;
        proj.Position = proj.Position + (proj.Direction * weapon.ProjectileSpeed * dt);
      }
            
      // Get targets
      List<GameObjectBase> characterObjects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_hitGroup);
      if (characterObjects.Count == 0)
        return;
        
      // Cast to characters
      List<CharacterObject> characters = new List<CharacterObject>();
      foreach (GameObjectBase obj in characterObjects)
        characters.Add(obj as CharacterObject);
      
      int gridSize = 64;
      
      // calculate spatial hashes of projectiles
      DoubleKeyMap<int, int, List<ProjectileObject>> projectileMap = new DoubleKeyMap<int, int, List<ProjectileObject>>();
      foreach (ProjectileObject proj in projectiles)
      {
        WeaponDefinition weapon = GameData.Instance.InventoryItems[proj.WeaponId] as WeaponDefinition;
        float projectileSize = weapon.ProjectileSize;

        int left = (int)(proj.Position.X - projectileSize) / gridSize;
        int right = (int)(proj.Position.X + projectileSize) / gridSize;
        int bottom = (int)(proj.Position.Y - projectileSize) / gridSize;
        int top = (int)(proj.Position.Y + projectileSize) / gridSize;
        
        for (int x = left; x <= right; x++)
        {
          for (int y = bottom; y <= top; y++)
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
        
        int left = (int)(character.Position.X - halfWidth) / gridSize;
        int right = (int)(character.Position.X + halfWidth) / gridSize;
        int bottom = (int)(character.Position.Y - halfHeight) / gridSize;
        int top = (int)(character.Position.Y + halfHeight) / gridSize;
        
        for (int x = left; x <= right; x++)
        {
          for (int y = bottom; y <= top; y++)
          {
            if (!characterMap.Contains(x, y))
              characterMap.Add(x, y, new List<CharacterObject>());

            characterMap[x, y].Add(character);
          }
        }
      }
      
      // Check for collisions
      List<KeyPair<int, int>> cells = projectileMap.GetKeys();
      foreach (KeyPair<int, int> key in cells)
      {
        List<ProjectileObject> projs = projectileMap[key.Key1, key.Key2];
        if (projs.Count == 0)
          continue;
          
        if (!characterMap.Contains(key.Key1, key.Key2))
          continue;
          
        List<CharacterObject> chars = characterMap[key.Key1, key.Key2];
        if (chars.Count == 0)
          continue;
          
        //Finally, check for collisions
        foreach (ProjectileObject proj in projs)
        {
          WeaponDefinition weapon = GameData.Instance.InventoryItems[proj.WeaponId] as WeaponDefinition;
          float projectileSize = weapon.ProjectileSize;
          foreach (CharacterObject chara in chars)
          {
            Rectangle2f projRect = new Rectangle2f(proj.Position.X - projectileSize, proj.Position.Y - projectileSize, projectileSize * 2, projectileSize * 2);

            float halfWidth = chara.HitBox.Width / 2.0f;
            float halfHeight = chara.HitBox.Height / 2.0f;
            Rectangle2f charRect = new Rectangle2f(chara.Position.X - halfWidth, chara.Position.Y - halfHeight, chara.HitBox.Width, chara.HitBox.Height);
            
            if (IntersectionTests.Rectangles(projRect.Min, projRect.Max, charRect.Min, charRect.Max))
            {
              chara.Damage(proj);
              GameData.Instance.ActiveScene.GameObjects.Remove(proj);
            }
          }
        }
      }
    }

    public void Finish()
    {
    }

  }
}
