using System;
using System.Collections.Generic;
using OkuBase;
using RougeLike.Character;

namespace RougeLike.Controller
{
  public class PlayerController : ICharacterController
  {
    public bool DoMoveLeft(CharacterObject character)
    {
      return OkuManager.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A);
    }

    public bool DoMoveRight(CharacterObject character)
    {
      return OkuManager.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D);
    }

    public bool DoJump(CharacterObject character)
    {
      return OkuManager.Instance.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.W);
    }

    public void Update(float dt, CharacterObject character)
    {
    }
  }
}
