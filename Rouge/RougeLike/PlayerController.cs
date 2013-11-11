using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using System.Windows.Forms;

namespace RougeLike
{
  public class PlayerController : ControllerProcess
  {
    private const float _speed = 100.0f;
    private bool _left, _right, _up, _down;
    private Orientation _orientation = Orientation.Down;

    private float _attackTime = 0.0f;

    public override void Initialize()
    {
      OkuManager.Instance.Input.OnKeyPressed += Input_OnKeyPressed;
      OkuManager.Instance.Input.OnKeyReleased += Input_OnKeyReleased;
    }

    void Input_OnKeyReleased(Keys key)
    {
      switch (key)
      {
        case Keys.W:
          _up = false;
          break;

        case Keys.A:
          _left = false;
          break;

        case Keys.S:
          _down = false;
          break;

        case Keys.D:
          _right = false;
          break;

        default:
          break;
      }
    }

    private void Input_OnKeyPressed(Keys key)
    {
      switch (key)
      {
        case Keys.W:
          _up = true;
          _orientation = Orientation.Up;
          break;

        case Keys.A:
          _left = true;
          _orientation = Orientation.Left;
          break;

        case Keys.S:
          _down = true;
          _orientation = Orientation.Down;
          break;

        case Keys.D:
          _right = true;
          _orientation = Orientation.Right;
          break;

        case Keys.Space:
          _attackTime = 0.1f;
          break;

        default:
          break;
      }
    }

    public override bool Update(float dt)
    {
      Vector2f velocity = Vector2f.Zero;
      float step = _speed * dt;

      if (_left)
        velocity.X -= step;

      if (_right)
        velocity.X += step;

      if (_up)
        velocity.Y += step;

      if (_down)
        velocity.Y -= step;

      foreach (Entity entity in Entities)
      {
        if (_attackTime >= 0.0f)
        {
          entity.StateMachine.CurrentStateId = _orientation.ToString().ToLower() + "_attack";
          _attackTime -= dt;
        }

        if (_attackTime <= 0.0f)
        {
          entity.StateMachine.CurrentStateId = "idle";
        }

        TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
        if (trans == null)
          continue;

        trans.Translation += velocity;
      }

      return false; //Process never ends by himself
    }

    public override void Destroy()
    {
      OkuManager.Instance.Input.OnKeyPressed -= Input_OnKeyPressed;
    }
  }
}
