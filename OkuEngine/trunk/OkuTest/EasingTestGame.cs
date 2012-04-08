﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class EasingTestGame : OkuGame
  {
    private const int _numSamples = 50;
    private const int _size = 100;

    private Vector[] _points = null;
    private EasingController _ease = null;

    private EasingController _imageEase = null;
    private ImageContent _image = null;
    private float _angle = 0.0f;
    private float _control = 0.0f;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.White;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }

    public override void Initialize()
    {
      _points = new Vector[_numSamples];
      _ease = new EasingController();
      _ease.Min = -1;
      _ease.Max = 1;
      _ease.Left = 0;
      _ease.Right = 1;

      _image = new ImageContent(".\\content\\yinyang.png");
      _imageEase = new EasingController(1);
      _imageEase.Left = -1;
      _imageEase.Right = 1;
      _imageEase.Min = -1;
      _imageEase.Max = 1;
    }

    public override void Update(float dt)
    {
      if (OkuDrivers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Add))
        _ease.Strength += 1;
      if (OkuDrivers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Subtract))
        _ease.Strength -= 1;

      long tick1, tick2, freq;
      Kernel32.QueryPerformanceFrequency(out freq);
      long passed = 0;
      for (int i = 0; i < _numSamples; i++)
      {
        float t = i / (float)(_numSamples - 1);

        Kernel32.QueryPerformanceCounter(out tick1);

        float v = _ease.GetValueAt(t);

        Kernel32.QueryPerformanceCounter(out tick2);
        passed += tick2 - tick1;

        Vector vec = _points[i];
        vec.X = t * _size;
        vec.Y = v * _size;
        _points[i] = vec;
      }

      float time = passed / (float)freq;
      OkuDrivers.Renderer.MainForm.Text = time.ToString();

      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _control = Math.Min(1.0f, _control + dt);

      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _control = Math.Max(-1.0f, _control - dt);

      _angle = 135.0f * _imageEase.GetValueAt(_control);
    }

    public override void Render(int pass)
    {
      OkuDrivers.Renderer.DrawLines(_points, Color.Blue, _points.Length, 1.0f, VertexInterpretation.Polygon);
      OkuDrivers.Renderer.DrawPoints(_points, Color.Red, _points.Length, 2.0f);

      OkuDrivers.Renderer.DrawImage(_image, Vector.Zero, _angle);
    }

  }
}