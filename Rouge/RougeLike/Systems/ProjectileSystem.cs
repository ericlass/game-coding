using System;
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
      // If no projectiles, return
      // Get targets
      // calculate spatial hashes of projectiles and targets
      // Check for collisions
      // if collission, apply damage
    }

    public void Finish()
    {
    }

  }
}
