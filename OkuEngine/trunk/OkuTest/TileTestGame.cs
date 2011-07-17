using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class TileTestGame : OkuGame
  {
    private Tilemap _map = null;
    private LineSegment _line = new LineSegment(50, 50, 200, 200);
    private Vector _colPoint = null;

    public override void Initialize()
    {
      int mapWidth = 32;
      int mapHeight = 24;

      _map = new Tilemap(mapWidth, mapHeight, 32);
      _map.TileImages = ImageContent.LoadSheet(".\\content\\tilesheet.png", 32, 6);

      Random rand = new Random();

      /*for (int y = 0; y < mapHeight; y++)
      {
        for (int x = 0; x < mapWidth; x++)
        {
          byte tileType = (byte)(rand.Next(5) + 1);
          _map[x, y] = new Tile(tileType, tileType);
        }
      }*/

      for (int i = 0; i < 50; i++)
      {
        byte tileType = (byte)rand.Next(6);
        int x = rand.Next(mapWidth);
        int y = rand.Next(mapHeight);
        _map[x, y] = new Tile(tileType, tileType);
      }

      OkuDrivers.Renderer.ClearColor = Color.White;
    }

    public override void Update(float dt)
    {
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Left))
      {
        System.Drawing.Point p = OkuDrivers.Renderer.MainForm.PointToClient(new System.Drawing.Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _line.X1 = p.X;
        _line.Y1 = p.Y;
      }
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Right))
      {
        System.Drawing.Point p = OkuDrivers.Renderer.MainForm.PointToClient(new System.Drawing.Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _line.X2 = p.X;
        _line.Y2 = p.Y;
      }
      _colPoint = _map.GetIntersection(_line);
    }

    public override void Render()
    {
      _map.Draw();
      OkuDrivers.Renderer.DrawLine(_line.X1, _line.Y1, _line.X2, _line.Y2, 2, Color.Red);
      OkuDrivers.Renderer.DrawPoint(_line.X1, _line.Y1, 4, Color.Blue);
      OkuDrivers.Renderer.DrawPoint(_line.X2, _line.Y2, 4, Color.Blue);

      if (_colPoint != null)
        OkuDrivers.Renderer.DrawPoint(_colPoint, 4, Color.Green);
    }

  }
}
