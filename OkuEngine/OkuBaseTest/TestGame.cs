using System;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;

namespace OkuBaseTest
{
  public abstract class TestGame
  {
    public OkuManager Oku { get; set; }

    public abstract bool Load();
    public abstract void Update(float dt);
    public abstract void Render();
    public abstract bool Unload();

    public abstract void OnMouseWheel(int delta);
    public abstract void OnMouseReleased(MouseButton button);
    public abstract void OnMousePressed(MouseButton button);
    public abstract void OnMouseDblClick(MouseButton button);
    public abstract void OnKeyReleased(Keys key);
    public abstract void OnKeyPressed(Keys key);

    public abstract string GetName();

  }
}
