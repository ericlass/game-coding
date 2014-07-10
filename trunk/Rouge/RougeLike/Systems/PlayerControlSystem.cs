using System;
using System.Collections.Generic;
using RougeLike.Objects;
using RougeLike.Character;

namespace RougeLike.Systems
{
  public class PlayerControlSystem : IGameSystem
  {
    private string _playerId = null; //ID of player object
    private CharacterObject _playerObject = null;

    public PlayerControlSystem(string playerId)
    {
      _playerId = playerId;
    }

    public string PlayerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }

    public void Init()
    {
      _playerObject = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_playerId) as CharacterObject;
    }

    public void Update(float dt)
    {
      switch (_playerObject.CurrentState)
      {
        case CharacterState.Idle:
          break;
        case CharacterState.Walking:
          break;
        case CharacterState.Jumping:
          break;
        case CharacterState.Falling:
          break;
        case CharacterState.Frozen:
          break;
        default:
          break;
      }
    }

    public void Finish()
    {
      _playerObject = null;
    }

  }
}
