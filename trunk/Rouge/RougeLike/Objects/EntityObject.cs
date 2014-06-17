using System;
using System.Collections.Generic;
using RougeLike.States;
using RougeLike.Attributes;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Controller;
using RougeLike.Behavior;

namespace RougeLike.Objects
{
  public class EntityObject : GameObjectBase
  {
    private const string CurrentStateAttributeName = "currentstate";

    private Rectangle2f _hitBox = new Rectangle2f(-4, -9, 8, 16);
    private StateMachine _stateMachine = new StateMachine();
    private IEntityController _controller = null;

    private const Color HitBoxColor = new Color(0, 0, 255, 128);

    public StateMachine StateMachine
    {
      get { return _stateMachine; }
    }

    public Rectangle2f HitBox
    {
      get { return _hitBox; }
      set { _hitBox = value; }
    }

    public IEntityController Controller
    {
      get { return _controller; }
      set { _controller = value; }
    }

    public Rectangle2f GetTransformedHitBox()
    {
      return new Rectangle2f(_hitBox.Min.X + Position.X, _hitBox.Min.Y + Position.Y, _hitBox.Width, _hitBox.Height);
    }

    public override void Init()
    {
      _stateMachine.GameObject = this;
      _stateMachine.Init();
    }

    public override void Update(float dt)
    {
      _stateMachine.Update(dt);
    }

    public override void Render()
    {
      _stateMachine.Render();

      if (GameData.Instance.DebugDraw)
      {
        Oku.Graphics.DrawRectangle(_hitBox.Min.X, _hitBox.Max.X, _hitBox.Min.Y, _hitBox.Max.Y, HitBoxColor);
        Oku.Graphics.DrawPoint(0, 0, 2.0f, Color.Green);
      }
    }

    public override void Finish()
    {
      _stateMachine.Finish();
    }

    public override string ObjectType
    {
      get { return "entitiy"; }
    }

    protected override List<string> DoGetAllAttributes()
    {
      return new List<string>() { CurrentStateAttributeName };
    }

    protected override IAttributeValue DoGetAttributeValue(string attribute)
    {
      if (attribute == CurrentStateAttributeName)
        return new TextValue(_stateMachine.CurrentState);

      return null;
    }

    protected override bool DoSetAttributeValue(string attribute, IAttributeValue value)
    {
      if (attribute == CurrentStateAttributeName)
      {
        _stateMachine.CurrentState = value.GetValueAsString();
        return true;
      }

      return false;
    }

    protected override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    protected override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }

  }
}
