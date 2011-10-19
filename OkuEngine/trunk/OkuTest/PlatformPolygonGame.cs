using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class PlatformPolygonGame : OkuGame
  {
    private Vector[] _floor = null;
    private Vector[] _ceiling = null;

    private Vector[] _player = null;
    private Vector[] _transformedPlayer = null;
    private Vector[] _collidedPlayer = null;
    private Vector _playerPos = new Vector(193, 153);
    private Matrix3 _transform = Matrix3.Indentity;
    private Vector _trans = new Vector(0, 50);
    private bool _collision = false;
    private Vector _collisionDistance = Vector.Zero;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      _floor = new Vector[100];
      _ceiling = new Vector[_floor.Length];
      PerlinNoise noise = new PerlinNoise();
      for (int i = 0; i < _floor.Length; i++)
      {
        float x = i * 50.0f;
        float y = 200.0f + noise.Noise(x, 0, 2, 100) * 50.0f;
        Vector value = _floor[i];
        value.X = x;
        value.Y = y;
        _floor[i] = value;

        y = -200.0f + noise.Noise(x, 500, 2, 100) * 50.0f;
        value = _ceiling[i];
        value.X = x;
        value.Y = y;
        _ceiling[i] = value;
      }

      _player = PolygonFactory.Box(-25, 25, -50, 50);
      _transformedPlayer = new Vector[_player.Length];
      _collidedPlayer = new Vector[_player.Length];
    }

    public override void Update(float dt)
    {
      float speed = 200 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad6))
        OkuDrivers.Renderer.ViewPort.Left += speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad4))
        OkuDrivers.Renderer.ViewPort.Left -= speed;

      speed = 200 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _playerPos.X -= speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _playerPos.X += speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
        _playerPos.Y -= speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Down))
        _playerPos.Y += speed;

      _transform.LoadIdentity();
      _transform.Translate(_playerPos);
      _transform.Transform(_player, _transformedPlayer);

      float mtd = 0;
      _collision = ContinuousCollision.PolygonPolygon(_transformedPlayer, _floor, _trans, out mtd);
      if (_collision)
      {
        _collisionDistance = _trans * mtd;
        _transform.LoadIdentity();
        _transform.Translate(_collisionDistance);
        _transform.Transform(_transformedPlayer, _collidedPlayer);
      }

      /*_playerPos += trans;

      _transform.LoadIdentity();
      _transform.Translate(_playerPos);
      _transform.Transform(_player, _transformedPlayer);*/
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLines(_floor, Color.Blue, _floor.Length, 1.0f, VertexInterpretation.Polygon);
      OkuDrivers.Renderer.DrawLines(_ceiling, Color.Red, _ceiling.Length, 1.0f, VertexInterpretation.Polygon);

      OkuDrivers.Renderer.DrawLines(_transformedPlayer, Color.Black, _transformedPlayer.Length, 1.0f, VertexInterpretation.PolygonClosed);

      if (_collision)
        OkuDrivers.Renderer.DrawLines(_collidedPlayer, Color.Silver, _collidedPlayer.Length, 1.0f, VertexInterpretation.PolygonClosed);

      OkuDrivers.Renderer.DrawLine(_playerPos, _playerPos + _trans, 1.0f, Color.Magenta);

      /*foreach (Vector vec in _transformedPlayer)
      {
        OkuDrivers.Renderer.DrawLine(vec, vec + _trans, 1.0f, new Color(255, 0, 255));
        if (_collision)
          OkuDrivers.Renderer.DrawPoint(vec + _collisionDistance, 2.0f, Color.Green);
      }

      foreach (Vector vec in _floor)
      {
        OkuDrivers.Renderer.DrawLine(vec, vec - _trans, 1.0f, new Color(255, 0, 255));
        if (_collision)
          OkuDrivers.Renderer.DrawPoint(vec - _collisionDistance, 2.0f, Color.Green);
      }*/
    }

  }
}
