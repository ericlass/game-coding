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
    public CharacterState State { get; set; }
    public StatePropertyMap StateAnimations { get; set; }

    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private string _currentState = null;

    public string CurrentState
    {
      get { return _currentState; }
      set
      {
        OnSwitchState(value, _currentState);
        _currentState = value;
      }
    }

    private void OnSwitchState(string oldState, string newState)
    {
      //TODO: Update animations accordingly
    }

    public override void Init()
    {
      foreach (string animName in StateAnimations.Values)
      {
        //TODO: Load animation
      }
    }

    public override void Finish()
    {
      //TODO: Release animations
    }

  }
}
