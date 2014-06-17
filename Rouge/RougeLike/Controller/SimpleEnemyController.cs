using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Tiles;
using RougeLike.Objects;

namespace RougeLike.Controller
{
  public class SimpleEnemyController : IEntityController
  {
    private enum EnemyState 
    {
      Idle,
      Attack
    };

    private EnemyState _state = EnemyState.Idle;
    private bool _moveLeft = DateTime.Now.Ticks % 2 == 0;

    private void CheckForMovement(EntityObject entity)
    {
      float direction = entity.GetAttributeValue<NumberValue>("direction").Value;
      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      Vector2f movement = Vector2f.Zero;
      if (tilemap.CollideMovingPoint(entity.Position, new Vector2f((entity.HitBox.Width / 2) * direction, 0), out movement))
      {
        _moveLeft = !_moveLeft;
        System.Diagnostics.Debug.WriteLine("Move Left: " + direction);
      }
    }

    public bool DoMoveLeft(EntityObject entity)
    {
      switch (_state)
      {
        case EnemyState.Idle:
          CheckForMovement(entity);
          return _moveLeft;

        case EnemyState.Attack:
          break;

        default:
          throw new OkuBase.OkuException("Unknown enemy state: " + _state.ToString());
      }

      return false;
    }

    public bool DoMoveRight(EntityObject entity)
    {
      switch (_state)
      {
        case EnemyState.Idle:
          CheckForMovement(entity);
          return !_moveLeft;

        case EnemyState.Attack:
          break;

        default:
          throw new OkuBase.OkuException("Unknown enemy state: " + _state.ToString());
      }

      return false;
    }

    public bool DoJump(EntityObject entity)
    {
      return false;
    }

  }
}
