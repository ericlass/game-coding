using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Character
{
  public class SkillSet
  {
    public float Run { get; set; }
    public float Jump { get; set; }
    public float BeamWeapons { get; set; }
    public float ProjectileWeapons { get; set; }
    public float Strength { get; set; }
    public float Armor { get; set; }

    public float GetWeaponRating(WeaponType weaponType)
    {
      switch (weaponType)
      {
        case WeaponType.Beam:
          return BeamWeapons;
        case WeaponType.Projectile:
          return ProjectileWeapons;
        default:
          throw new OkuBase.OkuException("Unknown weapon type: " + weaponType.ToString());
      }
    }

  }
}
