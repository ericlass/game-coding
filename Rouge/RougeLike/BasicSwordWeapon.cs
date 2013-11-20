using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class BasicSwordWeapon : IWeapon
  {
    public string ItemId
    {
      get { return "basicsword"; }
    }

    public WeaponType Type
    {
      get { return WeaponType.Sword; }
    }

    public int BaseDamage
    {
      get { return 10; }
    }

    public void Render()
    {
      throw new NotImplementedException();
    }
  }
}
