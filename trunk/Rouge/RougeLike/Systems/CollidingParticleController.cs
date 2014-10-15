using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Particles;
using RougeLike.Objects;

namespace RougeLike.Systems
{
  public class CollidingParticleController : IParticleController
  {
    private string _tileMapId = null;

    public CollidingParticleController(string tileMapId)
    {
      _tileMapId = tileMapId;
    }

    public void Update(Particle particle, float dt)
    {
      particle.OldPosition = particle.Position;

      if (!particle.Velocity.IsZero())
      {
        TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_tileMapId) as TileMapObject;
        Vector2f maxMove;
        if (tilemap.CollideMovingPoint(particle.Position, particle.Velocity * dt, out maxMove))
        {
          particle.Velocity = Vector2f.Zero;
        }

        particle.Position = particle.Position + maxMove * dt;
      }

      particle.Energy -= dt;
    }

  }
}
