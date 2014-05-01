using System;
using System.Collections.Generic;
using RougeLike.States;
using RougeLike.Attributes;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public class EntityObject : GameObjectBase
  {
    private const string CurrentStateAttributeName = "currentstate";

    private Rectangle2f _hitBox = new Rectangle2f(-4, -8, 8, 10);
    private StateMachine _stateMachine = new StateMachine();

    public StateMachine StateMachine
    {
      get { return _stateMachine; }
    }

    public override void Init()
    {
      _stateMachine.Init();
    }

    public override void Update(float dt)
    {
      _stateMachine.States[_stateMachine.CurrentState].Update(dt, this);
    }

    public override void Render()
    {
      _stateMachine.States[_stateMachine.CurrentState].Render();
      if (GameData.Instance.DebugDraw)
        Oku.Graphics.DrawRectangle(_hitBox.Min.X, _hitBox.Max.X, _hitBox.Min.Y, _hitBox.Max.Y, new Color(255, 0, 0, 128));
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
