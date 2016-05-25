using System;
using System.IO;
using System.Windows.Forms;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Assets;
using OkuEngine.Components;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class TilemapLevel : Level
  {
    protected override void Init()
    {
      Entity entity = new Entity("tilemap");

      TilemapComponent comp = TilemapComponent.LoadFromTiledXml(new FileStream("D:\\Graphics\\Tilemaps\\Zelda\\zelda3_kakariko.tmx", FileMode.Open),
        name =>
        {
          ImageData image = ImageData.FromFile(Path.Combine("D:\\Graphics\\Tilemaps\\Zelda", name));
          var imageHandle = Assets.AddImage(image);

          var materialhandle = Assets.AddMaterial(new MaterialAsset(imageHandle, Color.White));
          entity.AddComponent(new MaterialComponent(materialhandle));

          return imageHandle;
        }
      );

      entity.AddComponent(comp);

      PositionComponent position = new PositionComponent(Vector2f.Zero, false);
      entity.AddComponent(position);

      API.AddEntity(entity);

      InputAxisMapping vertical = new InputAxisMapping("vertical");
      vertical.Axes.Add(new KeyInputAxis(InputKey.KeyboardW, -1.0f));
      vertical.Axes.Add(new KeyInputAxis(InputKey.KeyboardS, 1.0f));

      InputAxisMapping horizontal = new InputAxisMapping("horizontal");
      horizontal.Axes.Add(new KeyInputAxis(InputKey.KeyboardD, -1.0f));
      horizontal.Axes.Add(new KeyInputAxis(InputKey.KeyboardA, 1.0f));

      InputContext context = new InputContext();
      context.AxisMappings.Add(vertical);
      context.AxisMappings.Add(horizontal);

      API.SetInputContext(0, context);

      const float trans = 200;
      API.AddEventListener(new EventListener(EventNames.EngineTick, ev => position.Position += new Vector2f(0, trans * API.GetAxisValue("vertical") * (float)ev.Data[0])));
      API.AddEventListener(new EventListener(EventNames.EngineTick, ev => position.Position += new Vector2f(trans * API.GetAxisValue("horizontal") * (float)ev.Data[0], 0)));
    }

    protected override void Finish()
    {
      throw new NotImplementedException();
    }

  }
}
