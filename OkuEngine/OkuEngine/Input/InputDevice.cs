using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Input
{
  internal enum InputDevice
  {
    Keyboard = 0x10000,
    Mouse = 0x20000,
    Gamepad = 0x30000,
    Joystick = 0x40000,
    Touch = 0x50000
  }
}
