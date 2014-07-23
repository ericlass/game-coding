using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class WeaponDefinition : InventoryItemDefinition
  {
    public WeaponType WeaponType { get; set; }
    public float RateOfFire { get; set; }
    public float Damage { get; set; }
    public float ProjectileSpeed { get; set; }
    public float ProjectileSize { get; set; }
    public bool Continuous { get; set; }
    public WeaponEffect Effect { get; set; } //Is applied when shot hits another character
    public string MuzzleFlashAnim { get; set; }
    public string ProjectileAnim { get; set; }
    public string HitAnim { get; set; }
    public string TrailAnim { get; set; }
    public string Sound { get; set; }
  }
}
