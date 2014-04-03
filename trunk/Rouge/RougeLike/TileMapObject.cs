using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;

namespace RougeLike
{
  public class TileMapObject : TileMapObjectBase
  {

    public TileMapObject(TileData tiles)
    {
      _tileData = tiles;
    }


    public override string ObjectType
    {
      get { return "tilemap"; }
    }

    public override void Update(float dt)
    {
      float speed = 500 * dt;
      Vector2f center = Oku.Graphics.Viewport.Center;

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Left))
        center.X -= speed;

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Right))
        center.X += speed;

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Up))
        center.Y += speed;

      if (Oku.Input.Keyboard.KeyIsDown(Keys.Down))
        center.Y -= speed;

      Oku.Graphics.Viewport.Center = center;
    }

    public override void Init()
    {
    }

    protected override StringPairMap DoSave()
    {
      return new StringPairMap();
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

  }
}
