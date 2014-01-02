using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using System.Windows.Forms;

namespace RougeLike
{
  public enum PlayerState
  {
    Idle,
    Move,
    Attack
  }

  public class PlayerGameObject : GameObjectBase
  {
    private Orientation _orientation = Orientation.Down;
    private PlayerState _state = PlayerState.Idle;
    private DoubleKeyMap<PlayerState, Orientation, Animation> _animations = new DoubleKeyMap<PlayerState, Orientation, Animation>();

    public override string ObjectType
    {
      get { return "player"; }
    }
    
    private GetStateString(PlayerState state, Orientation orient)
    {
      return ObjectType + "_" + orient.ToString().ToLower() + "_" + state.ToString().Tolower();
    }
    
    //TODO: Put this in a util class
    private Animation LoadAnimation(string baseName)
    {
      //TODO: Load files that start with baseName and create animation for them
      //ImageData data = ImageData.FromFile(".\\Content\\Graphics\\player_down_idle.png");
      //Image sprite = Oku.Graphics.NewImage(data);
      return null;
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
          Animation anim = LoadAnimation(baseName);
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
        case Idle:
          // If any of the movement buttons was pressed, go to move state
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Left) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Right) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Down) ||
              Oku.Input.Keyboard.KeyIsDown(Keys.Up))
          {
            SwitchState(PlayerState.Move);
          }
          
          if (Oku.Input.Keyboard.KeyIsDown(Keys.Space))
            SwitchState(PlayerStates.Attack)
          break;
          
        case Move:
          float speed = 120.0f * dt;
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
          
          if (dx == 0 && dy == 0)
            SwitchState(PlayerState.Idle);
          
          break;
          
        case Attack:
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
          break;
        
      }
    }

    public override void Render()
    {
      Oku.Graphics.DrawImage(_animations[_state, _orientation].CurrentFrame, Position.X, Position.Y);
    }

    public override void Finish()
    {
      //Oku.Graphics.ReleaseImage(_sprite);
      //TODO: Release all animation images. Must be able to iterate DoubleKeyMap for this.
    }

    public override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    public override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "player";
    }
    
  }
}
