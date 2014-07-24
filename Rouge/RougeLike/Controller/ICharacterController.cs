using System;
using System.Collections.Generic;
using RougeLike.Character;

namespace RougeLike.Controller
{
  /// <summary>
  /// Defines a controller for entities that controls when an entity is supposed to take some action.
  /// </summary>
  public interface ICharacterController
  {
    void Update(float dt, CharacterObject character);

    /// <summary>
    /// Checks if the entity is supposed to move to the left.
    /// </summary>
    /// <param name="character">The character object to be controlled.</param>
    /// <returns>True if the entity should move, else false.</returns>
    bool DoMoveLeft(CharacterObject character);

    /// <summary>
    /// Checks if the entity is supposed to move to the right.
    /// </summary>
    /// <param name="character">The character object to be controlled.</param>
    /// <returns>True if the entity should move, else false.</returns>
    bool DoMoveRight(CharacterObject character);

    /// <summary>
    /// Checks if the entity is supposed to jump.
    /// </summary>
    /// <param name="character">The character object to be controlled.</param>
    /// <returns>True if the entity should jump, else false.</returns>
    bool DoJump(CharacterObject character);

    /// <summary>
    /// Checks if the character is supposed to shoot.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns>True if a shot should be fired, else false.</returns>
    bool DoShoot(CharacterObject character);

  }
}
