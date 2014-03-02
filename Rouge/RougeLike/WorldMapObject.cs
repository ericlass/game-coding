using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace RougeLike
{
  public class WorldMapObject : TileMapObjectBase
  {
    private Vector2f _lineStart = Vector2f.Zero;
    private Vector2f _lineEnd = Vector2f.Zero;

    public override string ObjectType
    {
      get { return "worldmap"; }
    }

    public override void Init()
    {
      _tileImages = GameUtil.LoadSpriteSheet("simple_tiles.png", 16, 16);

      _tiles = new Tile[1000, 75];

      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          _tiles[x, y] = new Tile(true, -1);
        }
      }     

      PerlinNoise noise = new PerlinNoise(Environment.TickCount);
      for (int x = 0; x < _tiles.GetLength(0); x++)
      {
        int floor = (int)(noise.Noise(x, 0, 3, 100) * 15.0f) + (_tiles.GetLength(1) / 3);
        for (int y = 0; y < floor; y++)
        {
          _tiles[x, y].TileIndex = 2;
          _tiles[x, y].Walkable = false;
        }
      }
    }

    public override void Update(float dt)
    {
      if (Oku.Input.Mouse.ButtonIsDown(OkuBase.Input.MouseButton.Left))
      {
        _lineStart = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
        /*if (IsInside(mousePos))
        {
          mousePos = WorldToTile(mousePos);
          _tiles[(int)mousePos.X, (int)mousePos.Y].TileIndex = -1;
          _tiles[(int)mousePos.X, (int)mousePos.Y].Walkable = true;
        }*/         
      }

      if (Oku.Input.Mouse.ButtonIsDown(OkuBase.Input.MouseButton.Right))
      {
        _lineEnd = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
      }

      Oku.Graphics.Title = CountTilesOnLine(_lineStart, _lineEnd).ToString();
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

    protected override StringPairMap DoSave()
    {
      return new StringPairMap();
    }

    public override void Render()
    {
      base.Render();

      Oku.Graphics.DrawLine(_lineStart.X, _lineStart.Y, _lineEnd.X, _lineEnd.Y, 2.0f, OkuBase.Graphics.Color.Blue);
    }

  }
}
