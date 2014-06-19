using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Timer;
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
    private bool _doMove = false;
    private bool _moveLeft = DateTime.Now.Ticks % 2 == 0;

    public SimpleEnemyController()
    {
      SetNewTimer();
    }

    private void SetNewTimer()
    {
      OkuBase.OkuManager.Instance.Timer.SetTimer(GameUtil.Random.Next(500, 2000), new TimerEventDelegate(OnTimer));
    }

    private void OnTimer(int id, object data)
    {
      _doMove = !_doMove;
      _moveLeft = GameUtil.Random.Next(100) > 50;
      SetNewTimer();
    }

    private void CheckForMovement(EntityObject entity)
    {
      float direction = entity.GetAttributeValue<NumberValue>("direction").Value;
      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      Vector2f movement = Vector2f.Zero;
      if (tilemap.CollideMovingPoint(entity.Position, new Vector2f(((entity.HitBox.Width / 2) * direction) + direction, 0), out movement))
      {
        _moveLeft = !_moveLeft;
        System.Diagnostics.Debug.WriteLine("Move Left: " + direction);
      }
    }

    public void Update(float dt, EntityObject entity)
    {
      switch (_state)
      {
        case EnemyState.Idle:
          CheckForMovement(entity);
          break;

        case EnemyState.Attack:
          break;

        default:
          throw new OkuBase.OkuException("Unknown enemy state: " + _state.ToString());
      }      
    }   

    public bool DoMoveLeft(EntityObject entity)
    {
      switch (_state)
      {
        case EnemyState.Idle:
          return _doMove && _moveLeft;

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
          return _doMove && !_moveLeft;

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
