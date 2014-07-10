using System;
using System.Collections.Generic;
using RougeLike.Objects;

namespace RougeLike.Character
{
  public abstract class CharacterObject : GameObjectBase
  {
    public override string ObjectType
    {
      get { return "character"; }
    }

    public int Experience { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public SkillSet Skills { get; set; }
    public InventoryMap Inventory { get; set; }
    public StatePropertyMap StateAnimations { get; set; }

    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private CharacterState _currentState = CharacterState.Idle;

    public CharacterState CurrentState
    {
      get { return _currentState; }
      set
      {
        OnSwitchState(value, _currentState);
        _currentState = value;
      }
    }

    private void OnSwitchState(CharacterState oldState, CharacterState newState)
    {
      _animations[StateAnimations[newState]].Restart();
    }

    public override void Init()
    {
      foreach (string animName in StateAnimations.Values)
        _animations.Add(animName, GameUtil.LoadAnimation(animName));
    }

    public override void Finish()
    {
      foreach (Animation anim in _animations.Values)
        GameUtil.ReleaseAnimation(anim);
    }


    public override void Update(float dt)
    {
      _animations[StateAnimations[_currentState]].Update(dt);
      RenderDescription.Image = _animations[StateAnimations[_currentState]].CurrentFrame;
    }

    public override void PreRender()
    {      
    }

    protected override StringPairMap DoSave()
    {
      return null;
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

  }
}
