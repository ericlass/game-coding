using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;
using OkuBase.Settings;

namespace OkuBaseTest
{
  public class TestManager : OkuGame
  {
    private List<TestGame> _tests = new List<TestGame>();
    private TestGame _activeGame = null;

    public override OkuSettings Configure()
    {
      OkuSettings result = new OkuSettings();

      result.Audio.DriverName = "null";
      result.Graphics.Width = 1024;
      result.Graphics.Height = 768;

      return result;
    }

    public override void Initialize()
    {
      Oku.Input.OnKeyPressed += new KeyEventDelegate(Input_OnKeyPressed);
      Oku.Input.OnKeyReleased += new KeyEventDelegate(Input_OnKeyReleased);
      Oku.Input.OnMouseDblClick += new MouseEventDelegate(Input_OnMouseDblClick);
      Oku.Input.OnMousePressed += new MouseEventDelegate(Input_OnMousePressed);
      Oku.Input.OnMouseReleased += new MouseEventDelegate(Input_OnMouseReleased);
      Oku.Input.OnMouseWheel += new MouseWheelEventDelegate(Input_OnMouseWheel);
    }

    public override void Update(float dt)
    {
      if (_activeGame == null)
        return;

      _activeGame.Update(dt);
    }

    public override void Render()
    {
      if (_activeGame == null)
        return;

      _activeGame.Render();
    }

    private void Input_OnMouseWheel(int delta)
    {
      if (_activeGame == null)
        return;

      _activeGame.OnMouseWheel(delta);
    }

    private void Input_OnMouseReleased(MouseButton button)
    {
      if (_activeGame == null)
        return;

      _activeGame.OnMouseReleased(button);
    }

    private void Input_OnMousePressed(MouseButton button)
    {
      if (_activeGame == null)
        return;

      _activeGame.OnMousePressed(button);
    }

    private void Input_OnMouseDblClick(MouseButton button)
    {
      if (_activeGame == null)
        return;

      _activeGame.OnMouseDblClick(button);
    }

    private void Input_OnKeyReleased(Keys key)
    {
      if (_activeGame == null)
        return;

      _activeGame.OnKeyReleased(key);
    }

    private void Input_OnKeyPressed(Keys key)
    {
      Keys mod = key & Keys.Modifiers;
      System.Diagnostics.Debug.WriteLine(mod);

      if (_activeGame == null)
        return;
      
      _activeGame.OnKeyPressed(key);
    }

  }
}
