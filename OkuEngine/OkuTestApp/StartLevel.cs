using System;
using System.IO;
using System.Windows.Forms;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Assets;
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
      var image = API.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_square_grey.png");
      var imageHandle = Assets.AddAsset(new ImageAsset(image));

      //Add mesh component
      var meshAsset = API.GetMeshForImage(image.Width, image.Height);
      var meshHandle = MeshCache.CreateEntry();
      MeshCache.BufferData(meshHandle, meshAsset);

      entity.AddComponent(new SimpleMeshComponent(meshHandle));

      //Add material component
      var material = new MaterialAsset(imageHandle, Color.Green);
      var matHandle = Assets.AddAsset(material);
      entity.AddComponent(new MaterialComponent(matHandle));

      //Add transform components
      PositionComponent pos = new PositionComponent();
      AngleComponent angle = new AngleComponent();
      ScaleComponent scale = new ScaleComponent();
      entity.AddComponent(pos);
      entity.AddComponent(angle);
      entity.AddComponent(scale);

      API.AddEntity(entity);

      //Create entity instances
      Random rand = new Random();

      //Create some colored materials
      int[] mats = new int[] {
        Assets.AddAsset(new MaterialAsset(imageHandle, Color.Red)),
        Assets.AddAsset(new MaterialAsset(imageHandle, Color.Blue)),
        Assets.AddAsset(new MaterialAsset(imageHandle, Color.Yellow)),
        Assets.AddAsset(new MaterialAsset(imageHandle, Color.Cyan))
      };

      for (int i = 0; i < 100; i++)
      {
        Entity instance = new Entity("instance" + i);
        instance.Template = entity;

        //Instance overrides position and color components
        instance.AddComponent(new PositionComponent(new Vector2f(rand.Next(-400, 400), rand.Next(-300, 300)), false));
        float scaleFactor = (float)rand.NextDouble();
        instance.AddComponent(new ScaleComponent(new Vector2f(scaleFactor, scaleFactor)));
        instance.AddComponent(new SimpleMeshComponent(meshHandle));

        instance.AddComponent(new MaterialComponent(mats[rand.Next(mats.Length)]));

        API.AddEntity(instance);
      }

      //Generic key event listener
      API.AddEventListener(new EventListener(EventNames.GetGenericInputEventName(Keys.Space, InputAction.Down), ev => angle.Angle += 45.0f));

      //Create input context
      InputContext context = new InputContext();

      API.SetInterval(1, "colortimer");

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
      API.AddEventListener(new EventListener(EventNames.EveryFrame, ev => angle.Angle += API.GetAxisValue("horizontal") * (float)ev.Data[0] * 180.0f));

      //Add some event handlers for generic input events
      string eventName = EventNames.GetGenericInputEventName(Keys.S, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => pos.ScreenSpace = !pos.ScreenSpace));

      eventName = EventNames.GetGenericInputEventName(Keys.Add, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => scale.Scale = scale.Scale * 1.2f));

      eventName = EventNames.GetGenericInputEventName(Keys.Subtract, InputAction.Down);
      API.AddEventListener(new EventListener(eventName, ev => scale.Scale = scale.Scale * 0.8333f));

      API.AddEventListener(new EventListener("colortimer", ev => OkuBase.OkuManager.Instance.Graphics.BackgroundColor = Color.RandomColor(rand)));
    }

    protected override void Finish()
    {
    }

  }
}
