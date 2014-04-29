using System;
using System.Collections.Generic;
using RougeLike.States;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public class EntityObject : GameObjectBase
  {
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
      _stateMachine.States[_stateMachine.CurrentState].Update(dt);
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
