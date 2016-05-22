using System;
using System.IO;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Assets;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class TilemapLevel : Level
  {
    protected override void Init()
    {
      Entity entity = new Entity("tilemap");

      TilemapComponent comp = TilemapComponent.LoadFromTiledXml(new FileStream("D:\\Graphics\\Tilemaps\\Zelda\\zelda3_kakariko.tmx", FileMode.Open), LoadImage);
      entity.AddComponent(comp);

      API.AddEntity(entity);
    }

    private AssetHandle LoadImage(string name)
    {
      ImageData image = ImageData.FromFile(Path.Combine("D:\\Graphics\\Tilemaps\\Zelda", name));
      return Assets.AddImage(image);
    }

    protected override void Finish()
    {
      throw new NotImplementedException();
    }

  }
}
