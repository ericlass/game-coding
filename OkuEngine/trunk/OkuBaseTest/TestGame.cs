using System;
using OkuBase;

namespace OkuBaseTest
{
  public abstract class TestGame
  {
    public OkuManager Oku { get; set; }

    public abstract bool Load();
    public abstract void Update(float dt);
    public abstract void Render();
    public abstract bool Unload();

    public abstract string GetName();

  }
}
