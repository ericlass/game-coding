using System;
using System.Collections.Generic;
using RougeLike.Objects;
using OkuBase.Geometry;

namespace RougeLike.Character
{
  public delegate void OnCharacterStateChange(CharacterState oldState, CharacterState newState);

  public class CharacterObject : GameObjectBase
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
    public Rectangle2f HitBox { get; set; }

    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private CharacterState _currentState = CharacterState.Idle;

    public event OnCharacterStateChange OnStateChange;

    public CharacterState CurrentState
    {
      get { return _currentState; }
      set
      {
        OnSwitchState(_currentState, value);
        if (OnStateChange != null)
          OnStateChange(_currentState, value);

        _currentState = value;
      }
    }

    private void OnSwitchState(CharacterState oldState, CharacterState newState)
    {
      if (StateAnimations.ContainsKey(newState))
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
      if (StateAnimations.ContainsKey(_currentState))
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
