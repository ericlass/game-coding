using System;
using System.Collections.Generic;
using OkuEngine;
using OkuEngine.Events;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class StartLevel : Level
  {
    protected override void Init()
    {
      Entity entity = new Entity("first");
      entity.AddComponent(new ImageComponent(API.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_ball_glass_blue.png")));

      TransformComponent trans = new TransformComponent();
      entity.AddComponent(trans);
      

      API.AddEntity(entity);

      EventListener listener = new EventListener(EventNames.EngineTick, ev => trans.Rotation += 360.0f * (float)ev.Data[0]);
      API.AddEventListener(listener);
    }

    protected override void Finish()
    {
    }

  }
}
