using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace RougeLike.Objects
{
  public class ProjectileObject : GameObjectBase
  {
    private float _damageRatio = 1.0f;
    private string _weaponId = null;
    private Vector2f _direction = Vector2f.Zero;

    public override string ObjectType
    {
      get { return "projectile"; }
    }

    public float DamageRatio
    {
      get { return _damageRatio; }
      set { _damageRatio = value; }
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
