using System;
using System.Collections.Generic;
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
    private bool _moveLeft = DateTime.Now.Second % 2 == 0;

    private void CheckForMovement(EntityObject entity)
    {
      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      TileType ttb = tilemap.GetTileBelow(entity.Position);
      TileType tt = tilemap.GetTileAt(entity.Position);
      if (tt != TileType.Empty || (ttb != TileType.Filled && ttb != TileType.NorthEast && ttb != TileType.NorthWest))
        _moveLeft = !_moveLeft;
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
