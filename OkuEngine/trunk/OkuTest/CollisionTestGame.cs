using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class CollisionTestGame : OkuGame
  {
    private LineSegment _seg1 = new LineSegment(50, 50, 150, 200);
    private LineSegment _seg2 = new LineSegment(100, 50, 120, 200);
    private SpriteFont _font = null;
    private bool _intersects = false;
    private MeshInstance _strIntersect = null;
    private MeshInstance _strNoIntersect = null;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = OkuEngine.Color.White;
      _font = new SpriteFont("Courier New", 12, FontStyle.Regular, true);
      _strIntersect = _font.GetStringMesh("Intersection", 5, 5, OkuEngine.Color.Red);
      _strNoIntersect = _font.GetStringMesh("No Intersection", 5, 5, OkuEngine.Color.Black);
    }

    public override void Update(float dt)
    {
      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Left))
      {
        Point p = OkuDrivers.Renderer.MainForm.PointToClient(new Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _seg1.Start.X = p.X;
        _seg1.Start.Y = p.Y;
      }

      if (OkuDrivers.Input.Mouse.ButtonIsDown(MouseButton.Right))
      {
        Point p = OkuDrivers.Renderer.MainForm.PointToClient(new Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));
        _seg1.End.X = p.X;
        _seg1.End.Y = p.Y;
      }

      _intersects = Intersect(_seg1, _seg2);
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLine(_seg1.Start, _seg1.End, 1, OkuEngine.Color.Blue);
      OkuDrivers.Renderer.DrawLine(_seg2.Start, _seg2.End, 1, OkuEngine.Color.Red);

      if (_intersects)
        _strIntersect.Draw();
      else
        _strNoIntersect.Draw();
    }

    public bool Intersect(LineSegment seg1, LineSegment seg2)
    {
      //Get axis
      Vector axis1 = seg1.Normal();
      Vector axis2 = seg2.Normal();

      //Project one vector of seg1 to axis1. seg1 only has one projection as it is perpendicular to axis1.
      float projected = axis1.ProjectScalar(seg1.Start);
      float min1 = projected;
      float max1 = projected;

      //Project first vector of seg2 to axis1.
      projected = axis1.ProjectScalar(seg2.Start);
      float min2 = projected;
      float max2 = projected;

      //Project second vector of seg2 to axis1.
      projected = axis1.ProjectScalar(seg2.End);
      //Get minimum/maximum projection values for seg2.
      min2 = Math.Min(min2, projected);
      max2 = Math.Max(max2, projected);

      //If there is no intersection on the first axis, the segments do not intersect. return false.
      if (min1 > max2 || max1 < min2)
        return false;

      //Project first vector of seg1 to axis2.
      projected = axis2.ProjectScalar(seg1.Start);
      min1 = projected;
      max1 = projected;

      //Project second vector of seg1 to axis2.
      projected = axis2.ProjectScalar(seg1.End);
      //Get minimum/maximum projection values for seg1.
      min1 = Math.Min(min1, projected);
      max1 = Math.Max(max1, projected);

      //Project one vector of seg2 to axis2. seg2 only has one projection as it is perpendicular to axis2.
      projected = axis2.ProjectScalar(seg2.Start);
      min2 = projected;
      max2 = projected;

      if (min1 > max2 || max1 < min2)
        return false;

      return true;
    }

  }
}
