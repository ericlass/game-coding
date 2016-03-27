using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class StartLevel : Level
  {
    public override void Init()
    {
      Entity entity = new Entity("first");
      entity.Add(new ImageComponent(Engine.Functions.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_ball_glass_blue.png")));

      Entities.Add(entity);
    }

    public override void Finish()
    {
    }
    
  }
}
