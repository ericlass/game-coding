using System;
using System.Collections.Generic;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class TransformTestGame : OkuGame
  {
    private ImageContent _yinyang = null;
    private float _innerAngle = 0.0f;
    private float _outerAngle = 0.0f;
    private Vector2f _offset = new Vector2f(100, 0);

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.White;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }*/

    public override void Initialize()
    {
      _yinyang = new ImageContent(".\\content\\yinyang.png");
    }

    public override void Update(float dt)
    {
      dt *= 0.5f;
      _innerAngle += 180 * dt;
      _outerAngle += 360 * dt;
    }

    public override void Render(int pass)
    {
      /*OkuDrivers.Instance.Renderer.PushTransform();
      OkuDrivers.Instance.Renderer.ApplyTransform(Vector.Zero, Vector.One, _innerAngle);
      OkuDrivers.Instance.Renderer.DrawImage(_yinyang, Vector.Zero);
      OkuDrivers.Instance.Renderer.ApplyTransform(_offset, new Vector(0.8f, 0.8f), _outerAngle);
      OkuDrivers.Instance.Renderer.DrawImage(_yinyang, Vector.Zero);
      OkuDrivers.Instance.Renderer.ApplyTransform(_offset / 2, new Vector(0.5f, 0.5f), _outerAngle);
      OkuDrivers.Instance.Renderer.DrawImage(_yinyang, Vector.Zero);
      OkuDrivers.Instance.Renderer.PopTransform();*/
    }

  }
}
