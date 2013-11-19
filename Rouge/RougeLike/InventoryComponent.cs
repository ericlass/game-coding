using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class InventoryComponent : IComponent
  {
    public const string ComponentId = "inventory";

    private Entity _owner = null;
    private Dictionary<string, int> _items = new Dictionary<string, int>();

    public string Id
    {
      get { return ComponentId; }
    }

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public void AddItem(string itemId, int amount)
    {
      if (!_items.ContainsKey(itemId))
        _items.Add(itemId, 0);

      _items[itemId] += amount;
    }

    public void RemoveItem(string itemId, int amount)
    {
      if (!_items.ContainsKey(itemId))
        return;

      _items[itemId] = Math.Max(0, _items[itemId] - amount);
    }

    public int GetAmount(string itemId)
    {
      if (!_items.ContainsKey(itemId))
        return -1;

      return _items[itemId];
    }

    //HasItem - check if _items contains item
    //HasAmount - check if _items contains item and at least the given amount

    public void EnterState()
    {
    }
    
    public void Update(float dt)
    {
    }
    
    public void LeaveState()
    {
    }

  }
}
