using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OkuBase.Input
{
  public interface IInputHandler
  {
    void KeyPressed(Keys key);
    void KeyReleased(Keys key);
    void MousePressed(MouseButton button);
    void MouseReleased(MouseButton button);
    void MouseDblClick(MouseButton button);
    void MouseWheel(int delta);
  }
}
