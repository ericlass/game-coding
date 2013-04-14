using System;
using System.Collections.Generic;
using OkuEngine;
using OkuEngine.Driver.Renderer;

namespace OkuTest
{
  public class PlatformTileGame : OkuGame
  {
    private ImageContent _tile = null;
    private Tilemap _tileMap = null;
    private Vector2f[] _playerBB = null;
    private Vector2f[] _transformedPlayer = null;
    private Vector2f _playerPos = new Vector2f(16, 0);
    private Vector2f _playerVelocity = new Vector2f(0, 0);
    private Matrix3 _tranform = new Matrix3();
    private bool _jumping = false;
    private Vector2f _mtd = Vector2f.Zero;

    public override void Initialize()
    {
      _playerBB = new Vector2f[] { new Vector2f(-8, 16), new Vector2f(8, 16), new Vector2f(8, -16), new Vector2f(-8, -16) };
      _transformedPlayer = new Vector2f[_playerBB.Length];
      _tranform.LoadIdentity();

      _tile = new ImageContent(".\\content\\orange_tile.png");
      _tileMap = new Tilemap(640, 48, 16);
      _tileMap.Origin = new Vector2f(-512, -384);
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
      if (OkuManagers.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad6))
        dx += speed;
      if (OkuManagers.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad4))
        dx -= speed;

      OkuData.Instance.Scenes.ActiveScene.Viewport.Left += dx;

      speed = 200 * dt;
      _playerVelocity.X = 0;
      if (OkuManagers.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _playerVelocity.X = speed;
      if (OkuManagers.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _playerVelocity.X = -speed;

      _playerVelocity.Y -= 5 * dt;

      if (!_jumping && OkuManagers.Instance.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
      {
        _jumping = true;
        _playerVelocity.Y = 500 * dt;
      }

      _playerPos += _playerVelocity;

      _tranform.LoadIdentity();
      _tranform.Translate(_playerPos);
      _tranform.Transform(_playerBB, _transformedPlayer);

      Vector2f mtd = Vector2f.Zero;
      if (_tileMap.IntersectAABB(_transformedPlayer[0], _transformedPlayer[2], out mtd))
      {
        _playerPos += mtd;

        if (_jumping && mtd.Y > 0.0f)
          _jumping = false;

        _playerVelocity = mtd.GetNormal().Project(_playerVelocity);

        _tranform.LoadIdentity();
        _tranform.Translate(_playerPos);
        _tranform.Transform(_playerBB, _transformedPlayer);
      }

      _mtd = mtd;

      Vector2f center = OkuData.Instance.Scenes.ActiveScene.Viewport.Center;
      center.X = _transformedPlayer[0].X;
      OkuData.Instance.Scenes.ActiveScene.Viewport.Center = center;
    }

    public override void Render(int pass)
    {
      _tileMap.Draw();
      OkuDrivers.Instance.Renderer.DrawLines(_transformedPlayer, Color.Blue, _transformedPlayer.Length, 2, VertexInterpretation.PolygonClosed);
      OkuDrivers.Instance.Renderer.DrawLine(_playerPos, _playerPos + (_playerVelocity * 20), 2, Color.Green);
      OkuDrivers.Instance.Renderer.DrawLine(_playerPos, _playerPos + (_mtd * 20), 2, Color.Red);
    }

  }
}
