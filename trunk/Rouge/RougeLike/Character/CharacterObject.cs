using System;
using System.Collections.Generic;
using RougeLike.Objects;
using OkuBase.Geometry;

namespace RougeLike.Character
{
  public delegate void OnCharacterStateChange(CharacterState oldState, CharacterState newState);

  public class CharacterObject : GameObjectBase
  {
    public event OnCharacterStateChange OnStateChange;

    private SkillSet _skills = new SkillSet();
    private float _health = 0.0f;

    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private CharacterState _currentState = CharacterState.Idle;

    public InventoryMap Inventory { get; set; }
    public StatePropertyMap StateAnimations { get; set; }
    public Rectangle2f HitBox { get; set; }

    public string EquipedWeapon { get; set; }
    public string EquipedArmor { get; set; }

    public int Experience { get; set; }
    public int Level { get; set; }
    public float XP { get; set; } // The experience points that are given to characters that kill this character

    public SkillSet Skills
    {
      get { return _skills; }
      set { _skills = value; }
    }

    public override string ObjectType
    {
      get { return "character"; }
    }

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

    public float Health 
    {
      get { return _health; }
      set { _health = value; }
    }

    private void OnSwitchState(CharacterState oldState, CharacterState newState)
    {
      if (StateAnimations.ContainsKey(newState))
        _animations[StateAnimations[newState]].Restart();
    }

    public override void Init()
    {
      foreach (string animName in StateAnimations.Values)
        _animations.Add(animName, GameData.Instance.ActiveScene.Content.GetAnimation(animName));
    }

    public override void Finish()
    {
    }


    public override void Update(float dt)
    {
      if (StateAnimations.ContainsKey(_currentState))
        _animations[StateAnimations[_currentState]].Update(dt);

      RenderDescription.Image = _animations[StateAnimations[_currentState]].CurrentFrame;
    }

    protected override StringPairMap DoSave()
    {
      return null;
    }

    protected override void DoLoad(StringPairMap data)
    {
    }
    
    public void Hit(ProjectileObject projectile)
    {
      CharacterObject shooter = GameData.Instance.ActiveScene.GameObjects.GetObjectById(projectile.SourceId) as CharacterObject;
      WeaponDefinition weapon = GameData.Instance.InventoryItems[projectile.WeaponId] as WeaponDefinition;
    
      float armorRating = 1.0f;
      if (EquipedArmor != null)
      {
        ArmorDefinition armor = GameData.Instance.InventoryItems[EquipedArmor] as ArmorDefinition;
        armorRating = armor.GetWeaponRating(weapon.WeaponType);
      }

      float armorBuff = 1.0f;
      if (shooter.EquipedArmor != null)
      {
        ArmorDefinition armor = GameData.Instance.InventoryItems[shooter.EquipedArmor] as ArmorDefinition;
        armorBuff = armor.Buffs.GetWeaponRating(weapon.WeaponType);
      }

      float finalDamage = weapon.Damage * shooter.Skills.GetWeaponRating(weapon.WeaponType) * armorBuff * armorRating;
      
      Health -= finalDamage;
      
      if (Health <= 0)
      {
        CurrentState = CharacterState.Dead;
        ; // TODO: Give XP to shooter
      }
    }

  }
}
