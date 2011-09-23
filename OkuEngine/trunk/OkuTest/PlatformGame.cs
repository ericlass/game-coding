using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTest
{
  public class PlatformGame : OkuGame
  {
    private ImageContent _tile = null;
    private Tilemap _tileMap = null;
    private Vector[] _playerBB = null;
    private Vector[] _transformedPlayer = null;
    private Vector _playerPos = new Vector(8, 0);
    private Matrix3 _tranform = new Matrix3();

    public override void Initialize()
    {
      OkuDrivers.Renderer.ViewPort.Left = 0;
      OkuDrivers.Renderer.ViewPort.Top = 0;

      _playerBB = new Vector[] { new Vector(-8, -16), new Vector(8, -16), new Vector(8, 16), new Vector(-8, 16) };
      _transformedPlayer = new Vector[_playerBB.Length];
      _tranform.LoadIdentity();

      _tile = new ImageContent(".\\content\\orange_tile.png");
      _tileMap = new Tilemap(320, 48, 16);
      _tileMap.TileImages = new List<ImageContent>() { _tile };

      PerlinNoise noise = new PerlinNoise(3);
      for (int y = 0; y < _tileMap.Height; y++)
      {
        for (int x = 0; x < _tileMap.Width; x++)
        {
          float dens = y - (_tileMap.Height * 0.85f);
          float value = ((noise.Noise(x, y, 4, 50) + 1.0f) / 2.0f) * 30;
          dens += value;

          if (dens > 0)
            _tileMap[x, y] = new Tile(Tilemap.TILE_COLLISION_FULL, 0);
          else
            _tileMap[x, y] = new Tile(Tilemap.TILE_COLLISION_NONE, 0);
        }
      }
    }

    public override void Update(float dt)
    {
      float speed = 1000 * dt;
      float dx = 0;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad6))
        dx += speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad4))
        dx -= speed;

      OkuDrivers.Renderer.ViewPort.Left += dx;

      //TODO: Apply forces to player

      _tranform.LoadIdentity();
      _tranform.Translate(_playerPos);
      _tranform.Transform(_playerBB, _transformedPlayer);
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLines(_transformedPlayer, Color.Blue, _transformedPlayer.Length, 2, VertexInterpretation.PolygonClosed);
      _tileMap.Draw();
    }

  }
}
