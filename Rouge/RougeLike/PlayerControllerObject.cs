using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;

namespace RougeLike
{
  public class PlayerControllerObject : GameObjectBase
  {
    private string _playerId = null;
    private string _tilemapId = null;

    private PlayerObject _player = null;
    private TileMapObjectBase _tileMap = null;

    public override string ObjectType
    {
      get { return "playercontroller"; }
    }

    public override void Init()
    {
      _player = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_playerId) as PlayerObject;
      _tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_tilemapId) as TileMapObjectBase;
    }

    public override void Update(float dt)
    {
      switch (_player.State)
      {
        case PlayerState.Idle:
          // If any of the movement buttons was pressed, go to move state
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Left) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Right) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Down) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Up))
          {
            _player.SwitchState(PlayerState.Move);
          }

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Space))
            _player.SwitchState(PlayerState.Attack);
          break;

        case PlayerState.Move:
          float speed = 200.0f * dt;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.LControlKey))
            speed = 50.0f * dt;

          float dx = 0;
          float dy = 0;

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Left))
            dx -= speed;
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Right))
            dx += speed;
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Down))
            dy -= speed;
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Up))
            dy += speed;

          Vector2f disp = _tileMap.MoveBox(_player.GetTransformedHitbox(), new Vector2f(dx, dy));

          Vector2f pos = _player.Position;
          pos.X += disp.X;
          pos.Y += disp.Y;
          _player.Position = pos;

          //System.Diagnostics.Debug.WriteLine(_player.Position.ToString());

          if (dy > 0)
            _player.Orientation = Orientation.Up;
          if (dy < 0)
            _player.Orientation = Orientation.Down;
          if (dx > 0)
            _player.Orientation = Orientation.Right;
          if (dx < 0)
            _player.Orientation = Orientation.Left;

          if (dx == 0 && dy == 0)
            _player.SwitchState(PlayerState.Idle);

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Space))
            _player.SwitchState(PlayerState.Attack);

          break;

        case PlayerState.Attack:
          //Actually, the attack state is an extension of the move state.
          //The player can move while attacking.

          //TODO: Damage enemies in attack area

          //Switch back. Actually, you have to switch to the previous state. Maybe this can be done with a stack.
          //Instead of SwitchState there would then be EnterState and LeaveState.
          //if (_animations[_state, _orientation].Finished)
            //SwitchState(PlayerState.Idle);
          break;

        default:
          throw new Exception("Unsupported player state: '" + _player.State.ToString() + "'");

      }

      Oku.Graphics.Viewport.Center = _player.Position;
    }

    public override void Render()
    {
    }

    public override void Finish()
    {
      _player = null;
      _tileMap = null;
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("playerid", _player.Id);
      result.Add("tilemapid", _tileMap.Id);
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      if (data.ContainsKey("playerid"))
        _playerId = data["playerid"];
      else
        throw new OkuBase.OkuException("The 'playerid' property is mandatory for player controllers!");

      if (data.ContainsKey("tilemapid"))
        _tilemapId = data["tilemapid"];
      else
        throw new OkuBase.OkuException("The 'tilemapid' property is mandatory for player controllers!");
    }

    public override string ToString()
    {
      return ObjectType;
    }

  }
}
