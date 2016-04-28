using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine;
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
      entity.AddComponent(new ImageComponent(API.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_square_grey.png")));

      //Add transform components
      PositionComponent pos = new PositionComponent();
      AngleComponent angle = new AngleComponent();
      ScaleComponent scale = new ScaleComponent();
      entity.AddComponent(pos);
      entity.AddComponent(angle);
      entity.AddComponent(scale);

      entity.AddComponent(new ColorComponent(Color.Green));

      API.AddEntity(entity);

      //Create entity instance
      Entity instance = new Entity("instance");
      instance.Template = entity;

      //Instance overrides position and color components
      instance.AddComponent(new PositionComponent(new Vector2f(150, 50), false));
      instance.AddComponent(new ColorComponent(Color.Red));

      API.AddEntity(instance);

      //Generic key event listener
      API.AddEventListener(new EventListener(EventNames.GetGenericInputEventName(Keys.Space, InputAction.Down), ev => angle.Angle += 45.0f));

      //Create input context
      InputContext context = new InputContext();

      //Map some key actions to an event
      InputActionMapping am = new InputActionMapping("rotate_cw");
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardR, InputAction.Down));
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardNumPad6, InputAction.Down));
      am.Actions.Add(new InputKeyAction(InputKey.KeyboardRight, InputAction.Down));
      am.Actions.Add(new InputKeyAction(InputKey.MouseRButton, InputAction.Down));
      context.ActionMappings.Add(am);

      //Map some keys to an axis
      InputAxisMapping ax = new InputAxisMapping("horizontal");
      ax.Axes.Add(new KeyInputAxis(InputKey.KeyboardD, -1.0f));
      ax.Axes.Add(new KeyInputAxis(InputKey.KeyboardA, 1.0f));
      ax.Axes.Add(new MouseInputAxis(10.0f, 0.0f));
      context.AxisMappings.Add(ax);

      //Activate input context
      API.SetInputContext(0, context);

      //Listen to mapped event
      API.AddEventListener(new EventListener("rotate_cw", ev => angle.Angle -= 45.0f));

      //Check mapped axis every frame
      API.AddEventListener(new EventListener(EventNames.EngineTick, ev => angle.Angle += API.GetAxisValue("horizontal") * (float)ev.Data[0] * 180.0f));

      //Add some event handlers for generic input events
      string eventName = EventNames.GetGenericInputEventName(Keys.S, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => pos.ScreenSpace = !pos.ScreenSpace));

      eventName = EventNames.GetGenericInputEventName(Keys.Add, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => scale.Scale = scale.Scale * 1.2f));

      eventName = EventNames.GetGenericInputEventName(Keys.Subtract, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => scale.Scale = scale.Scale * 0.8333f));
    }

    protected override void Finish()
    {
    }

  }
}
