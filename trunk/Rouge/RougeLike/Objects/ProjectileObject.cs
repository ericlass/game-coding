using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace RougeLike.Objects
{
  public class ProjectileObject : GameObjectBase
  {
    private float _damage = 1.0f;
    private string _weaponId = null; // The item id of the weapon that fired the projectile
    private string sourceId = null; // The object id of the character who shot the projectile
    private Vector2f _direction = Vector2f.Zero;

    public override string ObjectType
    {
      get { return "projectile"; }
    }

    public float Damage
    {
      get { return _damage; }
      set { _damage = value; }
    }

    public string WeaponId
    {
      get { return _weaponId; }
      set { _weaponId = value; }
    }

    public Vector2f Direction
    {
      get { return _direction; }
      set { _direction = value; }
    }

    public override void Init()
    {
    }

    public override void Update(float dt)
    {
    }

    public override void Finish()
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
