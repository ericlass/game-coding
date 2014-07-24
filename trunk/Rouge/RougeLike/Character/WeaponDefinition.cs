using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class WeaponDefinition : InventoryItemDefinition
  {
    /// <summary>
    /// Defines the type of the wepaon.
    /// </summary>
    public WeaponType WeaponType { get; set; }

    /// <summary>
    /// The rate of fire in shots per second.
    /// </summary>
    public float RateOfFire { get; set; }

    /// <summary>
    /// The damage that one projectile causes when it hits something.
    /// </summary>
    public float Damage { get; set; }

    /// <summary>
    /// The speed of the projectiles in pixels per second.
    /// </summary>
    public float ProjectileSpeed { get; set; }

    /// <summary>
    /// The size of a projectile in pixels.
    /// </summary>
    public float ProjectileSize { get; set; }

    /// <summary>
    /// Defines if the player can hold down the shoot button to fire continuously or not.
    /// </summary>
    public bool Continuous { get; set; }

    /// <summary>
    /// Defines an additional effect the weapon has.
    /// </summary>
    public WeaponEffect Effect { get; set; }

    /// <summary>
    /// The id of the animation that used as the muzzle flash when the player shoots.
    /// </summary>
    public string MuzzleFlashAnim { get; set; }

    /// <summary>
    /// The id of the animation that is used to render the projectil.
    /// </summary>
    public string ProjectileAnim { get; set; }

    /// <summary>
    /// The id of the animation that is played when the projectile hits something.
    /// </summary>
    public string HitAnim { get; set; }

    /// <summary>
    /// The id of the anmation that is rendered along the path the projectile travels, for example a smoke trail.
    /// </summary>
    public string TrailAnim { get; set; }

    /// <summary>
    /// The sound that is played when the weapon is fired.
    /// </summary>
    public string Sound { get; set; }
  }
}
