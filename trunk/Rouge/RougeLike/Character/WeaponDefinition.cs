using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class WeaponDefinition : InventoryItemDefinition
  {
    public WeaponType WeaponType { get; set; }
    public int RateOfFire { get; set; }
    public int Damage { get; set; }
    public int ProjectileSpeed { get; set; }
    public int ProjectileSize { get; set; }
    public bool Continuous { get; set; }
    public WeaponEffect Effect { get; set; } //Is applied when shot hits another character
    public string MuzzleFlashAnim { get; set; }
    public string ProjectileAnim { get; set; }
    public string HitAnim { get; set; }
    public string TrailAnim { get; set; }
    public string Sound { get; set; }
  }
}
