using System;

namespace OkuEngine.Input
{
  public enum InputAction
  {
    MouseLeftDown = InputKey.MouseLeft | InputKeyAction.Down,
    MouseLeftUp = InputKey.MouseLeft | InputKeyAction.Up
  }
}
