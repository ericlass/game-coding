using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public interface IWeapon
  {
    string ItemId { get; }
    WeaponType Type { get; }
    int BaseDamage { get; }
    void Render();
  }
}
