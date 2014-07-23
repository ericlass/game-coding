using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class ArmorDefinition : InventoryItemDefinition
  {
    public float BeamRating { get; set; }
    public float ProjectileRating { get; set; }
    public SkillSet Buffs { get; set; }
    public List<WeaponEffect> Immunities { get; set; } // Must be checked by weapon effect before effect is applied
  }
}
