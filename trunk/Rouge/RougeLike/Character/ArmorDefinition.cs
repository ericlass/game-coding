using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class ArmorDefinition : InventoryItemDefinition
  {
    /// <summary>
    /// Defines how much beam weapons damage the carrier of the armor. 0.5 means only half damage is taken.
    /// </summary>
    public float BeamRating { get; set; }

    /// <summary>
    /// Defines how much projectile weapons damage the carrier of the armor. 0.5 means only half damage is taken.
    /// </summary>
    public float ProjectileRating { get; set; }

    /// <summary>
    /// Defines buffs the armor gives to the carrier.
    /// </summary>
    public SkillSet Buffs { get; set; }

    /// <summary>
    /// Defines a list of weapon effects the carrier of the armor is imun to.
    /// </summary>
    public List<WeaponEffect> Immunities { get; set; } // Must be checked by weapon effect before effect is applied

    public float GetWeaponRating(WeaponType weaponType)
    {
      switch (weaponType)
      {
        case WeaponType.Beam:
          return BeamRating;
        case WeaponType.Projectile:
          return ProjectileRating;
        default:
          throw new OkuBase.OkuException("Unknown weapon type: " + weaponType.ToString());
      }
    }

  }
}
