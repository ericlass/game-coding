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
    private LineSegment _line = new LineSegment(50, 50, 200, 200);
    private Vector _colPoint = null;

    public override void Initialize()
    {
      int mapWidth = 16;
      int mapHeight = 16;

      _map = new Tilemap(mapWidth, mapHeight, 32);
      _map.Origin.X = 50;
      _map.Origin.Y = 50;
      _map.TileImages = ImageContent.LoadSheet(".\\content\\tilesheet.png", 32);

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
        _line.Start.X = p.X;
        _line.Start.Y = p.Y;
      }
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Right))
      {
        System.Drawing.Point p = OkuDrivers.Renderer.MainForm.PointToClient(new System.Drawing.Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _line.End.X = p.X;
        _line.End.Y = p.Y;
      }
      _colPoint = _map.GetIntersection(_line);
    }

    public override void Render()
    {
      _map.Draw();
      OkuDrivers.Renderer.DrawLine(_line.Start, _line.End, 2, Color.Red);
      OkuDrivers.Renderer.DrawPoint(_line.Start, 4, Color.Blue);
      OkuDrivers.Renderer.DrawPoint(_line.End, 4, Color.Blue);

      if (_colPoint != null)
        OkuDrivers.Renderer.DrawPoint(_colPoint, 4, Color.Green);
    }

  }
}
