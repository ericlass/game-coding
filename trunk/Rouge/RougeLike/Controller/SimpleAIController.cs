using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Timer;
using RougeLike.Attributes;
using RougeLike.Tiles;
using RougeLike.Objects;
using RougeLike.Character;

namespace RougeLike.Controller
{
  public class SimpleAIController : ICharacterController
  {
    private enum EnemyState 
    {
      Idle,
      Attack
    };

    private EnemyState _state = EnemyState.Idle;
    private bool _doMove = false;
    private bool _moveLeft = DateTime.Now.Ticks % 2 == 0;

    public SimpleAIController()
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

    private void CheckForMovement(CharacterObject character)
    {
      float direction = character.GetAttributeValue<NumberValue>("direction").Value;
      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      Vector2f movement = Vector2f.Zero;
      if (tilemap.CollideMovingPoint(character.Position, new Vector2f(((character.HitBox.Width / 2) * direction) + direction, 0), out movement))
      {
        _moveLeft = !_moveLeft;
        System.Diagnostics.Debug.WriteLine("Move Left: " + direction);
      }
    }

    public void Update(float dt, CharacterObject character)
    {
      switch (_state)
      {
        case EnemyState.Idle:
          CheckForMovement(character);
          break;

        case EnemyState.Attack:
          break;

        default:
          throw new OkuBase.OkuException("Unknown enemy state: " + _state.ToString());
      }      
    }

    public bool DoMoveLeft(CharacterObject character)
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

    public bool DoMoveRight(CharacterObject character)
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

    public bool DoJump(CharacterObject character)
    {
      return false;
    }

    public bool DoShoot(CharacterObject character)
    {
      return false;
    }

  }
}
