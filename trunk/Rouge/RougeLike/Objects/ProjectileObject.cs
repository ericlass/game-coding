using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.Objects
{
  public class ProjectileObject : GameObjectBase
  {
    private string _weaponId = null;
    private string _sourceId = null;
    private Vector2f _direction = Vector2f.Zero;
    private Animation _animation = null;
    private bool _hit = false;
    private float _life = 1.5f;

    public override string ObjectType
    {
      get { return "projectile"; }
    }

    /// <summary>
    /// Gets or sets the id of the character object that fired the shot.
    /// </summary>
    public string SourceId
    {
      get { return _sourceId; }
      set { _sourceId = value; }
    }

    /// <summary>
    /// Gets or sets the item id of the weapon that was used.
    /// </summary>
    public string WeaponId
    {
      get { return _weaponId; }
      set { _weaponId = value; }
    }

    /// <summary>
    /// Gets or sets the direction in which the projectile is supposed to travel. Should be normalized.
    /// </summary>
    public Vector2f Direction
    {
      get { return _direction; }
      set { _direction = value; }
    }

    /// <summary>
    /// Gets or set the animation for this projectile.
    /// </summary>
    public Animation Animation
    {
      get { return _animation; }
      set { _animation = value; }
    }

    /// <summary>
    /// Gets or set if the projectile has hit something yet.
    /// </summary>
    public bool Hit
    {
      get { return _hit; }
      set { _hit = value; }
    }

    /// <summary>
    /// Gets or sets the rest of life time the projectile has.
    /// This is used to kill projectiles that hit nothing and would travel forever.
    /// </summary>
    public float Life
    {
      get { return _life; }
      set { _life = value; }
    }

    public override void Init()
    {
    }

    public override void Update(float dt)
    {
      if (_animation != null)
      {
        _animation.Update(dt);
        RenderDescription.Image = _animation.CurrentFrame;
      }
      else
        RenderDescription.Image = null;
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
