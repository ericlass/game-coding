using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTest
{
  public class InertiaTestGame : OkuGame
  {
    private ImageContent _image = null;

    private InertialMovement _angleInertia = null;
    private InertialMovement _xInertia = null;
    private InertialMovement _yInertia = null;
    private float _angle = 0.0f;
    private Vector2f _position = Vector2f.Zero;

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.White;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }*/

    public override void Initialize()
    {
      OkuManagers.Renderer.Display.Text = "Inertia Test";

      _image = new ImageContent(".\\content\\yinyang.png");
      _angleInertia = new InertialMovement();
      _angleInertia.Inertia = 2;

      _xInertia = new InertialMovement(0.3f);
      _yInertia = new InertialMovement(0.3f);
    }

    public override void Update(float dt)
    {
      //Update inertia direction depending on pressed keys
      _angleInertia.Direction = 0;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad4))
        _angleInertia.Direction += 1;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.NumPad6))
        _angleInertia.Direction -= 1;

      _xInertia.Direction = 0;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        _xInertia.Direction -= 1;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        _xInertia.Direction += 1;

      _yInertia.Direction = 0;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Down))
        _yInertia.Direction -= 1;
      if (OkuManagers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
        _yInertia.Direction += 1;

      //Update inertia for X and Y coordinate and rotation angle and apply changes
      _xInertia.Update(dt);
      _yInertia.Update(dt);
      _angleInertia.Update(dt);

      _position.X += _xInertia.CurrentSpeed * 200 * dt;
      _position.Y += _yInertia.CurrentSpeed * 200 * dt;
      _angle += _angleInertia.CurrentSpeed * 360 * dt;
    }

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawImage(_image, _position, _angle);
    }

  }
}
