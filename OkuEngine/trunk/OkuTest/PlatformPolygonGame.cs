﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;
using OkuEngine.Driver.Renderer;

namespace OkuTest
{
  public class PlatformPolygonGame : OkuGame
  {
    private Vector[] _floor = null;
    private Vector[] _ceiling = null;
    private int wallPoints = 200;

    private Vector[] _player = null;
    private Vector[] _transformedPlayer = null;
    private Vector[] _collidedPlayer = null;
    private Vector _playerPos = new Vector(193, -123);
    private Matrix3 _transform = Matrix3.Indentity;
    private Vector _trans = new Vector(40, -80);
    private bool _collision = false;
    private Vector _collisionDistance = Vector.Zero;

    public override void Initialize()
    {
      CollisionWorld world = new CollisionWorld();
      world.GetLinesOnLine(new Vector(50, 50), new Vector(150, 150));

      OkuManagers.Renderer.ClearColor = Color.White;

      _floor = new Vector[wallPoints];
      _ceiling = new Vector[_floor.Length];
      PerlinNoise noise = new PerlinNoise();
      for (int i = 0; i < _floor.Length; i++)
      {
        float x = i * (5000.0f / wallPoints);
        float y = -200.0f + noise.Noise(x, 0, 2, 100) * 50.0f;
        Vector value = _floor[i];
        value.X = x;
        value.Y = y;
        _floor[i] = value;

        y = 200.0f + noise.Noise(x, 500, 2, 100) * 50.0f;
        value = _ceiling[i];
        value.X = x;
        value.Y = y;
        _ceiling[i] = value;
      }

      //_player = PolygonFactory.Box(-25, 25, -50, 50);
      _player = PolygonFactory.Circle(0, 0, 25, 12);
      _transformedPlayer = new Vector[_player.Length];
      _collidedPlayer = new Vector[_player.Length];
    }

    public override void Update(float dt)
    {
      float speed = 200 * dt;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad6))
        OkuManagers.Renderer.ViewPort.Left += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad4))
        OkuManagers.Renderer.ViewPort.Left -= speed;

      speed = 200 * dt;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _playerPos.X -= speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _playerPos.X += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
        _playerPos.Y += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Down))
        _playerPos.Y -= speed;

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

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawLines(_floor, Color.Blue, _floor.Length, 1.0f, VertexInterpretation.Polygon);
      OkuManagers.Renderer.DrawLines(_ceiling, Color.Red, _ceiling.Length, 1.0f, VertexInterpretation.Polygon);

      OkuManagers.Renderer.DrawLines(_transformedPlayer, Color.Black, _transformedPlayer.Length, 1.0f, VertexInterpretation.PolygonClosed);

      if (_collision)
        OkuManagers.Renderer.DrawLines(_collidedPlayer, Color.Silver, _collidedPlayer.Length, 1.0f, VertexInterpretation.PolygonClosed);

      OkuManagers.Renderer.DrawLine(_playerPos, _playerPos + _trans, 1.0f, Color.Magenta);

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
