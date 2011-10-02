using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  public class TileTestGame : OkuGame
  {
    private Tilemap _map = null;
    private Vector[] _line = new Vector[2] { new Vector(80, 80), new Vector(180, 180) };
    private Vector _colPoint = Vector.Zero;
    private bool _intersect = false;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ViewPort.Center = new Vector(OkuDrivers.Renderer.ViewPort.Width / 2, OkuDrivers.Renderer.ViewPort.Height / 2);

      int mapWidth = 16;
      int mapHeight = 16;

      _map = new Tilemap(mapWidth, mapHeight, 32);
      _map.Origin = new Vector(50, 50);
      _map.TileImages = ImageContent.LoadSheet(".\\content\\realtiles.bmp", 32);

      Random rand = new Random();

      ushort[] tiles = new ushort[] { 4, 4, 8, 6, 0, 2 };

      for (int i = 0; i < 150; i++)
      {
        byte tileType = (byte)rand.Next(6);
        int x = rand.Next(mapWidth);
        int y = rand.Next(mapHeight);
        _map[x, y] = new Tile(tileType, tiles[tileType]);
      }

      OkuDrivers.Renderer.ClearColor = Color.White;
    }

    public override void Update(float dt)
    {
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Left))
      {
        System.Drawing.Point p = OkuDrivers.Renderer.MainForm.PointToClient(new System.Drawing.Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _line[0] = new Vector(p.X, p.Y);
      }
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Right))
      {
        System.Drawing.Point p = OkuDrivers.Renderer.MainForm.PointToClient(new System.Drawing.Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _line[1] = new Vector(p.X, p.Y);
      }
      
      //_intersect = _map.GetIntersection(new LineSegment( _line[0], _line[1]), out _colPoint);
      _intersect = _map.IntersectLineSegment(_line[0], _line[1], out _colPoint);

      float speed = 300 * dt;
      float dx = 0;
      float dy = 0;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Left))
        dx += speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Right))
        dx -= speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Up))
        dy += speed;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Down))
        dy -= speed;

      OkuDrivers.Renderer.ViewPort.Left += dx;
      OkuDrivers.Renderer.ViewPort.Top += dy;
    }

    public override void Render()
    {
      _map.Draw();
      OkuDrivers.Renderer.DrawLine(_line[0], _line[1], 2, Color.Red);
      OkuDrivers.Renderer.DrawPoint(_line[0], 4, Color.Blue);
      OkuDrivers.Renderer.DrawPoint(_line[1], 4, Color.Blue);

      if (_intersect)
        OkuDrivers.Renderer.DrawPoint(_colPoint, 4, Color.Green);
    }

  }
}
