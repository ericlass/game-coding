using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;

namespace OkuEngine.Input
{
  class KeyInputAxis : IInputAxis
  {
    public InputKey _key;
    public float _scale = 1.0f;

    public KeyInputAxis(InputKey key)
    {
      _key = key;
    }

    public KeyInputAxis(InputKey key, float scale)
    {
      _key = key;
      _scale = scale;
    }

    public InputKey Key
    {
      get { return _key; }
    }

    public float Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public float GetCurrentValue()
    {
      Keys key = (Keys)((int)_key | 0xFFFF);
      InputDevice device = (InputDevice)((int)_key | 0xF0000);

      float value = 0.0f;
      switch (device)
      {
        case InputDevice.Keyboard:
          value = OkuManager.Instance.Input.Keyboard.KeyIsDown(key) ? 1.0f : 0.0f;
          break;

        case InputDevice.Mouse:
          value = OkuManager.Instance.Input.Mouse.ButtonIsDown((MouseButton)key) ? 1.0f : 0.0f;
          break;

        case InputDevice.Gamepad:
          throw new NotImplementedException("Gamepad key axis mapping not implemented!");

        case InputDevice.Joystick:
          throw new NotImplementedException("Joystick key axis mapping not implemented!");

        case InputDevice.Touch:
          throw new NotImplementedException("Touch key axis mapping not implemented!");

        default:
          throw new ArgumentException("Unknown input device: " + device);
      }

      return value * _scale;
    }

  }
}
