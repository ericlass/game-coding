using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class InventoryItemDefinition
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public InventoryItemType ItemType { get; set; }
    public string Image { get; set; }
    public float Weight { get; set; }
    public bool Droppable { get; set; }
  }
}
