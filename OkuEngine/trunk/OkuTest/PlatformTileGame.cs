using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTest
{
  public class PlatformTileGame : OkuGame
  {
    private ImageContent _tile = null;
    private Tilemap _tileMap = null;
    private Vector[] _playerBB = null;
    private Vector[] _transformedPlayer = null;
    private Vector _playerPos = new Vector(16, 368);
    private Vector _playerVelocity = new Vector(0, 0);
    private Matrix3 _tranform = new Matrix3();
    private bool _jumping = false;
    private Vector _mtd = Vector.Zero;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ViewPort.Left = 0;
      OkuDrivers.Renderer.ViewPort.Top = 0;

      _playerBB = new Vector[] { new Vector(-8, -16), new Vector(8, -16), new Vector(8, 16), new Vector(-8, 16) };
      _transformedPlayer = new Vector[_playerBB.Length];
      _tranform.LoadIdentity();

      _tile = new ImageContent(".\\content\\orange_tile.png");
      _tileMap = new Tilemap(640, 48, 16);
      _tileMap.TileImages = new List<ImageContent>() { _tile };

      PerlinNoise noise = new PerlinNoise(6);
      for (int y = 0; y < _tileMap.Height; y++)
      {
        for (int x = 0; x < _tileMap.Width; x++)
        {
          //Terrain
          //float dens = y - (_tileMap.Height * 0.5f);

          //Corridor
          float dens = Math.Abs((_tileMap.Height / 2) - y) - _tileMap.Height / 5;

          float value = noise.Noise(x, y, 4, 50) * 10;
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

      speed = 200 * dt;
      _playerVelocity.X = 0;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _playerVelocity.X = speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _playerVelocity.X = -speed;

      _playerVelocity.Y += 5 * dt;

      if (!_jumping && OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
      {
        _jumping = true;
        _playerVelocity.Y = -500 * dt;
      }

      _playerPos += _playerVelocity;

      _tranform.LoadIdentity();
      _tranform.Translate(_playerPos);
      _tranform.Transform(_playerBB, _transformedPlayer);

      Vector mtd = Vector.Zero;
      if (_tileMap.IntersectAABB(_transformedPlayer[0], _transformedPlayer[2], out mtd))
      {
        _playerPos += mtd;

        if (_jumping && mtd.Y < 0.0f)
          _jumping = false;

        _playerVelocity = mtd.GetNormal().Project(_playerVelocity);

        _tranform.LoadIdentity();
        _tranform.Translate(_playerPos);
        _tranform.Transform(_playerBB, _transformedPlayer);
      }

      _mtd = mtd;

      Vector center = OkuDrivers.Renderer.ViewPort.Center;
      center.X = _transformedPlayer[0].X;
      OkuDrivers.Renderer.ViewPort.Center = center;
    }

    public override void Render(int pass)
    {
      _tileMap.Draw();
      OkuDrivers.Renderer.DrawLines(_transformedPlayer, Color.Blue, _transformedPlayer.Length, 2, VertexInterpretation.PolygonClosed);
      OkuDrivers.Renderer.DrawLine(_playerPos, _playerPos + (_playerVelocity * 20), 2, Color.Green);
      OkuDrivers.Renderer.DrawLine(_playerPos, _playerPos + (_mtd * 20), 2, Color.Red);
    }

  }
}
