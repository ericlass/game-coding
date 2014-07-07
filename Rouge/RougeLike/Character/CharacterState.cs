using System;

namespace RougeLike.Character
{
  public enum CharacterState
  {
    Idle,
    Walking,
    Jumping,
    Falling,
    Frozen // When frozen, the character cannot move. That is why it is a separate state in contrast to OnFire and Shocked.
  }
}
