using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  /// <summary>
  /// Defines the base properties for an inventory item.
  /// </summary>
  public interface IInventoryItem : IIdObject
  {
    string Name { get; }
    bool IsWeapon { get; }
  }
}
