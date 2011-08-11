﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  public class CollisionTestGame : OkuGame
  {
    private struct Ranges
    {
      public float Min1;
      public float Max1;
      public float Min2;
      public float Max2;

      public Ranges(float min1, float max1, float min2, float max2)
      {
        Min1 = min1;
        Max1 = max1;
        Min2 = min2;
        Max2 = max2;
      }
    }

    private Vector[] _box1 = PolygonFactory.Box(-50, 50, -100, 100);
    private Transformation _transform1 = new Transformation();
    private Vector[] _transformed1 = null;

    private Vector[] _box2 = PolygonFactory.Box(-25, 25, -50, 50);
    private Transformation _transform2 = new Transformation();
    private Vector[] _transformed2 = null;

    private Vector _mtd = Vector.Zero;
    private bool _intersect = false;
    private MeshInstance _strIntersect = null;
    private MeshInstance _strNoIntersect = null;

    private List<Ranges> _projections = new List<Ranges>();

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = OkuEngine.Color.White;

      SpriteFont font = new SpriteFont("Arial", 12, FontStyle.Regular, false);
      _strIntersect = font.GetStringMesh("Intersection", 5, 5, OkuEngine.Color.Red);
      _strNoIntersect = font.GetStringMesh("No Intersection", 5, 5, OkuEngine.Color.Black);

      _transform1.Translation = new Vector(100, 150);
      _transform2.Translation = new Vector(300, 150);

      _transformed1 = new Vector[_box1.Length];
      _transformed2 = new Vector[_box2.Length];

      Matrix3 transform = Matrix3.Indentity;
      transform.ApplyTransform(_transform1);
      transform.Transform(_box1, _transformed1);
    }

    public override void Update(float dt)
    {
      float transSpeed = 100;
      float rotSpeed = 90;

      float dx = 0;
      float dy = 0;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Left))
        dx += (-transSpeed) * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Right))
        dx += transSpeed * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Up))
        dy += (-transSpeed) * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Down))
        dy += transSpeed * dt;

      float rotation = 0;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.NumPad4))
        rotation += rotSpeed * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.NumPad6))
        rotation += (-rotSpeed) * dt;

      _transform2.Rotation += rotation;
      _transform2.Translation += new Vector(dx, dy);

      Matrix3 transform = Matrix3.Indentity;
      transform.ApplyTransform(_transform2);
      transform.Transform(_box2, _transformed2);

      _intersect = Intersections.Intersect(_transformed1, _transformed2, out _mtd);
      if (_intersect)
      {
        _transform2.Translation += _mtd;
        transform = Matrix3.Indentity;
        transform.ApplyTransform(_transform2);
        transform.Transform(_box2, _transformed2);
      }
    }

    private Vector _pos = new Vector(512, 384);

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLines(_transformed1, 1, OkuEngine.Color.Red, VertexInterpretation.PolygonClosed);
      OkuDrivers.Renderer.DrawLines(_transformed2, 1, OkuEngine.Color.Blue, VertexInterpretation.PolygonClosed);

      float x = 500;
      float y = 500;
      float diff = 20;

      for (int i = 0; i < _projections.Count; i++)
      {
        Ranges rang = _projections[i];
        OkuDrivers.Renderer.DrawLine(x + rang.Min1, y + (diff * i), x + rang.Max1, y + (diff * i), 2, OkuEngine.Color.Red);
        OkuDrivers.Renderer.DrawLine(x + rang.Min2, y + 4 + (diff * i), x + rang.Max2, y + 4 + (diff * i), 2, OkuEngine.Color.Blue);
      }

      if (_intersect)
      {
        _strIntersect.Draw();
        OkuDrivers.Renderer.DrawLine(_pos, _pos + _mtd, 1, OkuEngine.Color.Green);
      }
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
