using System;
using System.Collections.Generic;

namespace RougeLike.Character
{
  public class InventoryItemDefinition
  {
    /// <summary>
    /// The unique id of the inventory item.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The name of the item that is shown to the player.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A description of the item that is displayed on the inventory screen.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Defines of which type this item is.
    /// </summary>
    public InventoryItemType ItemType { get; set; }

    /// <summary>
    /// The id of the image that is rendered in the inventory screen.
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// The weight of the item in kilograms.
    /// </summary>
    public float Weight { get; set; }

    /// <summary>
    /// Defines if the item can be dropped. For example some quest items cannot be dropped.
    /// </summary>
    public bool Droppable { get; set; }
  }
}
