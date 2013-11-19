using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  /// <summary>
  /// Defines a component that stores the id of the currently equiped weapon inventory item.
  /// </summary>
  public class EquipedWeaponComponent : IComponent
  {
    public const string ComponentId = "equiped_weapon";

    private Entity _owner = null;
    private string _weaponItemId = null;

    /// <summary>
    /// Gets or sets the owning entity of this component.
    /// </summary>
    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    /// <summary>
    /// Gets or sets the ID of the inventory item that is used as a weapon at the moment.
    /// </summary>
    public string WeaponItemId
    {
      get { return _weaponItemId; }
      set
      {
        IInventoryItem item = GameManager.Instance.InventoryItems[value];
        if (item == null)
          throw new InvalidOperationException("There is no inventory item with the id " + value + "!");

        if (!item.IsWeapon)
          throw new InvalidOperationException("The item with the id " + value + " is not a weapon and cannot be equiped!");

        _weaponItemId = value;
      }
    }

    public void EnterState()
    {
    }
    
    public void Update(float dt)
    {
    }
    
    public void LeaveState()
    {
    }

    /// <summary>
    /// Gets the components id.
    /// </summary>
    public string Id
    {
      get { return ComponentId; }
    }

  }
}
