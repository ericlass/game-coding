using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  /// <summary>
  /// Defines a controller for entities that controls when an entity is supposed to take some action.
  /// </summary>
  public interface IEntityController
  {
    /// <summary>
    /// Checks if the entity is supposed to move to the left.
    /// </summary>
    /// <returns>True if the entity should move, else false.</returns>
    bool DoMoveLeft(EntityObject entity);

    /// <summary>
    /// Checks if the entity is supposed to move to the right.
    /// </summary>
    /// <returns>True if the entity should move, else false.</returns>
    bool DoMoveRight(EntityObject entity);

    /// <summary>
    /// Checks if the entity is supposed to jump.
    /// </summary>
    /// <returns>True if the entity should jump, else false.</returns>
    bool DoJump(EntityObject entity);

  }
}
