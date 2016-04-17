using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuEngine;
using OkuMath;
using OkuEngine.Events;
using OkuEngine.Components;
using OkuEngine.Input;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class StartLevel : Level
  {
    protected override void Init()
    {
      //Create entity
      Entity entity = new Entity("first");

      //Add image component
      entity.AddComponent(new ImageComponent(API.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_ball_glass_blue.png")));

      //Add transform component
      TransformComponent trans = new TransformComponent();
      entity.AddComponent(trans);

      API.AddEntity(entity);

      //Generic key event listener
      API.AddEventListener(new EventListener(EventNames.GetGenericInputEventName(Keys.Space, InputAction.Down), ev => trans.Rotation += 45.0f));

      //Create input context
      InputContext context = new InputContext();

      //Map some key actions to an event
      InputActionMapping am = new InputActionMapping("rotate_cw");
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardR, InputAction.Down));
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardNumPad6, InputAction.Down));
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardRight, InputAction.Down));
      context.ActionMappings.Add(am);

      //Map some keys to an axis
      InputAxisMapping ax = new InputAxisMapping("horizontal");
      ax.Axes.Add(new KeyInputAxis(InputKey.KeyboardD, -90.0f));
      ax.Axes.Add(new KeyInputAxis(InputKey.KeyboardA, 90.0f));
      context.AxisMappings.Add(ax);

      //Activate input context
      API.SetInputContext(0, context);

      //Listen to mapped event
      API.AddEventListener(new EventListener("rotate_cw", ev => trans.Rotation -= 45.0f));

      //Check mapped axis every frame
      API.AddEventListener(new EventListener(EventNames.EngineTick, ev => trans.Rotation += API.GetAxisValue("horizontal") * (float)ev.Data[0]));
    }

    protected override void Finish()
    {
    }

  }
}
