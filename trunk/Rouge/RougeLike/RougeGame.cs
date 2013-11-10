using System;
using OkuBase;
using OkuBase.Settings;

namespace RougeLike
{
  public class RougeGame : OkuGame
  {
    public override OkuSettings Configure()
    {
      OkuSettings settings = base.Configure();
      settings.Audio.DriverName = "null";

      return settings;
    }
    
    public override void Initialize()
    {
      GameManager.Instance.Initialize();
    }
    
    public override void Update(float dt)
    {
      GameManager.Instance.Update(dt);
    }
    
    public override void Render()
    {
      GameManager.Instance.Renderer.Render();
    }
    
  }
}
