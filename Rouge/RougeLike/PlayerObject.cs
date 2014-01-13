using System;
using System.Collections.Generic;
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
    private Rectangle2f _hitBox = new Rectangle2f(-4, -8, 8, 10);
    private DoubleKeyMap<PlayerState, Orientation, Animation> _animations = new DoubleKeyMap<PlayerState, Orientation, Animation>();

    public override string ObjectType
    {
      get { return "player"; }
    }

    public Orientation Orientation
    {
      get { return _orientation; }
      set { _orientation = value; }
    }

    public PlayerState State
    {
      get { return _state; }
      set { _state = value; }
    }

    public Rectangle2f GetTransformedHitbox()
    {
      return new Rectangle2f(_hitBox.Min + Position, _hitBox.Max + Position);
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
    
    public void SwitchState(PlayerState newState)
    {
      _state = newState;
      _animations[_state, _orientation].Restart();
    }

    public override void Update(float dt)
    {
      _animations[_state, _orientation].Update(dt);
    }

    public override void Render()
    {
      Oku.Graphics.DrawImage(_animations[_state, _orientation].CurrentFrame, 0, 0);
      if (GameData.Instance.DebugDraw)
      {
        //Rectangle2f hitbox = GetTransformedHitbox();
        Oku.Graphics.DrawRectangle(_hitBox.Min.X, _hitBox.Max.X, _hitBox.Min.Y, _hitBox.Max.Y, new Color(255, 0, 0, 128));
      }
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
      return ObjectType;
    }
    
  }
}
