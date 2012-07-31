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
      int mapWidth = 16;
      int mapHeight = 16;

      _map = new Tilemap(mapWidth, mapHeight, 32);
      _map.Origin = new Vector(mapWidth * -16, mapHeight * -16); //OkuDrivers.Renderer.ViewPort.ScreenSpaceMatrix.Transform(new Vector(5, 5));
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

      OkuManagers.Renderer.ClearColor = Color.White;
    }

    public override void Update(float dt)
    {
      if (OkuManagers.Input.Mouse.ButtonIsDown(MouseButton.Left))
      {
        _line[0] = OkuManagers.Renderer.ScreenToWorld(OkuManagers.Input.Mouse.X, OkuManagers.Input.Mouse.Y);
        //_line[0] = OkuDrivers.Renderer.ViewPort.ScreenSpaceMatrix.Transform(_line[0]);
      }
      if (OkuManagers.Input.Mouse.ButtonIsDown(MouseButton.Right))
      {
        _line[1] = OkuManagers.Renderer.ScreenToWorld(OkuManagers.Input.Mouse.X, OkuManagers.Input.Mouse.Y);
        //_line[1] = OkuDrivers.Renderer.ViewPort.ScreenSpaceMatrix.Transform(_line[1]);
      }
      if (OkuManagers.Input.Keyboard.KeyPressed(Keys.Space))
      {
        Random rand = new Random(System.Environment.TickCount);
        OkuData.ActiveScene.Viewport.Left -= rand.RandomFloat() * 50.0f;
        OkuData.ActiveScene.Viewport.Top -= rand.RandomFloat() * 50.0f;
        OkuData.ActiveScene.Viewport.Scale = new Vector(rand.RandomFloat(), rand.RandomFloat());
      }
      
      //_intersect = _map.GetIntersection(new LineSegment( _line[0], _line[1]), out _colPoint);
      _intersect = _map.IntersectLineSegment(_line[0], _line[1], out _colPoint);

      float speed = 300 * dt;
      float dx = 0;
      float dy = 0;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Left))
        dx += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Right))
        dx -= speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Up))
        dy += speed;
      if (OkuManagers.Input.Keyboard.KeyIsDown(Keys.Down))
        dy -= speed;

      OkuData.ActiveScene.Viewport.Left += dx;
      OkuData.ActiveScene.Viewport.Top += dy;
    }

    public override void Render(int pass)
    {
      _map.Draw();
      OkuManagers.Renderer.DrawLine(_line[0], _line[1], 2, Color.Red);
      OkuManagers.Renderer.DrawPoint(_line[0], 4, Color.Blue);
      OkuManagers.Renderer.DrawPoint(_line[1], 4, Color.Blue);

      if (_intersect)
        OkuManagers.Renderer.DrawPoint(_colPoint, 4, Color.Green);
    }

  }
}
