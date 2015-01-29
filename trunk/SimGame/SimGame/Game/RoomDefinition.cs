using System;
using System.Collections.Generic;

namespace SimGame.Game
{
  public class RoomDefinition
  {
    /// <summary>
    /// Gets or sets a unique id for this type of room.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or set a displayable name for this type of room.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets if this type of room can be moved or deleted or not.
    /// </summary>
    public bool Fixed { get; set; }

    /// <summary>
    /// Gets or sets the base type for this type of room.
    /// </summary>
    public RoomType BaseType { get; set; }

    /// <summary>
    /// Gets or sets the number of spaces this type of room uses.
    /// </summary>
    public int NumberOfSpaces { get; set; }
  }
}
