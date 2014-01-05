using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public enum PlayerState
  {
    Idle,
    Move,
    Attack
  }

  public class PlayerObject : GameObjectBase
  {
    private Orientation _orientation = Orientation.Down;
    private PlayerState _state = PlayerState.Idle;
    private DoubleKeyMap<PlayerState, Orientation, Animation> _animations = new DoubleKeyMap<PlayerState, Orientation, Animation>();

    public override string ObjectType
    {
      get { return "player"; }
    }
    
    private string GetStateString(PlayerState state, Orientation orient)
    {
      return ObjectType + "_" + orient.ToString().ToLower() + "_" + state.ToString().ToLower();
    }
    
    public override void Init()
    {
      PlayerState[] states = (PlayerState[])Enum.GetValues(typeof(PlayerState));
      Orientation[] orients = (Orientation[])Enum.GetValues(typeof(Orientation));
      
      foreach (PlayerState state in states)
      {
        foreach (Orientation orient in orients)
        {
          string baseName = GetStateString(state, orient);
          Animation anim = GameUtil.LoadAnimation(baseName);
          _animations.Add(state, orient, anim);
        }
      }
    }
    
    private void SwitchState(PlayerState newState)
    {
      _state = newState;
      _animations[_state, _orientation].Restart();
    }

    public override void Update(float dt)
    {
      _animations[_state, _orientation].Update(dt);
    
      switch (_state)
      {
        case PlayerState.Idle:
          // If any of the movement buttons was pressed, go to move state
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Left) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Right) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Down) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Up))
          {
            SwitchState(PlayerState.Move);
          }

          if (Oku.Input.Keyboard.KeyIsDown(Keys.Space))
            SwitchState(PlayerState.Attack);
          break;

        case PlayerState.Move:
          float speed = 100.0f * dt;
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

          Vector2f pos = Position;
          pos.X += dx;
          pos.Y += dy;
          Position = pos;

          if (dy > 0)
            _orientation = Orientation.Up;
          if (dy < 0)
            _orientation = Orientation.Down;
          if (dx > 0)
            _orientation = Orientation.Right;
          if (dx < 0)
            _orientation = Orientation.Left;
          
          if (dx == 0 && dy == 0)
            SwitchState(PlayerState.Idle);
          
          break;

        case PlayerState.Attack:
          //Actually, the attack state is an extension of the move state.
          //The player can move while attacking.
        
          //TODO: Damage enemies in attack area
          
          //Switch back. Actually, you have to switch to the previous state. Maybe this can be done with a stack.
          //Instead of SwitchState there would then be EnterState and LeaveState.
          if (_animations[_state, _orientation].Finished)
            SwitchState(PlayerState.Idle);
          break;
          
        default:
          throw new Exception("Unsupported player state: '" + _state.ToString() + "'");
        
      }
    }

    public override void Render()
    {
      Oku.Graphics.DrawImage(_animations[_state, _orientation].CurrentFrame, 0, 0);
    }

    public override void Finish()
    {
      List<Animation> anims = _animations.GetAllValues();
      foreach (Animation anim in anims)
      {
        foreach (ImageBase img in anim.Frames)
        {
          Oku.Graphics.ReleaseImage((Image)img);
        }
      }      
    }

    protected override StringPairMap DoSave()
    {
      //Nothing to do at the moment
      return new StringPairMap();
    }

    protected override void DoLoad(StringPairMap data)
    {
      //Nothing to do at the moment
    }

    public override string ToString()
    {
      return "player";
    }
    
  }
}
